# Star Citizen Handle Query

Overlay zur Abfrage von Star Citizen Spielern und ihrer Organisationszugehörigkeiten

![Handle Query](/Star%20Citizen%20Handle%20Query/Screenshots/MainWindow_LogMonitor.png?raw=true "Star Citizen Handle Query")

Das Tool-Hauptfenster kann nur dann im Vordergrund des Spiels dargestellt werden, wenn das Star Citizen Fenster im (randlosen) Fenstermodus läuft.

## Discord Server

Für das Tool existiert ein Discord Server, auf dem man über das Tool diskutieren kann.
https://discord.com/invite/WmzNY3mCm6

## Einstellungen

![Settings](/Star%20Citizen%20Handle%20Query/Screenshots/Settings.png?raw=true "Einstellungen")

### Anzeige
- __Sprache:__ Hier kann die Sprache für das Tool eingestellt werden. Standardmäßig stehen die Sprachen `Deutsch`, `Deutsch (Brevity Code)` und `English` zur Auswahl.
- __Affiliationen Maximum:__ Hier kann angegeben werden, wie viele Affiliationen maximal dargestellt werden sollen.
- __Unkenntliche Affiliationen ausblenden:__ Hier kann angegeben werden, ob unkenntlich gemachte Affiliationen ausgeblendet werden sollen
- __Stream Live-Status ausblenden:__ Angabe, ob der Twitch.tv Stream Live-Status eines Handles ausgeblendet werden soll
- __Bei Programmstart nach Update suchen:__ Angabe, ob bei jedem Programmstart geprüft werden soll, ob ein Programmupdate zur Verfügung steht
  - Ausschließlich wenn ein Update zur Verfügung steht, wird eine Benachrichtigung angezeigt.
- __Log-Monitor anzeigen:__ Angabe, ob der Log-Monitor angezeigt werden soll
- __Log-Einträge Maximum:__ Angabe, wie viele Einträge maximal im Log-Monitor angezeigt werden sollen
- __Log-Eintrag Anzeigedauer:__ Anzeigedauer eines Logeintrags in Minuten (`0` = unendlich)
- __Beziehungen anzeigen:__ Angabe, ob das Beziehungen-Fenster angezeigt werden soll
- __Beziehungen alphabetisch sortieren:__ Angabe, ob die Einträge auf dem Beziehungen-Fenster alphabetisch sortiert werden sollen (Standard: Reihenfolge, in welcher die Einträge hinzugefügt werden)
- __Beziehungen-Einträge Max.:__ Angabe, wie viele Einträge maximal auf dem Beziehungen-Fenster dargestellt werden sollen
### Fenster
- __Deckkraft:__ Hier kann eingestellt werden, wie hoch die Deckkraft des Fensters sein soll. Es können Werte zwischen 50% (halb transparent) und 100% (nicht transparent) eingegeben werden.
- __Globale Taste:__ Hier kann die Taste angegeben werden, welche global abgefangen wird, um das Programm in den Vordergrund zu holen. Zusätzlich können Modifikatoren (Strg, Alt und Umschalt) angegeben werden, um eine Tastenkombination angeben zu können.
- __Mauseingaben ignorieren:__ Wird diese Einstellung aktiviert, gehen sämtliche Mausklicks durch das Fenster durch in das dahinter liegende Programm.
- __Erreichbariekt via Alt + Tab:__ Wird diese Einstellung aktiviert, kann das Fenster via Tastenkobination `Alt` + `Tab` erreicht werden.
- __Position merken:__ Ist diese Einstellung aktiviert, merkt sich das Programm beim Beenden die Position des Hauptfensters und stellt sie beim Start wieder her.
### Lokaler Cache
- __Maximales Alter:__ Hier kann für den lokalen Cache das maximale Alter in Tagen angegeben werden, wann die Informationen eines bereits zuvor abgefragten Handles erneut via Star Citizen Webseite abgefragt werden sollen. Es können Werte zwischen 0 und 365 Tagen angegeben werden. Die Angabe von 0 Tagen wird die Handle-Informationen immer via Star Citizen Webseite abfragen.
### Schaltflächen
- __Speichern:__ Speichert die vorgenommenen Einstellungen und schließt das Einstellungen-Fenster
- __Schließen:__ Schließt das Einstellungen-Fenster, ohne die vorgenommenen Einstellungen zu speichern
- __Standard:__ Stellt die Standard-Einstellungen wieder her, mit Ausnahme der Sprache

