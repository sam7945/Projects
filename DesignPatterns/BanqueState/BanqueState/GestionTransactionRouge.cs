using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueState
{
    /// <summary>
    /// Auteur:             Samuel Dextraze
    /// Description:Classe  Gère le comportement du compte lorsqu'on est dans le rouge < 0$
    /// Date:               2019-02-11
    /// </summary>
    public class GestionTransactionRouge : AbsGestionTransaction
    {
        private double _fraisTransaction = 0.0;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="etat"></param>
        public GestionTransactionRouge(AbsGestionTransaction etat)
        {
            _balance = etat.Balance;
            _compte = etat.Compte;
            Initialiser();
        }

        /// <summary>
        /// Mise a jour de l'etat en fonction de la balance
        /// </summary>
        /// <returns></returns>
        public override AbsGestionTransaction ChangementEtat()
        {
            if (Balance > _limiteSup)
                return new GestionTransactionArgent(this).ChangementEtat();
            return this;

        }

        /// <summary>
        /// Réalise un depot avec le comportement d'un compte dans le rouge.
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public override string Depot(double montant)
        {
            _balance += montant;
            _compte.Transaction = ChangementEtat();
            return "Dépot -> Dans le rouge ";
        }
        /// <summary>
        /// Initialise les valeurs initiale pour la gestion du compte dans le rouge.
        /// </summary>
        protected override void Initialiser()
        {
            _fraisTransaction = 15.00;
            _interet = 0.0;
            _limiteInf = -500;
            _limiteSup = 0.0;
        }
        /// <summary>
        /// Réalise un retrait avec le comportement d'un compte dans le rouge.
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public override string Retrait(double montant)
        {
            if (_balance - montant - _fraisTransaction < -500)
                return "Pas possible, t'es pas fiable";
            _balance -= montant - _fraisTransaction;
            _compte.Transaction = ChangementEtat();
            return "Retrait -> Dans le rouge ";
        }
    }
}
