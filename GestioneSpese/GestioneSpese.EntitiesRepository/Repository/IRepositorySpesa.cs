using GestioneSpese.EntitiesRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese.EntitiesRepository.Repository
{
    public interface IRepositorySpesa : IRepository<Spesa>
    {
        //Metodi specifici dell'entità Spesa
        void Approve(int id);
        void Delete(int id);
        ICollection<Spesa> GetApprovedSpese();
        ICollection<Spesa> GetSpeseByUtente(string utente);
        ICollection<Spesa> GetTotSpeseByCategoria(string categoria);
    }
}
