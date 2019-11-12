using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : Utilitaire.cs
 * description : fonctions d'interface d'utilitées général
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/


namespace M2_GestionFlexibleChariot.Interface
{
    class Utilitaire
    {
        // utilitaire général

        /// <summary>
        /// Fonction demandant à l'utilisateur de saisir un nombre entier
        /// </summary>
        /// <param name="message"> message explicatif de la nature du nombre à saisir </param>
        /// <returns> nombre entier saisie par l'utilisateur</returns>
        public static int SaisirEntier(string message)
        {
            bool saisieValid = false;
            int result;

            do
            {
                System.Console.Write("Veuillez saisir la valeur entière ({0}) : ", message);

                // si la conversion est réussie
                if (int.TryParse(System.Console.ReadLine(), out result))
                {
                    saisieValid = true;
                }
                else
                {
                    System.Console.WriteLine("Veuillez saisir un nombre entier !");
                }

            } while (!saisieValid);

            return result;
        }

        /// <summary>
        /// Fonction demandant à l'utilisateur de saisir un nombre ou rien pour annuler la sélection
        /// </summary>
        /// <param name="message"> message explicatif de la nature du nombre à saisir </param>
        /// <param name="annulation"> paramètre décrivant si la saisie est arrivée à son terme ou a été annulée </param>
        /// <returns> nombre entier saisie par l'utilisateur si saisie par annulé</returns>
        public static int SaisirEntierOptionnel(string message,out bool annulation)
        {
            bool saisieValid = false;
            int result;
            string saisie;

            do
            {
                System.Console.Write("Veuillez saisir la valeur entière ({0}) ou rien pour garder la valeur existante : ", message);
                saisie = System.Console.ReadLine();
                annulation = false;

                // si l'utilisateur en souhaite pas remplir cette information
                if (saisie == "") {
                    annulation = true;
                    // -1 est une valeur incohérente dans ce projet
                    result = -1;
                    saisieValid = true;
                }// si la conversion est réussie
                else if (int.TryParse(saisie, out result))
                {
                    saisieValid = true;
                }
                else
                {
                    System.Console.WriteLine("Veuillez saisir un nombre entier !");
                }

            } while (!saisieValid);

            return result;
        }

        /// <summary>
        /// Fonction demandant à l'utilisateur de saisir une chaîn de charactère 
        /// </summary>
        /// <param name="message"> message détaillant la nature de la chaîne de charactère saisie </param>
        /// <returns>chaîne de charactère correspondant à la saisie de l'utilisateur</returns>
        public static string SaisirString(string message)
        {
            bool saisieValid = false;
            string result;

            do
            {
                System.Console.Write("Veuillez saisir la valeur chaîne de charactères ({0}) : ", message);

                result = System.Console.ReadLine();

                if (result.Length > 0)
                {
                    saisieValid = true;
                }
                else if (result.Length > 50)
                {
                    Console.WriteLine("Erreur saisie trop grande pour le champs");
                }
                else
                {
                    Console.WriteLine("Erreur saisie vide ");
                }

            } while (!saisieValid);

            return result;
        }

        /// <summary>
        /// Fonction demandant à l'utilisateur de saisir une chaîn de charactère ou rien pour annuler la saisie
        /// </summary>
        /// <param name="message"> message détaillant la nature de la chaîne de charactère saisie </param>
        /// <param name="annulation"> paramètre décrivant si la saisie est arrivée à son terme ou a été annulée </param>
        /// <returns> chaîne de charactère correspondant à la saisie de l'utilisateur</returns>
        public static string SaisirStringOptionnel(string message, out bool annulation)
        {
            bool saisieValid = false;
            string result;
            annulation = false;

            do
            {
                System.Console.Write("Veuillez saisir la valeur chaîne de charactères ou rien pour annuler la saisie ({0}) : ", message);

                result = System.Console.ReadLine();

                if (result == "")
                {
                    annulation = true;
                    saisieValid = true;
                }
                else if(result.Length > 0)
                {
                    saisieValid = true;
                    annulation = false; ;
                }
                else if (result.Length > 50)
                {
                    Console.WriteLine("Erreur saisie trop grande pour le champs");
                }
                else
                {
                    Console.WriteLine("Erreur saisie vide ");
                }

            } while (!saisieValid);

            return result;
        }

        /// <summary>
        /// Fonction gérant la saisie d'un booléen
        /// </summary>
        /// <param name="message"> Message explicitant le rôle du booléen entrée </param>
        /// <returns>le booléen correspondant à la saisie de l'utilisateur </returns>
        public static bool SaisirBool(string message)
        {
            bool saisieValid = false;
            string saisie;
            bool result = false;

            do
            {
                System.Console.Write("Veuillez saisir o(oui)/n(non) ({0}) : ", message);

                saisie = System.Console.ReadLine().ToUpper();

                if (saisie == "O")
                {
                    saisieValid = true;
                    result = true;
                }else if(saisie == "N")
                {
                    saisieValid = true;
                    result = false; ;
                }
                else
                {
                    System.Console.WriteLine("Veuillez entrer une valeur correcte o (pour oui) / n (pour non)");
                    System.Console.WriteLine();
                }

            } while (!saisieValid);

            return result;
        }

        /// <summary>
        /// Fonction gérant la saisie d'un booléen
        /// </summary>
        /// <param name="message"> Message explicitant le rôle du booléen entrée </param>
        /// <param name="annulation">booléean explicitant si la saisie a été annulée</param>
        /// <returns>le booléen correspondant à la saisie de l'utilisateur </returns>
        public static bool SaisirBoolOptionnel(string message, out bool annulation)
        {
            bool saisieValid = false;
            string saisie;
            bool result = false;

            do
            {
                System.Console.Write("Veuillez saisir o(oui)/n(non) ou rien pour annuler la saisie ({0}) : ", message);

                saisie = System.Console.ReadLine().ToUpper();
                annulation = false;

                if (saisie == "O")
                {
                    saisieValid = true;
                    result = true;
                }
                else if (saisie == "N")
                {
                    saisieValid = true;
                    result = false; ;
                } else if(saisie == ""){
                    saisieValid = true;
                    annulation = true;
                    result = false;
                }
                else
                {
                    System.Console.WriteLine("Veuillez entrer une valeur correcte o (pour oui) / n (pour non)");
                    System.Console.WriteLine();
                }

            } while (!saisieValid);

            return result;
        }

        /// <summary>
        /// Efface la console
        /// </summary>
        public static void NettoyerConsole()
        {
            System.Console.Clear();
        }

        /// <summary>
        /// attent une saise utilisateur avant de poursuivre
        /// </summary>
        public static void Attendre()
        {
            System.Console.Write("Appuyer sur une touche pour continuer ...");
            System.Console.ReadKey();
        }
    }
}
