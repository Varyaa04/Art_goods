//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Art_goods.Goods
{
    using System;
    using System.Collections.Generic;
    
    public partial class Goods_Art
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goods_Art()
        {
            this.Basket = new HashSet<Basket>();
        }
    
        public int idGoods_Art { get; set; }
        public string Article { get; set; }
        public int Name { get; set; }
        public int Unit { get; set; }
        public int Cost { get; set; }
        public int MaxSale { get; set; }
        public int Manufacturer { get; set; }
        public int Provider { get; set; }
        public int Category { get; set; }
        public int ActDisc { get; set; }
        public int OnStock { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string CurrentPhoto
        {
            get
            {
                if (string.IsNullOrEmpty(Image) || String.IsNullOrWhiteSpace(Image))
                {
                    return "/Image/picture.png";
                }
                else
                {
                    return "/Image/" + Image;
                }
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Basket { get; set; }
        public virtual Category Category1 { get; set; }
        public virtual Manufacturer Manufacturer1 { get; set; }
        public virtual Name_goods Name_goods { get; set; }
        public virtual Provider Provider1 { get; set; }
        public virtual Unit Unit1 { get; set; }
    }
}
