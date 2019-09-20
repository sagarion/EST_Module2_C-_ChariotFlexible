using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Class
{
    class Etat
    {
        // identifiant de gestion de l'état
        private int identifiant;

        // libellé décrivant l'état
        private string libellé;

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

        /// <summary>
        /// Constructeur pour l'import d'état
        /// </summary>
        /// <param name="identifiant"> identifiant de gestion de l'état</param>
        /// <param name="libellé"> libellé définissant l'événement </param>
        public Etat(int identifiant, string libellé)
        {
            this.identifiant = identifiant;
            this.libellé = libellé;
        }

    }
}
