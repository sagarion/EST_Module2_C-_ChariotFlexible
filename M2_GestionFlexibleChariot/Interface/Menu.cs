using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Interface
{
    class Menu
    {
        public static void AfficherMenuPrincipale()
        {
            Console.WriteLine("--- Application Gestion Chariot Flexible ---");
            Console.WriteLine("");
            Console.WriteLine("--> Menu Principale");
            Console.WriteLine("1) Gestion des Recettes");
            Console.WriteLine("2) Gestion des Lots");
            Console.WriteLine("3) Quitter");
            Console.WriteLine("");
        }
    }
}