## Kontextmenü Taskleiste

Das Kontextmenü kann via Mausrechtsklick auf das Tool-Icon unten rechts in der Windows-Taskbar erreicht werden.

![ContextMenu](/Star%20Citizen%20Handle%20Query/Screenshots/ContextMenu.png?raw=true "Kontextmenü")

- __Anzeigen:__ Falls das Fenster nicht sichtbar ist, wird es angezeigt und die Handle-Eingabebox erhält den Eingabefokus
- __Einstellungen:__ Öffnet das Einstellungen-Fenster
- __Lokaler Cache:__ Öffnet ein Fenster mit Informationen zum lokalen Cache
- __Nach Update suchen:__ Sucht auf GitHub nach einem Update für das Tool
- __Über:__ Öffnet ein Hinweisfenster mit Informationen zur Version des Tools
- __Beenden:__ Beendet das Tool

## Lokaler Cache

![LocalCache](/Star%20Citizen%20Handle%20Query/Screenshots/LocalCache.png?raw=true "Lokaler Cache")
- __Tabelle:__ Hier werden Informationen zu den im lokalen Cache gespeicherten Handles dargestellt. Außerdem kann in der Spalte `Kommentar` ein Kommentar eingegeben werden, welcher sowohl dort als auch im Hauptfenster dargestellt wird.
- __Handle- und Organisation-Darstellung:__ Unter der Tabelle werden die Informationen zum ausgewählten Handle und zu dessen Organisation so dargestellt, wie sie im Hauptfenster dargestellt werden.
- __Cache leeren:__ Durch Klicken dieser Schaltfläche kann der komplette lokale Cache geleert werden. Bevor der lokale Cache geleert wird, muss der Benutzer diesen Vorgang bestätigen.
- __Ordner öffnen:__ Öffnet den Ordner, welcher den lokalen Cache enthält
- __Schließen:__ Schließt das Fenster

## Hauptfenster

![Handle Query](/Star%20Citizen%20Handle%20Query/Screenshots/MainWindow.png?raw=true "Hauptfenster")
- Hier kann der eindeutige Name eines Star Citizen Spielers in die Handle-Eingabebox eingegeben werden (maximal 60 Zeichen). Durch die Betätigung der Enter-Taste wird die Abfrage ausgelöst und kurze Zeit später das Ergebnis der Abfrage unter der Handle-Eingabebox dargestellt.
  - Wird währenddessen die `Strg`-Taste gedrückt gehalten, wird das Auslesen der Handle-Informationen inklusive Avatare (Handle, Organisation und Affiliationen) via Star Citizen Webseite erzwungen.
  - Drückt man, während die Handle-Eingabebox den Fokus hat, die `+`-Taste, kann man einen Kommentar zum aktuellen Handle eingeben. Durch Betätigung der `Enter`-Taste, wird der Kommentar im lokalen Cache gespeichert. Verliert die Kommentar-Eingabebox den Fokus oder es wird die `Esc`-Taste gedrückt, wird die Eingabe des Kommentars abgebrochen.
  - Wird die Handle-Eingabebox geleert, wird ein gegebenenfall zuvor ermitteltes Ergebnis ausgeblendet.
- Durch die Betätigung der Esc-Taste wird das Hauptfenster ausgeblendet.
- Wurde eine globale Taste(nkobination) in den Einstellungen angegeben, kann das Fenster jederzeit mit dieser Taste(nkombination) wieder angezeigt werden.
- Sofern der Stream Live-Status dargestellt werden soll, wird unten rechts im Handle-Informationsfenster der Twitch.tv Live-Status des Handles angezeigt. Dieser kann folgende Werte enthalten:
  - `...` = Live-Status wird ermittelt
  - `N/A` = Im Handle-Profil ist kein Twitch.tv-Konto verknüpft
  - `OFF` = Im Handle-Profil ist ein Twitch.tv-Konto verknüpft, es wird aber gerade nicht gestreamt
  - `LIVE` = Im Handle-Profil ist ein Twitch.tv-Konto verknüpft und es wird gerade aktiv gestreamt
  - `ERR` = Beim Aufruf des Community-Hub-Profils des Handles gab es einen Fehler / Timeout (maximale Wartezeit: 10 Sekunden)
