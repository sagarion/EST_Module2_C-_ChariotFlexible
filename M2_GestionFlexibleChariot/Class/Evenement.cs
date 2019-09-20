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
    class Evenement
    {
        // identifiant de gestion de l'événement
        private int identifiant;
        // libellé décrivant l'événement
        private string libellé;
        // date d'occurence de l'évenement
        private DateTime date;

        // propriété associé à l'identifiant
        public int Identifiant
        {
            get
            {
                return identifiant;
            }
        }

        // propriétée associée au libellé
        public string Libellé
        {
            get
            {
                return libellé;
            }

            set
            {
                libellé = value;
            }
        }

        // propriété associé à la date de l'événement
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        /// <summary>
        /// constructeur pour l'import d'événement depuis la base de données
        /// </summary>
        /// <param name="identifiant"> identifiant de gestion de l'événement </param>
        /// <param name="libellé"> libellé décrivant l'événement </param>
        /// <param name="date"> date d'ocurence de l'événement </param>
        public Evenement(int identifiant, string libellé, DateTime date)
        {
            this.identifiant = identifiant;
            this.libellé = libellé;
            this.date = date;
        }
    }
}
