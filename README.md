# Star Citizen Handle Query

Mit Hilfe dieses Tools kann man via globaler Tastenkombination schnell Informationen zum Handle eines Star Citizen Spielers einsehen.

![Handle Query](https://drive.google.com/uc?id=1H7g6gxJ88Pzzt-Wm4kRyQep27PwTgIaS "Handle Query")

Um an diese Informationen zu gelangen, wird die inoffizielle Star Citizen API (https://starcitizen-api.com/) verwendet, weshalb ein API-Schlüssel (API-Key) benötigt wird. Ein API-Schlüssel ermöglicht den Abruf von 1.000 Live-Abfragen pro Tag. Wenn Daten aus dem Server-Cache der API-geladen werden, wird kein Abruf abgezogen. Außerdem verwendet dieses Tool einen lokalen Cache, um Handle-Informationen und Bilder für einen definierten Zeitraum lokal vorzuhalten.

Es gibt zwei Wege, um an einen API-Schlüssel zu kommen:
1. Dem Discord-Server der Webseite beitreten (https://discord.gg/8ekwNv4) und im Channel "keys" das Kommando "!api register" verwenden. Der API-Schlüssel wird anschließend direkt von einem Bot via persönlicher Nachricht zugestelle.
2. Auf der Webseite oben via Google oder Discord einloggen. Der API-Schlüssel wird anschließend oben auf der Webseite dargestellt.

__Einstellungen__

![Settings](https://drive.google.com/uc?id=1JM-F0KNxB-XRd3wVZUu8wbtzEy4zhkwJ "Settings")
- Gruppe: API (starcitizen-api.com)
  - Schlüssel: Hier muss der 32-stellige API-Schlüssel eingetragen werden, den man zugeteilt bekommen hat
  - Modus: Hier kann der Modus der API-Anfragen eingestellt werden, wie die Informationen von der API bereitgestellt werden sollen:
    - Live: Die Daten werden immer direkt von der Star Citizen Webseite abgerufen
    - Cache: Die Daten werden immer aus dem Servercache der API abgerufen. Liegen die Informationen zu einem Handle nicht im Servercache, werden diese auch nicht empfangen.
    - Auto: Es wird immer erst versucht, die Daten aus dem Servercache zu erhalten. Liegen die Informationen nicht vor, werden sie von der Star Citizen Webseite abgerufen.
    - Eager: Es wird immer erst versucht, die Daten von der Star Citizen Webseite abzurufen. Ist die Star Citizen Webseite gerade nicht erreichbar, werden die Informationen aus dem Servercache der API abgerufen, sofern diese dort vorliegen.
  - API-Test: Diese Schaltfläche wird aktiviert, wenn ein 32-stelliger API-Schlüssel eigegeben wurde. Bei Betätigung der Schaltfläche wird getestet, ob die API mit dem angegebenen API-Schlüssel funkioniert. Falls der API-Schlüssel valide ist, wird angezeigt, wie viele Live-Abfragen für den aktuellen Tag noch übrig sind. Ist der API-Schlüssel nicht valide, wird dies ebenfalls dargestellt.
- Gruppe: Fenster
  - Deckkraft: Hier kann eingestellt werden, wie hoch die Deckkraft des Fensters sein soll. Es können Werte zwischen 50% (halb transparent) und 100% (nicht transparent) eingegeben werden.
  - Globale Taste: Hier kann die Taste (Keine oder F1-F12) angegeben werden, welche global abgefangen wird, um das Programm in den Vordergrund zu holen. Zusätzlich können Modifizierer (Strg, Alt und Umschalt) angegeben werden, um eine Tastenkombination angeben zu können.
  - Mauseingaben ignorieren: Wird diese Einstellung aktiviert, gehen sämtliche Mausklicks durch das Fenster durch in das dahinter liegende Programm.
- Gruppe: Lokaler Cache
  - Maximales Alter: Hier kann für den lokalen Cache das maximale Alter in Tagen angegeben werden, wann die Information eines Handles wieder via API abgefragt werden soll. Es können Werte zwischen 0 und 30 Tagen angegeben werden. Die Angabe von 0 Tagen wird die Handle-Informationen immer via API abfragen.
- Speichern: Speichert die vorgenommenen Einstellungen und schließt das Einstellungen-Fenster
- Schließen: Schließt das Einstellungen-Fenster, ohne die vorgenommenen Einstellungen zu speichern
- Standard: Stellt die Standard-Einstellungen wieder her, mit Ausnahme des API-Schlüssels

Kontextmenü via Benachrichtigungssymbol in der Taskleiste:
- Anzeigen: Falls das Fenster nicht sichtbar ist, wird es angezeigt und die Handle-Eingabebox erhält den Eingabefokus
- Einstellungen: Öffnet das Einstellungen-Fenster
- Lokalen Cache leeren: Löscht sämtliche Dateien im lokalen Cache
- Neustarten: Startet das Tool neu
- Beenden: Beendet das Tool

__Hauptfenster__
- Hier kann der Handle eines Star Citizen Spielers in die Handle-Eingabebox eingegeben werden. Durch die Betätigung der Enter-Taste wird die Abfrage ausgelöst und kurze Zeit später das Ergebnis der Abfrage darunter dargestellt.
- Durch die Betätigung der Esc-Taste wird das Fenster ausgeblendet.
- Wurde eine globale Taste(nkobination) in den Einstellungen angegeben, kann das Fenster jederzeit mit dieser Taste(nkombination) wieder angezeigt werden.
- Folgende Funktionen sind nur aktiv, wenn in den Einstellungen in der Gruppe "Fenster" das Kontrollkästchen "Mauseingaben ignorieren" nicht gesetzt ist:
  - Ein Klick auf das Handle-Avatar öffnet die Informationsseite des Handles auf der Star Citizen Webseite (z.B. https://robertsspaceindustries.com/citizens/Kuehlwagen).
  - Ein Klick auf das Organisation-Avatar öffnet die Informationsseite der Organisation auf der Star Citizen Webseite (z.B. https://robertsspaceindustries.com/orgs/KRT).
