using System;
using System.Drawing;
using System.Windows.Forms;
using ChecadorApp_AGRDM.Negocio;
using ChecadorApp_AGRDM.Entidades;

namespace ChecadorApp_AGRDM
{
    public partial class Form1 : Form
    {
        private AsistenciaService _service;
        public Form1()
        {
            InitializeComponent();
            _service = new AsistenciaService();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                btnBuscar.Enabled = false;
                btnBuscar.Text = "Cargando...";

                var listaResultados = _service.ConsultarReporte(dtpInicio.Value, dtpFin.Value);

                dgvAsistencia.DataSource = null;
                dgvAsistencia.DataSource = listaResultados;

                ColorearGrid();

                if (listaResultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros en ese rango de fechas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBuscar.Enabled=true;
                btnBuscar.Text = "Generar reporte de asistencia";
            }
        }

        private void ColorearGrid()
        {
            foreach (DataGridViewRow row in dgvAsistencia.Rows)
            {
                var item = row.DataBoundItem as AsistenciaDiaria;

                if (item != null) continue;

                if (item.Estatus == "COMPLETO")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (item.Estatus == "FALTA")
                {
                    row.DefaultCellStyle.BackColor = Color.Salmon;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                else if (item.Estatus.Contains("FALTA_") || item.Estatus == "INCOMPLETO")
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                else if(item.Estatus == "FIN DE SEMANA")
                {
                    row.DefaultCellStyle.BackColor= Color.LightGray;
                    row.DefaultCellStyle.BackColor = Color.Gray;
                }

                if(item.RetardoMinutos > 10 && item.Estatus != "FALTA")
                {
                    row.Cells["RetardoMinutos"].Style.ForeColor = Color.Red;
                    row.Cells["RetardosMinutos"].Style.Font= new Font(dgvAsistencia.Font, FontStyle.Bold);
                }
            }
        }
    }
}
