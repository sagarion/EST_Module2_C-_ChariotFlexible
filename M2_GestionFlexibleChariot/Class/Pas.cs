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
    class Pas
    {
        /// <summary>
        /// identificateur de la base de donnée pour ce pas
        /// </summary>
        private int identifiant;

        /// <summary>
        /// numéro de pas pour la recette à laquel le pas est lié
        /// </summary>
        private int index;

        /// <summary>
        /// temps d'attente du chariot à la position
        /// </summary>
        private int temps;

        /// <summary>
        /// position à laquel le chariot doit se rendre
        /// </summary>
        private int position;

        /// <summary>
        /// libellé du pas
        /// </summary>
        private string libellé;

        /// <summary>
        /// quittance nécessaire avant de passer au pas suivant
        /// </summary>
        private bool quittance;

        // constructeur

        /// <summary>
        /// Constructeur pour créer un pas importé depuis la base de données
        /// </summary>
        /// <param name="identifiant"> identificateur de la base de donnée pour ce pas </param>
        /// <param name="index"> numéro de pas pour la recette à laquel le pas est lié </param>
        /// <param name="temps"> temps d'attente du chariot à la position </param>
        /// <param name="position"> position à laquel le chariot doit se rendre </param>
        /// <param name="libellé"> libellé du pas </param>
        /// <param name="quittance"> quittance nécessaire avant de passer au pas suivant </param>
        public Pas(int identifiant, int index, int temps, int position, string libellé, bool quittance)
        {
            this.identifiant = identifiant;
            this.index = index;
            this.temps = temps;
            this.position = position;
            this.libellé = libellé;
            this.quittance = quittance;
        }

        /// <summary>
        /// Constructeur pour créer un nouveau pas depuis l'application
        /// </summary>
        /// <param name="index"> numéro de pas pour la recette à laquel le pas est lié </param>
        /// <param name="temps"> temps d'attente du chariot à la position </param>
        /// <param name="position"> position à laquel le chariot doit se rendre </param>
        /// <param name="libellé"> libellé du pas </param>
        /// <param name="quittance"> quittance nécessaire avant de passer au pas suivant </param>
        public Pas(int index, int temps, int position, string libellé, bool quittance)
        {
            this.index = index;
            this.temps = temps;
            this.position = position;
            this.libellé = libellé;
            this.quittance = quittance;
        }


        // Getter / Setter
        public int GetIdentifiant()
        {
            return identifiant;
        }

        public int GetIndex()
        {
            return index;
        }

        public void SetIndex(int index)
        {
            this.index = index;
        }

        public int GetTemps()
        {
            return temps;
        }

        public void SetTemps(int temps)
        {
            this.temps = temps;
        }

        public int GetPosition()
        {
            return position;
        }

        public void SetPosition(int position)
        {
            this.position = position;
        }

        public string GetLibellé()
        {
            return libellé;
        }

        public void SetLibellé(string libellé)
        {
            this.libellé = libellé;
        }

        public bool GetQuittance()
        {
            return quittance;
        }

        public void SetQuittance(bool quittance)
        {
            this.quittance = quittance;
        }
    }
}
