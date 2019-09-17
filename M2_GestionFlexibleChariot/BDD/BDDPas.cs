using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDPas
    {
        /// <summary>
        /// Créer un nouveau pas en base de donnée
        /// </summary>
        /// <param name="pas">objet correspondant au pas à créer</param>
        public static void CreatePas(Pas pas)
        {
            try
            {
                // création des requêtes, execution de celles-ci
                string sqlRecette = $"INSERT INTO Pas (Pas_index, Pas_Position, Pas_Temps, Pas_Quittance, Pas_Libelle) "
                    + $"VALUES({pas.Index},{pas.Position}, {pas.Temps}, {Convert.ToInt32(pas.Quittance)}, {pas.Libellé}); ";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                command.ExecuteReader();

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
                                    $"SET Pas_Index = {pas.Index}, Pas_Position = {pas.Position}, Pas_Temps = {pas.Temps}," +
                                    $"Pas_Quittance = {pas.Quittance}, Pas_Libelle = {pas.Libellé}" +
                                    $"WHERE Pas_ID = {pas.Identifiant}";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
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
        /// Importe les pas lié à la recette dont l'identifiant est placé en paramètre et les retourne dans un tableau
        /// </summary>
        /// <param name="id"> identifiatn de la recette dont il faut importé les pas </param>
        /// <returns> Un tableau comportant les 10 pas qui forme la recette</returns>
        public static Pas[] RecetteSelectPas(int id)
        {
            Pas[] pas = new Pas[10];

            try
            {
                // création de la requête, execution de celle-ci et import des résultat dans le curseurs
                string sqlPas = $"SELECT identifiant,index,temps, position, libellé, quittance FROM Pas WHERE Recette_identifiant='{id}'";
                MySqlCommand command = new MySqlCommand(sqlPas, BDDConnexion.GetConnection());
                MySqlDataReader readerPas = command.ExecuteReader();
                int index = 0;

                // parcours le curseur jusqu'à créer le tableau complet de Pas pour la recette
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
    }
}
