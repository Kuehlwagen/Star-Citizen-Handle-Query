# Star Citizen Handle Query

Overlay zur Abfrage von Star Citizen Spielern und ihrer Organisationszugehörigkeiten

![Handle Query](/Star%20Citizen%20Handle%20Query/Screenshots/MainWindow.png?raw=true "Handle Query")

Das Tool-Hauptfenster kann nur dann im Vordergrund des Spiels dargestellt werden, wenn das Star Citizen Fenster im (randlosen) Fenstermodus läuft.

## Einstellungen

![Settings](/Star%20Citizen%20Handle%20Query/Screenshots/Settings.png?raw=true "Settings")

### Anzeige
- __Sprache:__ Hier kann die Sprache für das Tool eingestellt werden. Zur Verfügung stehen die Sprachen `Deutsch` und `English`.
- __Affiliationen Maximum:__ Hier kann angegeben werden, wie viele Affiliationen maximal dargestellt werden sollen.
- __Unkenntliche Affiliationen ausblenden:__ Hier kann angegeben werden, ob unkenntlich gemachte Affiliationen ausgeblendet werden sollen
- __Bei Programmstart nach Update suchen:__ Angabe, ob bei jedem Programmstart geprüft werden soll, ob ein Programmupdate zur Verfügung steht
  - Ausschließlich wenn ein Update zur Verfügung steht, wird eine Benachrichtigung angezeigt.
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

![ContextMenu](/Star%20Citizen%20Handle%20Query/Screenshots/ContextMenu.png?raw=true "ContextMenu")
- __Anzeigen:__ Falls das Fenster nicht sichtbar ist, wird es angezeigt und die Handle-Eingabebox erhält den Eingabefokus
- __Einstellungen:__ Öffnet das Einstellungen-Fenster
- __Lokaler Cache:__ Öffnet ein Fenster mit Informationen zum lokalen Cache
- __Nach Update suchen:__ Sucht auf GitHub nach einem Update für das Tool
- __Über:__ Öffnet ein Hinweisfenster mit Informationen zur Version des Tools
- __Beenden:__ Beendet das Tool

## Lokaler Cache

![LocalCache](/Star%20Citizen%20Handle%20Query/Screenshots/LocalCache.png?raw=true "LocalCache")
- __Tabelle:__ Hier werden Informationen zu den im lokalen Cache gespeicherten Handles dargestellt. Außerdem kann in der Spalte `Kommentar` ein Kommentar eingegeben werden, welcher sowohl dort als auch im Hauptfenster dargestellt wird.
- __Handle- und Organisation-Darstellung:__ Unter der Tabelle werden die Informationen zum ausgewählten Handle und zu dessen Organisation so dargestellt, wie sie im Hauptfenster dargestellt werden.
- __Cache leeren:__ Durch Klicken dieser Schaltfläche kann der komplette lokale Cache geleert werden. Bevor der lokale Cache geleert wird, muss der Benutzer diesen Vorgang bestätigen.
- __Ordner öffnen:__ Öffnet den Ordner, welcher den lokalen Cache enthält
- __Schließen:__ Schließt das Fenster

## Hauptfenster

![Handle Query](/Star%20Citizen%20Handle%20Query/Screenshots/MainWindow.png?raw=true "Handle Query")
- Hier kann der eindeutige Name eines Star Citizen Spielers in die Handle-Eingabebox eingegeben werden (maximal 60 Zeichen). Durch die Betätigung der Enter-Taste wird die Abfrage ausgelöst und kurze Zeit später das Ergebnis der Abfrage unter der Handle-Eingabebox dargestellt.
  - Wird währenddessen die Strg-Taste gedrückt gehalten, wird das Auslesen der Handle-Informationen inklusive Avatare (Handle, Organisation und Affiliationen) via Star Citizen Webseite erzwungen.
  - Drückt man, während die Handle-Eingabebox den Fokus hat, die `+`-Taste, kann man einen Kommentar zum aktuellen Handle eingeben. Durch Betätigung der `Enter`-Taste, wird der Kommentar im lokalen Cache gespeichert. Verliert die Kommentar-Eingabebox den Fokus oder es wird die `Esc`-Taste gedrückt, wird die Eingabe des Kommentars abgebrochen.
  - Wird die Handle-Eingabebox geleert, wird ein gegebenenfall zuvor ermitteltes Ergebnis ausgeblendet.
- Durch die Betätigung der Esc-Taste wird das Hauptfenster ausgeblendet.
- Wurde eine globale Taste(nkobination) in den Einstellungen angegeben, kann das Fenster jederzeit mit dieser Taste(nkombination) wieder angezeigt werden.
- Folgende Funktionen sind nur aktiv, wenn in den Einstellungen in der Gruppe `Fenster` das Kontrollkästchen `Mauseingaben ignorieren` nicht gesetzt ist:
  - Ein Mauslinksklick auf das Handle-Avatar öffnet die Informationsseite des Handles auf der Star Citizen Webseite (z.B. https://robertsspaceindustries.com/citizens/Kuehlwagen).
  - Ein Mauslinksklick auf ein Organisation-Avatar öffnet die Informationsseite der Organisation auf der Star Citizen Webseite (z.B. https://robertsspaceindustries.com/orgs/KRT).
  - Klickt man die Schloss-Schaltfläche links neben dem Handle-Schriftzug, wird das Hauptfenster entsperrt / gesperrt. Wenn das Hauptfenster entsperrt ist, kann mit gehaltener linker Maustaste auf dem Handle-Schriftzug das Hauptfenster verschoben werden. Drückt man stattdessen die mittlere Maustaste, wird das Hauptfenster an die Standard-Position (oben mittig) zurück gesetzt. Wenn das Hauptfenster gesperrt ist, kann es nicht verschoben werden.
  - Klickt man die Lupe-Schaltfläche, wird die Abfrage der Handle-Informationen ausgelöst.
  - Klickt man die Zahnrad-Schaltfläche, wird das Einstellungen-Fenster geöffnet.
  - Ist die Einstellung `Position merken` in der Kategorie `Fenster` aktiviert, wird beim Beenden des Tools die Position des Hauptfensters in den Einstellungen gespeichert. Beim Start des Tools wird das Hauptfenster an die zuvor gespeicherte Position gesetzt. Hält man, während das Tool gestartet wird, die `Umschalt`-Taste gedrückt, wird das Fenster immer an die Standardposition (oben mittig) gesetzt.
