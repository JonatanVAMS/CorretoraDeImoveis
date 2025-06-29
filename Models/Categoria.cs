using System.Collections.Generic;

namespace CorretoraDeImoveis.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty; 

        public virtual ICollection<Imovel> Imoveis { get; set; } = new List<Imovel>(); 
    }
}