using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXPERIENCIA_UX_CREDITO_DEPARTAMENTAL
{
    public partial class SolicitudCreditoForm : Form
    {
        private bool comprobanteCargado = false;
        private bool ineCargado = false;

        public SolicitudCreditoForm()
        {
            InitializeComponent();
            this.Size = new Size(400, 500);
            this.Text = "Solicitud de Crédito";
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Etiqueta para el título
            Label titleLabel = new Label();
            titleLabel.Text = "Solicitud de Crédito";
            titleLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            titleLabel.ForeColor = ColorTranslator.FromHtml("#B22222");
            titleLabel.Location = new Point(20, 20);
            this.Controls.Add(titleLabel);

            // Campo de entrada para el Nombre del Cliente
            Label lblNombre = new Label();
            lblNombre.Text = "Nombre del Cliente:";
            lblNombre.Location = new Point(20, 70);
            this.Controls.Add(lblNombre);

            TextBox txtNombre = new TextBox();
            txtNombre.Location = new Point(20, 100);
            txtNombre.Width = 350;
            this.Controls.Add(txtNombre);

            // Campo de entrada para el Ingreso Mensual
            Label lblIngreso = new Label();
            lblIngreso.Text = "Ingreso Mensual:";
            lblIngreso.Location = new Point(20, 140);
            this.Controls.Add(lblIngreso);

            TextBox txtIngreso = new TextBox();
            txtIngreso.Location = new Point(20, 170);
            txtIngreso.Width = 350;
            this.Controls.Add(txtIngreso);

            // Botón para cargar Comprobante de Domicilio
            Button btnComprobante = new Button();
            btnComprobante.Text = "Cargar Comprobante de Domicilio (PDF)";
            btnComprobante.Location = new Point(20, 210);
            btnComprobante.Width = 350;
            btnComprobante.Click += (s, e) => { comprobanteCargado = CargarArchivo("PDF (*.pdf)|*.pdf"); };
            this.Controls.Add(btnComprobante);

            // Botón para cargar INE
            Button btnINE = new Button();
            btnINE.Text = "Cargar INE (Imagen)";
            btnINE.Location = new Point(20, 260);
            btnINE.Width = 350;
            btnINE.Click += (s, e) => { ineCargado = CargarArchivo("Imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"); };
            this.Controls.Add(btnINE);

            // Botón para enviar solicitud
            Button btnEnviarSolicitud = new Button();
            btnEnviarSolicitud.Text = "Enviar Solicitud";
            btnEnviarSolicitud.BackColor = ColorTranslator.FromHtml("#B22222");
            btnEnviarSolicitud.ForeColor = Color.White;
            btnEnviarSolicitud.FlatStyle = FlatStyle.Flat;
            btnEnviarSolicitud.Location = new Point(20, 320);
            btnEnviarSolicitud.Width = 350;
            btnEnviarSolicitud.Click += (s, e) =>
            {
                // Validación de campos y archivos
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El campo 'Nombre del Cliente' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtIngreso.Text))
                {
                    MessageBox.Show("El campo 'Ingreso Mensual' es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!comprobanteCargado)
                {
                    MessageBox.Show("Debes cargar el comprobante de domicilio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ineCargado)
                {
                    MessageBox.Show("Debes cargar la imagen de tu INE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mostrar mensaje de éxito si todas las validaciones son correctas
                MessageBox.Show("Solicitud enviada para análisis.");
            };
            this.Controls.Add(btnEnviarSolicitud);

            // Botón para volver
            Button btnVolver = new Button();
            btnVolver.Text = "Volver";
            btnVolver.Font = new Font("Arial", 10, FontStyle.Regular);
            btnVolver.Size = new Size(100, 30);
            btnVolver.Location = new Point(20, 400);
            btnVolver.BackColor = ColorTranslator.FromHtml("#B22222");
            btnVolver.ForeColor = Color.White;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Click += (s, e) =>
            {
                this.Hide();
                INFORMACION form = new INFORMACION();
                form.ShowDialog();
            };
            this.Controls.Add(btnVolver);
        }

        private bool CargarArchivo(string filtro)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filtro;
            openFileDialog.Title = "Seleccionar archivo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Archivo cargado: " + openFileDialog.FileName);
                return true; // Se ha cargado el archivo exitosamente
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún archivo.");
                return false; // No se ha cargado el archivo
            }
        }
    }
}
