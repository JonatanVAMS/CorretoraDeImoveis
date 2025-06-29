using System.ComponentModel.DataAnnotations;

namespace CorretoraDeImoveis.Models
{
    public class Imovel
    {
        public int ImovelId { get; set; }

        [Display(Name = "Título do Imóvel")]
        public string Nome { get; set; } = string.Empty; 

        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty; 

        [Display(Name = "Endereço")]
        public string Endereco { get; set; } = string.Empty; 

        [Display(Name = "Nº de Quartos")]
        public int NroQuartos { get; set; }

        [Display(Name = "Vagas de Garagem")]
        public int NroVagasGaragem { get; set; }

        [Display(Name = "Nº de Banheiros")]
        public int NroBanheiros { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }
}