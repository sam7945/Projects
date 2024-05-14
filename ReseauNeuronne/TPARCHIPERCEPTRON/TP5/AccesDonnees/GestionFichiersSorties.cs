using System;
using System.Collections.Generic;
using System.IO;
using TP5.Metier;

namespace TP5.AccesDonnees
{
    /// <summary>
    /// Cette classe gère l'accès aux disques pour le fichiers d'apprentissages. 
    /// Permet de charger ou décharger dans la matrice d'apprentissage.
    /// </summary>
    public class GestionFichiersSorties : IGestionFichiersSorties
    {
        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        public List<Metier.ICoordDessin> ChargerCoordonnees(string fichier)
        {
            Metier.ICoordDessin coord;
            List<Metier.ICoordDessin> lstCoord = new List<Metier.ICoordDessin>();
            StreamReader reader;
            string sLigne;

            try
            {
                reader = new StreamReader(new FileStream(fichier, FileMode.Open, FileAccess.Read));
                while (!reader.EndOfStream)
                {
                    sLigne = reader.ReadLine();
                    coord = new Metier.CoordDessin(CstApplication.TAILLEDESSINX, CstApplication.TAILLEDESSINY);

                    string[] tabEntree = sLigne.Split('\t');
                    coord.Reponse = tabEntree[0];

                    for (int j = 1; j < tabEntree.Length - 1; j++)
                        coord.BitArrayDessin[j] = Convert.ToInt32(tabEntree[j]) == CstApplication.VRAI ? true : false;
                    lstCoord.Add(coord);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return lstCoord;
            }
            return lstCoord;
        }

        /// <summary>
        /// Permet de sauvegarder dans fichier texte dans une matrice pour l'apprentissage automatique
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        public int SauvegarderCoordonnees(string fichier, List<Metier.ICoordDessin> lstCoord)
        {
            try
            {
                MelangerEchantillon(lstCoord);
                StreamWriter writer = new StreamWriter(fichier);

                foreach (Metier.ICoordDessin c in lstCoord)
                {
                    writer.Write(c.Reponse + "\t");
                    for (int i = 0; i < c.BitArrayDessin.Length - 1; i++)
                        writer.Write((Convert.ToBoolean(c.BitArrayDessin[i]) == true ? CstApplication.VRAI : CstApplication.FAUX).ToString() + "\t");
                    writer.WriteLine((Convert.ToBoolean(c.BitArrayDessin[c.BitArrayDessin.Length - 1]) == true ? CstApplication.VRAI : CstApplication.FAUX).ToString());
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return CstApplication.ERREUR;
            }
            return CstApplication.OK;
        }

        /// <summary>
        /// Permet de mélanger aléatoirement les échantillons d'apprentissages(coordonnées) dans le but d'améliorer l'apprentissage.
        /// </summary>
        /// <param name="lstCoord">Les coordonnées à mélanger</param>
        private void MelangerEchantillon(List<Metier.ICoordDessin> lstCoord)
        {
            Random r1 = new Random();
            Random r2 = new Random();
            int index1;
            int index2;
            Metier.ICoordDessin coordTemp;

            for (int i = 0; i < CstApplication.MAXITERATION; i++)
            {
                index1 = r1.Next(lstCoord.Count);
                index2 = r2.Next(lstCoord.Count);

                coordTemp = lstCoord[index1];
                lstCoord[index1] = lstCoord[index2];
                lstCoord[index2] = coordTemp;
            }
        }
    }

}
