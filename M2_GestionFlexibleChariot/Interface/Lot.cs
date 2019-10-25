using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Interface
{
    class Lot
    {
        /// <summary>
        /// Fonction responsable de la création d'un lot
        /// </summary>
        /// <returns> Un objet Class.Lot correspondant au résultat des saisies de l'utilisateur </returns>
        public static Class.Lot SaisirCréation()
        {

            string nom = Utilitaire.SaisirString("Nom du lot");
            int quantiteAProduire = SaisirQuantite();
            int idRecette = MenuRecette.SelectionnerRecette().Identifiant;

            return new Class.Lot(nom, quantiteAProduire, idRecette);
        }

        /// <summary>
        /// Fonction responabel de la saisie d'une quantité de pièce(s) attribuée(s) à un lot
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void AfficherDetailLot(Class.Lot lot)
        {
            System.Console.WriteLine(" -- Détails Lot  -- ");
            System.Console.WriteLine("Identifiant      : {0}", lot.Identifiant);
            System.Console.WriteLine("Nom              : {0}", lot.Nom);
            System.Console.WriteLine("Recette          : {0}", lot.Recette.Libellé);
            System.Console.WriteLine("Quantité pièces  : {0}", lot.QuantitéAProduire);
            System.Console.WriteLine("Date de création : {0}", lot.DateCréation.ToShortDateString());
            System.Console.WriteLine("Etat actuel      : {0}", lot.Etat.Libellé);
            System.Console.WriteLine();
            if (lot.Evenements.Count > 0)
            {
                System.Console.WriteLine("  - Liste des événements associés à ce lot - ");
                foreach (Class.Evenement evenement in lot.Evenements)
                {
                    System.Console.WriteLine("{0} : {1}", evenement.Date.ToShortTimeString(), evenement.Libellé);
                };
            }
            else
            {
                System.Console.WriteLine("aucun événement associé à ce lot");
            }

        }
    }
}
