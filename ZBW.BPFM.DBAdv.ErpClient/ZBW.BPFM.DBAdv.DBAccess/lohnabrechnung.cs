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
    
    public partial class Lohnabrechnung
    {
        public int Id { get; set; }
        public int FkLohnabrechnungMitarbeiter { get; set; }
        public System.DateTime Datum { get; set; }
        public Nullable<decimal> Sollstunden { get; set; }
        public Nullable<decimal> Iststunden { get; set; }
        public Nullable<decimal> Ferienbezug { get; set; }
        public Nullable<decimal> Krankheitstunden { get; set; }
        public Nullable<decimal> Unbezahltstunden { get; set; }
        public Nullable<decimal> Eoersatzberechtigtestunden { get; set; }
        public decimal Stundenlohn { get; set; }
        public System.Guid SsmaRowid { get; set; }
    
        public virtual Mitarbeiter mitarbeiter { get; set; }
    }
}
