using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Sandwich : ISandwichPrototype
    {
        public string Pain;
        public string Viande;
        public string Fromage; //I will use this pun everywhere I can
        public string Legumes;

        public Sandwich(string pain, string viande, string fromage, string legumes)
        {
            Pain = pain;
            Viande = viande;
            Fromage = fromage;
            Legumes = legumes;
        }
        public ISandwichPrototype Clone()
        {
            string ingredientList = GetListeIngrediants();
            Console.WriteLine("Clonage de sandwich avec les ingrédiants: {0}", ingredientList.Remove(ingredientList.LastIndexOf(",")));

            return MemberwiseClone() as ISandwichPrototype;
        }
        private string GetListeIngrediants()
        {
            string ListeIngrediants = "";
            if (!string.IsNullOrWhiteSpace(Pain))
            {
                ListeIngrediants += Pain + ", ";
            }
            if (!string.IsNullOrWhiteSpace(Viande))
            {
                ListeIngrediants += Viande + ", ";
            }
            if (!string.IsNullOrWhiteSpace(Fromage))
            {
                ListeIngrediants += Fromage + ", ";
            }
            if (!string.IsNullOrWhiteSpace(Legumes))
            {
                ListeIngrediants += Legumes + ", ";
            }
            return ListeIngrediants;
        }
    }
}
