using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : DetailsRecette.cs
 * description : fonctions d'interface associées aux détails d'une recette
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.Interface
{
    class DetailsRecette
    {
        /// <summary>
        /// fonction responsable de gérer les saisie nécessaire à la création d'un objet métier recette
        /// </summary>
        /// <returns> une classe métier recette correpsondante aux saisies </returns>
        public static Class.Recette SaisirCréation()
        {
            Class.Recette recette = new Class.Recette(Utilitaire.SaisirString("libellé recette"));

            bool annulation = false;
            Console.WriteLine("");
            
            foreach (Class.Pas pas in recette.Pas)
            {
                Pas.ModificationPasOptionnel(pas, annulation);

            }

            return recette;
        }

        /// <summary>
        /// Affiche les informations détaillés d'un recette dans la console
        /// </summary>
        /// <param name="lot"> objet Class.recette correspondant au recette à afficher</param>
        public static void AfficherDetailRecette(Class.Recette recette)
        {
            System.Console.WriteLine(" -- Détails Recette  -- ");
            System.Console.WriteLine("Identifiant      : {0}", recette.Identifiant);
            System.Console.WriteLine("Libellé          : {0}", recette.Libellé);
            System.Console.WriteLine("Date de création : {0}", recette.DateCréation.ToShortDateString());
            System.Console.WriteLine();
            System.Console.WriteLine("  - Liste des pas de la recette - ");

            // la colonne du libellé a été déplacée à la fin car c'est celle qui est suceptible de varier le plus
            System.Console.WriteLine(String.Format("{0,-5} | {2,-5} | {3,-15} | {4,-10} | {1,-30}",
                        "Index", "Libellé", "Position", "Temps d'arrêt", "Quittance"));
            foreach (Class.Pas pas in recette.Pas)
                {
                    System.Console.WriteLine(String.Format("{0,-5} | {2,-8} | {3,-15} | {4,-10} | {1,-30}",
                        pas.Index, pas.Libellé, pas.Position, pas.Temps, pas.Quittance == true ? "oui" : "non"));
                }
        }

        /// <summary>
        /// Fonction responsable de la saisie de modification d'un recette
        /// </summary>
        /// <param name="recette"> Copie de la recette d'origine devant être modifiée </param>
        /// <returns>objet Recette modifiée selon les choix utilisateur</returns>
        public static Class.Recette ModifierRecette(Class.Recette recette)
        {
            AfficherDetailRecette(recette);
            Console.WriteLine();
            // variable représentant si une saisie a été annulé ou non
            bool annulation;

            // teste libellé
            string stringSaisie = Interface.Utilitaire.SaisirStringOptionnel("Libellé de la recette", out annulation);
            if (!annulation)
            {
                recette.Libellé = stringSaisie;
            }

            Console.WriteLine();
            foreach (Class.Pas pas in recette.Pas){
                Pas.ModificationPasOptionnel(pas, annulation);

            }

            return recette;
        }

        /// <summary>
        /// Affiche le menu lié au détails d'un lot
        /// </summary
        /// <param name="recette"> recette concerné par le menu (est mutable ou non) </param>
        public static void AfficherMenuDetailsRecette(Class.Recette recette)
        {
            System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
            Console.WriteLine("");
            AfficherDetailRecette(recette);
            Console.WriteLine("");
            Console.WriteLine("-- Menu Détails --");
            if (BDD.BDDRecette.EstMuable(recette.Identifiant))
            {
                System.Console.WriteLine("1) Modifier");
                System.Console.WriteLine("2) Supprimer");
            }
            else
            {
                System.Console.WriteLine("   Modification impossible Recette déjà associée à un Lot");
                System.Console.WriteLine("   Suppression impossible Recette déjà associée à un Lot");
            }
            System.Console.WriteLine("3) Quitter");
            System.Console.WriteLine("");
        }


        /// <summary>
        /// Gère la saisie pour le menu des détails d'un lot
        /// </summary>
        public static int SaisieMenu()
        {
            bool saisieValid = false;
            int saisie;

            do
            {
                saisie = Utilitaire.SaisirEntier("Menu détails recette");

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
