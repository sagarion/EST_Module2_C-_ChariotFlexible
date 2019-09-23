using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot.BDD
{
    class BDDEtat
    {
        /// <summary>
        /// fonction important l'état correspondant à l'identifiant
        /// </summary>
        /// <param name="identifiant"> identifiant de l'état à charger</param>
        /// <returns> l'objet état correspondant à l'identifiant</returns>
        public static Etat GetEtat(int identifiant)
        {
            Etat etat = null;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlEtat = $"SELECT Etat_ID, Etat_Libelle FROM Etat WHERE Etat_ID = '{identifiant}'";
                MySqlCommand command = new MySqlCommand(sqlEtat, BDDConnexion.GetConnection());
                MySqlDataReader readerEtat = command.ExecuteReader();

                // une fois le tableau de pas créé, créer l'objet etat
                etat = new Etat(int.Parse(readerEtat[0].ToString()),
                                                 readerEtat[1].ToString());
                // ferme le curseur de recette
                readerEtat.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return etat;
        }
    }
}
