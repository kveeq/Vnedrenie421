//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PenShop.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int id_customer { get; set; }
        public int id_pen { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Pen Pen { get; set; }
    }
}
