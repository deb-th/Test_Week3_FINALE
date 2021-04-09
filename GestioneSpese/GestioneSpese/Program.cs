using GestioneSpese.EntitiesRepository.Repository;
using GestioneSpese.RepositoryEF.RepositoryEF;
using System;

namespace GestioneSpese
{
    class Program
    {
        static void Main(string[] args)
        {
            char key;

            Console.WriteLine("GESTIONE SPESE");
            Console.WriteLine("Benvenuto!");

            //Inserisco delle categorie
            //ConsoleHelper.CreateCategorie();

            do
            {
                Menu.MenuIntro();
                
                Console.WriteLine("Per uscire premi q, altrimenti premi qualsiasi altro tasto");
                key = Console.ReadKey().KeyChar;

            } while (key != 'q'); //finchè l'utente decide di uscire dall'app
        }
    }
}