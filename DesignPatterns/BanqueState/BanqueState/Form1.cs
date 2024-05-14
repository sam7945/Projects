using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanqueState
{
    public partial class Form1 : Form
    {
        private Compte _compte;
        public Form1()
        {
            InitializeComponent();
            _compte = new Compte("Samuel Dextraze");
        }
        /// <summary>
        /// Simule un depot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepot_Click(object sender, EventArgs e)
        {
            double dMontant = Convert.ToDouble(txtMontant.Text);
            string sResultat = _compte.Depot(dMontant);
            txtResultat.Text += sResultat + "\r\n";
        }
        /// <summary>
        /// Simule un retrait
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrait_Click(object sender, EventArgs e)
        {
            double dMontant = Convert.ToDouble(txtMontant.Text);
            string sResultat = _compte.Retrait(dMontant);
            txtResultat.Text += sResultat + "\r\n";
        }
    }
}
