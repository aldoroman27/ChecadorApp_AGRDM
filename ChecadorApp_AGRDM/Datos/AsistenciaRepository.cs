using System;
using System.Collections.Generic;
using System.Configuration; // Para leer el App.config
using Npgsql;               // El conector de Postgres
using ChecadorApp_AGRDM.Entidades; // Para entender qué es una 'AsistenciaDiaria'

namespace ChecadorApp_AGRDM.Datos
{
    public class AsistenciaRepository
    {
        // Aquí guardaremos la cadena de conexión que pusimos en el paso 5
        private readonly string _connectionString;

        public AsistenciaRepository()
        {
            // Leemos la configuración
            _connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;
        }

        public List<AsistenciaDiaria> ObtenerPorRango(DateTime inicio, DateTime fin)
        {
            var lista = new List<AsistenciaDiaria>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                // PASO A: Ejecutar el Store Procedure (La Lógica SQL)
                // Esto recalcula los datos al momento para asegurar que estén frescos
                using (var cmdProc = new NpgsqlCommand("CALL public.sp_procesar_asistencia_rango(@f1::date, @f2::date)", conn))
                {
                    cmdProc.Parameters.AddWithValue("f1", inicio);
                    cmdProc.Parameters.AddWithValue("f2", fin);
                    cmdProc.ExecuteNonQuery();
                }

                // PASO B: Traer los datos ya procesados y limpios
                string sql = @"
                    SELECT 
                        e.zk_user_id, e.no_empleado, e.nombre, t.nombre_mostrar as turno,
                        d.work_date, d.p1_entrada, d.p2_break_out, d.p3_break_in, d.p4_salida,
                        d.horas_trabajadas, d.retardo_minutos, d.status
                    FROM daily_attendance d
                    JOIN empleados e ON d.zk_user_id = e.zk_user_id
                    LEFT JOIN cat_turnos t ON e.turno_id = t.id
                    WHERE d.work_date BETWEEN @f1 AND @f2
                    AND e.activo = TRUE
                    ORDER BY e.nombre DESC, d.work_date ASC";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("f1", inicio);
                    cmd.Parameters.AddWithValue("f2", fin);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new AsistenciaDiaria();

                            // 1. Datos básicos
                            item.ZkUserId = Convert.ToInt32(reader["zk_user_id"]);
                            item.NoEmpleado = reader["no_empleado"] as string ?? "S/N";
                            item.Nombre = reader["nombre"] as string;
                            item.Turno = reader["turno"] as string;

                            // 2. CORRECCIÓN DE FECHA (DateOnly -> DateTime)
                            var fechaSolo = (DateOnly)reader["work_date"];
                            item.Fecha = fechaSolo.ToDateTime(TimeOnly.MinValue);

                            // Verificamos si no es nulo, lo convertimos a TimeOnly y luego a TimeSpan
                            if (reader["p1_entrada"] != DBNull.Value)
                                item.Entrada = ((TimeOnly)reader["p1_entrada"]).ToTimeSpan();

                            if (reader["p2_break_out"] != DBNull.Value)
                                item.SalidaComida = ((TimeOnly)reader["p2_break_out"]).ToTimeSpan();

                            if (reader["p3_break_in"] != DBNull.Value)
                                item.RegresoComida = ((TimeOnly)reader["p3_break_in"]).ToTimeSpan();

                            if (reader["p4_salida"] != DBNull.Value)
                                item.Salida = ((TimeOnly)reader["p4_salida"]).ToTimeSpan();

                            // 4. Estatus
                            item.Estatus = reader["status"].ToString();

                            // 5. Horas trabajadas
                            if (reader["horas_trabajadas"] != DBNull.Value)
                            {
                                TimeSpan ts = (TimeSpan)reader["horas_trabajadas"];
                                item.HorasTrabajadas = string.Format("{0:00}:{1:00}", (int)ts.TotalHours, ts.Minutes);
                            }
                            else
                            {
                                item.HorasTrabajadas = "-";
                            }

                            // 6. Retardo
                            item.RetardoMinutos = reader["retardo_minutos"] != DBNull.Value ? Convert.ToDouble(reader["retardo_minutos"]) : 0;

                            lista.Add(item);
                        }
                    }
                }
            }
            return lista;
        }
    }
}