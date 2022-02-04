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

    private int _LocalCacheMaxAge = 3;
    /// <summary>Maximales Alter in Tagen für den lokalen Cache (Standard 3 Tage, Mimimum 0 Tage [deaktiviert], Maximum 30 Tage)</summary>
    public int LocalCacheMaxAge {
      get {
        return _LocalCacheMaxAge;
      }
      set {
        if (value < 0) {
          value = 0;
        } else if (value > 30) {
          value = 30;
        }
        _LocalCacheMaxAge = value;
      }
    }

    /// <summary>API-Key für starcitizen-api.com</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>API-Modus für starcitizen-api.com</summary>
    public ApiMode ApiMode { get; set; } = ApiMode.Auto;

    /// <summary>Globaler Hotkey</summary>
    public Keys GlobalHotkey { get; set; } = Keys.F3;

    /// <summary>Strg-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierCtrl { get; set; } = false;

    /// <summary>Alt-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierAlt { get; set; } = false;

    /// <summary>Umschalt-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierShift { get; set; } = true;

    /// <summary>Gibt an, ob das Hauptfenster via Alt + Tab erreichbar sein soll</summary>
    public bool AltTabEnabled { get; set; } = false;

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

    /// <summary>Angabe, ob der verwendete Cache-Typ angezeigt werden soll</summary>
    public bool ShowCacheType { get; set; } = false;

    /// <summary>Gibt an, ob für die Hauptorganisation zusätzliche Informationen angezeigt werden sollen (benötigt weitere API-Abfrage)</summary>
    public bool ShowAdditionalMainOrgInformation { get; set; } = false;

    public object Clone() {
      return MemberwiseClone();
    }
  }

  /// <summary>API-Modus</summary>
  public enum ApiMode {
    /// <summary>Immer aktuelle Daten</summary>
    Live,
    /// <summary>Auf dem Server gecachte Daten</summary>
    Cache,
    /// <summary>Wenn möglich, auf dem Server gecachte, ansonsten aktuelle Daten</summary>
    Auto,
    /// <summary>Wenn möglich, aktuelle Daten, ansonsten gecachte Daten</summary>
    Eager
  }

}
