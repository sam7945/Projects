using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combat_Tp4_.Models.Personnages;

namespace Combat_Tp4_.Models
{
    public class Arène
    {
        #region Champs
        Random _rnd = new Random();

        private Archer _archer = new Archer();
        private Blanc _MageBlanc = new Blanc();
        private CBlanc _CheBlanc = new CBlanc();
        private CNoir _CheNoir = new CNoir();
        private Noir _MageNoir = new Noir();

        private Chevalier _chevalier = new Chevalier();
        private Guerrier _guerrier = new Guerrier();
        private Magicien _magicien = new Magicien();

        private List<Archer> _ListArcher = new List<Archer>();
        private List<Blanc> _ListBlanc = new List<Blanc>();
        private List<CBlanc> _ListCBlanc = new List<CBlanc>();
        private List<CNoir> _ListCNoir = new List<CNoir>();
        private List<Noir> _ListNoir = new List<Noir>();

        private Archer _archer1 = new Archer();
        private Archer _archer2 = new Archer();
        private Archer _archer3 = new Archer();
        private Archer _archer4 = new Archer();
        private Archer _archer5 = new Archer();
        private Archer _archer6 = new Archer();
        private Archer _archer7 = new Archer();
        private Archer _archer8 = new Archer();

        private Blanc _Blanc1 = new Blanc();
        private Blanc _Blanc2 = new Blanc();
        private Blanc _Blanc3 = new Blanc();
        private Blanc _Blanc4 = new Blanc();
        private Blanc _Blanc5 = new Blanc();
        private Blanc _Blanc6 = new Blanc();
        private Blanc _Blanc7 = new Blanc();
        private Blanc _Blanc8 = new Blanc();

        private CBlanc _CBlanc1 = new CBlanc();
        private CBlanc _CBlanc2 = new CBlanc();
        private CBlanc _CBlanc3 = new CBlanc();
        private CBlanc _CBlanc4 = new CBlanc();
        private CBlanc _CBlanc5 = new CBlanc();
        private CBlanc _CBlanc6 = new CBlanc();
        private CBlanc _CBlanc7 = new CBlanc();
        private CBlanc _CBlanc8 = new CBlanc();

        private CNoir _CNoir1 = new CNoir();
        private CNoir _CNoir2 = new CNoir();
        private CNoir _CNoir3 = new CNoir();
        private CNoir _CNoir4 = new CNoir();
        private CNoir _CNoir5 = new CNoir();
        private CNoir _CNoir6 = new CNoir();
        private CNoir _CNoir7 = new CNoir();
        private CNoir _CNoir8 = new CNoir();

        private Noir _Noir1 = new Noir();
        private Noir _Noir2 = new Noir();
        private Noir _Noir3 = new Noir();
        private Noir _Noir4 = new Noir();
        private Noir _Noir5 = new Noir();
        private Noir _Noir6 = new Noir();
        private Noir _Noir7 = new Noir();
        private Noir _Noir8 = new Noir();

        private List<Personnage> _Personnages = new List<Personnage>();
        #endregion

