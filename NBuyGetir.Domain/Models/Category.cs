using NbuyGetir.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyGetir.Domain.Models
{
    public class Category: AuditableEntity
    {
        public string Name { get; private set; }

        /// <summary>
        /// Ekranda ilk açılışta en üst seviye olan kategorileri listeleyeceğiz. Bu üst seviye altına eklenen alt kategorileri ise ürünler ile bağlayacağız. ürünler IsTopLevel olarak işaretlenmemiş kategorilerin altına girilecekler.
        /// </summary>
        public bool IsTopLevel { get; private set; } // en üst seviye kategori mi

        private List<Category> _subCategories = new List<Category>();
        public IReadOnlyList<Category> SubCategories => _subCategories;

        private List<Product> _products = new List<Product>();
        public IReadOnlyList<Product> Products => _products;

        public Category(string name, bool isTopLevel = false)
        {
            SetName(name);
            IsTopLevel = isTopLevel;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Kategori ismi boş geçilemez");
            }
        }

        public void AddSubCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("kategori ismi boş geçilemez"); 
            }

            // dışarıdan üst seviye olan bir kategori başka kategorinin alt kategorisi olamaz.
            if (category.IsTopLevel) // eklenecek olan kategori
            {
                throw new Exception("Top Level kategori başka bir kategori altına atılamaz");
            }

            _subCategories.Add(category);
        }

        public void AddProduct(Product product)
        {
            // !IsTopLevel && _subCategories.Count() == 0 en alt kategoridir.
            // En üst seviye bir kategori değilse ve aynı zamanda kendi altında da bir alt kategori yoksa en alt kategoridir.
            if (!IsTopLevel && _subCategories.Count() == 0)
            {
                _products.Add(product);
            }
        }


    }
}
