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
        /// Affichage le menu des Recettes
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

        /// <summary>
        /// Affiche la liste des recettes disponibles
        /// </summary>
        public static void AfficherListeRecettes()
        {
            System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
            System.Console.WriteLine("");
            System.Console.WriteLine("--> Liste recettes ");
            System.Console.WriteLine("");
            foreach (Class.Recette recette in Data.recettes)
            {
                System.Console.WriteLine(recette.ToString());
            }
        }

        /// <summary>
        /// Renvoie la recette correspondante à l'identifiant saisie par l'utilisateur
        /// </summary>
        /// <returns> la recette correspondante à l'identifiant saisie par l'utilisateur </returns>
        public static Class.Recette SelectionnerRecette()
        {
            // affiche la listes des recettes disponibles
            AfficherListeRecettes();

            bool saisieValide = false;
            int identifiant = 0;
            do
            {
                identifiant = Utilitaire.SaisirEntier("Identifiant de la recette");

                // A MODIFIER
                if (Data.recettes[identifiant] == null)
                {
                    saisieValide = true;
                }
                else
                {
                    System.Console.WriteLine("Veuillez saisir identifiant correct d'une recette");
                }
            } while (!saisieValide);

            return Data.recettes[identifiant];
        }
    }
}
