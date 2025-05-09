# Star Citizen Handle Query

Overlay zur Abfrage von Star Citizen Spielern und ihrer Organisationszugehörigkeiten

![Handle Query](/Screenshots/MainWindow.png?raw=true "Star Citizen Handle Query")

Das Tool-Hauptfenster kann nur dann im Vordergrund des Spiels dargestellt werden, wenn das Star Citizen Fenster im (randlosen) Fenstermodus läuft.

## Verwandtes Projekt

### SCHQ_Web

Das Web-Interface `SCHQ_Web` ermöglicht die Konfiguration des gRPC-Servers. Außerdem ist es damit möglich, die Beziehungen der Kanäle zu synchronisieren.

Repository-URL: https://github.com/Kuehlwagen/SCHQ_Web

## Discord Server

Für das Tool existiert ein Discord Server, auf dem man über das Tool diskutieren kann.
https://discord.com/invite/WmzNY3mCm6

## Einstellungen

![Settings](/Screenshots/Settings.png?raw=true "Einstellungen")

### Anzeige
- __Sprache:__ Hier kann die Sprache für das Tool eingestellt werden. Standardmäßig stehen die Sprachen `Deutsch`, `Deutsch (Brevity Code)` und `English` zur Auswahl.
- __Affiliationen Maximum:__ Hier kann angegeben werden, wie viele Affiliationen maximal dargestellt werden sollen (Min. 0, Max. 9).
- __Unkenntliche Affiliationen ausblenden:__ Hier kann angegeben werden, ob unkenntlich gemachte Affiliationen ausgeblendet werden sollen
- __Stream Live-Status ausblenden:__ Angabe, ob der Twitch.tv Stream Live-Status eines Handles ausgeblendet werden soll
- __Bei Programmstart nach Update suchen:__ Angabe, ob bei jedem Programmstart geprüft werden soll, ob ein Programmupdate zur Verfügung steht
  - Ausschließlich wenn ein Update zur Verfügung steht, wird eine Benachrichtigung angezeigt.
- __Alternative DPI-Berechnung verwenden:__ Angabe, ob eine alternative DPI-Berechnung `DpiUnaware` verwendet werden soll. Das kann sinnvoll sein, wenn Monitore unterschiedliche Skalierungen verwenden und dadurch Fenster und/oder Kontrollelemente nicht korrekt dargestellt werden. Die Aktivierung dieser Einstellung kann dazu führen, dass Kontrollelemente verwaschen aussehen. Wenn diese Einstellung nicht aktiviert ist, wird die modernere DPI-Berechnung `PerMonitorV2` verwendet.
### Fenster
- __Deckkraft:__ Hier kann eingestellt werden, wie hoch die Deckkraft des Fensters sein soll. Es können Werte zwischen 50% (halb transparent) und 100% (nicht transparent) eingegeben werden (Min. 50, Max. 100).
- __Globale Taste:__ Hier kann die Taste angegeben werden, welche global abgefangen wird, um das Programm in den Vordergrund zu holen. Zusätzlich können Modifikatoren (Strg, Alt und Umschalt) angegeben werden, um eine Tastenkombination angeben zu können.
- __Mauseingaben ignorieren:__ Wird diese Einstellung aktiviert, gehen sämtliche Mausklicks durch das Fenster durch in das dahinter liegende Programm.
- __Erreichbariekt via Alt + Tab:__ Wird diese Einstellung aktiviert, kann das Fenster via Tastenkobination `Alt` + `Tab` erreicht werden.
- __Position merken:__ Ist diese Einstellung aktiviert, merkt sich das Programm beim Beenden die Position des Hauptfensters und stellt sie beim Start wieder her.
- __ESC blendet das Fenster aus:__ Wird diese Einstellung aktiviert, werden alle Fenster ausgeblendet, wenn eines der SCHQ-Fenster den Fokus hat und die `ESC`-Taste gedrückt wird.
### Lokaler Cache
- __Maximales Alter:__ Hier kann für den lokalen Cache das maximale Alter in Tagen angegeben werden, wann die Informationen eines bereits zuvor abgefragten Handles erneut via Star Citizen Webseite abgefragt werden sollen (Min. 0, Max. 365). Es können Werte zwischen 0 und 365 Tagen angegeben werden. Die Angabe von 0 Tagen wird die Handle-Informationen immer via Star Citizen Webseite abfragen.
### Orte (Alt + Eingabe)
- __Orte anzeigen:__ Angabe, ob das Orte-Fenster angezeigt werden soll
- __Einträge Maximum:__ Angabe, wie viele Einträge maximal im Orte-Fenster angezeigt werden sollen (Min. 1, Max. 50)
- __Linke Maustaste:__ URL, die bei der Betätigung der linken Maustaste geöffnet werden soll (inklusive Platzhalter)
- __Mittlere Maustaste:__ URL, die bei der Betätigung der mittleren Maustaste geöffnet werden soll (inklusive Platzhalter)
- __Rechte Maustaste:__ URL, die bei der Betätigung der rechten Maustaste geöffnet werden soll (inklusive Platzhalter)
- Folgende Platzhalter können verwendet werden:
  - `{Name}`: Name des Ortes
  - `{Type}`: Typ des Ortes
  - `{ParentBody}`: Übergeordnetes Objekt
  - `{ParentStar}`: Übergeordneter Stern
  - `{CoordinateX}`: X-Koordinate
  - `{CoordinateY}`: Y-Koordinate
  - `{CoordinateZ}`: Z-Koordinate
  - `{ThemeImage}`: URL zum Beispielbild aus dem Wiki
  - `{WikiLink}`: Link zum Wiki (starcitizen.tools)
  - `Quantum`: Angabe, ob der Ort angesprungen werden kann
  - `Private`: Angabe, ob der Ort privat ist
  - `Affiliation`: Angabe, welche Gruppe den Ort bewacht
