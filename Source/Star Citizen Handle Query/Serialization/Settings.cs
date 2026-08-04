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
      }
      set {
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
      }
      set {
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

    /// <summary>Angabe, ob Handle- und Organisationsinfos kompakt dargestellt werden sollen</summary>
    public bool CompactMode { get; set; } = false;

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
    internal Color AppForeColor => ColorTranslator.FromHtml(ForeColor);
    internal Color AppForeColorInactive => ColorTranslator.FromHtml(ForeColorInactive);
    internal Color AppBackColor => ColorTranslator.FromHtml(BackColor);
    internal Color AppSplitterColor => ColorTranslator.FromHtml(SplitterColor);

    public object Clone() {
      return MemberwiseClone();
    }
  }

}
