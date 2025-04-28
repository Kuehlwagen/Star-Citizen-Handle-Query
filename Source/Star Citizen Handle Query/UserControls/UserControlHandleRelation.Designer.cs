namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlHandleRelation {
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
      LabelFriendly = new Label();
      LabelNeutral = new Label();
      LabelBogey = new Label();
      LabelBandit = new Label();
      SuspendLayout();
      // 
      // LabelFriendly
      // 
      LabelFriendly.BackColor = Color.FromArgb(0, 64, 0);
      LabelFriendly.Cursor = Cursors.Hand;
      LabelFriendly.FlatStyle = FlatStyle.Flat;
      LabelFriendly.ForeColor = Color.Green;
      LabelFriendly.Location = new Point(3, 3);
      LabelFriendly.Name = "LabelFriendly";
      LabelFriendly.Size = new Size(89, 15);
      LabelFriendly.TabIndex = 0;
      LabelFriendly.TextAlign = ContentAlignment.MiddleCenter;
      LabelFriendly.Paint += Label_Paint;
      LabelFriendly.MouseClick += LabelFriendly_MouseClick;
      // 
      // LabelNeutral
      // 
      LabelNeutral.BackColor = Color.FromArgb(64, 64, 64);
      LabelNeutral.Cursor = Cursors.Hand;
      LabelNeutral.FlatStyle = FlatStyle.Flat;
      LabelNeutral.ForeColor = Color.Gray;
      LabelNeutral.Location = new Point(95, 3);
      LabelNeutral.Name = "LabelNeutral";
      LabelNeutral.Size = new Size(89, 15);
      LabelNeutral.TabIndex = 0;
      LabelNeutral.TextAlign = ContentAlignment.MiddleCenter;
      LabelNeutral.Paint += Label_Paint;
      LabelNeutral.MouseClick += LabelFriendly_MouseClick;
      // 
      // LabelBogey
      // 
      LabelBogey.BackColor = Color.FromArgb(127, 82, 0);
      LabelBogey.Cursor = Cursors.Hand;
      LabelBogey.FlatStyle = FlatStyle.Flat;
      LabelBogey.ForeColor = Color.Yellow;
      LabelBogey.Location = new Point(187, 3);
      LabelBogey.Name = "LabelBogey";
      LabelBogey.Size = new Size(89, 15);
      LabelBogey.TabIndex = 0;
      LabelBogey.TextAlign = ContentAlignment.MiddleCenter;
      LabelBogey.Paint += Label_Paint;
      LabelBogey.MouseClick += LabelFriendly_MouseClick;
      // 
      // LabelBandit
      // 
      LabelBandit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      LabelBandit.BackColor = Color.FromArgb(127, 0, 0);
      LabelBandit.Cursor = Cursors.Hand;
      LabelBandit.FlatStyle = FlatStyle.Flat;
      LabelBandit.ForeColor = Color.Red;
      LabelBandit.Location = new Point(279, 3);
      LabelBandit.Name = "LabelBandit";
      LabelBandit.Size = new Size(89, 15);
      LabelBandit.TabIndex = 0;
      LabelBandit.TextAlign = ContentAlignment.MiddleCenter;
      LabelBandit.Paint += Label_Paint;
      LabelBandit.MouseClick += LabelFriendly_MouseClick;
      // 
      // UserControlHandleRelation
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(19, 26, 33);
      Controls.Add(LabelBandit);
      Controls.Add(LabelBogey);
      Controls.Add(LabelNeutral);
      Controls.Add(LabelFriendly);
      ForeColor = Color.FromArgb(57, 206, 216);
      Margin = new Padding(0, 1, 0, 0);
      Name = "UserControlHandleRelation";
      Size = new Size(375, 21);
      Load += UserControlOrganization_Load;
      ResumeLayout(false);

    }

    #endregion

    private Label LabelFriendly;
    private Label LabelNeutral;
    private Label LabelBogey;
    private Label LabelBandit;
  }
}
