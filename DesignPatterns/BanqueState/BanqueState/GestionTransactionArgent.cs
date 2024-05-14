using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueState
{
    public class GestionTransactionArgent : AbsGestionTransaction
    {
        private double _fraisTransaction = 0.0;
        public GestionTransactionArgent(double balance, Compte compte)
        {
            _balance = balance;
            _compte = compte;
            Initialiser();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="etat"></param>
        public GestionTransactionArgent(AbsGestionTransaction etat)
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
                return new GestionTransactionOr(this).ChangementEtat();
            else if (Balance < _limiteInf)
                return new GestionTransactionRouge(this).ChangementEtat();
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
            return "Dépot -> Dans le Argent ";
        }
        /// <summary>
        /// Initialise les valeurs initiale pour la gestion du compte dans le rouge.
        /// </summary>
        protected override void Initialiser()
        {
            _fraisTransaction = 1.00;
            _interet = 0.0;
            _limiteInf = 0.0;
            _limiteSup = 1000.0;
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
            return "Retrait -> Dans le Argent ";
        }
    }
}