- Mehrere Einträge können Pipe `|` getrennt angegeben werden. Sobald ein Eintrag nach der Ersetzung der Platzhalter mindestens ein Zeichen enthält, wird dieser Wert verwendet. Beispiel: `{WikiLink}|https://starcitizen.tools/{Name}` (wenn `{WikiLink}` keinen Text zurückgibt, wird stattdessen `https://starcitizen.tools/{Name}` verwendet)
### Beziehungen
- __Beziehungen anzeigen:__ Angabe, ob das Beziehungen-Fenster angezeigt werden soll
  - __Alphabetisch sortieren:__ Angabe, ob die Einträge auf dem Beziehungen-Fenster alphabetisch sortiert werden sollen (Standard: Reihenfolge, in welcher die Einträge hinzugefügt werden)
  - __Einträge Maximum:__ Angabe, wie viele Einträge maximal auf dem Beziehungen-Fenster dargestellt werden sollen (es werden unendlich viele Einträge im lokalen Cache gespeichert; Min. 1, Max. 50)
  - __gRPC Server-URL:__ Hier kann die vollständige URL eines gRPC-Servers (`SCHQ_Web`) angegeben werden, um die Beziehungen mit anderen Benutzern zu synchronisieren
  - __gRPC Server-Kanal:__ Hier kann der zu verwendende Kanal angegeben werden, welcher für den gRPC-Server verwendet werden soll. Alle Benutzer, die den gleichen Kanal verwenden, synchronisieren die Beziehungen untereinander.
  - __Zahnrad-Schaltfläche:__ Wenn eine `gRPC Server-URL` angegeben wurde, können bei Klick auf diese Schaltfläche die gRPC-Kanäle ausgelesen werden (siehe SCHQ_Web gRPC-Kanalauswahl).
  - __gRPC Kanal-Passwort:__ Angabe des Kanalpassworts (nötig, wenn der Kanal so konfiguriert ist, dass man ohne Angabe des Passworts keine Berechtigungen hat)
  - __gRPC-Synchronisierung bei Programmstart:__ Angabe, ob beim Programmstart die Synchronisierung automatisch gestartet werden soll