- Per Tastenkürzel kann der Beziehungsstatus des aktuellen Handles festgelegt werden (auch dann, wenn die Anzeige des Beziehungen-Fensters nicht aktiviert ist):
  - `Strg + 1`: Freundlich
  - `Strg + 2`: Neutral
  - `Strg + 3`: Unbekannt
  - `Strg + 4`: Feindlich
  - `Strg + 0`: Beziehungsstatus entfernen
- Sofern in den Einstellungen die Anzeige des Beziehungen-Fensters aktiviert ist, können die Filter via Tastenkombination umgeschaltet werden:
  - `Alt + 1`: Freundlich
  - `Alt + 2`: Neutral
  - `Alt + 3`: Unbekannt
  - `Alt + 4`: Feindlich
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
  - Wenn in den Einstellungen die Anzeige des Beziehungen-Fensters aktiviert ist, werden unterhalb des Handle-Bereichs Schaltflächen dargestellt, mit denen man via Mauslinksklick die Beziehung des Handles festlegen kann. Die aktuell zugewiesene Beziehung wird als farblicher Balken rechts am Handle-Avatar dargestellt. Zusätzlich wird ein Eintrag auf dem Beziehungen-Fenster erstellt oder aktualisiert.

## Log-Monitor Fenster

![Handle Query](/Star%20Citizen%20Handle%20Query/Screenshots/LogMonitor.png?raw=true "Log-Monitor")

Wenn in den Einstellungen die Anzeige des Log-Monitors aktiviert ist, wird das Fenster angezeigt. Hier wird die Star Citizen `Games.log`-Datei in nahezu Echtzeit ausgelesen, um Informationen zu gestorbenen / getöteten Spielercharakteren auf dem eigenen Server darzustellen.
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
  - Rechts daneben werden Uhrzeit und Spieler-Handle angezeigt
  - Wenn der Spieler in einer Zone gestorben ist, in der es ein lokales Inventar gibt, wird ganz rechts zusätzlich ein `Ressourcen`-Symbol dargestellt.
  - Ein Mauslinksklick auf eine der genannten Informationen trägt den Handle des Spielers in das Hauptfenster ein und startet direkt eine Handle-Abfrage. Wird dabei die `Strg`-Taste gedrückt gehalten, wird ein Auslesen der Handle-Informationen von der RSI-Webseite erzwungen.

## Beziehungen Fenster

![Handle Query](/Star%20Citizen%20Handle%20Query/Screenshots/Relations.png?raw=true "Beziehungen")

Hier werden sämtliche Handles aufgelistet, denen eine Beziehung zugewiesen wurde. Dabei wird der Beziehungsstatus farblich vor dem Handle dargestellt:
- `Grün`: Freundlich
- `Grau`: Neutral
- `Orange`: Unbekannt
- `Rot`: Feindlich
Diese Liste wird beim Beenden des Tools gespeichert und beim erneuten Start des Tools wieder dargestellt.

# Titelleiste
- Via Mauslinksklick kann per Mauslinksklick auf eines der farbigen Vierecke der Filter für diesen Beziehungsstatus umgeschaltet werden. Die Filter können ebenfalls aus dem Hauptfenster heraus via Tastenkombination umgeschaltet werden:
  - `Alt + 1`: Freundlich
  - `Alt + 2`: Neutral
  - `Alt + 3`: Unbekannt
  - `Alt + 4`: Feindlich
  - `Alt + 0`: Alle Filter
- Via Mauslinksklick auf das Mülltonnen-Symbol kann, sofern mindestens ein Eintrag enthalten ist, die Liste gelöscht werden.

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
