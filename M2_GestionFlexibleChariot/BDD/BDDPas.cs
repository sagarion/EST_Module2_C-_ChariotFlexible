using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : BDDPas.cs
 * description : fonctions responsable des opérations avec la BDD pour la table Pas
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDPas
    {
        /// <summary>
        /// Créer un nouveau pas en base de donnée
        /// </summary>
        /// <param name="pas">objet correspondant au pas à créer</param>
        public static void CreatePas(Pas pas, int identifiantRecette)
        {
            try
            {
                // création des requêtes, execution de celles-ci
                string sqlRecette = $"INSERT INTO Pas (Pas_ID, Pas_index, Pas_Position, Pas_Temps, Pas_Quittance, Pas_Libelle, Recette_ID) "
                    + $"VALUES('{pas.Identifiant}','{pas.Index}','{pas.Position}', '{pas.Temps}', '{Convert.ToInt32(pas.Quittance)}', '{pas.Libellé}', {identifiantRecette}); ";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                command.ExecuteReader();

                BDD.BDDConnexion.ResetConnexion();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Mets à jour le pas en base de donnée en se basant sur l'objet placé en paramètre
        /// </summary>
        /// <param name="pas"> Objet servant de référence pour mettre à jour la base de données </param>
        public static void UpdatePas(Pas pas)
        {
            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"UPDATE Pas " +
                                    $"SET Pas_Position = '{pas.Position}', Pas_Temps = '{pas.Temps}'," +
                                    $"Pas_Quittance = '{ConvertBoolToInt(pas.Quittance)}', Pas_Libelle = '{pas.Libellé}' " +
                                    $"WHERE Pas_ID = '{pas.Identifiant}'";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


        }

        /// <summary>
        /// Supprimme le pas en base de données qui correspond à l'identifiatn placé en paramètre
        /// </summary>
        /// <param name="id"> Identifiant du pas à supprimer </param>
        public static void DeletePas(int id)
        {
            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"DELETE FROM Pas WHERE Pas_ID = {id};";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Importe les pas lié à la pas dont l'identifiant est placé en paramètre et les retourne dans un tableau
        /// </summary>
        /// <param name="id"> identifiant de la pas dont il faut importé les pas </param>
        /// <returns> Un tableau comportant les 10 pas qui forme la pas</returns>
        public static Pas[] RecetteSelectPas(int id)
        {
            Pas[] pas = new Pas[10];

            try
            {
                // création de la requête, execution de celle-ci et import des résultat dans le curseurs
                string sqlPas = $"SELECT Pas_ID,Pas_Index,Pas_Temps,Pas_Position,Pas_Libelle, Pas_Quittance FROM Pas WHERE Recette_ID='{id}' order by Pas_Index Asc";
                MySqlCommand command = new MySqlCommand(sqlPas, BDDConnexion.GetConnection());
                MySqlDataReader readerPas = command.ExecuteReader();
                int index = 0;

                // parcours le curseur jusqu'à créer le tableau complet de Pas pour la pas
                while (readerPas.Read())
                {
                    pas[index] = new Pas(int.Parse(readerPas[0].ToString()),
                        int.Parse(readerPas[1].ToString()),
                        int.Parse(readerPas[2].ToString()),
                        int.Parse(readerPas[3].ToString()),
                        readerPas[4].ToString(),
                        bool.Parse(readerPas[5].ToString()));

                    index++;
                }
                // ferme le curseur de pas
                readerPas.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return pas;
        }

        /// <summary>
        /// Convertir boolean en un nombre utilisable par la BDD
        /// </summary>
        /// <param name="boolean"> booléen à convertir</param>
        /// <returns></returns>
        private static int ConvertBoolToInt(bool boolean)
        {
            return boolean == true ? 1 : 0;
        }

        /// <summary>
        /// Renvoie le prochaine identifiant disponible
        /// </summary>
        /// <returns> entier correpsondant au prochaine identifiant disponible</returns>
        public static int GetNextIdentifiant()
        {
            
            int identifiant = 0;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlPas = $"SELECT Pas_ID FROM pas ORDER BY Pas_ID DESC LIMIT 1";
                MySqlCommand command = new MySqlCommand(sqlPas, BDDConnexion.GetConnection());
                MySqlDataReader readerPas = command.ExecuteReader();
                readerPas.Read();

                // vérifie que le nombre de lot lié à cette pas est bien 0
                identifiant = int.Parse(readerPas[0].ToString());
                // ferme le curseur de pas
                readerPas.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return identifiant + 1;
        }

        // <summary>
        /// Mets à jours les informations en base de données d'une pas par rapport à l'objet placé en paramètre
        /// </summary>
        /// <param name="pas"> L'objet Lot servant de référence pour la mise à jour </param>
        public static void DeletePas(Pas pas)
        {
            try
            {
                // mets à jour les données du pas
                string sqlLot = $"DELETE FROM `pas` WHERE Pas_ID = '{pas.Identifiant}';";
                MySqlCommand command = new MySqlCommand(sqlLot, BDDConnexion.GetConnection());
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
