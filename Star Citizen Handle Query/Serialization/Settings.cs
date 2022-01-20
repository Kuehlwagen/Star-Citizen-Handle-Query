namespace Star_Citizen_Handle_Query.Serialization {

  [Serializable()]
  public class Settings {

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
    public FKeys GlobalHotkey { get; set; } = FKeys.F3;

    /// <summary>Strg-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierCtrl { get; set; } = false;

    /// <summary>Alt-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierAlt { get; set; } = false;

    /// <summary>Umschalt-Modifizierer für globalen Hotkey</summary>
    public bool GlobalHotkeyModifierShift { get; set; } = true;

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

  /// <summary>F-Tasten für die Tastenbelegung</summary>
  public enum FKeys {
    Keine,
    F1,
    F2,
    F3,
    F4,
    F5,
    F6,
    F7,
    F8,
    F9,
    F10,
    F11,
    F12
  }

}
