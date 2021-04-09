using GestioneSpese.EntitiesRepository.Entities;
using GestioneSpese.EntitiesRepository.Repository;
using GestioneSpese.RepositoryEF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneSpese.RepositoryEF.RepositoryEF
{
    public class RepositoryCategoriaEF : IRepositoryCategoria
    {
        //Metodo per creare nuove categorie
        public void Create(Categoria categoria)
        {
            using (var ctx = new GestioneSpeseContext()) //variabile context
            {
                if (categoria == null)
                {
                    return;
                }

                //Aggiungo alla tabella Categorie
                ctx.Categorie.Add(categoria);

                ctx.SaveChanges();
            }
        }

        public void GetID(string nomeCategoria)
        {
            using (var ctx = new GestioneSpeseContext()) //variabile context
            {
                if (nomeCategoria == null)
                {
                    //return 0;
                }

                //return ctx.Categorie.Select(c => c.Id).Where(x => x.Nome == nomeCategoria);
            }
        }

    }
}
