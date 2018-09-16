# ZBW.BPFM.DBAdv.ErpClient

## Pre-Requirements
- Microsoft SQL Server 2017
- .bak File wiederherstellen
- .NET Framework 4.6.1

## Getting Started
### Connection-String setzen

#### Vor dem Ausführen
Beim Binary-Zip im File "ZBW.BPFM.DBAdv.ErpClient.exe.config" 

In der Sektion "connectionStrings", im Parameter "ErpContext", im Attribut "connectionString":
- suchen nach "SINTHORAS\MSSQLSERVER2017"
- ersetzen mit lokalem MSSQL SERVER 2017 Server (z.B. localhost oder localhost\MSSQLSERVER2017)

- suchen nach "Zbw.Bpfm.DbAdv.ErpDb"
- ersetzen mit dem Namen der Datenbank (.bak file, siehe Pre-Requirements)

Speichern

#### Vor dem Debuggen
Im Sourcecode nach im File app.config die obigen Anweisungen wiederholen oder die Werte aus dem .exe.config übernehmen

### Run or Debug
Den Releasebuild "ZBW.BPFM.DBAdv.ErpClient.exe" starten oder im Visual Studio das Projekt "ZBW.BPFM.DBAdv.ErpClient" Debuggen.
