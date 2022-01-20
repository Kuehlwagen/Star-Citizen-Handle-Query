﻿namespace Star_Citizen_Handle_Query.Serialization {

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
    public ApiMode ApiMode { get; set; } = ApiMode.auto;

    /// <summary>Globaler Hotkey</summary>
    public Keys GlobalHotkey { get; set; } = Keys.F3;

  }

  public enum ApiMode {
    /// <summary>Immer aktuelle Daten</summary>
    live,
    /// <summary>Auf dem Server gecachte Daten</summary>
    cache,
    /// <summary>Wenn möglich, auf dem Server gecachte, ansonsten aktuelle Daten</summary>
    auto,
    /// <summary>Wenn möglich, aktuelle Daten, ansonsten gecachte Daten</summary>
    eager
  }

}
