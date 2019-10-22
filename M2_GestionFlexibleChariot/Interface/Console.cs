using M2_GestionFlexibleChariot.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Interface
{
    class Console
    {

        // Gestion Recette



        /// <summary>
        /// Fait sélectionner à l'utilisateur l'id d'une recette
        /// </summary>
        /// <returns> l'id de la recette sélectionné</returns>
        public static int SelectionnerRecette()
        {
            bool saisieValid = false;
            int result;

            do
            {
                result = Utilitaire.SaisirEntier("identifiant de la recette");
                // A CHANGER
                if (result < 4 && result > 0)
                {
                    saisieValid = true;
                }

            } while (!saisieValid);

            return result;
        }

        public static void AfficherDetailsRecette(int id)
        {
            // A CHANGER
            Recette recette = Data.recettes[id - 1];

            // recette
            System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
            System.Console.WriteLine("");
            System.Console.WriteLine("--> Détails Recette {0}", id);
            System.Console.WriteLine("");
            System.Console.WriteLine("Identifiant : {0}", recette.Identifiant);
            System.Console.WriteLine("Libellé : {0}", recette.Libellé);
            System.Console.WriteLine("Date création : {0}", recette.DateCréation);
            System.Console.WriteLine("");

            // Pas
            System.Console.WriteLine(" PAS :");
            System.Console.WriteLine($"Identifiant /" +
                    " Libellé /" +
                    " Index /" +
                    " Position /" +
                    " Temps /" +
                    " Quittance");
            foreach (Pas pas in recette.Pas)
            {
                System.Console.WriteLine($"{pas.Identifiant} /" +
                    $" {pas.Libellé} /" +
                    $" {pas.Index} /" +
                    $" {pas.Position} /" +
                    $" {pas.Temps} /" +
                    $"{0}", pas.Quittance == true ? "oui" : "non");
            }
            System.Console.WriteLine("");

            // option 
            System.Console.WriteLine("1) modifier");
            System.Console.WriteLine("2) dupliquer");
            System.Console.WriteLine("3) Retour");
            System.Console.WriteLine("");
        }

        public static void SaisirDetailsRecette(int id)
        {
            bool saisieValid = false;
            int result;

            do
            {
                result = Utilitaire.SaisirEntier("Menu principal");

                if (result <= 3 && result > 0)
                {
                    saisieValid = true;
                }
                else
                {
                    System.Console.WriteLine(" Saisissez une valeur entre 1 et 3 comme précisé dans le menu ! ");
                }
            } while (!saisieValid);

            switch (result)
            {
                case 1:

                    break;
                case 2:
                    int newId = Data.GetNextIdRecette();
                    Data.recettes[newId] = Data.recettes[id].Duplicate();
                    AfficherDetailsRecette(newId);
                    SaisirDetailsRecette(newId);
                    break;
                case 3:
                    //AfficherMenuRecette();
                    break;
                default:
                    System.Console.WriteLine(" Une erreur à eu lieu et l'application va prendre fin");
                    Utilitaire.Attendre();
                    break;
            }
        }

        public static void AffichageModificationRecette(int id)
        {
            // A TERMINER
        }

        // Lot
    }
}
