//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZBW.BPFM.DBAdv.DBAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class lieferschein
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lieferschein()
        {
            this.lieferschein1 = new HashSet<lieferschein>();
        }
    
        public int Id { get; set; }
        public System.DateTime Lieferdatum { get; set; }
        public Nullable<int> fk_Lieferschein_Rechnung { get; set; }
        public Nullable<int> fk_Lieferschein_Lieferschein { get; set; }
        public int fk_Lieferschein_Bestellung { get; set; }
        public int fk_Lieferschein_Adresse { get; set; }
    
        public virtual adresse adresse { get; set; }
        public virtual bestellung bestellung { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lieferschein> lieferschein1 { get; set; }
        public virtual lieferschein lieferschein2 { get; set; }
        public virtual rechnung rechnung { get; set; }
    }
}
