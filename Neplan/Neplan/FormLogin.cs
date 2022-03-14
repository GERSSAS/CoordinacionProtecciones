using System;
using System.Text;
using System.Windows.Forms;
using Neplan_coordinacion.NeplanService;
using System.Security.Cryptography;

namespace Neplan
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public static NeplanServiceClient nepService;
        //public static int prueba;
        public static string usuario;
        public static string contraseña;
        public string url = "https://neplan1.gers.co/Services/External/NeplanService.svc";



        private void selecionarServidor_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ("SERVIDOR DE CALI" == selecionarServidor.SelectedItem.ToString())
            {
                url = "https://neplan1.gers.co/Services/External/NeplanService.svc";
            }
            else
            {
                url = "https://192.168.5.2/Services/External/NeplanService.svc";
            }
        }


        private void btnAcceder_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender2, certificate, chain, sslPolicyError) => true);
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
           

            NeplanServiceClient nepService = new NeplanServiceClient("WSHttpBinding_NeplanService", url);

            nepService.ClientCredentials.UserName.UserName = usuario;
            nepService.ClientCredentials.UserName.Password = getSHA1Hash(contraseña);

            try
            {
                nepService.Open();
                
                Form formulario = new FormCoordinacionProtecciones();
                
                formulario.Show();

                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }

        }

        private string getSHA1Hash(string contraseña)
        {
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] data = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(contraseña));
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                stringBuilder.Append(data[i].ToString("x2"));

            return stringBuilder.ToString();
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
    }
}
