using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDRecette
    {
        public static void CreateRecette(Recette recette)
        {
            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlRecette = $"INSERT INTO Recette ( Recette_libelle, Recette_DateCrea)" +
                                    $"VALUES( {recette.Libellé}, {recette.DateCréation.ToShortDateString()}); ";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
               
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
                string sqlRecette = $"SELECT identifiant,libelle, date création FROM Recette WHERE index='{identifiant}'";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();

                // importe les pas liés à la recette
                Pas[] pas = BDDPas.RecetteSelectPas(recette.Identifiant);

                // une fois le tableau de pas créé, créer l'objet recette
                recette = new Recette(int.Parse(readerRecette[0].ToString()),
                                                 readerRecette[1].ToString(),
                                                pas,
                                                DateTime.Parse(readerRecette[2].ToString())
                                                );
                // ferme le curseur de recette
                readerRecette.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return recette;
        }
    }
}
