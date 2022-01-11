using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Entites
{

    public class Sample2: AuditableEntity
    {
        public Sample2()
        {
           
        }
    }
    public class Sample : Entity, IAuditableEntity
    {
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UpdatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    /// <summary>
    /// Denetelenebilir Entity Kimin tarafından Updated Created yapıldığı bilgisini tutacağız
    /// </summary>
    public interface IAuditableEntity
    {
        // Bu entity önemli ürün gibi bir nesne ise bu alanları kesinlikle tutarız.
        
        /// <summary>
        /// Entity Hangi tarih de ilk eklendi
        /// </summary>
        DateTime CreatedDate {  get;  set; }
        /// <summary>
        /// Entity Hangi Tarihte ilk güncellendi
        /// </summary>
         DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Kim tarafından eklendi
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Kim tarafından güncellendi.
        /// </summary>
        string UpdatedBy { get; set; }

    }
}
