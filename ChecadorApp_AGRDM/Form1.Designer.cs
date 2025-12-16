namespace ChecadorApp_AGRDM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            btnBuscar = new Button();
            dgvAsistencia = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencia).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(385, 62);
            label1.Name = "label1";
            label1.Size = new Size(491, 54);
            label1.TabIndex = 0;
            label1.Text = "Generar Reporte General";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // dtpInicio
            // 
            dtpInicio.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpInicio.Location = new Point(139, 153);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(290, 27);
            dtpInicio.TabIndex = 1;
            // 
            // dtpFin
            // 
            dtpFin.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFin.Location = new Point(513, 153);
            dtpFin.MaxDate = new DateTime(2025, 12, 16, 11, 49, 5, 0);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(269, 27);
            dtpFin.TabIndex = 2;
            dtpFin.Value = new DateTime(2025, 12, 16, 0, 0, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(69, 151);
            label2.Name = "label2";
            label2.Size = new Size(69, 28);
            label2.TabIndex = 3;
            label2.Text = "Inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(462, 153);
            label3.Name = "label3";
            label3.Size = new Size(45, 28);
            label3.TabIndex = 4;
            label3.Text = "Fin:";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.Lime;
            btnBuscar.BackgroundImageLayout = ImageLayout.None;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = SystemColors.ActiveCaptionText;
            btnBuscar.Location = new Point(900, 151);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(203, 29);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar por rango de Fechas";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += Buscar_Click;
            // 
            // dgvAsistencia
            // 
            dgvAsistencia.BackgroundColor = Color.FromArgb(25, 25, 32);
            dgvAsistencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsistencia.Dock = DockStyle.Bottom;
            dgvAsistencia.Location = new Point(0, 239);
            dgvAsistencia.Name = "dgvAsistencia";
            dgvAsistencia.RowHeadersWidth = 51;
            dgvAsistencia.Size = new Size(1225, 534);
            dgvAsistencia.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 32);
            ClientSize = new Size(1225, 773);
            Controls.Add(dgvAsistencia);
            Controls.Add(btnBuscar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Reportes";
            ((System.ComponentModel.ISupportInitialize)dgvAsistencia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private Label label2;
        private Label label3;
        private Button btnBuscar;
        private DataGridView dgvAsistencia;
    }
}
