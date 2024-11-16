using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXPERIENCIA_UX_CREDITO_DEPARTAMENTAL
{
    public partial class INFORMACION : Form
    {
        public INFORMACION()
        {
            InitializeComponent();
            this.Size = new Size(400, 600); // Aumentamos la altura del formulario
            this.Text = "Consulta de Crédito";
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;


            // Panel para la cabecera
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(this.Width, 60);
            headerPanel.Location = new Point(0, 0);
            headerPanel.BackColor = ColorTranslator.FromHtml("#B22222"); // Color rojo estilo Liverpool
            this.Controls.Add(headerPanel);

            Label titleLabel = new Label();
            titleLabel.Text = "Consulta de Crédito";
            titleLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(20, 15);
            titleLabel.AutoSize = true;  // Permite que el label ajuste su tamaño según el texto


            // Agregar el ícono
            PictureBox iconPictureBox = new PictureBox();
            iconPictureBox.Image = Image.FromFile(@"C:\Users\pepec\Downloads\productos.jpeg");  // Asegúrate de poner la ruta correcta de la imagen
            iconPictureBox.Size = new Size(70, 30);  // Tamaño del icono
            iconPictureBox.Location = new Point(this.Width - iconPictureBox.Width - 20, 15);  // Ubicar el ícono a la derecha del panel
            iconPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;  // Ajustar imagen sin distorsionarla
            headerPanel.Controls.Add(iconPictureBox);

            // Evento clic del icono para abrir el formulario de productos disponibles
            iconPictureBox.Click += (sender, e) =>
            {
                this.Hide();
                // Aquí abres el formulario de productos disponibles
                ProductosDisponibles productosForm = new ProductosDisponibles();  // Suponiendo que tienes un formulario llamado ProductosDisponiblesForm
                productosForm.Show();
            };

            headerPanel.Controls.Add(titleLabel);

            int topOffset = 70; // Espacio debajo del panel

            // Sección de Crédito Disponible
            Label lblCreditoDisponible = new Label();
            lblCreditoDisponible.Text = "Limite de Credito: $3000";
            lblCreditoDisponible.Font = new Font("Arial", 12, FontStyle.Bold);
            lblCreditoDisponible.ForeColor = ColorTranslator.FromHtml("#333333");
            lblCreditoDisponible.Location = new Point(20, topOffset);
            lblCreditoDisponible.Size = new Size(350, 25);
            this.Controls.Add(lblCreditoDisponible);

            // Sección de Saldo Restante
            Label lblSaldoRestante = new Label();
            lblSaldoRestante.Text = "Saldo Disponible: $2500"; // Actualizar dinámicamente
            lblSaldoRestante.Font = new Font("Arial", 10, FontStyle.Regular);
            lblSaldoRestante.ForeColor = ColorTranslator.FromHtml("#333333");
            lblSaldoRestante.Location = new Point(20, topOffset + 30);
            lblSaldoRestante.Size = new Size(350, 25);
            this.Controls.Add(lblSaldoRestante);

            // Historial de Compras
            Label lblCompras = new Label();
            lblCompras.Text = "Historial de Compras:";
            lblCompras.Font = new Font("Arial", 10, FontStyle.Bold);
            lblCompras.ForeColor = ColorTranslator.FromHtml("#333333");
            lblCompras.Location = new Point(20, topOffset + 70);
            lblCompras.AutoSize = true;  // Permite que el label ajuste su tamaño según el texto
            this.Controls.Add(lblCompras);

            ListView listaCompras = new ListView();
            listaCompras.Location = new Point(20, topOffset + 100);
            listaCompras.Size = new Size(350, 100);
            listaCompras.View = View.Details;
            listaCompras.BackColor = Color.WhiteSmoke;
            listaCompras.Columns.Add("Fecha", 100);
            listaCompras.Columns.Add("Descripción", 150);
            listaCompras.Columns.Add("Monto", 100);
            listaCompras.Items.Add(new ListViewItem(new[] { "01/11/2024", "Compra en tienda", "$500" }));
            this.Controls.Add(listaCompras);

            // Sección de Pagos
            Label lblPagos = new Label();
            lblPagos.Text = "Pagos:";
            lblPagos.Font = new Font("Arial", 10, FontStyle.Underline);
            lblPagos.ForeColor = ColorTranslator.FromHtml("#333333");
            lblPagos.Location = new Point(20, topOffset + 220);
            lblPagos.Cursor = Cursors.Hand;  // Cambia el cursor para indicar que es clickeable
            lblPagos.Click += (s, e) => {
                PagosForm pagosForm = new PagosForm();
                pagosForm.ShowDialog();  // Muestra el formulario de Pagos
            };
            this.Controls.Add(lblPagos);

            Label lblPagosVencidos = new Label();
            lblPagosVencidos.Text = "Pagos Vencidos: Ninguno"; // Actualizar según sea necesario
            lblPagosVencidos.Location = new Point(20, topOffset + 250);
            lblPagosVencidos.ForeColor = Color.DarkRed;
            lblPagosVencidos.Size = new Size(350, 25);
            this.Controls.Add(lblPagosVencidos);

            Label lblProximoPago = new Label();
            lblProximoPago.Text = "Próximo Pago: 15/11/2024"; // Actualizar según sea necesario
            lblProximoPago.Location = new Point(20, topOffset + 280);
            lblProximoPago.ForeColor = ColorTranslator.FromHtml("#333333");
            lblProximoPago.Size = new Size(350, 25);
            this.Controls.Add(lblProximoPago);

            // Fecha de Corte
            Label lblFechaCorte = new Label();
            lblFechaCorte.Text = "Fecha de Corte: 30/11/2024"; // Actualizar según sea necesario
            lblFechaCorte.Font = new Font("Arial", 10, FontStyle.Italic);
            lblFechaCorte.ForeColor = ColorTranslator.FromHtml("#333333");
            lblFechaCorte.Location = new Point(20, topOffset + 310);
            lblFechaCorte.Size = new Size(350, 25);
            this.Controls.Add(lblFechaCorte);

            // Botón para volver
            Button btnVolver = new Button();
            btnVolver.Text = "Volver";
            btnVolver.Font = new Font("Arial", 10, FontStyle.Regular);
            btnVolver.Size = new Size(100, 30);
            btnVolver.Location = new Point(20, 430);
            btnVolver.BackColor = ColorTranslator.FromHtml("#B22222");
            btnVolver.ForeColor = Color.White;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnVolver);
            btnVolver.Click += (s, e) =>
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            };
            this.Controls.Add(btnVolver);


            // Botón para Solicitar Credito
            Button btnPagar = new Button();
            btnPagar.Text = "Aumento de Credito";
            btnPagar.Font = new Font("Arial", 10, FontStyle.Regular);
            btnPagar.Size = new Size(150, 30);
            btnPagar.Location = new Point(140, 430);
            btnPagar.BackColor = ColorTranslator.FromHtml("#B22222");
            btnPagar.ForeColor = Color.White;
            btnPagar.FlatStyle = FlatStyle.Flat;
            btnPagar.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnPagar);
            btnPagar.Click += (s, e) =>
            {
                this.Hide();
                SolicitudCreditoForm form = new SolicitudCreditoForm();
                form.ShowDialog();
            };
            this.Controls.Add(btnVolver);
        }
    }
}
