using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese
{
    public class Menu
    {
        public static void MenuIntro()
        {

            Console.Write("\n");
            Console.WriteLine("Scegliere l'operazione da eseguire:");
            Console.WriteLine("1 - Inserire una nuova spesa");
            Console.WriteLine("2 - Approvare una spesa");
            Console.WriteLine("3 - Cancellare una spesa");
            Console.WriteLine("4 - Visualizzare l'elenco delle spese approvate");
            Console.WriteLine("5 - Visualizzare l'elenco delle spese effettuate da un utente");
            Console.WriteLine("6 - Visualizzare il totale delle spese di una Categoria");

            char key = (char)Console.ReadKey().KeyChar;
            Console.Write("\n");

            switch (key)
            {
                case '1':
                    ConsoleHelper.NewSpesa();
                    break;
                case '2':
                    ConsoleHelper.ApproveSpesa();
                    break;
                case '3':
                    ConsoleHelper.DeleteSpesa();
                    break;
                case '4':
                    ConsoleHelper.SpeseApprovate();
                    break;
                case '5':
                    ConsoleHelper.SpeseUtente();
                    break;
                case '6':
                    ConsoleHelper.TotByCategoria();
                    break;
                default:
                    Console.WriteLine("Operazione non è disponibile! Sceglierne uno valido!");
                    break;
            }
        }
    }
}