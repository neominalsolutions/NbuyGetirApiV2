using NbuyGetir.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyGetir.Domain.Models
{
    public class Product: AuditableEntity
    {
        public string Name { get; private set; }
        public decimal UnitPrice { get; private set; } // alış fiyatı
        public decimal ListPrice { get; private set; } // satış fiyatı

        // Bu alan sadece program tarafında tutulacak bir alan olsun.
        public decimal DiscountedListPrice { get; private set; } // indirimli fiyat
        public int Stock { get; set; } // current Stock
        public string Description { get; set; } // 10x1 adet 1lt 2kg 30cc 50ml
        public string PictureBase64 { get; private set; }
        public string PictureUrl { get; set; }

        /// <summary>
        /// Indirimli ürün olup olmadığını Db de saklamayacağız. Zaten elimizde bilgilere göre bu property tarafından indirimli ürün olup olmadığını buluyoruz. Ürün indirimli mi
        /// </summary>
        public bool IsDiscounted { get {

                return DiscountedListPrice < ListPrice ? true : false;
            
            } }


        public Product(string name, decimal unitPrice, decimal listPrice,int stock,string description, string pictureUrl)
        {

        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("ürün ismi boş geçilemez");
            }

            Name = name.Trim();
        }

        private void SetPrice(decimal unitPrice, decimal listPrice)
        {
            if(unitPrice > listPrice)
            {
                throw new Exception("Birim fiyat liste fiyatından büyük olamaz");
            }

            if(unitPrice <= 0 || listPrice <= 0)
            {
                throw new Exception("Ürün birim fiyatı veya ürün satış fiyatı negatif ve 0  verilemez");
            }

            ListPrice = listPrice;
            UnitPrice = unitPrice;

        }

        /// <summary>
        /// Bu method ile bir ürünün satış fiyatına belirli bir oranda indirim yapılır. İndirim oranı güncellenir ve sadece Program tarafında DiscountedListPrice tutacağız bu indirimli fiyatımız olacaktır.11 unitPrice 13 listPrice 12.67 discountedListPrice
        /// </summary>
        /// <param name="newPrice"></param>
        public void DecreasePrice(decimal newPrice) // ürünün satış fiyatına indirim yap.
        {
           
            if(newPrice > ListPrice)
            {
                throw new Exception("indirimli fiyat liste fiyatından büyük olamaz");
            }

          
            if (newPrice <= UnitPrice)
            {
                throw new Exception("indirimli fiyat birim fiyatından küçük olamaz");
            }

            DiscountedListPrice = newPrice;

            // Indirim Uygula Eventi fırlatacağız.
            // Bu ürünü favorisine ekleyen müşterilere mail atsın. Ürünün fiyatı düştü maili atsın. yada push notification yapsın.
        }
        /// <summary>
        /// Ürünün liste fiyatı güncellenirse diye yaptık. Satış fiyatını artırıyoruz.
        /// </summary>
        /// <param name="newListPrice"></param>
        /// <param name="newDiscountedListPrice"></param>
        public void IncreasePrice(decimal newListPrice, decimal newDiscountedListPrice)
        {
            if(newListPrice < ListPrice)
            {
                throw new Exception("yeni fiyat liste fiyatından küçük olamaz");
            }

            if(newDiscountedListPrice > newListPrice)
            {
                throw new Exception("indirimli fiyat yeni liste fiyatından büyük olamaz");
            }

            ListPrice = newListPrice;
            DiscountedListPrice = newDiscountedListPrice;
            // Zamlı ürünleri event olarak fırlatabiliriz.
        }

        


    }
}
