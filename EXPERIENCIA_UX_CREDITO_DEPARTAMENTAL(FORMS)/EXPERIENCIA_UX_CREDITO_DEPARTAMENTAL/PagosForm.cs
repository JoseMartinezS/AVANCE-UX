using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXPERIENCIA_UX_CREDITO_DEPARTAMENTAL
{
    public partial class PagosForm : Form
    {
        public PagosForm()
        {
            InitializeComponent();
            this.Size = new Size(450, 600);  // Ajustamos la altura del formulario
            this.Text = "Historial de Compras";
            this.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel para la cabecera
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(this.Width, 60);
            headerPanel.Location = new Point(0, 0);
            headerPanel.BackColor = ColorTranslator.FromHtml("#B22222"); // Color rojo estilo Liverpool
            this.Controls.Add(headerPanel);

            Label titleLabel = new Label();
            titleLabel.Text = "Pagos";
            titleLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(20, 15);
            headerPanel.Controls.Add(titleLabel);

            // Espacio debajo del panel
            int topOffset = 80;  // Aumentar este valor para mover los productos más abajo

            // Contenedor para los productos (esto ayudará a que el diseño sea más limpio)
            FlowLayoutPanel productosPanel = new FlowLayoutPanel();
            productosPanel.Size = new Size(this.Width - 20, this.Height - topOffset - 100);  // Ajustar el tamaño para que ocupe el espacio restante
            productosPanel.Location = new Point(10, topOffset);  // Agregar el desplazamiento de los productos
            productosPanel.AutoScroll = true;  // Permite desplazarse por los productos
            productosPanel.Padding = new Padding(10);
            productosPanel.FlowDirection = FlowDirection.TopDown;
            this.Controls.Add(productosPanel);

            // Agregar productos
            CrearProducto("Electrodoméstico", "Un excelente microondas", @"C:\Users\pepec\Downloads\microondas.jpeg", 150.00m, productosPanel);
            CrearProducto("Ropa", "Camiseta de algodón", @"C:\Users\pepec\Downloads\ropa.jpeg", 25.50m, productosPanel);

            // Botón para volver
            Button btnVolver = new Button();
            btnVolver.Text = "Volver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.Location = new Point((this.Width - btnVolver.Width) / 2, this.ClientSize.Height - 60);  // Centrado
            btnVolver.BackColor = ColorTranslator.FromHtml("#4CAF50");
            btnVolver.ForeColor = Color.White;
            btnVolver.Click += (s, e) => this.Close();

            btnVolver.BringToFront();

            this.Controls.Add(btnVolver);
        }

        private void CrearProducto(string nombre, string descripcion, string rutaImagen, decimal precio, FlowLayoutPanel productosPanel)
        {
            // Panel para el producto
            Panel panelProducto = new Panel();
            panelProducto.Size = new Size(this.Width - 40, 150);  // Ajusta el tamaño del panel para dejar un margen en los bordes
            panelProducto.BackColor = Color.White;
            panelProducto.Margin = new Padding(0, 10, 0, 10);  // Espaciado entre productos
            panelProducto.BorderStyle = BorderStyle.FixedSingle;  // Asegúrate de que cada producto tenga su propio borde
            productosPanel.Controls.Add(panelProducto);

            // Imagen del producto
            PictureBox pictureBox = new PictureBox();
            if (File.Exists(rutaImagen))  // Verifica si el archivo existe
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(rutaImagen);
                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        pictureBox.Image = Image.FromStream(memoryStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error de imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBox.Image = null;  // Imagen por defecto
                }
            }
            else
            {
                MessageBox.Show($"La imagen no se encuentra en la ruta: {rutaImagen}", "Error de imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox.Image = null;  // Imagen por defecto
            }

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(10, 10);  // Alineado a la izquierda
            pictureBox.Size = new Size(60, 60);
            panelProducto.Controls.Add(pictureBox);

            // Nombre del producto
            Label lblNombre = new Label();
            lblNombre.Text = nombre;
            lblNombre.Font = new Font("Arial", 10, FontStyle.Bold);
            lblNombre.ForeColor = ColorTranslator.FromHtml("#333333");
            lblNombre.Location = new Point(100, 10);  // A la derecha de la imagen
            lblNombre.AutoSize = true;
            panelProducto.Controls.Add(lblNombre);

            // Descripción del producto
            Label lblDescripcion = new Label();
            lblDescripcion.Text = descripcion;
            lblDescripcion.Font = new Font("Arial", 9, FontStyle.Regular);
            lblDescripcion.ForeColor = ColorTranslator.FromHtml("#666666");
            lblDescripcion.Location = new Point(100, 40);  // A la derecha de la imagen
            lblDescripcion.AutoSize = true;
            panelProducto.Controls.Add(lblDescripcion);

            // Precio del producto
            Label lblPrecio = new Label();
            lblPrecio.Text = $"Precio: ${precio:F2}";
            lblPrecio.Font = new Font("Arial", 9, FontStyle.Bold);
            lblPrecio.ForeColor = ColorTranslator.FromHtml("#4CAF50");
            lblPrecio.Location = new Point(100, 70);  // A la derecha de la imagen
            lblPrecio.AutoSize = true;
            panelProducto.Controls.Add(lblPrecio);

            // Botón "Volver a Comprar"
            Button btnComprar = new Button();
            btnComprar.Text = "Volver a Comprar";
            btnComprar.Font = new Font("Arial", 8, FontStyle.Regular);
            btnComprar.BackColor = ColorTranslator.FromHtml("#FF5733");
            btnComprar.ForeColor = Color.White;
            btnComprar.Location = new Point(100, 90);  // A la derecha de la imagen
            btnComprar.Size = new Size(120, 25);
            btnComprar.Click += (s, e) => MessageBox.Show($"Has seleccionado {nombre} para comprar nuevamente.");
            panelProducto.Controls.Add(btnComprar);
        }
    }
}
