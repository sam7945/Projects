using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            IProduit produit;
            Createur createur = new Createur();
            InitializeComponent();
            for (int i = 1; i <= 12; i++)
            {
                produit = createur.FactoryMethod(i);
                txtResultat.Text += i + "-" + produit.RetournerPays() + "\r\n";
            }
        }
    }
}
