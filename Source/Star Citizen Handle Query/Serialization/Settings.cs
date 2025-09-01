using Star_Citizen_Handle_Query.Classes;
using System.Text.Json.Serialization;

namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable()]
  public class Settings : ICloneable {

    /// <summary>Sprache für die Oberfläche des Tools</summary>
    public string Language { get; set; } = "Deutsch";

    private int _WindowOpacity = 85;
    /// <summary>Fenster-Deckkraft in Prozent (Standard 85%, Minimum 50%, Maximum 100%)</summary>
    public int WindowOpacity {
      get {
        return _WindowOpacity;
      }
      set {
        if (value < 50) {
          value = 50;
        } else if (value > 100) {
          value = 100;
        }
        _WindowOpacity = value;
      }
    }

    /// <summary>Mauseingaben ignorieren</summary>
    public bool WindowIgnoreMouseInput { get; set; } = false;

    private int _LocalCacheMaxAge = 30;
    /// <summary>Maximales Alter in Tagen für den lokalen Cache (Standard 3 Tage, Mimimum 0 Tage [deaktiviert], Maximum 30 Tage)</summary>
    public int LocalCacheMaxAge {
      get {
        return _LocalCacheMaxAge;
      }
      set {
        if (value < 0) {
          value = 0;
        } else if (value > 365) {
          value = 365;
        }
        _LocalCacheMaxAge = value;
      }
    }

    private int _AutoCloseDuration = 0;
    /// <summary>Ergebnis nach x Sekunden ausblenden (0 = dauerhaft, max. 600)</summary>
    public int AutoCloseDuration {
      get {
        return _AutoCloseDuration;
      } set {
        if (value < 0) {
          value = 0;
        } else if (value > 600) {
          value = 600;
        }
        _AutoCloseDuration = value;
      }
    }

    /// <summary>Angabe, ob wenn das Ergebnis ausgeblendet werden soll, zusätzlich die Fenster ausgeblendet werden sollen</summary>
    public bool AutoCloseHideWindows { get; set; } = false;

    /// <summary>Globaler Hotkey</summary>
    public Keys GlobalHotkey { get; set; } = Keys.F3;

    /// <summary>Strg-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierCtrl { get; set; } = false;

    /// <summary>Alt-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierAlt { get; set; } = false;

    /// <summary>Umschalt-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierShift { get; set; } = true;

    /// <summary>Gibt an, ob das Hauptfenster via Alt + Tab erreichbar sein soll</summary>
    public bool AltTabEnabled { get; set; } = true;

    /// <summary>Maximal darzustellende Affiliationen</summary>
    private int _AffiliationsMax = 3;
    public int AffiliationsMax {
      get {
        return _AffiliationsMax;
      } set {
        if (value < 0) {
          value = 0;
        } else if (_AffiliationsMax > 9) {
          value = 9;
        }
        _AffiliationsMax = value;
      }
    }

    /// <summary>Angabe, ob unkenntliche Affiliationen ausgeblendet werden sollen</summary>
    public bool HideRedactedAffiliations { get; set; } = false;

    /// <summary>Angabe, ob sich die Position des Hauptfensters gemerkt werden soll</summary>
    public bool RememberWindowLocation { get; set; } = true;

    /// <summary>Angabe, ob bei ESC das Fenster ausgeblendet werden soll</summary>
    public bool HideWindowOnEscPress { get; set; } = true;

    /// <summary>Position des Hauptfensters</summary>
    public Point WindowLocation { get; set; } = Point.Empty;

    /// <summary>Größe des Hauptfensters</summary>
    public Size WindowSize { get; set; } = Size.Empty;

    /// <summary>Angabe, ob beim Programmstart nach einem Programm-Update gesucht werden soll</summary>
    public bool AutoCheckForUpdate { get; set; } = false;

    /// <summary>Angabe, ob die Stream Live-Anzeige ausgeblendet werden soll</summary>
    public bool HideStreamLiveStatus { get; set; } = false;

    /// <summary>Angabe, ob HighDpiMode.DpiUnaware anstatt HighDpiMode.PerMonitorV2 verwendet werden soll</summary>
    public bool DpiUnaware { get; set; } = false;

    /// <summary>LogFileWatcher relevante Einstellungen</summary>
    public LogMonitorSettings LogMonitor { get; set; } = new();

    /// <summary>Beziehungen relevante Einstellungen</summary>
    public RelationsSettings Relations { get; set; } = new();

    /// <summary>Orte relevante Einstellungen</summary>
    public LocationsSettings Locations { get; set; } = new();

    /// <summary>App-Farben</summary>
    [JsonIgnore]
    public AppColors Colors { get; set; } = new();

    public object Clone() {
      return MemberwiseClone();
    }
  }

  [Serializable]
  public class AppColors : ICloneable {
    public string ForeColor { get; set; } = "#39CED8";
    public string ForeColorInactive { get; set; } = "#2E9D9E";
    public string BackColor { get; set; } = "#131A21";
    public string SplitterColor { get; set; } = "#FFFF00";
    public string StatusInactiveForeColor { get; set; } = "#FF0000";
    public string StatusInactiveBackColor { get; set; } = "#7F0000";
    public string StatusInitializingForeColor { get; set; } = "#FF7A00";
    public string StatusInitializingBackColor { get; set; } = "#CC4500";
    public string StatusActiveForeColor { get; set; } = "#10AA00";
    public string StatusActiveBackColor { get; set; } = "#105500";
    public string RelationFriendlyForeColor { get; set; } = "#008000";
    public string RelationFriendlyBackColor { get; set; } = "#004000";
    public string RelationNeutralForeColor { get; set; } = "#827D78";
    public string RelationNeutralBackColor { get; set; } = "#3C3732";
    public string RelationBogeyForeColor { get; set; } = "#FFA500";
    public string RelationBogeyBackColor { get; set; } = "#6F4200";
    public string RelationBanditForeColor { get; set; } = "#FF0000";
    public string RelationBanditBackColor { get; set; } = "#7F0000";
    public string RelationOrganizationForeColor { get; set; } = "#39CED8";
    public string RelationOrganizationBackColor { get; set; } = "#214E4F";
    internal Color AppForeColor => ColorTranslator.FromHtml(ForeColor);
    internal Color AppForeColorInactive => ColorTranslator.FromHtml(ForeColorInactive);
    internal Color AppBackColor => ColorTranslator.FromHtml(BackColor);
    internal Color AppSplitterColor => ColorTranslator.FromHtml(SplitterColor);
    internal Color AppStatusInactiveForeColor => ColorTranslator.FromHtml(StatusInactiveForeColor);
    internal Color AppStatusInactiveBackColor => ColorTranslator.FromHtml(StatusInactiveBackColor);
    internal Color AppStatusInitializingForeColor => ColorTranslator.FromHtml(StatusInitializingForeColor);
    internal Color AppStatusInitializingBackColor => ColorTranslator.FromHtml(StatusInitializingBackColor);
    internal Color AppStatusActiveForeColor => ColorTranslator.FromHtml(StatusActiveForeColor);
    internal Color AppStatusActiveBackColor => ColorTranslator.FromHtml(StatusActiveBackColor);
    internal Color AppRelationFriendlyForeColor => ColorTranslator.FromHtml(RelationFriendlyForeColor);
    internal Color AppRelationFriendlyBackColor => ColorTranslator.FromHtml(RelationFriendlyBackColor);
    internal Color AppRelationNeutralForeColor => ColorTranslator.FromHtml(RelationNeutralForeColor);
    internal Color AppRelationNeutralBackColor => ColorTranslator.FromHtml(RelationNeutralBackColor);
    internal Color AppRelationBogeyForeColor => ColorTranslator.FromHtml(RelationBogeyForeColor);
    internal Color AppRelationBogeyBackColor => ColorTranslator.FromHtml(RelationBogeyBackColor);
    internal Color AppRelationBanditForeColor => ColorTranslator.FromHtml(RelationBanditForeColor);
    internal Color AppRelationBanditBackColor => ColorTranslator.FromHtml(RelationBanditBackColor);
    internal Color AppRelationOrganizationForeColor => ColorTranslator.FromHtml(RelationOrganizationForeColor);
    internal Color AppRelationOrganizationBackColor => ColorTranslator.FromHtml(RelationOrganizationBackColor);

    public object Clone() {
      return MemberwiseClone();
    }
  }

  public class LogMonitorSettings : ICloneable {

    /// <summary>Angabe, ob das Fenster angezeigt werden soll</summary>
    public bool ShowWindow { get; set; } = true;

    /// <summary>Position des LogFileWatcher-Fensters</summary>
    public Point WindowLocation { get; set; } = Point.Empty;

    /// <summary>Größe des LogFileWatcher-Fensters</summary>
    public Size WindowSize { get; set; } = Size.Empty;

    /// <summary>Maximal anzuzeigende Einträge</summary>
    private int _EntriesMax = 10;
    public int EntriesMax {
      get {
        return _EntriesMax;
      }
      set {
        if (value < 1) {
          value = 1;
        } else if (_EntriesMax > 50) {
          value = 50;
        }
        _EntriesMax = value;
      }
    }

    /// <summary>Anzeigedauer eines Eintrags in Minuten (0 = unendlich)</summary>
    private int _EntryDisplayDurationInMinutes = 10;
    public int EntryDisplayDurationInMinutes {
      get {
        return _EntryDisplayDurationInMinutes;
      }
      set {
        if (value < 0) {
          value = 0;
        } else if (value > 60) {
          value = 60;
        }
        _EntryDisplayDurationInMinutes = value;
      }
    }

    /// <summary>Angabe, ob die komplette Log-Datei ausgelesen werden soll</summary>
    public bool LoadCompleteFile { get; set; } = false;

    /// <summary>Filter für den Log-Monitor</summary>
    public LogMonitorFilter Filter { get; set; } = new LogMonitorFilter();

    /// <summary>Handle-Filter</summary>
    public List<string> HandleFilter { get; set; } = [];

    /// <summary>Webhook-URL</summary>
    public string WebhookURL { get; set; } = string.Empty;

    /// <summary>Globale NPC-Namen</summary>
    public readonly List<string> Global_NPC_Filter = [
      "NPC_",
      "AIModule_",
      "PU_",
      "Kopion_",
      "Quasigrazer_",
      "Shipjacker_",
      "vlk_adult_",
      "vlk_juvenile_"
    ];

    /// <summary>NPC-Filter (StartsWith)</summary>
    public List<string> NPC_Filter { get; set; } = [];

    /// <summary>NPC-Tode anzeigen</summary>
    public bool Show_NPC_Deaths { get; set; } = false;

    /// <summary>Eigene Handles</summary>
    public List<string> OwnHandles { get; set; } = [];

    public object Clone() {
      return MemberwiseClone();
    }

  }

  public class LogMonitorFilter : ICloneable {

    /// <summary>Angabe, ob Spielertode angezeigt werden sollen</summary>
    public bool Corpse { get; set; } = true;

    /// <summary>Angabe, ob Ladezeiten angezeigt werden sollen</summary>
    public bool LoadingScreenDuration { get; set; } = false;
    
    /// <summary>Angabe, ob Feindseligkeitsereignisse angezeigt werden sollen</summary>
    public bool Hostility_Events { get; set; } = true;

    /// <summary>Angabe, ob der eigene Handle angezeigt werden soll</summary>
    public bool Own_Handle { get; set; } = true;

    public object Clone() {
      return MemberwiseClone();
    }

  }

  public class RelationsSettings : ICloneable {

    /// <summary>Angabe, ob das Fenster angezeigt werden soll</summary>
    public bool ShowWindow { get; set; } = true;

    /// <summary>Position des Relation-Fensters</summary>
    public Point WindowLocation { get; set; } = Point.Empty;

    /// <summary>Größe des Relation-Fensters</summary>
    public Size WindowSize { get; set; } = Size.Empty;

    /// <summary>Maximal anzuzeigende Einträge</summary>
    private int _EntriesMax = 10;
    public int EntriesMax {
      get {
        return _EntriesMax;
      }
      set {
        if (value < 1) {
          value = 1;
        } else if (_EntriesMax > 50) {
          value = 50;
        }
        _EntriesMax = value;
      }
    }

    /// <summary>Angabe, ob die Einträge alphabetisch aufsteigend sortiert werden sollen</summary>
    public bool SortAlphabetically { get; set; } = true;

    /// <summary>gRPC-URL für den Benutzer übergreifenden Abgleich von Beziehungen</summary>
    public string RPC_URL { get; set; } = string.Empty;

    /// <summary>Der zu verwendende Channel des gRPC-Servers</summary>
    public string RPC_Channel { get; set; } = string.Empty;

    /// <summary>Enthält das unverschlüsselte Passwort</summary>
    internal string RPC_Sync_Channel_Password_Decrypted {
      get { return Encryption.DecryptText(RPC_Channel_Password); }
      set { RPC_Channel_Password = !string.IsNullOrEmpty(value) ? Encryption.EncryptText(value) : string.Empty; }
    }

    /// <summary>Das Passwort für den zu verwendenden Channels des gRPC-Servers</summary>
    public string RPC_Channel_Password { get; set; } = string.Empty;

    /// <summary>Angabe, ob die Synchronisierung mit dem gRPC-Server beim Programmstart automatisch erfolgen soll</summary>
    public bool RPC_Sync_On_Startup { get; set; } = false;

    public object Clone() {
      return MemberwiseClone();
    }

  }

  public class LocationsSettings : ICloneable {

    /// <summary>Angabe, ob das Fenster angezeigt werden soll</summary>
    public bool ShowWindow { get; set; } = true;

    /// <summary>Position des Location-Fensters</summary>
    public Point WindowLocation { get; set; } = Point.Empty;

    /// <summary>Größe des Location-Fensters</summary>
    public Size WindowSize { get; set; } = Size.Empty;

    /// <summary>Maximal anzuzeigende Einträge</summary>
    private int _EntriesMax = 10;
    public int EntriesMax {
      get {
        return _EntriesMax;
      }
      set {
        if (value < 1) {
          value = 1;
        } else if (_EntriesMax > 50) {
          value = 50;
        }
        _EntriesMax = value;
      }
    }

    /// <summary>URL der linken Maustaste</summary>
    public string LMB_URL { get; set; } = "https://dydrmr.github.io/VerseTime/#{Name}";

    /// <summary>URL der mittleren Maustaste</summary>
    public string MMB_URL { get; set; } = "{WikiLink}|https://starcitizen.tools/{Name}";

    /// <summary>URL der rechten Maustaste</summary>
    public string RMB_URL { get; set; } = "";

    public object Clone() {
      return MemberwiseClone();
    }

  }

}
