namespace EXPERIENCIA_UX_CREDITO_DEPARTAMENTAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Login";
            this.BackColor = Color.White;
            this.Size = new Size(400, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Etiqueta de Bienvenida
            Label lblBienvenida = new Label();
            lblBienvenida.Text = "Bienvenido";
            lblBienvenida.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblBienvenida.ForeColor = ColorTranslator.FromHtml("#ED1C24");
            lblBienvenida.Location = new Point(120, 50);
            lblBienvenida.AutoSize = true;
            this.Controls.Add(lblBienvenida);

            // Etiqueta para el usuario
            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuario";
            lblUsuario.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblUsuario.Location = new Point(50, 120);
            this.Controls.Add(lblUsuario);

            // Campo de texto para el usuario
            TextBox txtUsuario = new TextBox();
            txtUsuario.Size = new Size(250, 30);
            txtUsuario.Location = new Point(50, 150);
            txtUsuario.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtUsuario.PlaceholderText = "Ingresa tu usuario";
            this.Controls.Add(txtUsuario);

            // Etiqueta para la contraseña
            Label lblContraseña = new Label();
            lblContraseña.Text = "Contraseña";
            lblContraseña.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblContraseña.Location = new Point(50, 200);
            this.Controls.Add(lblContraseña);

            // Campo de texto para la contraseña
            TextBox txtContraseña = new TextBox();
            txtContraseña.Size = new Size(250, 30);
            txtContraseña.Location = new Point(50, 230);
            txtContraseña.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtContraseña.PasswordChar = '●';
            txtContraseña.PlaceholderText = "Ingresa tu contraseña";
            this.Controls.Add(txtContraseña);

            // Botón de Login
            Button btnLogin = new Button();
            btnLogin.Text = "Ingresar";
            btnLogin.Size = new Size(250, 40);
            btnLogin.Location = new Point(50, 300);
            btnLogin.BackColor = ColorTranslator.FromHtml("#ED1C24");
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += (s, e) =>
            {
                if (txtUsuario.Text == "" || txtContraseña.Text == "")
                {
                    MessageBox.Show("Por favor, ingresa tu usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Aquí se puede colocar la lógica de validación del login.
                    MessageBox.Show("Bienvenido " + txtUsuario.Text + "!", "Acceso Permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    INFORMACION infoForm = new INFORMACION();
                    infoForm.Show();
                }
            };
            this.Controls.Add(btnLogin);

            // Enlace para registrar una cuenta nueva
            LinkLabel linkRegistro = new LinkLabel();
            linkRegistro.Text = "¿No tienes cuenta? Regístrate aquí";
            linkRegistro.Location = new Point(90, 360);
            linkRegistro.AutoSize = true;
            linkRegistro.LinkColor = ColorTranslator.FromHtml("#4A4A4A");
            linkRegistro.Click += (s, e) =>
            {
                RegistroDeUsuario registroForm = new RegistroDeUsuario();
                 registroForm.ShowDialog();
                this.Hide();
            };
            this.Controls.Add(linkRegistro);



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
