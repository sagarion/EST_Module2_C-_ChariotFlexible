using M2_GestionFlexibleChariot.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : MenuRecette.cs
 * description : fonctions d'interface associées au menu de gestion des recettes
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

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
        public static void AfficherListeRecettes(List<Class.Recette> recettes)
        {
            System.Console.WriteLine("-- Liste recettes --");
            System.Console.WriteLine("");
            System.Console.WriteLine(String.Format("{0,-11} | {1,-16} | {2,-10}",
                        "Identifiant", "Date de création", "libellé de la recette"));
            foreach (Class.Recette recette in recettes)
            {
                System.Console.WriteLine(String.Format("{0,-11} | {1,-16} | {2,-10}",
                        recette.Identifiant, recette.DateCréation.ToShortDateString(), recette.Libellé));
            }
        }

        /// <summary>
        /// Renvoie la recette correspondante à l'identifiant saisie par l'utilisateur
        /// </summary>
        /// <returns> la recette correspondante à l'identifiant saisie par l'utilisateur </returns>
        public static Class.Recette SelectionnerRecette(List<Class.Recette> recettes)
        {
            // affiche la listes des recettes disponibles
            AfficherListeRecettes(recettes);
            Console.WriteLine();

            bool saisieValide = false;
            int identifiant = 0;
            do
            {
                identifiant = Utilitaire.SaisirEntier("Identifiant de la recette");

                // A MODIFIER
                if (BDD.BDDRecette.EstIdentifiantValide(identifiant))
                {
                    saisieValide = true;
                }
                else
                {
                    System.Console.WriteLine("Erreur Veuillez saisir identifiant correct d'une recette");
                }
            } while (!saisieValide);

            return BDD.BDDRecette.GetRecette(identifiant);
        }

        /// <summary>
        /// Renvoie la recette correspondante à l'identifiant saisie par l'utilisateur
        /// </summary>
        /// <returns> la recette correspondante à l'identifiant saisie par l'utilisateur </returns>
        public static Class.Recette SelectionnerRecetteOptionnel(out bool annulation, List<Class.Recette> recettes)
        {
            // affiche la listes des recettes disponibles
            AfficherListeRecettes(recettes);

            bool saisieValide = false;
            int identifiant = 0;
            do
            {
                annulation = false;
                identifiant = Utilitaire.SaisirEntierOptionnel("Identifiant de la recette",out annulation);
                // A MODIFIER
                if (annulation)
                {
                    saisieValide = true;
                }
                else if (BDD.BDDRecette.EstIdentifiantValide(identifiant))
                {
                    saisieValide = true;
                }
                else
                {
                    System.Console.WriteLine("Erreur Veuillez saisir identifiant correct d'une recette");
                }
            } while (!saisieValide);

            if (annulation)
            {
                return null;
            }
            else{
                return BDD.BDDRecette.GetRecette(identifiant);
            }
        }
    }
}
