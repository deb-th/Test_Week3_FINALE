using GestioneSpese.EntitiesRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese.EntitiesRepository.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        void Create(T item);
    }
}
