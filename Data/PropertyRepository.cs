using CorretoraDeImoveis.Models;
using System.Collections.Generic;
using System.Linq;

namespace CorretoraDeImoveis.Data
{
    public static class PropertyRepository
    {
        private static List<Category> _categories;
        private static List<Property> _properties;
        private static int _nextPropertyId = 1;

        static PropertyRepository()
        {
            _categories = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Apartamento" },
                new Category { CategoryId = 2, Name = "Casa" },
                new Category { CategoryId = 3, Name = "Sítio" },
                new Category { CategoryId = 4, Name = "Sala Comercial" }
            };

            _properties = new List<Property>();

            AddProperty(new Property { Title = "Apartamento Central", Description = "Lindo apartamento com 3 quartos.", Address = "Rua Principal, 123", Bedrooms = 3, Bathrooms = 2, ParkingSpaces = 1, CategoryId = 1 });
            AddProperty(new Property { Title = "Casa com Piscina", Description = "Casa espaçosa com área de lazer.", Address = "Av. das Árvores, 456", Bedrooms = 4, Bathrooms = 3, ParkingSpaces = 2, CategoryId = 2 });
            AddProperty(new Property { Title = "Sítio Vista Verde", Description = "Sítio com pomar e lago.", Address = "Estrada Rural, Km 5", Bedrooms = 2, Bathrooms = 1, ParkingSpaces = 5, CategoryId = 3 });
            AddProperty(new Property { Title = "Sala no Prédio Comercial", Description = "Sala comercial com 50m².", Address = "Av. Central, 789, Sala 101", Bedrooms = 0, Bathrooms = 1, ParkingSpaces = 1, CategoryId = 4 });
            AddProperty(new Property { Title = "Cobertura Duplex", Description = "Apartamento de luxo.", Address = "Rua das Flores, 99", Bedrooms = 4, Bathrooms = 4, ParkingSpaces = 3, CategoryId = 1 });
        }

        public static List<Property> GetAllProperties()
        {
            foreach (var property in _properties)
            {
                if (property.Category == null)
                {
                    property.Category = _categories.FirstOrDefault(c => c.CategoryId == property.CategoryId);
                }
            }
            return _properties;
        }

        public static List<Category> GetAllCategories()
        {
            return _categories;
        }

        public static void AddProperty(Property property)
        {
            property.PropertyId = _nextPropertyId++;
            _properties.Add(property);
        }
    }
}