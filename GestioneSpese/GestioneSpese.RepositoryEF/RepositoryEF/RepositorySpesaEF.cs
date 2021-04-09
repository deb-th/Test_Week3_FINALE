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
    public class RepositorySpesaEF : IRepositorySpesa
    {
        //Metodo per inserire nuove Spese
        public void Create(Spesa spesa)
        {
            using (var ctx = new GestioneSpeseContext()) //variabile context
            {
                if (spesa == null)
                {
                    return;
                }

                //Prelevo la categoria correlata
                //var categoria = ctx.Categorie
                //                   .Include(s => s.Spese)
                //                   .Where(c => c.Nome == spesa.Categoria.Nome)
                //                   .SingleOrDefault();
                var categoria = ctx.Categorie
                                   .Include(s => s.Spese)
                                   .Where(c => c.Id == spesa.CategoriaId)
                                   .SingleOrDefault();

                if (categoria != null)
                {
                    //Aggiungo la spesa nella lista Spese della Categoria correlata
                    categoria.Spese.Add(spesa);
                }
                else
                {
                    return;
                }

                //Inserisco la spesa nella tabella Spese
                ctx.Spese.Add(spesa);

                ctx.SaveChanges();
            }
        }


        //Metodo per Approvare una spesa esistente
        public void Approve(int id)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                bool approved = false;

                do
                {
                    try
                    {
                        if (id < 0)
                        {
                            return;
                        }
                        //verifico l'esistenza della spesa da approvare
                        var spesa = ctx.Spese.Find(id);

                        if (spesa != null)
                        {
                            //se esiste la spesa imposto il flag di approvazione a true
                            spesa.Approvato = true;
                        }

                        //marco la spesa come modificata
                        ctx.Entry<Spesa>(spesa).State = EntityState.Modified;

                        //aggiorno la spesa in DbSet
                        ctx.SaveChanges(); 

                        approved = true; //Approvazione eseguita
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        foreach (var entity in ex.Entries)
                        {
                            //in caso di accesso concorrente alla spesa in approvazione
                            var dbValue = entity.GetDatabaseValues();
                            entity.OriginalValues.SetValues(dbValue);
                            //ripristino il valore di partenza
                        }
                    }
                } while (!approved);
            }
        }


        //Metodo per Cancellare una spesa esistente
        public void Delete(int id)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                if (id < 0)
                {
                    return;
                }
                //Verifico che la spesa associata all'id sia esistente
                var spesa = ctx.Spese.Find(id);

                if (spesa != null)
                {
                    //se esiste la cancello dalla DbSet Spese
                    ctx.Spese.Remove(spesa);
                    ctx.SaveChanges();
                }
            }
        }


        //Metodo per restituire l'elenco delle spese approvate
        public ICollection<Spesa> GetApprovedSpese()
        {
            using (var ctx = new GestioneSpeseContext())
            {
                //restituisco l'elenco delle spese approvate con la categoria correlata
                return ctx.Spese.Include(c => c.Categoria)
                                .Where(s => s.Approvato == true)
                                .ToList();
            };
        }


        //Metodo per recuperare l'elenco delle Spese di uno specifico Utente
        public ICollection<Spesa> GetSpeseByUtente(string utente)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                if (utente == null)
                {
                    return null;
                }

                //restituisco l'elenco delle spese dell'utente con la categoria associata
                return ctx.Spese.Include(c => c.Categoria)
                                .Where(s => s.Utente == utente)
                                .ToList();
            };
        }


        //Metodo per restituire il totale delle spese della categoria
        public ICollection<Spesa> GetTotSpeseByCategoria(string categoria)
        {
            using (var ctx = new GestioneSpeseContext())
            {
                //restituisco la somma delle spese della categoria indicata
                return ctx.Spese.Include(c => c.Categoria)
                                .Where(s => s.Categoria.Nome == categoria)
                                .ToList();
            }
        }
    }
}