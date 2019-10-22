using M2_GestionFlexibleChariot.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Interface
{
    class MenuRecette
    {
        // Gestion Recette
        /// <summary>
        /// Affichage menu Recette
        /// </summary>
        public static void AfficherMenu()
        {
            System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
            System.Console.WriteLine("");
            System.Console.WriteLine("--> Menu Recette");
            System.Console.WriteLine("1) Liste Recette");
            System.Console.WriteLine("2) Détails d'une Recette");
            System.Console.WriteLine("3) Créer Recette");
            System.Console.WriteLine("4) Retour");
            System.Console.WriteLine("");
        }


        /// <summary>
        /// Gère la saisie pour le menu Recette
        /// </summary>
        public static int SaisieMenu()
        {
            bool saisieValid = false;
            int saisie;

            do
            {
                saisie = Utilitaire.SaisirEntier("Menu recette");

                if (saisie <= 4 && saisie > 0)
                {
                    saisieValid = true;
                }
                else
                {
                    System.Console.WriteLine(" Saisissez une valeur entre 1 et 4 comme précisé dans le menu ! ");
                }
            } while (!saisieValid);

            return saisie;
        }

        public static void AfficherListe()
        {
            System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
            System.Console.WriteLine("");
            System.Console.WriteLine("--> Menu Recette ");
            System.Console.WriteLine("");
            foreach (Recette recette in Data.recettes)
            {
                System.Console.WriteLine(recette.ToString());
            }
        }
    }
}
