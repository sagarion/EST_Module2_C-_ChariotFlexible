using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : BDDRecette.cs
 * description : fonctions responsable des opérations avec la BDD pour la table Recette
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDRecette
    {
        /// <summary>
        /// fonction créant une recette dans la base de donnée à partir 'dun objet métier recette
        /// </summary>
        /// <param name="recette"> objet métier recette servant de référence à la création</param>
        public static void CreateRecette(Recette recette)
        {
            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"INSERT INTO Recette (Recette_ID, Recette_libelle, Recette_DateCrea)" +
                                    $"VALUES('{recette.Identifiant}', '{recette.Libellé}', '{BDDUtilitaire.ConvertDateTimeToString(recette.DateCréation)}'); ";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                command.ExecuteNonQuery();

                BDD.BDDConnexion.ResetConnexion();

                foreach (Pas pas in recette.Pas)
                {
                    pas.Identifiant = BDDPas.GetNextIdentifiant();
                    BDD.BDDPas.CreatePas(pas, recette.Identifiant);
                }
               
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Importe les données d'une recette depuis la base de donnée et créer un objet correspondant
        /// </summary>
        /// <param name="identifiant"> identifiant de la recette à importer et créer </param>
        /// <returns> un objet Recette équivalent à la recette en base de données correspondant à l'identifant fourni</returns>
        public static Recette GetRecette(int identifiant)
        {
            Recette recette = null;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"SELECT Recette_ID,Recette_Libelle, Recette_DateCrea FROM Recette WHERE Recette_ID='{identifiant}'";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();

                readerRecette.Read();

                // une fois le tableau de pas créé, créer l'objet recette
                recette = new Recette(int.Parse(readerRecette[0].ToString()),
                                                 readerRecette[1].ToString(),
                                                null,
                                                DateTime.Parse(readerRecette[2].ToString())
                                                );
                // ferme le curseur de recette
                readerRecette.Close();

                // importe les pas liés à la recette

                recette.Pas = BDDPas.RecetteSelectPas(recette.Identifiant);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return recette;
        }

        /// <summary>
        /// Importe les données d'une recette depuis la base de donnée et créer un objet correspondant
        /// </summary>
        /// <param name="identifiant"> identifiant de la recette à importer et créer </param>
        /// <returns> un objet Recette équivalent à la recette en base de données correspondant à l'identifant fourni</returns>
        public static Recette GetRecetteFromLot(int identifiantLot)
        {
            Recette recette = null;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"SELECT recette.Recette_ID,recette.Recette_Libelle, recette.Recette_DateCrea FROM Recette Join recette ON recette.Recette_ID = recette.Recette_ID WHERE recette.Lot_ID='{identifiantLot}'";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();

                readerRecette.Read();

                // une fois le tableau de pas créé, créer l'objet recette
                recette = new Recette(int.Parse(readerRecette[0].ToString()),
                                                 readerRecette[1].ToString(),
                                                null,
                                                DateTime.Parse(readerRecette[2].ToString())
                                                );
                // ferme le curseur de recette
                readerRecette.Close();

                // importe les pas liés à la recette

                recette.Pas = BDDPas.RecetteSelectPas(recette.Identifiant);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return recette;
        }

        /// <summary>
        /// Importe les données d'une recette depuis la base de donnée et créer un objet correspondant
        /// </summary>
        /// <param name="identifiant"> identifiant de la recette à importer et créer </param>
        /// <returns> un objet Recette équivalent à la recette en base de données correspondant à l'identifant fourni</returns>
        public static List<Class.Recette> GetRecettes()
        {

            List<Class.Recette> recettes = new List<Recette>();
            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"SELECT Recette_ID,Recette_Libelle, Recette_DateCrea FROM Recette";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();

                while (readerRecette.Read())
                {
                    // créer une recette et l'ajoute à la liste
                    recettes.Add(new Recette(int.Parse(readerRecette[0].ToString()),
                                                 readerRecette[1].ToString(),
                                                null,
                                                DateTime.Parse(readerRecette[2].ToString())
                                                ));
                }

                // ferme le curseur de recette
                readerRecette.Close();

                foreach (Class.Recette recette in recettes)
                {
                    recette.Pas = BDDPas.RecetteSelectPas(recette.Identifiant);
                }
                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return recettes;
        }


        /// <summary>
        /// Mets à jours les informations en base de données d'une recette par rapport à l'objet placé en paramètre
        /// </summary>
        /// <param name="recette"> L'objet recette servant de référence pour la mise à jour </param>
        public static void UpdateRecette(Recette recette)
        {
            try
            {
                // mets à jour les données de la recette
                string sqlRecette = $"UPDATE Recette " +
                                    $"SET Recette_Libelle = '{recette.Libellé}' " +
                                    $"WHERE Recette_ID = '{recette.Identifiant}';";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                command.ExecuteNonQuery();

                // met à jour les données de chaque pas de la recette
                foreach (Pas pas in recette.Pas)
                {
                    BDDPas.UpdatePas(pas);
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Détermine si la recette est "muable" (modifiable/supprimable) en vérifiant si un recette y est associé
        /// </summary>
        /// <param name="identifiant"> identifiant de gestion de la recette à vérifier</param>
        /// <returns> un booléen décrivant si la recette est muable</returns>
        public static bool EstMuable(int identifiant)
        {
            // par défaut est non-muable
            bool muable = false;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"SELECT count(*) FROM Lot WHERE Recette_ID = {identifiant}";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();
                readerRecette.Read();

                // vérifie que le nombre de recette lié à cette recette est bien 0
                muable = int.Parse(readerRecette[0].ToString()) == 0;
                // ferme le curseur de recette
                readerRecette.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return muable;
        }

        /// <summary>
        /// Détermine si l'identifiant correpsonda à une recette valide
        /// </summary>
        /// <param name="identifiant"> identifiant à vérifier</param>
        /// <returns> un booléen décrivant si l'identifiant correspond bien à une recette</returns>
        public static bool EstIdentifiantValide(int identifiant)
        {
            // par défaut est non-muable
            bool valide = false;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"SELECT count(*) FROM Recette WHERE Recette_ID = {identifiant}";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();
                readerRecette.Read();

                // vérifie que le nombre de recette lié à cette recette est bien 0
                valide = int.Parse(readerRecette[0].ToString()) != 0;
                // ferme le curseur de recette
                readerRecette.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return valide;
        }

        /// <summary>
        /// Détermine si la recette est "muable" (modifiable/supprimable) en vérifiant si un recette y est associé
        /// </summary>
        /// <param name="identifiant"> identifiant de gestion de la recette à vérifier</param>
        /// <returns> un booléen décrivant si la recette est muable</returns>
        public static int GetNextIdentifiant()
        {
            // par défaut est non-muable
            int identifiant = 0;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"SELECT Recette_ID FROM recette ORDER BY Recette_ID DESC LIMIT 1";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();
                readerRecette.Read();

                // vérifie que le nombre de recette lié à cette recette est bien 0
                identifiant = int.Parse(readerRecette[0].ToString());
                // ferme le curseur de recette
                readerRecette.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return identifiant + 1;
        }

        // <summary>
        /// Mets à jours les informations en base de données d'une recette par rapport à l'objet placé en paramètre
        /// </summary>
        /// <param name="recette"> L'objet Lot servant de référence pour la mise à jour </param>
        public static void DeleteRecette(Recette recette)
        {
            try
            {
                foreach (Pas pas in recette.Pas)
                {
                    BDD.BDDPas.DeletePas(pas);
                }

                // mets à jour les données du recette
                string sqlLot = $"DELETE FROM `recette` WHERE Recette_ID = '{recette.Identifiant}';";
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