### Log-Monitor
- __Log-Monitor anzeigen:__ Angabe, ob der Log-Monitor angezeigt werden soll
  - __Einträge Maximum:__ Angabe, wie viele Einträge maximal im Log-Monitor angezeigt werden sollen (Min. 1, Max. 50)
  - __Eintrag Anzeigedauer:__ Anzeigedauer eines Logeintrags in Minuten (Min. 0, Max. 60; `0` = unendlich)
  - __Spielertode anzeigen:__ Angabe, ob Spielertode im Log-Monitor angezeigt werden sollen
  - __Ladebildschirm-Dauer anzeigen:__ Angabe, ob die Ladebildschirm-Dauer im Log-Monitor angezeigt werden sollen
  - __Komplette Datei auswerten:__ Angabe, ob die komplette Log-Datei ausgewertet und die Ergebnisse dargestellt werden sollen. Wenn deaktiviert, wird ausschließlich der Dateiinhalt ab dem Start des Auslesens der Log-Datei berücksichtigt.
### Schaltflächen
- __Speichern:__ Speichert die vorgenommenen Einstellungen und schließt das Einstellungen-Fenster
- __Schließen:__ Schließt das Einstellungen-Fenster, ohne die vorgenommenen Einstellungen zu speichern
- __Standard:__ Stellt die Standard-Einstellungen wieder her, mit Ausnahme der Sprache

## SCHQ_Web gRPC-Kanalauswahl

![Kanalauswahl](/Screenshots/Settings_gRPC.png?raw=true "gRPC-Kanalauswahl")

Auf dem gRPC-Kanalauswahl Fenster können die Kanäle eines gRPC-Servers ausgelesen werden. Beim Öffnen des Fensters werden die Kanäle des gRPC-Servers initial geladen.

- __Kanäle Laden Schaltfläche:__ Mit dieser Schaltfläche können die Kanäle des Servers erneut geladen werden.
- __Kanäle-Tabelle:__ Hier werden die Kanäle des gRPC-Servers aufgelistet.
  - __Kanalname:__ Name des Kanals
  - __Berechtigungen:__ Angabe, welche Berechtigungen ein Benutzer ohne Angabe des Passworts hat
- __OK-Schaltfläche:__ Mit dieser Schaltfläche wird das Fenster geschlossen und der in der Tabelle ausgewählte Kanal auf das Einstellungen-Fenster übernommen.
- __Schließen-Schaltfläche:__ Mit dieser Schaltfläche wird das Fenster geschlossen. Dabei wird der in der Tabelle ausgewählte Kanal nicht auf das Einstellungen-Fenster übernommen.

## Kontextmenü Taskleiste

Das Kontextmenü kann via Mausrechtsklick auf das Tool-Icon unten rechts in der Windows-Taskbar erreicht werden.

![ContextMenu](/Screenshots/ContextMenu.png?raw=true "Kontextmenü")

- __Anzeigen:__ Falls das Fenster nicht sichtbar ist, wird es angezeigt und die Handle-Eingabebox erhält den Eingabefokus
- __Einstellungen:__ Öffnet das Einstellungen-Fenster
- __Lokaler Cache:__ Öffnet ein Fenster mit Informationen zum lokalen Cache
- __Nach Update suchen:__ Sucht auf GitHub nach einem Update für das Tool
- __Über:__ Öffnet ein Hinweisfenster mit Informationen zur Version des Tools
- __Beziehungen bereitstellen:__ Stellt die Beziehungen in einer JSON-Datei bereit (nur sichtbar, wenn das Beziehungen-Fenster dargestellt werden soll)
- __Beziehungen übernehmen:__ Übernimmt die Beziehungen aus einer zuvor bereitgestellten JSON-Datei (nur sichtbar, wenn das Beziehungen-Fenster dargestellt werden soll)
- __Beenden:__ Beendet das Tool

## Lokaler Cache

![LocalCache](/Screenshots/LocalCache.png?raw=true "Lokaler Cache")
- __Tabelle:__ Hier werden Informationen zu den im lokalen Cache gespeicherten Handles dargestellt. Außerdem kann in der Spalte `Kommentar` ein Kommentar eingegeben werden, welcher sowohl dort als auch im Hauptfenster dargestellt wird.
- __Handle- und Organisation-Darstellung:__ Unter der Tabelle werden die Informationen zum ausgewählten Handle und zu dessen Organisation so dargestellt, wie sie im Hauptfenster dargestellt werden.
- __Cache leeren:__ Durch Klicken dieser Schaltfläche kann der komplette lokale Cache geleert werden. Bevor der lokale Cache geleert wird, muss der Benutzer diesen Vorgang bestätigen.
- __Ordner öffnen:__ Öffnet den Ordner, welcher den lokalen Cache enthält
- __Schließen:__ Schließt das Fenster

