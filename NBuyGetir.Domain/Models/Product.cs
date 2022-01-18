using NbuyGetir.Common.Uri;
using NbuyGetir.Core.Entites;
using NBuyGetir.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string PictureUrl { get; set; }

        /// <summary>
        /// Indirimli ürün olup olmadığını Db de saklamayacağız. Zaten elimizde bilgilere göre bu property tarafından indirimli ürün olup olmadığını buluyoruz. Ürün indirimli mi
        /// </summary>
        public bool IsDiscounted { get {

                return DiscountedListPrice < ListPrice ? true : false;
            
            } }

        /// <summary>
        /// Stock kritik seviyede bunları ekranda göstermeyebiliriz.
        /// </summary>
        public bool IsStockInCriticalLevel
        {
            get
            {
                return Stock < 10 ? true : false;
            }
        }


        public Product(string name, decimal unitPrice, decimal listPrice,decimal discountedListPrice,int stock,string description, string pictureUrl)
        {
            SetName(name);
            SetPrice(unitPrice, listPrice, discountedListPrice);
            SetDescription(description);
            SetStock(stock);
            SetPictureUrl(pictureUrl);
        }

        /// <summary>
        /// Hem kayıt hemde güncelleme işleminde kullanılacağı için public yapıldı.
        /// Eğer boş ise default ürün'e ait bir url verelim.
        /// </summary>
        public void SetPictureUrl(string pictureUrl)
        {
         
            if (!UrlHelper.IsUrl(pictureUrl))
            {
                throw new Exception("resim yolu url formatında değildir");
            }

            if (string.IsNullOrEmpty(pictureUrl))
            {
                PictureUrl = "default-product.jpeg";
            }
            else
            {
                PictureUrl = pictureUrl.Trim();
            }
           
        }

        /// <summary>
        /// İlk kayıt işleminde sadece stok değeri formdan alınırken kullanılacağı için private yaptık. Diğer tüm stok işlemleride StockIn ve StockOut operasyonlarını kullanacağız.
        /// </summary>
        /// <param name="stock"></param>
        private void SetStock(int stock)
        {
            if(stock < 0)
            {
                throw new Exception("Stok değeri sıfırdan küçük olamaz");
            }

            Stock = stock;
        }

        /// <summary>
        /// Stoklama işlemi ürünün envantere girilmesi işlemi
        /// </summary>
        public void StockIn(int quantity)
        {
            if(quantity <= 0)
            {
                throw new Exception("stoğa girilecek yeni ürün adeti 0 ve daha düşük olamaz");
            }

            int oldStock = Stock;
            int newStock = Stock + quantity;
            Stock = newStock;
            // Stoğa ürün girildi eventi fırlatalım

            AddEvents(new StockedIn(this.Id, oldStock, newStock));
        }

        public void StockOut(int quantity)
        {
            if(quantity < 0)
            {
                throw new Exception("0 dan küçük değer stoktan düşülemez");
            }
       

            if (IsStockInCriticalLevel)
            {
                // Kritik stok seviyesindeki bir ürün sipariş edildi diye bir mesaj atalım.
            }

            if(quantity > Stock)
            {
                // hatalı kayıt gönderme işlemi
                throw new Exception("stoktan düşülen miktar stok değerinden büyük olamaz");
            }

            Stock -= quantity;

        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("ürün açıklama alanı doldurdurunuz");
            }

            if(description.Length > 50)
            {
                throw new Exception("Maksimum 50 karakter girebilirsiniz");
            }

            Description = description.Trim();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("ürün ismi boş geçilemez");
            }

            Name = name.Trim();
        }

        /// <summary>
        /// Ürüne ait fiyatların değişimini bu method ile yapacağız.
        /// </summary>
        /// <param name="unitPrice"></param>
        /// <param name="listPrice"></param>
        /// <param name="discountedListPrice"></param>
        public void SetPrice(decimal unitPrice, decimal listPrice, decimal discountedListPrice)
        {
            if(unitPrice > listPrice)
            {
                throw new Exception("Birim fiyat liste fiyatından büyük olamaz");
            }

            if(unitPrice <= 0 || listPrice <= 0 || discountedListPrice <= 0)
            {
                throw new Exception("Ürün birim fiyatı veya ürün satış veya indirimli satış fiyatı 0 ve daha küçük bir değer olamaz");
            }

            if(discountedListPrice > listPrice)
            {
                throw new Exception("indirimli satış fiyatı satış fiyatından büyük olamaz");
            }

            if(discountedListPrice < unitPrice)
            {
                throw new Exception("indirimli satış fiyatı birim fiyattan küçük olamaz");
            }

            ListPrice = listPrice;
            UnitPrice = unitPrice;
            DiscountedListPrice = discountedListPrice;

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
