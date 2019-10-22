using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.Interface
{
    class Utilitaire
    {
        // utilitaire général

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int SaisirEntier(string message)
        {
            bool saisieValid = false;
            int result;

            do
            {
                System.Console.Write("Veuillez saisire la valeur entière ({0}) : ", message);

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
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string SaisirString(string message)
        {
            bool saisieValid = false;
            string result;

            do
            {
                System.Console.Write("Veuillez saisire la valeur chaîne de charactères ({0}) : ", message);

                result = System.Console.ReadLine();

                if (result.Length > 0)
                {
                    saisieValid = true;
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