        #region Méthodes
        public List<Personnage> création()
        {
            _ListArcher.Add(_archer1);
            _ListArcher.Add(_archer2);
            _ListArcher.Add(_archer3);
            _ListArcher.Add(_archer4);
            _ListArcher.Add(_archer5);
            _ListArcher.Add(_archer6);
            _ListArcher.Add(_archer7);
            _ListArcher.Add(_archer8);

            _ListBlanc.Add(_Blanc1);
            _ListBlanc.Add(_Blanc2);
            _ListBlanc.Add(_Blanc3);
            _ListBlanc.Add(_Blanc4);
            _ListBlanc.Add(_Blanc5);
            _ListBlanc.Add(_Blanc6);
            _ListBlanc.Add(_Blanc7);
            _ListBlanc.Add(_Blanc8);

            _ListCBlanc.Add(_CBlanc1);
            _ListCBlanc.Add(_CBlanc2);
            _ListCBlanc.Add(_CBlanc3);
            _ListCBlanc.Add(_CBlanc4);
            _ListCBlanc.Add(_CBlanc5);
            _ListCBlanc.Add(_CBlanc6);
            _ListCBlanc.Add(_CBlanc7);
            _ListCBlanc.Add(_CBlanc8);

            _ListCNoir.Add(_CNoir1);
            _ListCNoir.Add(_CNoir2);
            _ListCNoir.Add(_CNoir3);
            _ListCNoir.Add(_CNoir4);
            _ListCNoir.Add(_CNoir5);
            _ListCNoir.Add(_CNoir6);
            _ListCNoir.Add(_CNoir7);
            _ListCNoir.Add(_CNoir8);

            _ListNoir.Add(_Noir1);
            _ListNoir.Add(_Noir2);
            _ListNoir.Add(_Noir3);
            _ListNoir.Add(_Noir4);
            _ListNoir.Add(_Noir5);
            _ListNoir.Add(_Noir6);
            _ListNoir.Add(_Noir7);
            _ListNoir.Add(_Noir8);

            Stats();

            int iChoix = 0;
            for (int iPerso = 0; iPerso < 8; iPerso++)
            {
                iChoix = _rnd.Next(0, 5);

                if (iChoix == 0)
                    _Personnages.Add(_ListArcher[iPerso]);
                if (iChoix == 1)
                    _Personnages.Add(_ListBlanc[iPerso]);
                if (iChoix == 2)
                    _Personnages.Add(_ListNoir[iPerso]);
                if (iChoix == 3)
                    _Personnages.Add(_ListCBlanc[iPerso]);
                if (iChoix == 4)
                    _Personnages.Add(_ListCNoir[iPerso]);
            };
            return _Personnages;
        }
        public void Stats()
        {
            foreach (var perso in _ListArcher)
            {
                perso.Niveau = 1;
                perso.Classe_Armure = 9;
                perso.Expérience = 0;
                perso.Point_de_vie = 17;
                perso.Dommage_Max = 8 + perso.Bonus_Attaque;
                perso.Nom = "Archer";
                perso.Nombre_Flèche = 30;
            }
            foreach (var perso in _ListBlanc)
            {
                perso.Niveau = 1;
                perso.Classe_Armure = 10;
                perso.Expérience = 0;
                perso.Point_de_vie = 25;
                perso.Dommage_Max = 2*4 + perso.Bonus_Attaque;
                perso.Nom = "Mage blanc";
                perso.Potions = "Élixir du renouveau";
                perso.Nombre_Potion = 10;
                perso.Sorts = "Guérison divine";
            }
            foreach (var perso in _ListCBlanc)
            {
                perso.Niveau = 1;
                perso.Classe_Armure = 11;
                perso.Expérience = 0;
                perso.Point_de_vie = 20;
                perso.Dommage_Max = 8 + perso.Bonus_Attaque;
                perso.Nom = "Chevalier blanc";
            }
            foreach (var perso in _ListCNoir)
            {
                perso.Niveau = 1;
                perso.Classe_Armure = 11;
                perso.Expérience = 0;
                perso.Point_de_vie = 20;
                perso.Dommage_Max = 8 + perso.Bonus_Attaque;
                perso.Nom = "Chevalier noir";
            }
            foreach (var perso in _ListNoir)
            {
                perso.Niveau = 1;
                perso.Classe_Armure=8;
                perso.Expérience = 0;
                perso.Point_de_vie = 18;
                perso.Dommage_Max = 10 + perso.Bonus_Attaque;
                perso.Nom = "Mage noir";
                perso.Potions = "Brasier interne";
                perso.Nombre_Potion =15;
                perso.Sorts = "HellFire";
                perso.Demon_Nom = "Ragnarok";
            }
        }
        #endregion
    }
}