## Hauptfenster

![Handle Query](/Screenshots/MainWindow.png?raw=true "Hauptfenster")
- Hier kann der eindeutige Name eines Star Citizen Spielers in die Handle-Eingabebox eingegeben werden (maximal 60 Zeichen). Durch die Betätigung der Enter-Taste wird die Abfrage ausgelöst und kurze Zeit später das Ergebnis der Abfrage unter der Handle-Eingabebox dargestellt.
  - Wird währenddessen die `Strg`-Taste gedrückt gehalten, wird das Auslesen der Handle-Informationen inklusive Avatare (Handle, Organisation und Affiliationen) via Star Citizen Webseite erzwungen.
  - Wird währenddessen die `Alt`-Taste gedrückt gehalten, bekommt das Orte-Fenster den Fokus, sodass man direkt den Namen eines Ortes eintippen kann.
  - Drückt man, während die Handle-Eingabebox den Fokus hat, die `+`-Taste, kann man einen Kommentar zum aktuellen Handle eingeben. Durch Betätigung der `Enter`-Taste, wird der Kommentar im lokalen Cache gespeichert. Verliert die Kommentar-Eingabebox den Fokus oder es wird die `Esc`-Taste gedrückt, wird die Eingabe des Kommentars abgebrochen.
  - Wird die Handle-Eingabebox geleert, wird ein gegebenenfall zuvor ermitteltes Ergebnis ausgeblendet.
- Durch die Betätigung der Esc-Taste wird das Hauptfenster ausgeblendet.
- Wurde eine globale Taste(nkobination) in den Einstellungen angegeben, kann das Fenster jederzeit mit dieser Taste(nkombination) wieder angezeigt werden.
- Sofern der Stream Live-Status dargestellt werden soll, wird unten rechts im Handle-Informationsfenster der Twitch.tv Live-Status des Handles angezeigt. Dieser kann folgende Werte enthalten:
  - `...` = Live-Status wird ermittelt
  - `OFF` = Es wird gerade nicht gestreamt
  - `LIVE` = Es wird gerade aktiv gestreamt
  - `ERR` = Beim Aufruf des Community-Hub-Profils des Handles gab es einen Fehler / Timeout (maximale Wartezeit: 10 Sekunden)
- Per Tastenkürzel kann der Beziehungsstatus des aktuellen Handles festgelegt werden (auch dann, wenn die Anzeige des Beziehungen-Fensters nicht aktiviert ist):
  - `Strg + 1`: Freundlich
  - `Strg + 2`: Neutral
  - `Strg + 3`: Unbekannt
  - `Strg + 4`: Feindlich
  - `Strg + 0`: Beziehungsstatus entfernen
- Per Tastenkürzel kann der Beziehungsstatus der aktuellen Hauptorganisation festgelegt werden (auch dann, wenn die Anzeige des Beziehungen-Fensters nicht aktiviert ist):
  - `Umschalt + 1`: Freundlich
  - `Umschalt + 2`: Neutral
  - `Umschalt + 3`: Unbekannt
  - `Umschalt + 4`: Feindlich
  - `Umschalt + 0`: Beziehungsstatus entfernen
- Sofern in den Einstellungen die Anzeige des Beziehungen-Fensters aktiviert ist, können die Filter via Tastenkombination umgeschaltet werden:
  - `Alt + 1`: Freundlich
  - `Alt + 2`: Neutral
  - `Alt + 3`: Unbekannt
  - `Alt + 4`: Feindlich
  - `Alt + 5`: Organisation
  - `Alt + 0`: Alle Filter
