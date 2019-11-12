using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : DetailsLot.cs
 * description : fonctions d'interface associées aux détails d'un lot
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.Interface
{
    class DetailsLot
    {
        /// <summary>
        /// Fonction responsable de la création d'un lot
        /// </summary>
        /// <returns> Un objet Class.Lot correspondant au résultat des saisies de l'utilisateur </returns>
        public static Class.Lot SaisirCréation(List<Class.Recette> recettes)
        {
            Console.WriteLine("-- création lot ---");
            string nom = Utilitaire.SaisirString("Nom du lot");
            Console.WriteLine();
            int quantiteAProduire = SaisirQuantite();
            Console.WriteLine();
            int idRecette = MenuRecette.SelectionnerRecette(recettes).Identifiant;

            return new Class.Lot(nom, quantiteAProduire, idRecette);
        }

        /// <summary>
        /// Fonction responsable de la saisie d'une quantité de pièce(s) attribuée(s) à un lot
        /// </summary>
        /// <returns> un entier correspondant à la quantité de pièce attribué au lot</returns>
        public static int SaisirQuantite()
        {
            bool saisieCorrecte = false;
            int quantite = 0;

            do
            {
                quantite = Utilitaire.SaisirEntier("quantité de pièce(s) à produire");

                if (quantite > 0)
                {
                    saisieCorrecte = true;
                }
                else
                {
                    System.Console.WriteLine("Erreur veuillez saisir une quantité supérieur à 0 !");
                }

            } while (!saisieCorrecte);

            return quantite;
        }

        /// <summary>
        /// Affiche les informations détaillés d'un lot dans la console
        /// </summary>
        /// <param name="lot"> objet Class.lot correspondant au lot à afficher</param>
        public static void AfficherDetailLot(Class.Lot lot)
        {
            System.Console.WriteLine("-- Détails Lot --");
            System.Console.WriteLine("Identifiant                : {0}", lot.Identifiant);
            System.Console.WriteLine("Nom                        : {0}", lot.Nom);
            System.Console.WriteLine("Recette                    : {0}", lot.Recette.Libellé);
            System.Console.WriteLine("Quantité pièces à produire : {0}", lot.QuantitéAProduire);
            System.Console.WriteLine("Date de création           : {0}", lot.DateCréation.ToString());
            System.Console.WriteLine("Etat actuel                : {0}", lot.Etat.Libellé);
            System.Console.WriteLine("Quantité déjà Produite     : {0}", lot.QuantitéProduite);
            System.Console.WriteLine();
            if (lot.Evenements.Count > 0)
            {
                System.Console.WriteLine("  - Liste des événements associés à ce lot - ");
                foreach (Class.Evenement evenement in lot.Evenements)
                {
                    System.Console.WriteLine(" {0} : {1}", evenement.Date, evenement.Libellé);
                };
                
            }
            else
            {
                System.Console.WriteLine("aucun événement associé à ce lot");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Fonction responsable de la saisie de modification d'un lot
        /// </summary>
        /// <param name="lot"> Copie du Lot d'origine devant être modifié </param>
        /// <returns>objet Lot modifié selon les choix utilisateur</returns>
        public static Class.Lot ModifierLot(Class.Lot lot, List<Class.Recette> recettes)
        {
            AfficherDetailLot(lot);

            // variable représentant si une saisie a été annulé ou non
            bool annulation;

            // teste nom
            string stringSaisie = Interface.Utilitaire.SaisirStringOptionnel("Nom du lot", out annulation);
            if (!annulation)
            {
                lot.Nom = stringSaisie;
            }

            // teste recette 
            Class.Recette recetteSaisie = Interface.MenuRecette.SelectionnerRecetteOptionnel(out annulation, recettes);
            if (!annulation)
            {
                lot.Recette = recetteSaisie;
            }

            // teste nombre de pièces
            int enierSaisie = Interface.Utilitaire.SaisirEntierOptionnel("nombre de pièce à produire", out annulation);
            if (!annulation)
            {
                lot.QuantitéAProduire = enierSaisie;
            }

            return lot;
        }

        /// <summary>
        /// Affiche le détail du lot puis le menu propre à son état (mutable ou non)
        /// </summary>
        /// <param name="lot"> lot présenté à l'utilisateur </param>
        public static void AfficherMenu(Class.Lot lot)
        {
            AfficherDetailLot(lot);

            System.Console.WriteLine();
            if (lot.Etat.Libellé == "en attente de production")
            {

            }
                System.Console.WriteLine("1) modifier le lot");
            System.Console.WriteLine("2) Détails d'un lot");
            System.Console.WriteLine("3) Créer un nouveau lot");
            System.Console.WriteLine("4) Retour au menu principale");
        }


        /// <summary>
        /// Affiche le menu lié au détails d'un lot
        /// </summary>
        /// <param name="lot">lot concerné par l'affichage </param>
        public static void AfficherMenuDetailsLot(Class.Lot lot)
        {
            System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
            System.Console.WriteLine("");
            System.Console.WriteLine("--> Détails Lot ");
            Console.WriteLine("");
            AfficherDetailLot(lot);
            Console.WriteLine("");
            Console.WriteLine("-- Menu Détails --");
            if (BDD.BDDLot.EstMuable(lot.Identifiant))
            {
                System.Console.WriteLine("1) Modifier");
                System.Console.WriteLine("2) Supprimer");
            }
            else
            {
                System.Console.WriteLine("   Modification impossible Lot déjà commencé");
                System.Console.WriteLine("   Suppression impossible Lot déjà commencé");
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
                saisie = Utilitaire.SaisirEntier("Menu détails lot");

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
