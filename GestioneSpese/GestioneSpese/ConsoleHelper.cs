using GestioneSpese.EntitiesRepository.Entities;
using GestioneSpese.EntitiesRepository.Repository;
using GestioneSpese.RepositoryEF.RepositoryEF;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese
{
    public class ConsoleHelper
    {
        public static void CreateCategorie()
        {
            IRepositoryCategoria repoCategoria = new RepositoryCategoriaEF();

            Categoria cibo = new Categoria { Nome = "Cibo" };
            Categoria abbigliamento = new Categoria { Nome = "Abbigliamento" };
            Categoria scuola = new Categoria { Nome = "Scuola" };

            repoCategoria.Create(cibo);
            repoCategoria.Create(abbigliamento);
            repoCategoria.Create(scuola);

        }

        public static void NewSpesa()
        {
            IRepositorySpesa repoSpesa = new RepositorySpesaEF();

            Console.WriteLine("Inserisci la descrizione della tua spesa: ");
            string descrizione = Console.ReadLine();

            Console.WriteLine("Inserisci il nome dell'utente: ");
            string utente = Console.ReadLine();

            Console.WriteLine("Inserisci l'importo della tua spesa: ");
            decimal importo = Decimal.Parse(Console.ReadLine());

            //Console.WriteLine("Inserisci il nome della categoria della spesa: ");
            //string categoria = Console.ReadLine();

            Console.WriteLine("Inserisci l'id della categoria della spesa: ");
            int categoria = Int32.Parse(Console.ReadLine());

            Spesa newSpesa = new Spesa
            {
                Descrizione = descrizione,
                Utente = utente,
                Importo = importo,
                CategoriaId = categoria
            };

            repoSpesa.Create(newSpesa);
        }

        public static void ApproveSpesa()
        {
            IRepositorySpesa repoSpesa = new RepositorySpesaEF();

            Console.WriteLine("Inserisci l'id della spesa da approvare: ");
            int spesaId = Int32.Parse(Console.ReadLine());

            repoSpesa.Approve(spesaId);
        }

        public static void DeleteSpesa()
        {
            IRepositorySpesa repoSpesa = new RepositorySpesaEF();

            Console.WriteLine("Inserisci l'id della spesa da eliminare: ");
            int spesaDel = Int32.Parse(Console.ReadLine());

            repoSpesa.Approve(spesaDel);
        }

        public static void SpeseApprovate()
        {
            IRepositorySpesa repoSpesa = new RepositorySpesaEF();

            Console.WriteLine(repoSpesa.GetApprovedSpese().ToString());
        }

        public static void SpeseUtente()
        {
            IRepositorySpesa repoSpesa = new RepositorySpesaEF();

            Console.WriteLine("Inserisci il nome dell'utente: ");
            string utente = Console.ReadLine();

            Console.WriteLine(repoSpesa.GetSpeseByUtente(utente).ToString());
        }

        public static void TotByCategoria()
        {
            IRepositorySpesa repoSpesa = new RepositorySpesaEF();

            Console.WriteLine("Inserisci il nome della categoria: ");
            string categoria = Console.ReadLine();

            Console.WriteLine(repoSpesa.GetTotSpeseByCategoria(categoria).ToString());
        }
    }
}
