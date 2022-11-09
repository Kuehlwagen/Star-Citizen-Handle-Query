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
    public bool RememberWindowLocation { get; set; } = false;

    /// <summary>Position des Hauptfensters</summary>
    public Point WindowLocation { get; set; } = Point.Empty;

    /// <summary>Angabe, ob beim Programmstart nach einem Programm-Update gesucht werden soll</summary>
    public bool AutoCheckForUpdate { get; set; } = false;

    /// <summary>Angabe, ob die Stream Live-Anzeige ausgeblendet werden soll</summary>
    public bool HideStreamLiveStatus { get; set; } = false;

    /// <summary>LogFileWatcher relevante Einstellungen</summary>
    public SARMonitorSettings SARMonitor { get; set; } = new SARMonitorSettings();

    public object Clone() {
      return MemberwiseClone();
    }
  }

  public class SARMonitorSettings : ICloneable {

    /// <summary>Angabe, ob das Fenster angezeigt werden soll</summary>
    public bool ShowWindow { get; set; } = false;

    /// <summary>Position des LogFileWatcher-Fensters</summary>
    public Point WindowLocation { get; set; } = Point.Empty;

    /// <summary>Maximal anzuzeigende Einträge</summary>
    private int _EntriesMax = 10;
    public int EntriesMax {
      get {
        return _EntriesMax;
      }
      set {
        if (value < 1) {
          value = 1;
        } else if (_EntriesMax > 25) {
          value = 25;
        }
        _EntriesMax = value;
      }
    }

    public object Clone() {
      return MemberwiseClone();
    }
  }

}
