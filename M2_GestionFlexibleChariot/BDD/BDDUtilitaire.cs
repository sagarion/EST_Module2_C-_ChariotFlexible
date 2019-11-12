using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : BDDUtilitaire.cs
 * description : fonction utilitaire pour la communication avec la BDD
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDUtilitaire
    {
        /// <summary>
        /// Converti une datetime dans un format utilisable en BDD
        /// </summary>
        /// <param name="date"> date à convertir</param>
        /// <returns> version string de la date </returns>
        public static string ConvertDateTimeToString(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour + ":" + date.Minute + ":" + date.Second;
        }
    }
}
