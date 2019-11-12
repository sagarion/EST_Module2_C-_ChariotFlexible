using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : MenuPrincipal.cs
 * description : fonctions d'interface associées au menu principal de l'application
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.Interface
{
    class MenuPrincipal
    {
        // Menu principale

        /// <summary>
        /// Affiche le menu principale de l'application
        /// </summary>
        public static void AfficherMenu()
        {
            System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
            System.Console.WriteLine("");
            System.Console.WriteLine("--> Menu Principale");
            System.Console.WriteLine("1) Gestion des Recettes");
            System.Console.WriteLine("2) Gestion des Lots");
            System.Console.WriteLine("3) Quitter");
            System.Console.WriteLine("");
        }

        /// <summary>
        /// Gère la saisie pour le menu principal
        /// </summary>
        public static int SaisieMenu()
        {
            bool saisieValid = false;
            int saisie;

            do
            {
                saisie = Utilitaire.SaisirEntier("Menu principal");

                if (saisie <= 3 && saisie > 0)
                {
                    saisieValid = true;
                }
                else
                {
                    System.Console.WriteLine(" Saisissez une valeur entre 1 et 3 comme précisé dans le menu ! ");
                }
            } while (!saisieValid);

            return saisie;
        }
    }
}
