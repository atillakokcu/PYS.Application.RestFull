using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PYS.Application.Business;
using PYS.Application.Security;

namespace PYS.Application.Security.TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           TxtEncryptext.Text= PysSecurity.Encrypt(TxtCleanText.Text,"123");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtDecrypText.Text = PysSecurity.Decrypt(TxtEncryptext.Text, "123");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KullaniciIslemleri kullaniciIslemleri = new KullaniciIslemleri();
            string Mesaj = "";
            string Token= kullaniciIslemleri.GetToken("adasdsa", "asdas",out Mesaj);
            
        }
    }
}
