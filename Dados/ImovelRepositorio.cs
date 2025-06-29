using CorretoraDeImoveis.Models;
using System.Collections.Generic;
using System.Linq;

namespace CorretoraDeImoveis.Dados
{
    public class ImovelRepositorio
    {
        private static List<Categoria> _categorias;
        private static List<Imovel> _imoveis;
        private static int _nextImovelId = 1;

        static ImovelRepositorio()
        {
            _categorias = new List<Categoria>()
            {
                new Categoria { CategoriaId = 1, Nome = "Apartamento" },
                new Categoria { CategoriaId = 2, Nome = "Casa" },
                new Categoria { CategoriaId = 3, Nome = "Sítio" },
                new Categoria { CategoriaId = 4, Nome = "Sala Comercial" }
            };

            _imoveis = new List<Imovel>();

            AdicionarImovel(new Imovel
            {
                Nome = "Apartamento Central",
                Descricao = "Lindo apartamento com 3 quartos no centro da cidade.",
                Endereco = "Rua Principal, 123",
                NroQuartos = 3,
                NroBanheiros = 2,
                NroVagasGaragem = 1,
                CategoriaId = 1 // Apartamento
            });

            AdicionarImovel(new Imovel
            {
                Nome = "Casa com Piscina",
                Descricao = "Casa espaçosa com área de lazer completa.",
                Endereco = "Av. das Árvores, 456",
                NroQuartos = 4,
                NroBanheiros = 3,
                NroVagasGaragem = 2,
                CategoriaId = 2 // Casa
            });
        }

        public static List<Imovel> ObterTodosImoveis()
        {
            foreach (var imovel in _imoveis)
            {
                if (imovel.Categoria == null)
                {
                    imovel.Categoria = _categorias.FirstOrDefault(c => c.CategoriaId == imovel.CategoriaId);
                }
            }
            return _imoveis;
        }

        public static List<Categoria> ObterTodasCategorias()
        {
            return _categorias;
        }

        public static void AdicionarImovel(Imovel imovel)
        {
            imovel.ImovelId = _nextImovelId++;
            _imoveis.Add(imovel);
        }
    }
}
