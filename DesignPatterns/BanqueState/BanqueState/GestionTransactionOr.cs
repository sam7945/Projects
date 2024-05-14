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
    public class GestionTransactionOr :AbsGestionTransaction
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="etat"></param>
        public GestionTransactionOr(AbsGestionTransaction etat)
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
            if (Balance < _limiteInf)
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
            return "Dépot -> Dans le Or ";
        }
        /// <summary>
        /// Initialise les valeurs initiale pour la gestion du compte dans le rouge.
        /// </summary>
        protected override void Initialiser()
        {
            _interet = 0.05;
            _limiteInf = 1000;
            _limiteSup = double.MaxValue;
        }
        /// <summary>
        /// Réalise un retrait avec le comportement d'un compte dans le rouge.
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public override string Retrait(double montant)
        {
            if (_balance-montant < -500)
                return "Pas possible, t'es pas fiable";
            _balance -= montant;
            _compte.Transaction = ChangementEtat();
            return "Retrait -> Dans le Or ";
        }
    }
}
