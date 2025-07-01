using System.ComponentModel.DataAnnotations;

namespace CorretoraDeImoveis.Models
{
    public class Property
    {
        public int PropertyId { get; set; }

        [Display(Name = "Título do Imóvel")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Endereço")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Nº de Quartos")]
        public int Bedrooms { get; set; }

        [Display(Name = "Vagas de Garagem")]
        public int ParkingSpaces { get; set; }

        [Display(Name = "Nº de Banheiros")]
        public int Bathrooms { get; set; }

        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}