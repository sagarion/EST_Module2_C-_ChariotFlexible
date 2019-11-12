using MySql.Data.MySqlClient;
using System;

/* Titre : BDDConnexion.cs
 * description : fonctions responsable de la connexion avec la BDD
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDConnexion
    {
        /*
        // BDD local wamp server
        private const string server = "localhost";
        private const string database = "pheufab_chariot1";
        private const string uid = "root" ;
        private const string pwd = "";
        */
        
        //BDD école
        private const string server = "172.16.100.9";
        private const string database = "pheufab_chariot1";
        private const string uid = "pheufab";
        private const string pwd = "basepheufab";
        
        private static MySqlConnection connexion = null;

        /// <summary>
        /// Donne accès à une connection et la crée s'il n'existe pas encore
        /// </summary>
        /// <returns> objet connection </returns>
        public static MySqlConnection GetConnection()
        {
            if (connexion == null)
            {
                Connecter();
            }

            return connexion;
        }


        /// <summary>
        /// créer la connexion à la base de donnée selon les constante de cette classe
        /// </summary>
        public static void Connecter()
        {
            try
            {
                string connexionString = $"server={server};database={database};uid={uid};pwd={pwd};";
                connexion = new MySqlConnection(connexionString);
                connexion.Open();
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Déconnecte la connexion à la base de donnée
        /// </summary>
        public static void Deconnecter()
        {
            try
            {
                connexion.Close();
                connexion = null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ferme et rouvre la connection après un insert
        /// </summary>
        public static void ResetConnexion()
        {
            BDD.BDDConnexion.Deconnecter();
            BDD.BDDConnexion.Connecter();
        }
    }
}
