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

                string sqlPas = $"SELECT identifiant,index,temps, position, libellé, quittance FROM Pas WHERE Recette_identifiant='{identifiant}'";
                command = new MySqlCommand(sqlPas, BDDConnexion.GetConnection());
                MySqlDataReader readerPas = command.ExecuteReader();


                Pas[] pas = new Pas[10];
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
