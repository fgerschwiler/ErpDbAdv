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
    
    public partial class Mitarbeiter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mitarbeiter()
        {
            this.lohnabrechnung = new HashSet<Lohnabrechnung>();
            this.kunde = new HashSet<Kunde>();
        }
    
        public int Id { get; set; }
        public int FkMitarbeiterPerson { get; set; }
        public int FkMitarbeiterAbteilung { get; set; }
        public decimal Salaer { get; set; }
        public int Arbeitspensum { get; set; }
        public decimal Feriensaldo { get; set; }
        public Nullable<decimal> Ueberstundensaldo { get; set; }
        public string Zivilstand { get; set; }
        public Nullable<int> Anzahlkinder { get; set; }
        public string Konfession { get; set; }
        public string Ahvnr { get; set; }
        public System.Guid SsmaRowid { get; set; }
    
        public virtual Abteilung abteilung { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lohnabrechnung> lohnabrechnung { get; set; }
        public virtual Person person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kunde> kunde { get; set; }
    }
}
