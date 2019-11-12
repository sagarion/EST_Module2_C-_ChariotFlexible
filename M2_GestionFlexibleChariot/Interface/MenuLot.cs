using M2_GestionFlexibleChariot.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : MenuLot.cs
 * description : fonctions d'interface associées au menu de gestion des lots
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.Interface
{
    class MenuLot
    {

        /// <summary>
        /// Affiche la liste des lots en mémoire suivi d'options d'opération
        /// </summary>
        public static void AfficherMenu()
        {
            Console.WriteLine("--> Menu des lots ");
            System.Console.WriteLine("1) Liste des lots");
            System.Console.WriteLine("2) Détails d'un lot");
            System.Console.WriteLine("3) Créer un nouveau lot");
            System.Console.WriteLine("4) Retour au menu principale");
            Console.WriteLine();

        }

        /// <summary>
        /// Fonction responable pour de la saisie au niveau du menu des lots
        /// </summary>
        /// <returns> un entier correspondant au scénario choisi par l'utilisateur </returns>
        public static int SaisieMenu()
        {
            bool saisieValid = false;
            int saisie;

            do
            {
                saisie = Utilitaire.SaisirEntier("Menu Lot");

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
        /// Affiche dans la console la liste des informations des lots en mémoire (sauf événement)
        /// </summary>
        public static void AfficherListeLots()
        {
            System.Console.WriteLine("-- Liste Lots --");
            System.Console.WriteLine(String.Format("{0,-11} | {1,-30} | {2,-20} | {3,-25} | {4,10}",
                "Identifiant", "Nom", "Quantitée A Produire", "Etat", "Quantitée déjà Produite"));
            foreach (Class.Lot lot in BDD.BDDLot.GetLots())
            {
                System.Console.WriteLine(String.Format("{0,-11} | {1,-30} | {2,-20} | {3,-25} | {4,10}",
                    lot.Identifiant, lot.Nom, lot.QuantitéAProduire, lot.Etat.Libellé, lot.QuantitéProduite));
            }
        }

        /// <summary>
        /// Fonction permettant à l'utilisateur de sélectionner un lot
        /// </summary>
        /// <returns>un objet Class.Lot qui correspond à l'identifiant saisit par utilisateur</returns>
        public static Class.Lot SelectionnerLot()
        {
            // affiche la listes des lots disponibles
            AfficherListeLots();
            Console.WriteLine();
            bool saisieValide = false;
            int identifiant = 0;
            do
            {
                identifiant = Utilitaire.SaisirEntier("Identifiant du lot");

                // A MODIFIER
                if (BDD.BDDLot.EstIdentifiantValide(identifiant))
                {
                    saisieValide = true;
                }
                else
                {
                    System.Console.WriteLine("Veuillez saisir identifiant correct d'un Lot");
                }
            } while (!saisieValide);

            return BDD.BDDLot.GetLot(identifiant);
        }

    }
}
