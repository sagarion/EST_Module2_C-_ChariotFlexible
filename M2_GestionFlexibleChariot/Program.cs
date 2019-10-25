// Auteur : Thibault Daucourt
// Projet : M2 : Gestion Chariot Flexible
// Date création : 09.09.2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M2_GestionFlexibleChariot
{
    class Program
    {
        static void Main(string[] args)
        {
            // temp Data
            Data.Init();

            bool MenuPrincipalFin = false;

            // valeur saisie par l'utilisateur correspondant au choix de navigation
            // cette valeur a été utilisée pour toutes les options de navigation à tous les niveaux 
            int ChoixUtilisateur;

            // variable utilisée pour stocker une recette avant son affichage
            Class.Recette recetteTemp = null; ;
            // variable utilisée pour stocker un lot avant son affichage
            Class.Lot lot = null; ;

            do
            {
                Interface.Utilitaire.NettoyerConsole();
                Interface.MenuPrincipal.AfficherMenu();
                ChoixUtilisateur = Interface.MenuPrincipal.SaisieMenu();

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

                            switch (ChoixUtilisateur)
                            {
                                // afficher la liste des recettes
                                case 1:
                                    Interface.Utilitaire.NettoyerConsole();
                                    Interface.MenuRecette.AfficherListeRecettes();
                                    Interface. Utilitaire.Attendre();
                                    break;
                                // Affiche les détails d'une recette
                                case 2:
                                    Interface.MenuRecette.AfficherListeRecettes();
                                    recetteTemp = Interface.MenuRecette.SelectionnerRecette();
                                    Console.WriteLine(" détails d'une recette");
                                    Interface.Utilitaire.Attendre();
                                    // A COMPLETER
                                    break;
                                // créer une recette
                                case 3:
                                    Console.WriteLine(" créer une recette");
                                    Data.recettes.Add(Interface.Recette.SaisirCréation());
                                    // A COMPLETER
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
                            Interface.MenuLot.AfficherMenu();
                            ChoixUtilisateur = Interface.MenuLot.SaisieMenu();

                            switch (ChoixUtilisateur)
                            {
                                // afficher la liste des lots
                                case 1:
                                    Interface.Utilitaire.NettoyerConsole();
                                    Interface.MenuLot.AfficherListeLots();
                                    Interface.Utilitaire.Attendre();
                                    break;
                                // Affiche les détails d'une recette
                                case 2:
                                    Interface.Utilitaire.NettoyerConsole();
                                    Interface.MenuLot.AfficherListeLots();
                                    lot = Interface.MenuLot.SelectionnerLot();
                                    Console.WriteLine(" détails d'un lot");
                                    Interface.Lot.AfficherDetailLot(lot);
                                    Interface.Utilitaire.Attendre();
                                    // A COMPLETER
                                    break;
                                // créer une recette
                                case 3:
                                    Console.WriteLine(" créer un lot");
                                    lot = Interface.Lot.SaisirCréation();
                                    Data.lots.Add(lot);
                                    Interface.Lot.AfficherDetailLot(lot)
                                    Interface.Utilitaire.Attendre();
                                    break;
                                // quitter le menu recette --> retour au menu principal
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
    }
}
