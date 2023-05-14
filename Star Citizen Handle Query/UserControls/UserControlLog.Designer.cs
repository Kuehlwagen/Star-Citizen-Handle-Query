namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlLog {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent() {
      PictureBoxLeft = new PictureBox();
      LabelText = new Label();
      LabelTime = new Label();
      PictureBoxRight = new PictureBox();
      ((System.ComponentModel.ISupportInitialize)PictureBoxLeft).BeginInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxRight).BeginInit();
      SuspendLayout();
      // 
      // PictureBoxLeft
      // 
      PictureBoxLeft.Location = new Point(1, 2);
      PictureBoxLeft.Name = "PictureBoxLeft";
      PictureBoxLeft.Size = new Size(21, 21);
      PictureBoxLeft.TabIndex = 0;
      PictureBoxLeft.TabStop = false;
      // 
      // LabelText
      // 
      LabelText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      LabelText.Location = new Point(55, 5);
      LabelText.Name = "LabelText";
      LabelText.Size = new Size(160, 15);
      LabelText.TabIndex = 1;
      LabelText.Text = "Text";
      LabelText.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // LabelTime
      // 
      LabelTime.ForeColor = Color.FromArgb(46, 157, 158);
      LabelTime.Location = new Point(23, 2);
      LabelTime.Name = "LabelTime";
      LabelTime.Size = new Size(34, 21);
      LabelTime.TabIndex = 0;
      LabelTime.Text = "00:00";
      LabelTime.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // PictureBoxRight
      // 
      PictureBoxRight.Location = new Point(214, 2);
      PictureBoxRight.Name = "PictureBoxRight";
      PictureBoxRight.Size = new Size(21, 21);
      PictureBoxRight.TabIndex = 0;
      PictureBoxRight.TabStop = false;
      // 
      // UserControlLog
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      Controls.Add(LabelTime);
      Controls.Add(LabelText);
      Controls.Add(PictureBoxRight);
      Controls.Add(PictureBoxLeft);
      ForeColor = Color.FromArgb(57, 206, 216);
      Margin = new Padding(0, 1, 0, 0);
      Name = "UserControlLog";
      Size = new Size(238, 25);
      Load += UserControlLog_Load;
      ((System.ComponentModel.ISupportInitialize)PictureBoxLeft).EndInit();
      ((System.ComponentModel.ISupportInitialize)PictureBoxRight).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private PictureBox PictureBoxLeft;
    private Label LabelText;
    private Label LabelTime;
    private PictureBox PictureBoxRight;
  }
}
