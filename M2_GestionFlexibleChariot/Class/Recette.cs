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
        private int identifiant { get; }
        private string libellé { get; set; }
        private Pas[] Pas{ get; }
        private DateTime dateCréation { get; set; }

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
            Pas = pas;
            this.dateCréation = dateCréation;
        }

        /// <summary>
        /// constructeur pour une nouvelle recette
        /// </summary>
        /// <param name="libellé"> libellé décrivant la recette </param>
        public Recette(string libellé)
        {
            this.libellé = libellé;
            Pas = new Pas[10];

            for (int i = 0; i < 10; i++)
            {
                Pas[i] = new Pas(i + 1, 0, 0, "new", false);
            }
            this.dateCréation = DateTime.Now;
        }

        // Getter / Setter

        /// <summary>
        /// modifie le pas à l'index donnée avec les information fournis
        /// </summary>
        /// <param name="pas"></param>
        /// <param name="index"></param>
        public void SetPas(Pas pas, int index)
        {
            this.Pas[index] = pas;
        }

    }
}
