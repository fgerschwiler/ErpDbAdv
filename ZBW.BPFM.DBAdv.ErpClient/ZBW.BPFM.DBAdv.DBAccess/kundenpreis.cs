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
    
    public partial class Kundenpreis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kundenpreis()
        {
            this.bestellposition = new HashSet<Bestellposition>();
        }
    
        public int Id { get; set; }
        public int FkKundenpreisArtikel { get; set; }
        public int FkKundenpreisKunde { get; set; }
        public decimal Verkaufspreis { get; set; }
        public Nullable<System.DateTime> Gueltigbis { get; set; }
        public string Waehrung { get; set; }
        public Nullable<int> Rabatt { get; set; }
    
        public virtual Artikel artikel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bestellposition> bestellposition { get; set; }
        public virtual Kunde kunde { get; set; }
    }
}
