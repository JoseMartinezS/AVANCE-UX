using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXPERIENCIA_UX_CREDITO_DEPARTAMENTAL
{
    public partial class ProductosDisponibles : Form
    {
        private int currentY = 10; // Variable para llevar el control de la posición Y de los productos

        public ProductosDisponibles()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Crear panel para la cabecera
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(this.Width, 60);
            headerPanel.Location = new Point(0, 0);
            headerPanel.BackColor = ColorTranslator.FromHtml("#B22222"); // Color rojo estilo Liverpool
            this.Controls.Add(headerPanel);

            // Crear título para el panel
            Label titleLabel = new Label();
            titleLabel.Text = "Productos Disponibles";
            titleLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(20, 15);
            titleLabel.AutoSize = true;
            headerPanel.Controls.Add(titleLabel);

            // Crear panel para los productos
            Panel productPanel = new Panel();
            productPanel.Size = new Size(this.Width - 40, 400); // Deja espacio para márgenes
            productPanel.Location = new Point(20, headerPanel.Bottom + 10); // Coloca el panel de productos debajo de la cabecera
            productPanel.AutoScroll = true;  // Permite desplazamiento si los productos son muchos
            this.Controls.Add(productPanel);

            // Agregar productos al panel
            AddProduct(productPanel, "Desodorante", "Descripción del producto 1", GenerateRandomPrice(), @"C:\Users\pepec\Downloads\producto1.jpeg");
            AddProduct(productPanel, "Perfume", "Descripción del producto 2", GenerateRandomPrice(), @"C:\Users\pepec\Downloads\producto2.jpeg");
            AddProduct(productPanel, "Gel", "Descripción del producto 3", GenerateRandomPrice(), @"C:\Users\pepec\Downloads\producto3.jpeg");

            // Botón Volver
            Button btnVolver = new Button();
            btnVolver.Text = "Volver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.Location = new Point((this.Width - btnVolver.Width) / 2, this.ClientSize.Height - 80);
            btnVolver.BackColor = ColorTranslator.FromHtml("#4CAF50");
            btnVolver.ForeColor = Color.White;
            btnVolver.Click += (s, e) =>
            {
                this.Hide();
                INFORMACION iNFORMACION = new INFORMACION();
                iNFORMACION.ShowDialog();
            };
            btnVolver.BringToFront();
            this.Controls.Add(btnVolver);
        }

        // Método para agregar productos al panel
        private void AddProduct(Panel parentPanel, string productName, string description, decimal price, string imagePath)
        {
            // Panel para cada producto
            Panel productPanel = new Panel();
            productPanel.Size = new Size(parentPanel.Width - 20, 150);
            productPanel.Margin = new Padding(5);
            productPanel.Location = new Point(10, currentY);  // Establecer la posición del producto
            parentPanel.Controls.Add(productPanel);

            // Imagen del producto
            PictureBox productImage = new PictureBox();
            productImage.Image = Image.FromFile(imagePath);  // Ruta de la imagen
            productImage.Size = new Size(100, 100);
            productImage.Location = new Point(10, 10);
            productImage.SizeMode = PictureBoxSizeMode.StretchImage;
            productPanel.Controls.Add(productImage);

            // Nombre del producto
            Label productNameLabel = new Label();
            productNameLabel.Text = productName;
            productNameLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            productNameLabel.Location = new Point(120, 10);
            productNameLabel.AutoSize = true;
            productPanel.Controls.Add(productNameLabel);

            // Descripción del producto
            Label productDescriptionLabel = new Label();
            productDescriptionLabel.Text = description;
            productDescriptionLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            productDescriptionLabel.Location = new Point(120, 40);
            productDescriptionLabel.Size = new Size(productPanel.Width - 140, 40);
            productDescriptionLabel.AutoSize = false;
            productPanel.Controls.Add(productDescriptionLabel);

            // Precio del producto
            Label productPriceLabel = new Label();
            productPriceLabel.Text = $"Precio: ${price}";
            productPriceLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            productPriceLabel.ForeColor = Color.Green;
            productPriceLabel.Location = new Point(120, 80);
            productPriceLabel.AutoSize = true;
            productPanel.Controls.Add(productPriceLabel);

            // Actualiza la posición para el siguiente producto
            currentY += productPanel.Height + 10;  // Ajusta la posición Y para el siguiente panel
        }

        // Método para generar un precio aleatorio dentro de los 2500 pesos
        private decimal GenerateRandomPrice()
        {
            Random rand = new Random();
            decimal price = (decimal)(rand.Next(100, 2501) / 1.0);
            return price;
        }
    }
}
