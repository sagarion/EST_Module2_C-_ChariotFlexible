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


        /// <summary>
        /// constructeur pour l'import de données
        /// </summary>
        /// <param name="identifiant"> l'identifiant de gestion du lot</param>
        /// <param name="nom"> le nom du lot</param>
        /// <param name="dateCréation"> la date de création du lot</param>
        /// <param name="quantitéAProduire"> la quantité de pièce à produire</param>
        /// <param name="evenements"> la liste d'événement lié à ce lot</param>
        /// <param name="etat"> l'état actuel du lot</param>
        public Lot(int identifiant, string nom, DateTime dateCréation, int quantitéAProduire, List<Evenement> evenements, Etat etat)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.dateCréation = dateCréation;
            this.quantitéAProduire = quantitéAProduire;
            this.evenements = evenements;
            this.etat = etat;
        }

        public Lot(string nom, int quantitéAProduire, Etat etat)
        {
            this.nom = nom;
            this.quantitéAProduire = quantitéAProduire;
            this.etat = etat;
            this.evenements = new List<Evenement>();
            dateCréation = DateTime.Now;
        }
    }
}
