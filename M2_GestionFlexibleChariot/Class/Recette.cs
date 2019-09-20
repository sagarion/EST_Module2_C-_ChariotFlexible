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
    class Recette
    {
        /// <summary>
        /// Identifiant en abse de donnée associé à cette recette
        /// </summary>
        private int identifiant;
        /// <summary>
        /// Libellé associé à cette recette
        /// </summary>
        private string libellé;
        /// <summary>
        /// Tableau regroupant les pas d'une recette
        /// </summary>
        private Pas[] pas;
        /// <summary>
        /// Date de création de la recette
        /// </summary>
        private DateTime dateCréation;
        // Constructeur

        /// <summary>
        /// contructeur pour un recette importé depuis la base de données
        /// </summary>
        /// <param name="identifiant"> identifiant de gestion de la base de données</param>
        /// <param name="libellé"> libellé décrivant la recette </param>
        /// <param name="pas"> tableau stockant les pas(opération) de la recette </param>
        /// <param name="dateCréation"> date de la création de la recette </param>
        public Recette(int identifiant, string libellé, Pas[] pas, DateTime dateCréation)
        {
            this.identifiant = identifiant;
            this.libellé = libellé;
            pas = pas;
            this.dateCréation = dateCréation;
        }

        /// <summary>
        /// constructeur pour une nouvelle recette
        /// </summary>
        /// <param name="libellé"> libellé décrivant la recette </param>
        public Recette(string libellé)
        {
            this.libellé = libellé;
            pas = new Pas[10];

            for (int i = 0; i < 10; i++)
            {
                pas[i] = new Pas(i + 1, 0, 0, "new", false);
            }
            this.dateCréation = DateTime.Now;
        }

        // Getter / Setter

        /// <summary>
        /// Modifie le pas à l'index donnée avec les information fournis
        /// </summary>
        /// <param name="pas"></param>
        /// <param name="index"></param>
        public void UpdateUnPas(Pas pas, int index)
        {
            this.pas[index] = pas;
        }

        /// <summary>
        /// Propriété gérant l'identifiant en abse de donnée associé à cette recette
        /// </summary>
        public int Identifiant
        {
            get
            {
                return identifiant;
            }

        }

        /// <summary>
        /// Propriété gérant le libellé associé à cette recette
        /// </summary>
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

        /// <summary>
        /// Propriété gérant le tableau regroupant les pas d'une recette
        /// </summary>
        public Pas[] Pas
        {
            get
            {
                return pas;
            }
            set
            {
                pas = value;
            }
        }

        /// <summary>
        /// Propriété gérant la date de création de la recette
        /// </summary>
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
    }
}
