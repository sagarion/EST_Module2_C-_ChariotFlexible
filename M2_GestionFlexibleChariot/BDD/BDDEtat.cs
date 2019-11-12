using M2_GestionFlexibleChariot.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Titre : BDDEtat.cs
 * description : fonctions responsable des opérations avec la BDD pour la table Etat
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

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

                readerEtat.Read();
                //  créer l'objet etat
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

        // <summary>
        /// fonction important l'état correspondant à un lot
        /// </summary>
        /// <param name="identifiant"> identifiant du lot dont il faut charger l'état</param>
        /// <returns> l'objet état correspondant à l'identifiant</returns>
        public static Etat GetEtatFromLot(int identifiantLot)
        {
            Etat etat = null;

            try
            {
                // création des requêtes, execution de celles-ci et import des résultat dans les curseurs
                string sqlEtat = $"SELECT Etat.Etat_ID, Etat.Etat_Libelle FROM Etat Join lot ON lot.Etat_ID = etat.Etat_ID WHERE Lot.Lot_ID = '{identifiantLot}'";
                MySqlCommand command = new MySqlCommand(sqlEtat, BDDConnexion.GetConnection());
                MySqlDataReader readerEtat = command.ExecuteReader();

                readerEtat.Read();
                //  créer l'objet etat
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
