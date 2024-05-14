using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace singletonExercice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Adresse a = Adresse.Instance();
            a.adresses.Add("serveur 1","192.168.0.1");
            a.adresses.Add("serveur 0","127.0.0.1");
            a.adresses.Add("serveur 2","192.168.0.2");
            foreach (var item in a.adresses)
            {
                txtResultat.Text += "\r\n"+item;
            }
            Adresse a1 = Adresse.Instance();
            a1.adresses.Remove("serveur 1");
            foreach (var item in a.adresses)
            {
                txtResultat.Text += "\r\n" + item;
            }
        }
    }
}
