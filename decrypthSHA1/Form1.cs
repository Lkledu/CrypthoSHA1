using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace decrypthSHA1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelCryptho.ReadOnly = true;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            labelCryptho.Text = SenhaAcesso(textBox1.Text);
        }


        private static string SenhaAcesso(string value)
        {

            byte[] toByte = UTF8Encoding.ASCII.GetBytes(value);
            byte[] resultado;

            try
            {
                using (SHA1Managed sh = new SHA1Managed())
                {
                    resultado = sh.ComputeHash(toByte);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criptografar: " + ex.Message);
            }
            return Convert.ToBase64String(resultado);
        }
    }
}
