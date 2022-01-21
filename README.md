# Star Citizen Handle Query

Mit Hilfe dieses Tools kann man mit einer globalen Tastenkombination schnell Informationen zum Handle eines Star Citizen Spielers einsehen.

![Handle Query](/Star%20Citizen%20Handle%20Query/Screenshots/MainWindow.png?raw=true "Handle Query")

## API-Schlüssel

Um an die Handle-Informationen zu gelangen, wird die inoffizielle Star Citizen API (https://starcitizen-api.com/) verwendet, weshalb ein API-Schlüssel (API-Key) benötigt wird. Ein API-Schlüssel ermöglicht den Abruf von 1.000 Live-Abfragen pro Tag. Wenn Daten aus dem Server-Cache der API-geladen werden, wird kein Abruf abgezogen. Außerdem verwendet dieses Tool einen lokalen Cache, um Handle-Informationen und Bilder für einen definierten Zeitraum lokal vorzuhalten.

Es gibt zwei Wege, um an einen API-Schlüssel zu kommen:
1. Dem Discord-Server der Webseite beitreten (https://discord.gg/8ekwNv4) und im Channel "keys" das Kommando `!api register` verwenden. Der API-Schlüssel wird anschließend direkt von einem Bot in Form einer persönlichen Nachricht zugestellt.
2. Auf der Webseite oben via Google oder Discord einloggen. Der API-Schlüssel wird anschließend oben auf der Webseite dargestellt.

## Einstellungen

![Settings](/Star%20Citizen%20Handle%20Query/Screenshots/Settings.png?raw=true "Settings")
### API (starcitizen-api.com)
- __Schlüssel:__ Hier muss der 32-stellige API-Schlüssel eingetragen werden, den man zugeteilt bekommen hat
- __Modus:__ Hier kann der Modus der API-Anfragen eingestellt werden, wie die Informationen von der API bereitgestellt werden sollen:
  - __Live:__ Die Daten werden immer direkt von der Star Citizen Webseite abgerufen
  - __Cache:__ Die Daten werden immer aus dem Servercache der API abgerufen. Liegen die Informationen zu einem Handle nicht im Servercache, werden diese auch nicht empfangen.
  - __Auto:__ Es wird immer erst versucht, die Daten aus dem Servercache zu erhalten. Liegen die Informationen nicht vor, werden sie von der Star Citizen Webseite abgerufen.
  - __Eager:__ Es wird immer erst versucht, die Daten von der Star Citizen Webseite abzurufen. Ist die Star Citizen Webseite gerade nicht erreichbar, werden die Informationen aus dem Servercache der API abgerufen, sofern diese dort vorliegen.
- __API-Test:__ Diese Schaltfläche wird aktiviert, wenn ein 32-stelliger API-Schlüssel eigegeben wurde. Bei Betätigung der Schaltfläche wird getestet, ob die API mit dem angegebenen API-Schlüssel funktioniert. Falls der API-Schlüssel valide ist, wird angezeigt, wie viele Live-Abfragen für den aktuellen Tag noch übrig sind. Ist der API-Schlüssel nicht valide, wird dies ebenfalls dargestellt.
### Fenster
- __Deckkraft:__ Hier kann eingestellt werden, wie hoch die Deckkraft des Fensters sein soll. Es können Werte zwischen 50% (halb transparent) und 100% (nicht transparent) eingegeben werden.
- __Globale Taste:__ Hier kann die Taste angegeben werden, welche global abgefangen wird, um das Programm in den Vordergrund zu holen. Zusätzlich können Modifikatoren (Strg, Alt und Umschalt) angegeben werden, um eine Tastenkombination angeben zu können.
- __Mauseingaben ignorieren:__ Wird diese Einstellung aktiviert, gehen sämtliche Mausklicks durch das Fenster durch in das dahinter liegende Programm.
### Lokaler Cache
- __Maximales Alter:__ Hier kann für den lokalen Cache das maximale Alter in Tagen angegeben werden, wann die Information eines Handles wieder via API abgefragt werden soll. Es können Werte zwischen 0 und 30 Tagen angegeben werden. Die Angabe von 0 Tagen wird die Handle-Informationen immer via API abfragen.
### Schaltflächen
- __Speichern:__ Speichert die vorgenommenen Einstellungen und schließt das Einstellungen-Fenster
- __Schließen:__ Schließt das Einstellungen-Fenster, ohne die vorgenommenen Einstellungen zu speichern
- __Standard:__ Stellt die Standard-Einstellungen wieder her, mit Ausnahme des API-Schlüssels

## Kontextmenü Taskleiste
- __Anzeigen:__ Falls das Fenster nicht sichtbar ist, wird es angezeigt und die Handle-Eingabebox erhält den Eingabefokus
- __Einstellungen:__ Öffnet das Einstellungen-Fenster
- __Lokalen Cache leeren:__ Löscht sämtliche Dateien im lokalen Cache
- __Neustarten:__ Startet das Tool neu
- __Beenden:__ Beendet das Tool

## Hauptfenster
- Hier kann der eindeutige Name eines Star Citizen Spielers in die Handle-Eingabebox eingegeben werden. Durch die Betätigung der Enter-Taste wird die Abfrage ausgelöst und kurze Zeit später das Ergebnis der Abfrage darunter dargestellt.
- Durch die Betätigung der Esc-Taste wird das Fenster ausgeblendet.
- Wurde eine globale Taste(nkobination) in den Einstellungen angegeben, kann das Fenster jederzeit mit dieser Taste(nkombination) wieder angezeigt werden.
- Folgende Funktionen sind nur aktiv, wenn in den Einstellungen in der Gruppe "Fenster" das Kontrollkästchen "Mauseingaben ignorieren" nicht gesetzt ist:
  - Ein Klick auf das Handle-Avatar öffnet die Informationsseite des Handles auf der Star Citizen Webseite (z.B. https://robertsspaceindustries.com/citizens/Kuehlwagen).
  - Ein Klick auf das Organisation-Avatar öffnet die Informationsseite der Organisation auf der Star Citizen Webseite (z.B. https://robertsspaceindustries.com/orgs/KRT).
