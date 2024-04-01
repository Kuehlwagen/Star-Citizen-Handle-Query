namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable()]
  public class Translation(string language = null) : IEquatable<Translation> {
    public string Language { get; set; } = language ?? "Deutsch";

    public Translation_Window Window { get; set; } = new();

    public Translation_Settings Settings { get; set; } = new();

    public Translation_Local_Cache Local_Cache { get; set; } = new();

    public Translation_Notification Notification { get; set; } = new();

    public Translation_LogMonitor Log_Monitor { get; set; } = new();

    public Translation_Relations Relations { get; set; } = new();

    public Translation_Locations Locations { get; set; } = new();

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

    public Translation_Window_ToolTips ToolTips { get; set; } = new();

    public Translation_Window_Context_Menu Context_Menu { get; set; } = new();

    public Translation_Window_MessageBoxes MessageBoxes { get; set; } = new();

  }

  [Serializable()]
  public class Translation_Window_ToolTips {
    public string Lock_Unlock_Window { get; set; } = "Fenster sperren/freigeben";

    public string Query_Handle { get; set; } = "Handleinformationen aufrufen";

    public string Settings { get; set; } = "Einstellungen öffnen";
  }

  [Serializable()]
  public class Translation_Window_Context_Menu {
    public string Show { get; set; } = "Anzeigen";

    public string Settings { get; set; } = "Einstellungen";

    public string Local_Cache { get; set; } = "Lokalen Cache leeren";

    public string Close { get; set; } = "Beenden";

    public string About { get; set; } = "Über";

    public string Check_For_Update { get; set; } = "Nach Update suchen";

    public string Export_Relations { get; set; } = "Beziehungen bereitstellen";

    public string Import_Relations { get; set; } = "Beziehungen übernehmen";
  }

  [Serializable()]
  public class Translation_Window_MessageBoxes {

    public string Clear_Local_Cache_Question { get; set; } = "Der komplette lokale Cache wird geleert. Fortfahren?";

    public string Local_Cache_Cleared { get; set; } = "Der lokale Cache wurde geleert";

  }

  [Serializable()]
  public class Translation_Settings {

    public string Title { get; set; } = "Einstellungen";

    public Translation_Settings_Display Display { get; set; } = new();

    public Translation_Settings_Window Window { get; set; } = new();

    public Translation_Settings_Locations Locations { get; set; } = new();

    public Translation_Settings_Relations Relations { get; set; } = new();

    public Translation_Settings_Log_Monitor Log_Monitor { get; set; } = new();

    public Translation_Settings_Local_Cache Local_Cache { get; set; } = new();

    public Translation_Settings_Buttons Buttons { get; set; } = new();

    public Translation_Settings_MessageBoxes MessageBoxes { get; set; } = new();

  }

  [Serializable()]
  public class Translation_Settings_Display {

    public string Group_Title { get; set; } = "Anzeige";

    public string Language { get; set; } = "Sprache:";

    public string Affiliations_Max { get; set; } = "Affiliationen Maximum:";

    public string Hide_Redacted_Affiliations { get; set; } = "Unkenntliche Affiliationen ausblenden";

    public string Auto_Check_For_Update { get; set; } = "Bei Programmstart nach Update suchen";

    public string Hide_Stream_Live_Status { get; set; } = "Stream Live-Status ausblenden";

  }

  [Serializable()]
  public class Translation_Settings_Window {

    public string Group_Title { get; set; } = "Fenster";

    public string Opacity { get; set; } = "Deckkraft:";

    public string Opacity_Percent { get; set; } = "%";

    public string Global_Hotkey { get; set; } = "Globale Taste:";

    public string Global_Hotkey_Ctrl { get; set; } = "Strg";

    public string Global_Hotkey_Alt { get; set; } = "Alt";

    public string Global_Hotkey_Shift { get; set; } = "Umschalt";

    public string Ignore_Mouseinput { get; set; } = "Mauseingaben ignorieren";

    public string Enable_Alt_Tab { get; set; } = "Erreichbarkeit via Alt + Tab";

    public string RememberWindowLocation { get; set; } = "Position merken";

  }

  [Serializable()]
  public class Translation_Settings_Locations {

    public string Group_Title { get; set; } = "Orte (Alt + Eingabe)";

    public string Show_Locations { get; set; } = "Orte anzeigen";

    public string Locations_Entries_Max { get; set; } = "Einträge Maximum:";

    public string LMB_URL { get; set; } = "Linke Maustaste:";

    public string MMB_URL { get; set; } = "Mittlere Maustaste:";

    public string RMB_URL { get; set; } = "Rechte Maustaste:";

  }

  [Serializable()]
  public class Translation_Settings_Relations {

    public string Group_Title { get; set; } = "Beziehungen";

    public string Show_Relations { get; set; } = "Beziehungen anzeigen";

    public string Sort_Relations_Alphabetically { get; set; } = "Alphabetisch sortieren";

    public string Relations_Entries_Max { get; set; } = "Einträge Maximum:";

    public string RPC_Server_URL { get; set; } = "gRPC Server-URL:";

    public string RPC_Server_Channel { get; set; } = "gRPC Server-Kanal:";

    public string RPC_Sync_On_Startup { get; set; } = "gRPC-Synchronisation bei Programmstart";

  }

  [Serializable()]
  public class Translation_Settings_Log_Monitor {

    public string Group_Title { get; set; } = "Log-Monitor";

    public string Show_Log_Monitor { get; set; } = "Log-Monitor anzeigen";

    public string Log_Entries_Max { get; set; } = "Einträge Maximum:";

    public string Log_Entry_Display_Duration { get; set; } = "Eintrag Anzeigedauer:";

    public string Log_Show_Corpse { get; set; } = "Spielertode anzeigen";

    public string Log_Show_Loading_Screen_Duration { get; set; } = "Ladebildschirm-Dauer anzeigen";

    public string Log_Entry_Display_Duration_Minutes { get; set; } = "Minute(n)";

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

  }

  [Serializable()]
  public class Translation_Local_Cache {

    public string Title { get; set; } = "Lokaler Cache";

    public Translation_Local_Cache_Columns Columns { get; set; } = new();

    public Translation_Local_Cache_Buttons Buttons { get; set; } = new();

    public Translation_Local_Cache_Relation Relation { get; set; } = new();

  }

  [Serializable()]
  public class Translation_Local_Cache_Columns {

    public string Cache_Date { get; set; } = "Cache Datum";

    public string Handle { get; set; } = "Handle";

    public string Community_Moniker { get; set; } = "CM";

    public string Enlisted { get; set; } = "Angeworben";

    public string UEE_Citizen_Record { get; set; } = "UEE CR";

    public string Organization { get; set; } = "Organisation";

    public string Organization_Rank { get; set; } = "Org. Rang";

    public string Affiliation_Count { get; set; } = "Anz. Aff.";

    public string Relation { get; set; } = "Beziehung";

    public string Comment { get; set; } = "Kommentar";

  }

  [Serializable()]
  public class Translation_Local_Cache_Buttons {

    public string Clear_Cache { get; set; } = "Cache leeren";

    public string Open_Folder { get; set; } = "Ordner öffnen";

    public string Close { get; set; } = "Schließen";

  }

  [Serializable()]
  public class Translation_Local_Cache_Relation {

    public string Not_Assigned { get; set; } = "Keine Zuordnung";
    public string Friendly { get; set; } = "FRIENDLY";
    public string Neutral { get; set; } = "NEUTRAL";
    public string Bogey { get; set; } = "BOGEY";
    public string Bandit { get; set; } = "BANDIT";

  }

  [Serializable()]
  public class Translation_Notification {

    public string Notify_Icon_Info { get; set; } = "Einstellungen und weitere Bereiche können via Mausrechtsklick auf das Symbol in der Taskleiste erreicht werden";

    public string Update_Info { get; set; } = "Update verfügbar";

    public string Update_Info_Show_Release_Notes { get; set; } = "Klicken, um Release-Notes zu öffnen";

    public string Update_Up_To_Date { get; set; } = "Programm ist aktuell";

    public string Update_Error { get; set; } = "Update-Informationen konnten nicht ausgelesen werden";

  }

  [Serializable]
  public class Translation_LogMonitor {

    public string Title { get; set; } = "Log-Monitor";

  }

  [Serializable]
  public class Translation_Relations {

    public string Title { get; set; } = "Beziehungen";

  }

  public class Translation_Locations {

    public string Title { get; set; } = "Orte";

    public string Filter_Placeholder { get; set; } = "Orte filtern...";

    public string More_Location { get; set; } = "weiterer Ort...";

    public string More_Locations { get; set; } = "weitere Orte...";

  }

}
