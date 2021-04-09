using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestioneSpese.EntitiesRepository.Entities
{
    public class Spesa : IEntity
    {
        public int Id { get; set; } //uso la convenzione EF della Primary Key, auto-incremetativa
        public DateTime Data { get; set; } = DateTime.Now;

        [MaxLength(500), Required]
        public string Descrizione { get; set; }

        [MaxLength(100), Required]
        public string Utente { get; set; }

        [Required]
        public decimal Importo { get; set; }
        public bool Approvato { get; set; } = false;

        //Navigation Properties per EF
        [Required]
        public int CategoriaId { get; set; }
        //Id della categoria associata
        //Relazione 1:N
        //Usa delle DataAnnotation per indicare la Chiave Esterna
        [ForeignKey(nameof(CategoriaId))]  
        public Categoria Categoria { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - Data: {Data.ToShortDateString()} - {Descrizione} ({Categoria.Nome}) - E {Importo} - Utente: {Utente} - Approvato: {Approvato}";
        }
    }
}
