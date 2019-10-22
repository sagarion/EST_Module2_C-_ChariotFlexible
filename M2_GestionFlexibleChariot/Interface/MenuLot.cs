using M2_GestionFlexibleChariot.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Interface
{
    class MenuLot
    {

        /// <summary>
        /// Affiche la liste des lots en mémoire suivi d'options d'opération
        /// </summary>
        public static void AfficherMenu()
        {
            AfficherListe();
            System.Console.WriteLine();

            System.Console.WriteLine("1) Liste des lots");
            System.Console.WriteLine("2) Détails d'un lot");
            System.Console.WriteLine("3) Créer un nouveau lot");
            System.Console.WriteLine("4) Retour au menu principale");

        }

        /// <summary>
        /// Affiche dans la console la liste des informations des lots en mémoire (sauf événement)
        /// </summary>
        public static void AfficherListe()
        {
            System.Console.WriteLine("Liste Lots");
            System.Console.WriteLine("{0} / {1} / {2} / {3}", "Identifiant", "Nom", "QuantitéAProduire", "Etat");
            foreach (Lot lot in Data.lots)
            {
                System.Console.WriteLine("{0} / {1} / {2} / {3}", lot.Identifiant, lot.Nom, lot.QuantitéAProduire, lot.Etat.Libellé);
            }
        }

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
                    System.Console.WriteLine(" Saisissez une valeur entre 1 et 3 comme précisé dans le menu ! ");
                }
            } while (!saisieValid);

            return saisie;
        }



    }
}
