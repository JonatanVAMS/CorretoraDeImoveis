using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CorretoraDeImoveis.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name = "Nome da Categoria")]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}