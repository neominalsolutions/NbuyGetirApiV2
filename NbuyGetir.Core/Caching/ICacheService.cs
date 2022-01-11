using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Caching
{
    #region Sample
    public class Category
    {
        public string Name { get; set; }
    }
    public class CategoryCacheService : ICacheService<List<Category>>
    {
        public List<Category> GetFromCache(string key)
        {
            // json string c# dizisine çevrilir.
            return new List<Category>();
        }

        public void SetCache(string key, List<Category> cacheData)
        {
            // jsonstring olarak kaydedicez.
        }
    }

    public class Sample
    {

        public Sample()
        {
            var s = new CategoryCacheService();
            s.SetCache("deneme",new List<Category>());
           var data =  s.GetFromCache("deneme");
        }
    }

    #endregion

    /// <summary>
    /// Getir uygulamasındaki Kategorileri ve bu kategorilere ait alt kategori bilgisini cacheden yani ram üzerinden okuyacağız. Böylece her seferinde dbden çekmediğimiz için daha hızlı bir sonuç döndüreceğiz. Bu gibi çok fazla crud operasyonun yapılmadığı sınıflarımızı ramden okuyabiliriz. aynı zamanda sepet gibi işlemler içinde tanımlanabilir. Çok fazla insert update işlemi olmayan verilerimiz için cache mekanizmasını kullanırız.
    /// </summary>
    public interface ICacheService<TResult> where TResult:class
    {
        /// <summary>
        ///  Aynı sessiondaki gibi string key göre içerisinde obje tanımlayacağız.
        ///  
        /// </summary>
        /// <param name="cacheData"></param>
        void SetCache(string key,TResult cacheData);

        /// <summary>
        /// Json string deseralize edip key göre cache storedan okuyacağız.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TResult GetFromCache(string key); 
    }
}
