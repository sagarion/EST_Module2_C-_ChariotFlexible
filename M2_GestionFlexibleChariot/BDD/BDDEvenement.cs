using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDEvenement
    {

        /// <summary>
        /// Importe les évéenements liés à un lot dont l'identifiant est placé en paramètre et les retourne dans une liste
        /// </summary>
        /// <param name="id"> identifiant de la recette dont il faut importé les événements </param>
        /// <returns> Une liste comprenant tous les événements lié à un lot</returns>
        public static List<Evenement> RecetteSelectEvenements(int id)
        {
            List<Evenement> evenements = new List<Evenement>();

            try
            {
                // création de la requête, execution de celle-ci et import des résultats dans le curseurs
                string sqlEvenement = $"SELECT Evenement_ID,Evenement_Libelle,Evenement_DateEv FROM Pas WHERE Lot_ID='{id}' order by Evenenement DESC";
                MySqlCommand command = new MySqlCommand(sqlEvenement, BDDConnexion.GetConnection());
                MySqlDataReader readerEvenement = command.ExecuteReader();

                // parcours le curseur jusqu'à créer la liste complète d'événements pour le lot
                while (readerEvenement.Read())
                {
                    evenements.Add(new Evenement(  int.Parse(readerEvenement[0].ToString()),
                                                    readerEvenement[1].ToString(),
                                                    DateTime.Parse(readerEvenement[2].ToString())
                                                  )
                                   );
                }
                // ferme le curseur de pas
                readerEvenement.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return evenements;
        }
    }
}
