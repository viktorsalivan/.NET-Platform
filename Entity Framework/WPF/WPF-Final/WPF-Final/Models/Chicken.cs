//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Contexts;

    public partial class Chicken
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chicken()
        {
            this.Reports = new HashSet<Report>();
        }
    
        public int id { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public int Eggs { get; set; }
        public int IdBreed { get; set; }
        public int IdWorkshop { get; set; }
        public int IdWorker { get; set; }
        
        public virtual Breed Breed { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual Workshop Workshop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}
