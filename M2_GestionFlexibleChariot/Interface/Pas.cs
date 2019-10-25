using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Interface
{
    class Pas
    {
        /// <summary>
        /// Fonction responsable de la saisie d'un Pas
        /// </summary>
        /// <param name="index"> entier correspondant à l'index du Pas saisie</param>
        /// <returns></returns>
        public static Class.Pas SaisirCréation(int index)
        {
            Utilitaire.SaisirString("");

            int temps = SaisirTemps();
            int position = SaisirPosition();
            string libellé = Utilitaire.SaisirString("libelle");
            bool quittance = Utilitaire.SaisirBool("quittance");


            return new Class.Pas(index, temps, position, libellé, quittance);
        }

        /// <summary>
        /// Fonction responsable d'une saisie de libelle d'attente pour un pas
        /// </summary>
        /// <returns> un entier correspondant au libelle d'attente en secondes </returns>
        public static int SaisirTemps()
        {
            bool saisieCorrecte = false;
            int temps = 0;

            do
            {
                temps = Utilitaire.SaisirEntier("libelle d'attente");

                if (temps >= 0)
                {
                    saisieCorrecte = true;
                }

            } while (!saisieCorrecte);

            return temps;
        }

        /// <summary>
        /// Fonction responsable d'une saisie de position pour un pas
        /// </summary>
        /// <returns> un entier correspondant à une des positions d'arrêt du chariot </returns>
        public static int SaisirPosition()
        {
            bool saisieCorrecte = false;
            int position = 0;

            do
            {
                position = Utilitaire.SaisirEntier("position");

                if (position > 0 && position < 6)
                {
                    saisieCorrecte = true;
                }
                else
                {
                    System.Console.WriteLine("Positions de 1 à 5 autorisées");
                }

            } while (!saisieCorrecte);

            return position;
        }

    }
}
