# ZBW.BPFM.DBAdv.ErpClient
Ein WPF-Client mit Entity-Frameworks DB-First Anbindung.

## Pre-Requirements
- Microsoft SQL Server 2017
- .NET Framework 4.6.1

## Getting Started
### Schritt 1: Datenbank Backup restoren
Das mitgelieferte .bak File im SQL Server Studio restoren, am besten mit dem Namen "ZBW.BPFM.DBAdv.ErpDb"

### Schritt 2: Connection-String setzen

#### Im Release-Binary Verzeichnis
Beim Binary-Zip im File "ZBW.BPFM.DBAdv.ErpClient.exe.config" 

In der Sektion "connectionStrings", im Parameter "ErpContext", im Attribut "connectionString":
- suchen nach "SINTHORAS\MSSQLSERVER2017"
- ersetzen mit lokalem MSSQL SERVER 2017 Server (z.B. localhost oder localhost\MSSQLSERVER2017)

- suchen nach "Zbw.Bpfm.DbAdv.ErpDb"
- ersetzen mit dem Namen der Datenbank (.bak file, siehe Pre-Requirements)

Speichern

#### Im app.config
Im Sourcecode nach im File app.config die obigen Anweisungen wiederholen oder die Werte aus dem .exe.config übernehmen

### Run or Debug
Den Releasebuild "ZBW.BPFM.DBAdv.ErpClient.exe" starten oder im Visual Studio das Projekt "ZBW.BPFM.DBAdv.ErpClient" Debuggen.
