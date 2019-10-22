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

        /// <summary>
        /// Mets à jours les informations en base de données d'une recette par rapport à l'objet placé en paramètre
        /// </summary>
        /// <param name="recette"> L'objet recette servant de référence pour la mise à jour </param>
        public static void UpdateRecette(Recette recette)
        {
            try
            {
                // mets à jour les données de la recette
                string sqlRecette = $"UPDATE Recette" +
                                    $"SET Recette_Libelle = {recette.Libellé}, " +
                                        $"Recette_dateCrea = {recette.DateCréation.ToShortDateString()}" +
                                    $"WHERE Recette_ID = {recette.Identifiant};";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());

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
                string sqlRecette = $"SELECT count(*) FROM Lot WHERE Recette_ID = {identifiant}";
                MySqlCommand command = new MySqlCommand(sqlRecette, BDDConnexion.GetConnection());
                MySqlDataReader readerRecette = command.ExecuteReader();

                // vérifie que le nombre de lot lié à cette recette est bien 0
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
    }
}
