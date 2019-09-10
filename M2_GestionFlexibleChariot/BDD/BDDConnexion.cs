using MySql.Data.MySqlClient;
using System;

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDConnexion
    {
        private const string server = "localhost";
        private const string database = "testDB" ;
        private const string uid = "root" ;
        private const string pwd = "abc123" ;

        private static MySqlConnection connexion = null;

        /// <summary>
        /// Donne accès à une connection et la crée s'il n'existe pas encore
        /// </summary>
        /// <returns></returns>
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
                System.Console.WriteLine(ex.Message);
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
    }
}
