using M2_GestionFlexibleChariot.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2_GestionFlexibleChariot
{
    class Data
    {
        public static List<Recette> recettes = new List<Recette>();

        public static List<Lot> lots = new List<Lot>();

        private static int nextIdRecette = 3;
        private static int nextIdLot = 3;

        public static void Init()
        {
            Pas[] pas = new Pas[10];
            for (int i = 0; i < 10; i++)
            {
                pas[i] = new Pas(i+1,i+1,(i+1)%5, "Pas "+ i+1, false);
            }

            recettes.Add(new Recette(1,"Recette 1",pas,DateTime.Now));
            recettes.Add(new Recette(2, "Recette 2", pas, DateTime.Now));
            recettes.Add(new Recette(3, "Recette 3", pas, DateTime.Now));

            lots.Add(new Lot(1, "lot 1",DateTime.Now, 2, new List<Evenement>(), new Etat(1, "En attente"),recettes[0]));
            lots.Add(new Lot(2, "lot 2", DateTime.Now, 2, new List<Evenement>(), new Etat(1, "En production"), recettes[1]));
            lots.Add(new Lot(2, "lot 2", DateTime.Now, 2, new List<Evenement>(), new Etat(1, "Terminée"), recettes[2]));
        }

        public static int GetNextIdRecette()
        {
            nextIdRecette += 1;

            return nextIdRecette;
        }

        public static Recette GetRecette(int id)
        {
            return recettes[id - 1];
        }

        public static Lot GetLot(int id)
        {
            return lots[id - 1];
        }
    }
}
