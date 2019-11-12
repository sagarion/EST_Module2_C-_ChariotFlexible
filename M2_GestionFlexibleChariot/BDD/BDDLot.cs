using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : BDDLot.cs
 * description : fonctions responsable des opérations avec la BDD pour la table Lot
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDLot
    {
        /// <summary>
        /// Créer un nouveau lot en base de données sur la base de l'objet lot placé en paramètre
        /// </summary>
        /// <param name="lot"> l'objet lot servant de référance pour l'insertion en base de données </param>
        public static void CreateLot(Lot lot)
        {
            lot.Identifiant = GetNextIdentifiant();

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"INSERT INTO Lot (Lot_ID, Lot_Nom, Lot_DateCreation,Lot_QtePceAproduire,Etat_ID,Recette_ID)" +
                                    $"VALUES( '{lot.Identifiant}', " +
                                    $"'{lot.Nom}', " +
                                    $"'{BDD.BDDUtilitaire.ConvertDateTimeToString(DateTime.Now)}'," +
                                    $"'{lot.QuantitéAProduire}'," +
                                    $"'{lot.Etat.Identifiant}', " +
                                    $"'{lot.Recette.Identifiant}'); ";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        
        public static Lot GetLot(int identifiant)
        {
            Lot lot = null;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlLot = $"SELECT Lot_ID, Lot_Nom, Lot_DateCreation, Lot_QtePceAproduire, Etat_ID, Recette_ID, Lot_QtePceProduite FROM Lot WHERE Lot_ID='{identifiant}'";
                MySqlCommand command = new MySqlCommand(sqlLot, BDDConnexion.GetConnection());
                MySqlDataReader readerLot = command.ExecuteReader();

                readerLot.Read();

                int identifiantLot = int.Parse(readerLot[0].ToString());
                string nomLot = readerLot[1].ToString();
                DateTime dateCreation = DateTime.Parse(readerLot[2].ToString());
                int quantite = int.Parse(readerLot[3].ToString());
                int identifiantEtat = int.Parse(readerLot[4].ToString());
                int identifiantRecette = int.Parse(readerLot[5].ToString());
                int quantiteProduite = int.Parse(readerLot[6].ToString());

                // ferme le curseur de lot
                readerLot.Close();

                // importe les evenement liés au lot
                List<Evenement> evenements = BDDEvenement.LotSelectEvenements(identifiantLot);

                // importe l'état lié au lot
                Etat etat = BDDEtat.GetEtat(identifiantEtat);

                // importe l'état lié au lot
                Recette recette = BDDRecette.GetRecette(identifiantRecette);

                // une fois le tableau de pas créé, créer l'objet lot
                // créer l'objet Etat du lot selon la requette de sélection du lot
                lot = new Lot(identifiantLot,
                              nomLot,
                              dateCreation,
                              quantite,
                              evenements,
                              etat,
                              recette,
                              quantiteProduite);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return lot;
        }

        /// <summary>
        /// Fonction important tous les lots en base de données et créer des objets métiers locaux correspondant
        /// </summary>
        /// <returns> une liste d'obet Lot correspondant à ceux enregistrés dans la base de données </returns>
        public static List<Lot> GetLots()
        {

            List<Lot> lots = new List<Lot>();

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlLot = $"SELECT Lot_ID, Lot_Nom, Lot_DateCreation, Lot_QtePceAproduire, Etat_ID, Recette_ID, Lot_QtePceProduite FROM Lot";
                MySqlCommand command = new MySqlCommand(sqlLot, BDDConnexion.GetConnection());
                MySqlDataReader readerLot = command.ExecuteReader();
                
                //import imparfait des lots
                while (readerLot.Read()){

                    int identifiantLot = int.Parse(readerLot[0].ToString());
                    string nomLot = readerLot[1].ToString();
                    DateTime dateCreation = DateTime.Parse(readerLot[2].ToString());
                    int quantite = int.Parse(readerLot[3].ToString());
                    int identifiantEtat = int.Parse(readerLot[4].ToString());
                    int identifiantRecette = int.Parse(readerLot[5].ToString());

                    // une fois le tableau de pas créé, créer l'objet lot
                    // créer l'objet Etat du lot selon la requette de sélection du lot
                    lots.Add(new Lot(identifiantLot,
                                  nomLot,
                                  dateCreation,
                                  quantite,
                                  null,
                                  null,
                                  null,
                                  int.Parse(readerLot[6].ToString())));

                };
                // ferme le curseur de lot
                readerLot.Close();

                // complétion des lots
                foreach (Lot item in lots)
                {
                    // importe les evenement liés au lot
                    item.Evenements = BDDEvenement.LotSelectEvenements(item.Identifiant);

                    // importe l'état lié au lot
                    item.Etat = BDDEtat.GetEtatFromLot(item.Identifiant);

                    // importe la recette lié au lot
                    item.Recette = BDDRecette.GetRecetteFromLot(item.Identifiant);
                }

                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return lots;
        }

        /// <summary>
        /// Mets à jours les informations en base de données d'un lot par rapport à l'objet placé en paramètre
        /// </summary>
        /// <param name="recette"> L'objet Lot servant de référence pour la mise à jour </param>
        public static void UpdateLot(Lot lot)
        {
            try
            {
                // mets à jour les données du lot
                string sqlLot = $"UPDATE Lot " +
                                    $"SET Lot_Nom = '{lot.Nom}', " +
                                    $"Lot_QtePceAproduire = '{lot.QuantitéAProduire}', " +
                                    $"Recette_ID = '{lot.Recette.Identifiant}' " +
                                    $"WHERE Lot_ID = '{lot.Identifiant}';";
                MySqlCommand command = new MySqlCommand(sqlLot, BDDConnexion.GetConnection());
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        // <summary>
        /// Mets à jours les informations en base de données d'un lot par rapport à l'objet placé en paramètre
        /// </summary>
        /// <param name="recette"> L'objet Lot servant de référence pour la mise à jour </param>
        public static void DeleteLot(Lot lot)
        {
            try
            {
                // mets à jour les données du lot
                string sqlLot = $"DELETE FROM `lot` WHERE Lot_ID = '{lot.Identifiant}';";
                MySqlCommand command = new MySqlCommand(sqlLot, BDDConnexion.GetConnection());
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Renvoie le prochaine identifiant disponible
        /// </summary>
        /// <returns> un booléen décrivant si la recette est muable</returns>
        public static int GetNextIdentifiant()
        {
            // par défaut est non-muable
            int identifiant = 0;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlLot = $"SELECT Lot_ID FROM lot ORDER BY Lot_ID DESC LIMIT 1";
                MySqlCommand command = new MySqlCommand(sqlLot, BDDConnexion.GetConnection());
                MySqlDataReader readerLot = command.ExecuteReader();
                readerLot.Read();

                // vérifie que le nombre de lot lié à cette recette est bien 0
                identifiant = int.Parse(readerLot[0].ToString());
                // ferme le curseur de recette
                readerLot.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return identifiant + 1;
        }

        /// <summary>
        /// Détermine si la recette est "muable" (modifiable/supprimable) en vérifiant si un lot y est associé
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
                string sqlRecette = $"SELECT Etat_ID FROM Lot WHERE Lot_ID = '{identifiant}'";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();
                readerRecette.Read();

                // vérifie que le nombre de lot lié à cette recette est bien 0
                muable = int.Parse(readerRecette[0].ToString()) == 1;
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
        /// Détermine si l'identifiant correpsonda à un lot valide
        /// </summary>
        /// <param name="identifiant"> identifiant à vérifier</param>
        /// <returns> un booléen décrivant si l'identifiant correspond bien à un lot</returns>
        public static bool EstIdentifiantValide(int identifiant)
        {
            // par défaut est invalide
            bool valide = false;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlLot = $"SELECT count(*) FROM lot WHERE Lot_ID = {identifiant}";
                MySqlCommand command = new MySqlCommand(sqlLot, BDDConnexion.GetConnection());
                MySqlDataReader readerLot = command.ExecuteReader();
                readerLot.Read();

                // vérifie que le nombre de lot lié à cette recette est bien 0
                valide = int.Parse(readerLot[0].ToString()) != 0;
                // ferme le curseur de recette
                readerLot.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return valide;
        }

    }
}
