using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            // Initialise les sandwichs par default
            sandwichMenu["BLT"] = new Sandwich("Blé", "Bacon", "", "Laitue, Tomate");
            sandwichMenu["PB&J"] = new Sandwich("Blanc", "", "", "Beurre de peanut, Gelée");
            sandwichMenu["Dinde"] = new Sandwich("Seigle", "Dinde", "Fromage Suisse", "Laitue, oignon, Tomate");

            // Ajout de sandwich custom
            sandwichMenu["BLTComplet"] = new Sandwich("Blé", "Dinde, Bacon", "Americain", "Laitue, Tomate, Oignon, Olives");
            sandwichMenu["ComboTroisViande"] = new Sandwich("Seigle", "Dinde, Jambon, Salami", "Provolone", "Laitue, Oignon");
            sandwichMenu["Vegetarien"] = new Sandwich("Blé", "", "", "Laitue, Oignion, Tomate, Olives, Épinard");

            
            // Clone des sandwichs
            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["ComboTroisViande"].Clone() as Sandwich;
            Sandwich sandwich3 = sandwichMenu["Vegetarien"].Clone() as Sandwich;
            sandwich1.Fromage = "Suisse";
            Console.WriteLine(sandwich1.Pain +", "+ sandwich1.Viande +", "+ sandwich1.Fromage +", "+ sandwich1.Legumes);
            Console.ReadKey();
        }
    }
}
