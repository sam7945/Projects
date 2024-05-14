using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combat_Tp4_.Models.Personnages
{
    public abstract class Personnage
    {
        #region Champs
        public List<Personnage> Victoires = new List<Personnage>();
        public List<Personnage> Défaites = new List<Personnage>();
        public List<Personnage> Fuites = new List<Personnage>();
        public List<int> Nombre_Attaque = new List<int>();
        Random _rnd = new Random();
        public bool bFin = false;
        #endregion

        #region Propriétés
        public string Nom { get; set; }
        public int Niveau { get; set; }
        public int Classe_Armure { get; set; }
        public float Point_de_vie { get; set; }
        public int Bonus_Attaque { get; set; }
        public int Dommage_Max { get; set; }
        public int Expérience { get; set; }
        #endregion

        #region Méthode
        public void Attaquer(Personnage Attaquant,Personnage Attaquer,int Dé)
        {
            int iRnd = 0;
            int iRnd2 = 0;

            if (Attaquant.Nom == "Mage blanc" && Attaquer.Nom== "Mage blanc")
                Attaquant.Bonus_Attaque = 0;
            else if (Attaquant.Nom == "Mage noir" && Attaquer.Nom == "Mage blanc")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Chevalier noir" && Attaquer.Nom == "Mage blanc")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Chevalier blanc" && Attaquer.Nom == "Mage blanc")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Archer" && Attaquer.Nom == "Mage blanc")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Mage blanc" && Attaquer.Nom == "Mage noir")
                Attaquant.Bonus_Attaque = 1;
            else if (Attaquant.Nom == "Mage noir" && Attaquer.Nom == "Mage noir")
                Attaquant.Bonus_Attaque = 0;
            else if (Attaquant.Nom == "Chevalier noir" && Attaquer.Nom == "Mage noir")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Chevalier blanc" && Attaquer.Nom == "Mage noir")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Archer" && Attaquer.Nom == "Mage noir")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Mage blanc" && Attaquer.Nom == "Chevalier noir")
                Attaquant.Bonus_Attaque = 1;
            else if (Attaquant.Nom == "Mage noir" && Attaquer.Nom == "Chevalier noir")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Chevalier noir" && Attaquer.Nom == "Chevalier noir")
                Attaquant.Bonus_Attaque = 0;
            else if (Attaquant.Nom == "Chevalier blanc" && Attaquer.Nom == "Chevalier noir")
                Attaquant.Bonus_Attaque = 0;
            else if (Attaquant.Nom == "Archer" && Attaquer.Nom == "Chevalier noir")
                Attaquant.Bonus_Attaque = 3;
            else if (Attaquant.Nom == "Mage blanc" && Attaquer.Nom == "Chevalier blanc")
                Attaquant.Bonus_Attaque = 1;
            else if (Attaquant.Nom == "Mage noir" && Attaquer.Nom == "Chevalier blanc")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Chevalier noir" && Attaquer.Nom == "Chevalier blanc")
                Attaquant.Bonus_Attaque = 0;
            else if (Attaquant.Nom == "Chevalier blanc" && Attaquer.Nom == "Chevalier blanc")
                Attaquant.Bonus_Attaque = 0;
            else if (Attaquant.Nom == "Archer" && Attaquer.Nom == "Chevalier blanc")
                Attaquant.Bonus_Attaque = 3;
            else if (Attaquant.Nom == "Mage blanc" && Attaquer.Nom == "Archer")
                Attaquant.Bonus_Attaque = 1;
            else if (Attaquant.Nom == "Mage noir" && Attaquer.Nom == "Archer")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Chevalier noir" && Attaquer.Nom == "Archer")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Chevalier blanc" && Attaquer.Nom == "Archer")
                Attaquant.Bonus_Attaque = 2;
            else if (Attaquant.Nom == "Archer" && Attaquer.Nom == "Archer")
                Attaquant.Bonus_Attaque = 0;

            if (Attaquant.Nom == "Chevalier noir")
                iRnd = _rnd.Next(1, 9);
            else if (Attaquant.Nom == "Chevalier blanc")
                iRnd = _rnd.Next(1, 9);
            else if (Attaquant.Nom == "Archer")
                iRnd = _rnd.Next(1, 9);
            else if (Attaquant.Nom == "Mage blanc")
            { 
                iRnd = _rnd.Next(1, 5);
                iRnd2 = _rnd.Next(1, 5);
            }
            else if (Attaquant.Nom == "Mage noir")
                iRnd = _rnd.Next(1, 11);


            if (Dé+Attaquant.Bonus_Attaque > Attaquer.Classe_Armure)
            {
                Attaquer.Point_de_vie= Attaquer.Point_de_vie - (iRnd+iRnd2);
            }

            if (Attaquer.Point_de_vie <=0)
            {
                Défaites.Add(Attaquer);

            }
        }

        public void AjouterExpérience(int expérience,Personnage GagneXp,Personnage Perdant)
        {
            GagneXp.Expérience += Perdant.Niveau * 50;
            AugmenterNiveau(GagneXp);
        }

        public void AugmenterNiveau(Personnage Monter)
        {
            if (Monter.Expérience >= 300 && Monter.Niveau == 1)
                Monter.Niveau = 2;
            else if (Monter.Expérience >= 900 && Monter.Niveau == 2)
                Monter.Niveau = 3;
            else if (Monter.Expérience >= 2700 && Monter.Niveau == 3)
                Monter.Niveau = 4;
            else if (Monter.Expérience >= 6500 && Monter.Niveau == 4)
                Monter.Niveau = 5;
            else if (Monter.Expérience >= 14000 && Monter.Niveau == 5)
                Monter.Niveau = 6;
            else if (Monter.Expérience >= 23000 && Monter.Niveau == 6)
                Monter.Niveau = 7;
            else if (Monter.Expérience >= 34000 && Monter.Niveau == 7)
                Monter.Niveau = 8;
            else if (Monter.Expérience >= 48000 && Monter.Niveau == 8)
                Monter.Niveau = 9;
            else if (Monter.Expérience >= 64000 && Monter.Niveau == 9)
            {
                Monter.Niveau = 10;
                Victoires.Add(Monter);
                bFin = true;
            }
        }
        #endregion
    }
}