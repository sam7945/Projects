using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueState
{
    /// <summary>
    /// Auteur:             Samuel Dextraze
    /// Description:Classe  abstraite du gestionnaire de transaction qui contient les valeur de l'etat qui sont les limites.
    /// Date:               2019-02-11
    /// </summary>
    public abstract class AbsGestionTransaction
    {
        //variable membre
        protected double _balance;
        protected double _interet;
        protected double _limiteInf;
        protected double _limiteSup;
        protected Compte _compte;
        internal double Balance
        {
            get { return _balance; }
        }
        internal Compte Compte
        {
            get { return _compte; }
        }

        public abstract string Depot(double montant);
        public abstract string Retrait(double montant);

        protected abstract void Initialiser();
        public abstract AbsGestionTransaction ChangementEtat();
    }
}