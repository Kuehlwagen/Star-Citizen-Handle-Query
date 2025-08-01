namespace Star_Citizen_Handle_Query.Serialization;

[Serializable]
public class AppColors {
  public string ForeColor { get; set; } = "#39CED8";
  public string ForeColorInactive { get; set; } = "#2E9D9E";
  public string BackColor { get; set; } = "#131A21";
  internal Color AppForeColor => ColorTranslator.FromHtml(ForeColor);
  internal Color AppForeColorInactive => ColorTranslator.FromHtml(ForeColorInactive);
  internal Color AppBackColor => ColorTranslator.FromHtml(BackColor);
}
