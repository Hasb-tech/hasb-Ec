//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SanjyShop.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ID_PROOF_TYPES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ID_PROOF_TYPES()
        {
            this.SANJY_SHOP_REGISTRATION = new HashSet<SANJY_SHOP_REGISTRATION>();
        }
    
        public int Id_proof_Id { get; set; }
        public string Id_proof_Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANJY_SHOP_REGISTRATION> SANJY_SHOP_REGISTRATION { get; set; }
    }
}