- Folgende Funktionen sind nur aktiv, wenn in den Einstellungen in der Gruppe `Fenster` das Kontrollkästchen `Mauseingaben ignorieren` nicht gesetzt ist:
  - Ein Mauslinksklick auf das Handle-Avatar öffnet die Informationsseite des Handles auf der Star Citizen Webseite (z.B. https://robertsspaceindustries.com/citizens/Kuehlwagen).
  - Ein Mauslinksklick auf ein Organisation-Avatar öffnet die Informationsseite der Organisation auf der Star Citizen Webseite (z.B. https://robertsspaceindustries.com/orgs/KRT).
  - Ein Mauslinksklick auf die Live-Status-Schaltfläche öffnet das Community-Hub-Profil des Handles (z.B. https://robertsspaceindustries.com/community-hub/user/Kuehlwagen).
  - Klickt man die Schloss-Schaltfläche links neben dem Handle-Schriftzug, wird das Hauptfenster entsperrt / gesperrt. Wenn das Hauptfenster entsperrt ist, kann mit gehaltener linker Maustaste auf dem Handle-Schriftzug das Hauptfenster verschoben werden. Drückt man stattdessen die mittlere Maustaste, wird das Hauptfenster an die Standard-Position (oben mittig) zurück gesetzt. Wird das Fenster 10 Pixel oder näher an einen Bildschirmrand gezogen, wird das Fenster an den Bildschirmrand verschoben, außer es wird währenddessen die `Alt`-Taste gedrückt gehalten. Wenn das Hauptfenster gesperrt ist, kann es nicht verschoben werden.
  - Klickt man die Lupe-Schaltfläche, wird die Abfrage der Handle-Informationen ausgelöst.
  - Wird währenddessen die `Strg`-Taste gedrückt gehalten, wird das Auslesen der Handle-Informationen inklusive Avatare (Handle, Organisation und Affiliationen) via Star Citizen Webseite erzwungen.
  - Klickt man die Zahnrad-Schaltfläche, wird das Einstellungen-Fenster geöffnet.
  - Ist die Einstellung `Position merken` in der Kategorie `Fenster` aktiviert, wird beim Beenden des Tools die Position des Hauptfensters in den Einstellungen gespeichert. Beim Start des Tools wird das Hauptfenster an die zuvor gespeicherte Position gesetzt. Hält man, während das Tool gestartet wird, die `Umschalt`-Taste gedrückt, wird das Fenster immer an die Standardposition (oben mittig) gesetzt.
  - Wenn in den Einstellungen die Anzeige des Beziehungen-Fensters aktiviert ist, werden unterhalb des Handle-Bereichs Schaltflächen dargestellt, mit denen man via Mauslinksklick die Beziehung des Handles und bei gedrückter Umschalt-Taste die Beziehung der Hauptorganisation festlegen kann. Die aktuell zugewiesene Beziehung wird als farblicher Balken rechts am Handle-Avatar dargestellt. Zusätzlich wird ein Eintrag auf dem Beziehungen-Fenster erstellt oder aktualisiert.

## Log-Monitor Fenster

![Handle Query](/Screenshots/LogMonitor.png?raw=true "Log-Monitor")

Wenn in den Einstellungen die Anzeige des Log-Monitors aktiviert ist, wird das Fenster angezeigt. Hier wird die Star Citizen `Games.log`-Datei in nahezu Echtzeit ausgelesen, um beispielsweise Informationen zu gestorbenen / getöteten Spielercharakteren auf dem eigenen Server darzustellen.
- Wenn das Hauptfenster entsperrt ist, wird auch das Log-Monitor-Fenster entsperrt und kann durch Mauslinksklick und ziehen des `Log-Monitor`-Schriftzugs an eine andere Positon gezogen werden. Ist die Einstellung `Position merken` aktiviert, wird die Position des Fensters beim Beenden des Tools gespeichert und beim Start wieder an die gespeicherte Position gesetzt.

Das Fenster enthält folgende Informationen:
- Titelleiste
  - Auf der linken Seite wird mit einem farbigen ausgefüllten Kreis dargestellt, in welchem Status sich der Log-Monitor gerade befindet:
    - `Rot`: Star Citizen ist nicht gestartet 
    - `Orange`: Star Citizen ist gestartet und die Games.log-Datei wird gerade initial geöffnet
    - `Grün`: Die Games.log-Datei wird in Echtzeit ausgelesen
  - Auf der rechten Seite wird ein Mülltonnen-Symbol angezeigt. Wenn mindestens ein Log-Eintrag dargestellt wird, können via Mauslinksklick alle Log-Einträge entfernt werden.
  - Beim Start eines Star Citizen-Prozesses werden die Log-Einträge automatisch entfernt.
- Log-Einträge
  - Auf der linken Seite wird ein Symbol angezeigt, welches folgende Informationen bereitstellen kann:
    - `Totenkopf`: Der Spieler ist gestorben und es wurde kein Leichnam erstellt (z.B. Selbstmord in einer Hauptstadt)
    - `Kreuz`: Der Spieler ist gestorben und es wurde ein Leichnam erstellt
    - `Totenkopf mit Zielmarkierung`: Der Spieler ist gestorben und wurde zur Rehabilitation nach Klescher geschickt
    - `Information`: Es handelt sich um einen Info-Eintrag (z.B.: Ladezeit im Ladebildschirm)
  - Rechts daneben werden Uhrzeit und weitere Informationen, welche zum Log-Typ passen, angezeigt
  - Links neben dem Handle eines Spielers wird die Beziehung zum Spieler farblich dargestellt, sofern zum Zeitpunkt der Erstellung eines Log-Eintrags eine Beziehung festgelegt ist.
  - Wenn Informationen zum Ort des Todes eines Spielers vorliegen, wird vor dem Handle ein Stern dargestellt. Die Informationen werden als Tooltip bereitgestellt.
  - Wenn der Spieler in einer Zone gestorben ist, in der es ein lokales Inventar gibt, wird ganz rechts zusätzlich ein `Ressourcen`-Symbol dargestellt.
  - Ein Mauslinksklick auf eine der genannten Informationen trägt den Handle des Spielers in das Hauptfenster ein und startet direkt eine Handle-Abfrage. Wird dabei die `Strg`-Taste gedrückt gehalten, wird ein Auslesen der Handle-Informationen von der RSI-Webseite erzwungen.

## Beziehungen Fenster

![Handle Query](/Screenshots/Relations.png?raw=true "Beziehungen")

Hier werden sämtliche Handles und Organisationen aufgelistet, denen eine Beziehung zugewiesen wurde. Dabei wird der Beziehungsstatus farblich vor dem Handle dargestellt:
- `Grün`: Freundlich
- `Grau`: Neutral
- `Orange`: Unbekannt
- `Rot`: Feindlich

Wenn Beziehungen synchronisiert werden und für einen Handle / eine Organisation ein Kommentar vorhanden ist, wird vor dem Namen ein Stern dargestellt. Der Kommentar wird als Tooltip bereitgestellt.
Organisationen werden via Organisation-Symbol auf der rechten Seite dargestellt.
Diese Liste wird beim Beenden des Tools gespeichert und beim erneuten Start des Tools wieder dargestellt.

### Titelleiste
- Via Mauslinksklick kann auf eines der farbigen Vierecke der Filter für diesen Beziehungsstatus umgeschaltet werden. Die Filter können ebenfalls aus dem Hauptfenster heraus via Tastenkombination umgeschaltet werden:
  - `Alt + 1`: Freundlich (grün)
  - `Alt + 2`: Neutral (grau)
  - `Alt + 3`: Unbekannt (gelb)
  - `Alt + 4`: Feindlich (rot)
  - `Alt + 5`: Organisation (cyan)
  - `Alt + 0`: Alle Filter
- Via Mauslinksklick auf das Mülltonnen-Symbol kann, sofern mindestens ein Eintrag enthalten ist, die Liste gelöscht werden.
- Wenn in den Einstellungen `gRPC Server-URL` und `gRPC Server-Kanal` angegeben sind, wird statt des Mülltonnen-Symbols der Status der Synchronisierung dargestellt:
  - `Rot`: Synchronisierung inaktiv
  - `Orange`: Synchronisierungsverbindung wird hergestellt
  - `Grün`: Synchronisierung aktiv
  - Via Mauslinksklick kann die Synchronisierung, abhängig vom aktuellen Synchronisierungsstatus (de-)aktiviert werden.

## Orte Fenster

![Handle Query](/Screenshots/Locations.png?raw=true "Orte")

Hier können Informationen zu Star Citizen Orten angezeigt werden.

### Titelleiste
- In der Titelleiste befindet sich eine Texteingabebox, in welche ein Orte-Name eingetippt werden kann. Nach 600 Millisekunden, oder durch die Betätigung der `Eingabe`-Taste, wird die Suche ausgelöst. Dabei werden alle Orte, welche den eingetippten Text im Namen enthalten, unterhalb der Titelleiste angezeigt. Orte, deren Namen mit dem eingegebenen Text beginnen, werden über den Orten angezeigt, die den eingegebenen Text im Namen beinhalten. Die Orte werden in beiden Fällen alphabetisch sortiert.
- Wenn die Texteingabebox geleert wird, oder das Orte-Fenster den Fokus verliert, wird das Suchergebnis entfernt.

### Ergebnisse
- Wird ein Mauslinksklick auf einem Ort ausgeführt, wird standardmäßig die VerseTime-Webseite `https://dydrmr.github.io/VerseTime/` des Ortes im Browser aufgerufen. Wählt man stattdessen die mittlere Maustaste, wird die Wiki-Webseite `https://starcitizen.tools/` des Ortes im Browser aufgerufen.

## Sprachen / Übersetzungen

Die standardmäßig mit ausgelieferten Sprachen werden über die eingebetteten Ressourcen des Programms ermittelt. Diese werden zusätzlich als Vorlage beim Programmstart in folgendes Verzeichnis geschrieben:
- `%LocalAppData%\Kuehlwagen@GitHub\SC_Handle_Query\{VERSION}\Localization\Templates\`

Die Sprachen aus den eingebetteten Ressourcen werden durch gültige Sprachdateien (JSON) aus dem Verzeichnis `%LocalAppData%\Kuehlwagen@GitHub\SC_Handle_Query\{VERSION}\Localization\` erweitert / überschrieben. Bindend ist hierfür das Feld `Language` der JSON-Sprachdatei.

Möchte man das Programm in eine neue Sprache übersetzen, kann man folgendermaßen vorgehen:
1. Die Sprachdatei `de-DE.json` aus dem Sprachen-Vorlageverzeichnis `%LocalAppData%\Kuehlwagen@GitHub\SC_Handle_Query\{VERSION}\Localization\Templates\` in das Sprachen-Verzeichnis `%LocalAppData%\Kuehlwagen@GitHub\SC_Handle_Query\{VERSION}\Localization\` kopieren
2. Die kopierte Datei im Sprachen-Verzeichnis umbenennen (z.B.: `xx-XX.json`)
3. Die Datei mit einem Texteditor öffnen und den Wert des Feldes `Language` von `Deutsch` nach `Xxxxxx` ändern
4. Die Werte aller anderen Felder übersetzen
5. Die Datei speichern
6. Das Programm (neu-)starten und die Einstellungen öffnen, um die neue Sprache auszuwählen

Felder und Gruppen, die in der Sprachdatei (JSON) nicht enthalten sind, erben von der Standardsprache `Deutsch`. Eine Sprachdatei mit dem Namen `xx-XX.json` und folgendem Inhalt ist demnach eine gültige Sprachdatei:

```json
{
  "Language": "Xxxxxx",
  "Window": {
    "Handle": "Name:"
  }
}
```

## Programm deinstallieren

Um das Programm vollständig zu deinstallieren und alle vom Programm erstellten Dateien zu entfernen, müssen folgende Verzeichnisse und Dateien gelöscht werden:
- Das Installationsverzeichnis, insbesondere die folgenden Dateien:
  - `SC_Handle_Query.dll`
  - `SC_Handle_Query.exe`
  - `SC_Handle_Query.deps.json`
  - `SC_Handle_Query.runtimeconfig.json`
- Das lokale App-Verzeichnis: `%LocalAppData%\Kuehlwagen@GitHub\SC_Handle_Query\` und ggf. auch das darüber liegende `Kuehlwagen@GitHub`-Verzeichnis
