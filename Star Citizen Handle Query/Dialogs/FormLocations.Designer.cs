namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormLocations {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLocations));
      PanelHeader = new Panel();
      LabelTitle = new Label();
      PanelLocations = new FlowLayoutPanel();
      PanelHeader.SuspendLayout();
      SuspendLayout();
      // 
      // PanelHeader
      // 
      PanelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      PanelHeader.BackColor = Color.FromArgb(19, 26, 33);
      PanelHeader.Controls.Add(LabelTitle);
      PanelHeader.Location = new Point(1, 1);
      PanelHeader.Name = "PanelHeader";
      PanelHeader.Size = new Size(238, 29);
      PanelHeader.TabIndex = 0;
      // 
      // LabelTitle
      // 
      LabelTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      LabelTitle.Location = new Point(4, 7);
      LabelTitle.Name = "LabelTitle";
      LabelTitle.Size = new Size(223, 15);
      LabelTitle.TabIndex = 0;
      LabelTitle.Text = "Orte";
      LabelTitle.TextAlign = ContentAlignment.MiddleLeft;
      LabelTitle.MouseCaptureChanged += LabelTitle_MouseCaptureChanged;
      LabelTitle.MouseDown += LabelTitle_MouseDown;
      LabelTitle.MouseMove += LabelTitle_MouseMove;
      // 
      // PanelLocations
      // 
      PanelLocations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      PanelLocations.BackColor = Color.Lime;
      PanelLocations.FlowDirection = FlowDirection.TopDown;
      PanelLocations.Location = new Point(1, 30);
      PanelLocations.Margin = new Padding(0);
      PanelLocations.Name = "PanelLocations";
      PanelLocations.Size = new Size(238, 29);
      PanelLocations.TabIndex = 1;
      PanelLocations.ControlAdded += PanelLocations_ControlAdded;
      PanelLocations.ControlRemoved += PanelLocations_ControlRemoved;
      // 
      // FormLocations
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Lime;
      ClientSize = new Size(240, 60);
      Controls.Add(PanelLocations);
      Controls.Add(PanelHeader);
      ForeColor = Color.FromArgb(57, 206, 216);
      FormBorderStyle = FormBorderStyle.None;
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "FormLocations";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Star Citizen Handle Query";
      TopMost = true;
      TransparencyKey = Color.Lime;
      Deactivate += FormLocations_Deactivate;
      Shown += FormLocations_Shown;
      PanelHeader.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel PanelHeader;
    private Label LabelTitle;
    private FlowLayoutPanel PanelLocations;
  }
}