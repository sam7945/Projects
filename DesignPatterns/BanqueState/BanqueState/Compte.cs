using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueState
{
    /// <summary>
    /// Auteur:     Samuel Dextraze
    /// Description:L'objet compte modélise un compte de banque. 
    ///             Les transactions se feront selon les conditions 
    ///             implémenter dans différent objets.
    /// Date:       2019-02-11
    /// </summary>
    public class Compte
    {
        private string _proprio;
        public AbsGestionTransaction Transaction;
        public Compte(string proprio)
        {
            _proprio = proprio;
            Transaction = new GestionTransactionArgent(0.0,this);
        }
        /// <summary>
        /// Depot d'argent
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public string Depot(double montant)
        {
            string sRetour = Transaction.Depot(montant);
            sRetour += $"\r\n {Transaction.GetType().Name}";
            return sRetour;
        }
        /// <summary>
        /// Retrait d'argent
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public string Retrait(double montant)
        {
            string sRetour = Transaction.Retrait(montant);
            sRetour += $"\r\n {Transaction.GetType().Name}";
            return sRetour;
        }
    }
}
