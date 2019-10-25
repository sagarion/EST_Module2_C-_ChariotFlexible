using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Interface
{
    class Recette
    {
        public static Class.Recette SaisirCréation()
        {
            Class.Recette recette = new Class.Recette(Utilitaire.SaisirString("libellé recette"));

            for (int i = 1; i <= 10; i++)
            {
                recette.Pas[i] = Pas.SaisirCréation(i);
            }

            return recette;
        }
    }
}
