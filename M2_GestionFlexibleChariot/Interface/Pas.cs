using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : Pas.cs
 * description : fonctions d'interface associées au pas
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

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
                temps = Utilitaire.SaisirEntier("temps d'attente");

                if (temps >= 0)
                {
                    saisieCorrecte = true;
                }

            } while (!saisieCorrecte);

            return temps;
        }

        /// <summary>
        /// Fonction responsable d'une saisie de libelle d'attente pour un pas
        /// </summary>
        /// <param name="annulation"> paramètre booléen gérant l'annulation de la saisie </param>
        /// <returns> un entier correspondant au libelle d'attente en secondes </returns>
        public static int SaisirTempsOptionnel(out bool annulation)
        {
            bool saisieCorrecte = false;
            int temps = 0;

            do
            {
                temps = Utilitaire.SaisirEntierOptionnel("temps d'attente", out annulation);

                if (temps >= 0 || annulation == true)
                {
                    saisieCorrecte = true;
                }

            } while (!saisieCorrecte);

            return temps;
        }

        /// <summary>
        /// Fonction responsable d'une saisie de position pour un pas
        /// </summary>
        /// <param name="annulation"> paramètre booléen gérant l'annulation de la saisie </param>
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

        /// <summary>
        /// Fonction responsable d'une saisie de position pour un pas
        /// </summary>
        /// <returns> un entier correspondant à une des positions d'arrêt du chariot </returns>
        public static int SaisirPositionOptionnel(out bool annulation)
        {
            bool saisieCorrecte = false;
            int position = 0;

            do
            {
                position = Utilitaire.SaisirEntierOptionnel("position", out annulation);

                if (position > 0 && position < 6 || annulation)
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

        /// <summary>
        /// Affiche les informations d'un pas dans la console
        /// </summary>
        /// <param name="pas"> objet pas à présenter dans la console </param>
        public static void AfficherPas(Class.Pas pas)
        {
            Console.WriteLine("Identifiant  : {0}",pas.Identifiant);
            Console.WriteLine("Index        : {0}", pas.Index);
            Console.WriteLine("Libellé      : {0}", pas.Libellé);
            Console.WriteLine("Position     : {0}", pas.Position);
            Console.WriteLine("Temps(second): {0}", pas.Temps);
            Console.WriteLine("Quittance    : {0}", pas.Quittance == true ? "oui":"non");

        }
        
        /// <summary>
        /// Fonction responsable de la saisie d'un Pas
        /// </summary>
        /// <param name="pas"> Pas à modifier</param>
        /// <returns> le pas une fois modifié</returns>
        public static Class.Pas ModificationPas(Class.Pas pas)
        {
            AfficherPas(pas);
            int temps = SaisirTemps();
            int position = SaisirPosition();
            string libellé = Utilitaire.SaisirString("libelle");
            bool quittance = Utilitaire.SaisirBool("quittance");

            
            return pas;
        }

        /// <summary>
        /// Fonction responsable de la saisie d'un Pas
        /// </summary>
        /// <param name="pas"> Pas à modifier</param>
        /// <param name="annulation"> variable gérant l'annonce de la'nnulation de la saisie </param>
        /// <returns> le pas une fois modifié</returns>
        public static Class.Pas ModificationPasOptionnel(Class.Pas pas,bool annulation)
        {
            AfficherPas(pas);

            annulation = SauterPas();

            if(annulation != true)
            {
                bool annulationLocal = false;

                int entierTemporaire = SaisirTempsOptionnel(out annulationLocal);
                if (annulationLocal != true)
                {
                    pas.Temps = entierTemporaire;
                }
                else
                { 
                    // reset condition annulation
                    annulationLocal = false;
                }

                entierTemporaire = SaisirPositionOptionnel(out annulationLocal);
                if (annulationLocal != true)
                {
                    pas.Position = entierTemporaire;
                }
                else
                {
                    // reset condition annulation
                    annulationLocal = false;
                }

                string stringTemporaire = Utilitaire.SaisirStringOptionnel("libelle", out annulationLocal);
                if (annulationLocal != true)
                {
                    pas.Libellé = stringTemporaire;
                }
                else
                {
                    // reset condition annulation
                    annulationLocal = false;
                }

                bool booleanTemporaire = Utilitaire.SaisirBoolOptionnel("quittance", out annulationLocal);
                if (annulationLocal != true)
                {
                    pas.Quittance = booleanTemporaire;
                }
                else
                {
                    // reset condition annulation
                    annulationLocal = false;
                }
            }
            Console.WriteLine();
            return pas;
        }

        /// <summary>
        /// Fonction dédié à vérifié si un utiliseur souhaite sauter une étape 
        /// </summary>
        /// <returns> booléen correpsondant à si un pas doit être sauté ou non  </returns>
        public static bool SauterPas()
        {
            Console.WriteLine("Voulez-vous sauter ce pas ?");
            return Interface.Utilitaire.SaisirBool("Sauter ce pas");
        }

    }
}
