using Star_Citizen_Handle_Query.Serialization;

namespace Star_Citizen_Handle_Query.Dialogs;
public partial class FormEditRpcChannels : Form {

  private readonly Settings ProgramSettings;
  private readonly Translation ProgramTranslation;

  public FormEditRpcChannels(Settings settings, Translation translation) {
    InitializeComponent();
    ProgramSettings = settings;
    ProgramTranslation = translation;
    UpdateLocalization();
  }

  private void UpdateLocalization() {
    PerformLayout();

    Text = $"SCHQ_Server {ProgramTranslation.Settings.Relations.RPC_Channels.Title} - {ProgramSettings.Relations.RPC_URL}";

    ResumeLayout();
  }

}
