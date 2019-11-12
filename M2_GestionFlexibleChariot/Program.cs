// Auteur : Thibault Daucourt
// Projet : M2 : Gestion Chariot Flexible
// Date création : 09.09.2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Titre : Program.cs
 * description : fichier responsable de l'execution du programme. Contient également l'algorithme de l'application.
 * Auteur : Daucourt Thibault
 * Date : novembre 2019
*/

namespace M2_GestionFlexibleChariot
{
    class Program
    {
        static void Main(string[] args)
        {

            // connection à la base de donnée
            BDD.BDDConnexion.Connecter();

            // teste conneciotn avec la base de données
            if (BDD.BDDConnexion.GetConnection().State == System.Data.ConnectionState.Open)
            {
                bool MenuPrincipalFin = false;

                // valeur saisie par l'utilisateur correspondant au choix de navigation
                // cette valeur a été utilisée pour toutes les options de navigation à tous les niveaux 
                int ChoixUtilisateur;

                // variable utilisée pour stocker une recette temporairement
                Class.Recette recetteTemp = null;
                // variable utilisée pour stocker un lotTemp avant son affichage
                Class.Lot lotTemp = null;


                do
                {
                    Interface.Utilitaire.NettoyerConsole();
                    Interface.MenuPrincipal.AfficherMenu();
                    ChoixUtilisateur = Interface.MenuPrincipal.SaisieMenu();
                    Interface.Utilitaire.NettoyerConsole();
                    switch (ChoixUtilisateur)
                    {
                        // Menu Recette
                        case 1:
                            bool MenuRecetteFin = false;
                            do
                            {
                                Interface.Utilitaire.NettoyerConsole();
                                Interface.MenuRecette.AfficherMenu();
                                ChoixUtilisateur = Interface.MenuRecette.SaisieMenu();
                                Interface.Utilitaire.NettoyerConsole();
                                switch (ChoixUtilisateur)
                                {
                                    // afficher la liste des recettes
                                    case 1:
                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                        System.Console.WriteLine("");
                                        Console.WriteLine("");
                                        Interface.MenuRecette.AfficherListeRecettes(BDD.BDDRecette.GetRecettes());
                                        Interface.Utilitaire.Attendre();
                                        break;
                                    // Affiche les détails d'une recette et options UD sur une recette
                                    case 2:
                                        recetteTemp = Interface.MenuRecette.SelectionnerRecette(BDD.BDDRecette.GetRecettes());

                                        Interface.Utilitaire.NettoyerConsole();

                                        Interface.DetailsRecette.AfficherMenuDetailsRecette(recetteTemp);

                                        bool MenuDetailRecetteFin = false;
                                        do
                                        {
                                            ChoixUtilisateur = Interface.DetailsRecette.SaisieMenu();

                                            switch (ChoixUtilisateur)
                                            {
                                                case 1:
                                                    if (BDD.BDDRecette.EstMuable(recetteTemp.Identifiant))
                                                    {
                                                        Interface.Utilitaire.NettoyerConsole();
                                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                                        System.Console.WriteLine("");
                                                        System.Console.WriteLine("--> Modification de la recette");
                                                        Console.WriteLine("");
                                                        recetteTemp = Interface.DetailsRecette.ModifierRecette(recetteTemp);
                                                        BDD.BDDRecette.UpdateRecette(recetteTemp);

                                                        // affichage du résultat de la modification
                                                        Interface.Utilitaire.NettoyerConsole();
                                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                                        System.Console.WriteLine("");
                                                        System.Console.WriteLine("--> Details de la recette modifiée");
                                                        Console.WriteLine("");
                                                        Interface.DetailsRecette.AfficherDetailRecette(BDD.BDDRecette.GetRecette(recetteTemp.Identifiant));

                                                        MenuDetailRecetteFin = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Erreur modification impossible car recette associée avec un lot !");
                                                    }
                                                    break;
                                                case 2:
                                                    if (BDD.BDDRecette.EstMuable(recetteTemp.Identifiant))
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine("Etes-vous sur de vouloir supprimer la recette ?");
                                                        if (Interface.Utilitaire.SaisirBool("suppresion Recette"))
                                                        {
                                                            BDD.BDDRecette.DeleteRecette(recetteTemp);
                                                            MenuDetailRecetteFin = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine("Erreur Suppression impossible car recette associée avec un lot !");
                                                        Console.WriteLine();
                                                    }
                                                    break;
                                                case 3:
                                                    MenuDetailRecetteFin = true;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        } while (!MenuDetailRecetteFin);

                                        break;
                                    // créer une recette
                                    case 3:
                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                        System.Console.WriteLine("");
                                        Console.WriteLine("-- créer une recette --");
                                        Console.WriteLine("");
                                        recetteTemp = Interface.DetailsRecette.SaisirCréation();
                                        recetteTemp.Identifiant = BDD.BDDRecette.GetNextIdentifiant();
                                        BDD.BDDRecette.CreateRecette(recetteTemp);

                                        // affichage une fois créer
                                        Interface.Utilitaire.NettoyerConsole();
                                        Interface.DetailsRecette.AfficherDetailRecette(BDD.BDDRecette.GetRecette(recetteTemp.Identifiant));
                                        Interface.Utilitaire.Attendre();
                                        break;
                                    // quitter le menu recette --> retour au menu principal
                                    case 4:
                                        MenuRecetteFin = true;
                                        break;
                                    default:
                                        System.Console.WriteLine(" Une erreur à eu lieu, vous allez retourner au Menu principal");
                                        MenuRecetteFin = true;
                                        break;
                                }

                            } while (!MenuRecetteFin);

                            break;

                        // Menu Lot
                        case 2:
                            bool MenuLotFin = false;
                            do
                            {
                                Interface.Utilitaire.NettoyerConsole();
                                System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                System.Console.WriteLine("");
                                Interface.MenuLot.AfficherMenu();
                                ChoixUtilisateur = Interface.MenuLot.SaisieMenu();

                                Interface.Utilitaire.NettoyerConsole();
                                switch (ChoixUtilisateur)
                                {
                                    // afficher la liste des lots
                                    case 1:
                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                        System.Console.WriteLine("");
                                        Interface.MenuLot.AfficherListeLots();
                                        Interface.Utilitaire.Attendre();
                                        break;
                                    // Affiche les détails d'un lotTemp
                                    case 2:
                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                        System.Console.WriteLine("");
                                        lotTemp = Interface.MenuLot.SelectionnerLot();
                                        Interface.Utilitaire.NettoyerConsole();


                                        Interface.DetailsLot.AfficherMenuDetailsLot(lotTemp);

                                        bool MenuDetailLotFin = false;
                                        do
                                        {
                                            ChoixUtilisateur = Interface.DetailsLot.SaisieMenu();

                                            switch (ChoixUtilisateur)
                                            {
                                                case 1:
                                                    if (BDD.BDDLot.EstMuable(lotTemp.Identifiant))
                                                    {
                                                        Interface.Utilitaire.NettoyerConsole();
                                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                                        System.Console.WriteLine("");
                                                        System.Console.WriteLine("--> Modification du lot");
                                                        Console.WriteLine("");
                                                        lotTemp = Interface.DetailsLot.ModifierLot(lotTemp, BDD.BDDRecette.GetRecettes());
                                                        BDD.BDDLot.UpdateLot(lotTemp);

                                                        // affichage du résultat de la modification
                                                        Interface.Utilitaire.NettoyerConsole();
                                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                                        System.Console.WriteLine("");
                                                        System.Console.WriteLine("-- Details du lot modifié --");
                                                        Console.WriteLine("");
                                                        Interface.DetailsLot.AfficherDetailLot(BDD.BDDLot.GetLot(lotTemp.Identifiant));

                                                        MenuDetailLotFin = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Erreur modification impossible car lot déjà commencé !");
                                                    }
                                                    break;
                                                case 2:
                                                    if (BDD.BDDLot.EstMuable(lotTemp.Identifiant))
                                                    {
                                                        Console.WriteLine("Etes-vous sur de vouloir supprimer le lot ?");
                                                        if (Interface.Utilitaire.SaisirBool("suppresion Lot"))
                                                        {
                                                            BDD.BDDLot.DeleteLot(lotTemp);
                                                            MenuDetailLotFin = true;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine("Erreur Suppression impossible car lot déjà commencé !");
                                                        Console.WriteLine();
                                                    }
                                                    break;
                                                case 3:
                                                    MenuDetailLotFin = true;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        } while (!MenuDetailLotFin);

                                        Interface.Utilitaire.Attendre();

                                        break;
                                    // créer une lotTemp
                                    case 3:
                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                        System.Console.WriteLine("");
                                        lotTemp = Interface.DetailsLot.SaisirCréation(BDD.BDDRecette.GetRecettes());
                                        BDD.BDDLot.CreateLot(lotTemp);
                                        Interface.Utilitaire.NettoyerConsole();
                                        System.Console.WriteLine("--- Application Gestion Chariot Flexible ---");
                                        System.Console.WriteLine("");
                                        Console.WriteLine("-- Détails lot créé --");
                                        Interface.DetailsLot.AfficherDetailLot(BDD.BDDLot.GetLot(lotTemp.Identifiant));
                                        Interface.Utilitaire.Attendre();
                                        break;
                                    // quitter le menu lot --> retour au menu principal
                                    case 4:
                                        MenuLotFin = true;
                                        break;
                                    default:
                                        System.Console.WriteLine(" Une erreur à eu lieu, vous allez retourner au Menu principal");
                                        MenuLotFin = true;
                                        break;
                                }

                            } while (!MenuLotFin);

                            break;
                        // Quitter application
                        case 3:
                            MenuPrincipalFin = true;
                            Console.WriteLine("L'application va prendre fin ...");
                            break;
                        // ERREUR
                        default:
                            Console.WriteLine("Une valeur impossible à été accepter par le programme.");
                            Console.WriteLine("L'application va revenir au menu principale.");
                            Interface.Utilitaire.Attendre();
                            break;
                    }

                } while (!MenuPrincipalFin);
            }
            else
            {
                Console.WriteLine("Il y a eu une erreur lors de la connexion à la base !");
                Console.WriteLine("");
                Console.WriteLine("Vérifié les infomraiton de connexion dans le fichier BDDConnexion.cs et que la base de données est bien opérationnel");
            }
            
            
        }
    }
}
