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
    
    public partial class zahlung
    {
        public int Id { get; set; }
        public int fk_Zahlung_Kunde { get; set; }
        public int fk_Zahlung_Rechnung { get; set; }
        public decimal Betrag { get; set; }
    
        public virtual kunde kunde { get; set; }
        public virtual rechnung rechnung { get; set; }
    }
}
