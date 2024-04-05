namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormEditRpcChannels {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditRpcChannels));
      SuspendLayout();
      // 
      // FormEditRpcChannels
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      ClientSize = new Size(800, 450);
      ForeColor = Color.FromArgb(57, 206, 216);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "FormEditRpcChannels";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "SCHQ_Server gRPC Kanalverwaltung";
      ResumeLayout(false);
    }

    #endregion
  }
}