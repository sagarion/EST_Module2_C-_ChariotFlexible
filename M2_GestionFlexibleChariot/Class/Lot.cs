// Auteur : Thibault Daucourt
// Projet : M2 : Gestion Chariot Flexible
// Date création : 09.09.2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Class
{
    class Lot
    {
        private int identifiant;

        private string nom;

        private DateTime dateCréation;

        private int quantitéAProduire;

        private List<Evenement> evenements;

        private Etat etat;

        private Recette recette;

        // propriété associé à l'identifiant
        public int Identifiant
        {
            get
            {
                return identifiant;
            }
        }

        // propriétée associée au nom
        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        // propriété associé à la date de création du lot
        public DateTime DateCréation
        {
            get
            {
                return dateCréation;
            }

            set
            {
                dateCréation = value;
            }
        }

        // propriété associé à la quantité de pièce à produire
        public int QuantitéAProduire
        {
            get
            {
                return quantitéAProduire;
            }
            set
            {
                quantitéAProduire = value;
            }
        }

        // propriété associé aux événements liés au lot
        public List<Evenement> Evenements
        {
            get
            {
                return evenements;
            }
            set
            {
                evenements = value;
            }
        }

        // propriété associé à l'état actuel du lot
        public Etat Etat
        {
            get
            {
                return etat;
            }
            set
            {
                etat = value;
            }
        }

        // propriété associé à la recette du lot
        public Recette Recette
        {
            get
            {
                return recette;
            }
            set
            {
                recette = value;
            }
        }


        /// <summary>
        /// constructeur pour l'import de données
        /// </summary>
        /// <param name="identifiant"> l'identifiant de gestion du lot</param>
        /// <param name="nom"> le nom du lot</param>
        /// <param name="dateCréation"> la date de création du lot</param>
        /// <param name="quantitéAProduire"> la quantité de pièce à produire</param>
        /// <param name="evenements"> la liste d'événement lié à ce lot</param>
        /// <param name="etat"> l'état actuel du lot</param>
        /// /// <param name="recette"> recette lié au lot</param>
        public Lot(int identifiant, string nom, DateTime dateCréation, int quantitéAProduire, List<Evenement> evenements, Etat etat, Recette recette)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.dateCréation = dateCréation;
            this.quantitéAProduire = quantitéAProduire;
            this.evenements = evenements;
            this.etat = etat;
            this.recette = recette;
        }

        public Lot(string nom, int quantitéAProduire, int idRecette)
        {
            this.nom = nom;
            this.quantitéAProduire = quantitéAProduire;
            this.etat = new Etat(1,"En attente");
            this.evenements = new List<Evenement>();
            this.dateCréation = DateTime.Now;
            this.recette = Data.recettes[idRecette];
        }
    }
}
