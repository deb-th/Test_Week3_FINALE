using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestioneSpese.EntitiesRepository.Entities
{
    public class Categoria : IEntity
    {
        public int Id { get; set; }  //uso la convenzione EF della Primary Key, auto-incremetativa

        [MaxLength(100), Required]
        public string Nome { get; set; } //Categoria

        //Navigation Properties per EF
        //Relazione 1:N
        public ICollection<Spesa> Spese { get; set; } = new List<Spesa>();
        //Lista delle spese associate

        public override string ToString()
        {
            return $"{Nome}";
        }
    }
}
