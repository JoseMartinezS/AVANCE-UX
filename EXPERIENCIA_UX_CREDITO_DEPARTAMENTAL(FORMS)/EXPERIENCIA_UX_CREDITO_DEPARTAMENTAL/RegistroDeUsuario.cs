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
    public partial class RegistroDeUsuario : Form
    {
        public RegistroDeUsuario()
        {
            InitializeComponent();
            this.Text = "Registro de Usuario - Liverpool";
            this.BackColor = Color.White;
            this.Size = new Size(450, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Etiqueta de Bienvenida
            Label lblTitulo = new Label();
            lblTitulo.Text = "Crear una Nueva Cuenta";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#ED1C24");
            lblTitulo.Location = new Point(80, 30);
            lblTitulo.AutoSize = true;
            this.Controls.Add(lblTitulo);

            // Etiqueta y campo de Nombre
            Label lblNombre = new Label();
            lblNombre.Text = "Nombre";
            lblNombre.Location = new Point(50, 80);
            this.Controls.Add(lblNombre);

            TextBox txtNombre = new TextBox();
            txtNombre.Size = new Size(300, 30);
            txtNombre.Location = new Point(50, 100);
            txtNombre.PlaceholderText = "Ingresa tu nombre";
            this.Controls.Add(txtNombre);

            // Etiqueta y campo de Apellido
            Label lblApellido = new Label();
            lblApellido.Text = "Apellido";
            lblApellido.Location = new Point(50, 140);
            this.Controls.Add(lblApellido);

            TextBox txtApellido = new TextBox();
            txtApellido.Size = new Size(300, 30);
            txtApellido.Location = new Point(50, 160);
            txtApellido.PlaceholderText = "Ingresa tu apellido";
            this.Controls.Add(txtApellido);

            // Etiqueta y campo de Correo Electrónico
            Label lblCorreo = new Label();
            lblCorreo.Text = "Correo Electrónico";
            lblCorreo.Location = new Point(50, 200);
            this.Controls.Add(lblCorreo);

            TextBox txtCorreo = new TextBox();
            txtCorreo.Size = new Size(300, 30);
            txtCorreo.Location = new Point(50, 220);
            txtCorreo.PlaceholderText = "ejemplo@correo.com";
            this.Controls.Add(txtCorreo);

            // Etiqueta y campo de Teléfono
            Label lblTelefono = new Label();
            lblTelefono.Text = "Teléfono";
            lblTelefono.Location = new Point(50, 260);
            this.Controls.Add(lblTelefono);

            TextBox txtTelefono = new TextBox();
            txtTelefono.Size = new Size(300, 30);
            txtTelefono.Location = new Point(50, 280);
            txtTelefono.PlaceholderText = "10 dígitos";
            this.Controls.Add(txtTelefono);

            // Etiqueta y campo de Contraseña
            Label lblContraseña = new Label();
            lblContraseña.Text = "Contraseña";
            lblContraseña.Location = new Point(50, 320);
            this.Controls.Add(lblContraseña);

            TextBox txtContraseña = new TextBox();
            txtContraseña.Size = new Size(300, 30);
            txtContraseña.Location = new Point(50, 340);
            txtContraseña.PasswordChar = '●';
            txtContraseña.PlaceholderText = "Ingresa tu contraseña";
            this.Controls.Add(txtContraseña);

            // Etiqueta y campo de Confirmar Contraseña
            Label lblConfirmarContraseña = new Label();
            lblConfirmarContraseña.Text = "Confirmar Contraseña";
            lblConfirmarContraseña.Location = new Point(50, 380);
            this.Controls.Add(lblConfirmarContraseña);

            TextBox txtConfirmarContraseña = new TextBox();
            txtConfirmarContraseña.Size = new Size(300, 30);
            txtConfirmarContraseña.Location = new Point(50, 400);
            txtConfirmarContraseña.PasswordChar = '●';
            txtConfirmarContraseña.PlaceholderText = "Repite tu contraseña";
            this.Controls.Add(txtConfirmarContraseña);

            // Botón para volver
            Button btnVolver = new Button();
            btnVolver.Text = "Volver";
            btnVolver.Font = new Font("Arial", 10, FontStyle.Regular);
            btnVolver.Size = new Size(100, 30);
            btnVolver.Location = new Point(20, 520);
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

            // Botón de Registro
            Button btnRegistro = new Button();
            btnRegistro.Text = "Registrarse";
            btnRegistro.Size = new Size(300, 40);
            btnRegistro.Location = new Point(50, 460);
            btnRegistro.BackColor = ColorTranslator.FromHtml("#ED1C24");
            btnRegistro.ForeColor = Color.White;
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.Click += (s, e) =>
            {
                // Validación de los campos de entrada
                if (txtNombre.Text == "" || txtApellido.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == "" || txtContraseña.Text == "" || txtConfirmarContraseña.Text == "")
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtContraseña.Text != txtConfirmarContraseña.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Registro exitoso. ¡Bienvenido a Liverpool!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Aquí puedes incluir la lógica para guardar el usuario, si fuera necesario.
                    this.Hide();
                    Form1 Inicio = new Form1();
                    Inicio.ShowDialog();
                }
            };
            this.Controls.Add(btnRegistro);
        }
    
    }
}
