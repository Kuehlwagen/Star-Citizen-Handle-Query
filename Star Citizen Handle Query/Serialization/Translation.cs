namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable()]
  public class Translation : IEquatable<Translation> {

    public Translation(string language = null) {
      Language = language ?? "Deutsch";
    }

    public string Language { get; set; } = "Deutsch";

    public Translation_Window Window { get; set; } = new();

    public Translation_Settings Settings { get; set; } = new();

    /// <summary>Vergleich in Liste ermöglichen</summary>
    /// <param name="other">Anderes Translation-Objekt</param>
    /// <returns>true, wenn das Feld "Language" übereinstimmt, andernfalls false</returns>
    public bool Equals(Translation other) {
      return Language != null && other.Language != null && Language == other.Language;
    }

    public override bool Equals(object obj) {
      return Equals(obj as Translation);
    }

    public override int GetHashCode() {
      return HashCode.Combine(Language);
    }

    /// <summary>ToString() überschreiben</summary>
    /// <returns>Language</returns>
    public override string ToString() {
      return Language;
    }

  }

  [Serializable()]
  public class Translation_Window {

    public string Handle { get; set; } = "Handle:";

    public string Handle_Placeholder { get; set; } = "Handle eingeben...";

    public string Handle_Not_Found { get; set; } = "Handle nicht gefunden...";

    public string Context_Menu_Show { get; set; } = "Anzeigen";

    public string Context_Menu_Settings { get; set; } = "Einstellungen";

    public string Context_Menu_Clear_Local_Cache { get; set; } = "Lokalen Cache leeren";

    public string Context_Menu_Restart { get; set; } = "Neustarten";

    public string Context_Menu_Close { get; set; } = "Beenden";

    public Translation_Window_MessageBoxes MessageBoxes { get; set; } = new();

  }

  [Serializable()]
  public class Translation_Window_MessageBoxes {

    public string API_Key_Missing { get; set; } = "Es muss ein 32-stelliger API-Key angegeben werden.\r\nDas Programm wird beendet.";

    public string Local_Cache_Emptied { get; set; } = "Der lokale Cache wurde geleert";

  }

  [Serializable()]
  public class Translation_Settings {

    public string Title { get; set; } = "Einstellungen";

    public Translation_Settings_API API { get; set; } = new ();

    public Translation_Settings_Window Window { get; set; } = new();

    public Translation_Settings_Local_Cache Local_Cache { get; set; } = new();

    public Translation_Settings_Buttons Buttons { get; set; } = new();

    public Translation_Settings_MessageBoxes MessageBoxes { get; set; } = new();

  }

  [Serializable()]
  public class Translation_Settings_API {

    public string Group_Title { get; set; } = "API";

    public string Key { get; set; } = "Schlüssel:";

    public string Key_Placeholder { get; set; } = "32-stelligen API-Schlüssel eingeben";

    public string Mode { get; set; } = "Modus:";

    public string Mode_Description_Live { get; set; } = "(immer Live-Daten)";

    public string Mode_Description_Cache { get; set; } = "(immer Server-Cache)";

    public string Mode_Description_Auto { get; set; } = "(Server-Cache / Live-Daten)";

    public string Mode_Description_Eager { get; set; } = "(Live-Daten / Server-Cache)";

    public string Test { get; set; } = "API-Test";

    public string Test_Error { get; set; } = "Fehler bei der Abfrage der API";

    public string Test_Information { get; set; } = "Live-Abfragen übrig";

  }

  [Serializable()]
  public class Translation_Settings_Window {

    public string Group_Title { get; set; } = "Fenster";

    public string Language { get; set; } = "Sprache:";

    public string Opacity { get; set; } = "Deckkraft:";

    public string Opacity_Percent { get; set; } = "%";

    public string Global_Hotkey { get; set; } = "Globale Taste:";

    public string Global_Hotkey_Ctrl { get; set; } = "Strg";

    public string Global_Hotkey_Alt { get; set; } = "Alt";

    public string Global_Hotkey_Shift { get; set; } = "Umschalt";

    public string Ignore_Mouseinput { get; set; } = "Mauseingaben ignorieren";

    public string Enable_Alt_Tab { get; set; } = "Erreichbarkeit via Alt + Tab";

  }

  [Serializable()]
  public class Translation_Settings_Local_Cache {

    public string Group_Title { get; set; } = "Lokaler Cache";

    public string Max_Age { get; set; } = "Maximales Alter:";

    public string Max_Age_Days { get; set; } = "Tag(e)";

  }

  [Serializable()]
  public class Translation_Settings_Buttons {

    public string Save { get; set; } = "Speichern";

    public string Close { get; set; } = "Schließen";

    public string Standard { get; set; } = "Standard";

  }

  [Serializable()]
  public class Translation_Settings_MessageBoxes {

    public string Save_Fail { get; set; } = "Das Speichern der Einstellungen ist fehlgeschlagen:\r\nFehlermeldung:";

    public string API_Key_Missing { get; set; } = "Es muss ein 32-stelliger API-Key angegeben werden.";

  }

}
