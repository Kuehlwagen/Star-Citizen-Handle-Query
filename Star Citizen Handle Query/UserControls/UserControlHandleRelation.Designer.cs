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
      this.LabelFriendly = new System.Windows.Forms.Label();
      this.LabelNeutral = new System.Windows.Forms.Label();
      this.LabelBogey = new System.Windows.Forms.Label();
      this.LabelBandit = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // LabelFriendly
      // 
      this.LabelFriendly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.LabelFriendly.Cursor = System.Windows.Forms.Cursors.Hand;
      this.LabelFriendly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.LabelFriendly.ForeColor = System.Drawing.Color.Green;
      this.LabelFriendly.Location = new System.Drawing.Point(3, 3);
      this.LabelFriendly.Name = "LabelFriendly";
      this.LabelFriendly.Size = new System.Drawing.Size(89, 15);
      this.LabelFriendly.TabIndex = 0;
      this.LabelFriendly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.LabelFriendly.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
      this.LabelFriendly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LabelFriendly_MouseClick);
      // 
      // LabelNeutral
      // 
      this.LabelNeutral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabelNeutral.Cursor = System.Windows.Forms.Cursors.Hand;
      this.LabelNeutral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.LabelNeutral.ForeColor = System.Drawing.Color.Gray;
      this.LabelNeutral.Location = new System.Drawing.Point(95, 3);
      this.LabelNeutral.Name = "LabelNeutral";
      this.LabelNeutral.Size = new System.Drawing.Size(89, 15);
      this.LabelNeutral.TabIndex = 0;
      this.LabelNeutral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.LabelNeutral.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
      this.LabelNeutral.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LabelFriendly_MouseClick);
      // 
      // LabelBogey
      // 
      this.LabelBogey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(82)))), ((int)(((byte)(0)))));
      this.LabelBogey.Cursor = System.Windows.Forms.Cursors.Hand;
      this.LabelBogey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.LabelBogey.ForeColor = System.Drawing.Color.Yellow;
      this.LabelBogey.Location = new System.Drawing.Point(187, 3);
      this.LabelBogey.Name = "LabelBogey";
      this.LabelBogey.Size = new System.Drawing.Size(89, 15);
      this.LabelBogey.TabIndex = 0;
      this.LabelBogey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.LabelBogey.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
      this.LabelBogey.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LabelFriendly_MouseClick);
      // 
      // LabelBandit
      // 
      this.LabelBandit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.LabelBandit.Cursor = System.Windows.Forms.Cursors.Hand;
      this.LabelBandit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.LabelBandit.ForeColor = System.Drawing.Color.Red;
      this.LabelBandit.Location = new System.Drawing.Point(279, 3);
      this.LabelBandit.Name = "LabelBandit";
      this.LabelBandit.Size = new System.Drawing.Size(89, 15);
      this.LabelBandit.TabIndex = 0;
      this.LabelBandit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.LabelBandit.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
      this.LabelBandit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LabelFriendly_MouseClick);
      // 
      // UserControlHandleRelation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.Controls.Add(this.LabelBandit);
      this.Controls.Add(this.LabelBogey);
      this.Controls.Add(this.LabelNeutral);
      this.Controls.Add(this.LabelFriendly);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.Name = "UserControlHandleRelation";
      this.Size = new System.Drawing.Size(375, 21);
      this.Load += new System.EventHandler(this.UserControlOrganization_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private Label LabelFriendly;
    private Label LabelNeutral;
    private Label LabelBogey;
    private Label LabelBandit;
  }
}
