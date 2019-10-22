using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"INSERT INTO Lot (Lot_Nom, Lot_DateCreation,LotQtePceAproduire,Etat_ID)" +
                                    $"VALUES( {lot.Nom}, " +
                                    $"{DateTime.Now.ToShortDateString()}," +
                                    $"{lot.QuantitéAProduire}," +
                                    $"{lot.Etat.Identifiant}); ";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());

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
                string sqlLot = $"SELECT Lot_ID, Lot_Nom, Lot_DateCreation, Lot_QtePceAproduire, Etat_ID FROM Lot WHERE Lot_ID='{identifiant}'";
                MySqlCommand command = new MySqlCommand(sqlLot, BDDConnexion.GetConnection());
                MySqlDataReader readerLot = command.ExecuteReader();

                // importe les pas liés au lot
                List<Evenement> evenements = BDDEvenement.RecetteSelectEvenements(lot.Identifiant);

                // importe l'état lié au lot
                Etat etat = BDDEtat.GetEtat(int.Parse(readerLot[4].ToString()));

                // une fois le tableau de pas créé, créer l'objet lot
                // créer l'objet Etat du lot selon la requette de sélection du lot
                lot = new Lot(int.Parse(readerLot[0].ToString()),
                              readerLot[1].ToString(),
                              DateTime.Parse(readerLot[2].ToString()),
                              int.Parse(readerLot[3].ToString()),
                              evenements,
                              etat);

                // ferme le curseur de lot
                readerLot.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return lot;
        }

    }
}
