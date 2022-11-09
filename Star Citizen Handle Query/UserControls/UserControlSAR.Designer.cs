namespace Star_Citizen_Handle_Query.UserControls {
  partial class UserControlSAR {
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
      this.PictureBoxEvent = new System.Windows.Forms.PictureBox();
      this.LabelHandle = new System.Windows.Forms.Label();
      this.LabelTime = new System.Windows.Forms.Label();
      this.PictureBoxLocalInventory = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxEvent)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLocalInventory)).BeginInit();
      this.SuspendLayout();
      // 
      // PictureBoxEvent
      // 
      this.PictureBoxEvent.Cursor = System.Windows.Forms.Cursors.Hand;
      this.PictureBoxEvent.Location = new System.Drawing.Point(1, 2);
      this.PictureBoxEvent.Name = "PictureBoxEvent";
      this.PictureBoxEvent.Size = new System.Drawing.Size(21, 21);
      this.PictureBoxEvent.TabIndex = 0;
      this.PictureBoxEvent.TabStop = false;
      this.PictureBoxEvent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Handle_MouseClick);
      // 
      // LabelHandle
      // 
      this.LabelHandle.Cursor = System.Windows.Forms.Cursors.Hand;
      this.LabelHandle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelHandle.Location = new System.Drawing.Point(58, 2);
      this.LabelHandle.Name = "LabelHandle";
      this.LabelHandle.Size = new System.Drawing.Size(156, 21);
      this.LabelHandle.TabIndex = 1;
      this.LabelHandle.Text = "Handle";
      this.LabelHandle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.LabelHandle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Handle_MouseClick);
      // 
      // LabelTime
      // 
      this.LabelTime.Cursor = System.Windows.Forms.Cursors.Hand;
      this.LabelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(157)))), ((int)(((byte)(158)))));
      this.LabelTime.Location = new System.Drawing.Point(23, 2);
      this.LabelTime.Name = "LabelTime";
      this.LabelTime.Size = new System.Drawing.Size(37, 21);
      this.LabelTime.TabIndex = 0;
      this.LabelTime.Text = "00:00";
      this.LabelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.LabelTime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Handle_MouseClick);
      // 
      // PictureBoxLocalInventory
      // 
      this.PictureBoxLocalInventory.Cursor = System.Windows.Forms.Cursors.Hand;
      this.PictureBoxLocalInventory.Location = new System.Drawing.Point(214, 2);
      this.PictureBoxLocalInventory.Name = "PictureBoxLocalInventory";
      this.PictureBoxLocalInventory.Size = new System.Drawing.Size(21, 21);
      this.PictureBoxLocalInventory.TabIndex = 0;
      this.PictureBoxLocalInventory.TabStop = false;
      this.PictureBoxLocalInventory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Handle_MouseClick);
      // 
      // UserControlSAR
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.Controls.Add(this.LabelTime);
      this.Controls.Add(this.LabelHandle);
      this.Controls.Add(this.PictureBoxLocalInventory);
      this.Controls.Add(this.PictureBoxEvent);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.Name = "UserControlSAR";
      this.Size = new System.Drawing.Size(238, 25);
      this.Load += new System.EventHandler(this.UserControlSAR_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxEvent)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLocalInventory)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion

        private PictureBox PictureBoxEvent;
        private Label LabelHandle;
        private Label LabelTime;
        private PictureBox PictureBoxLocalInventory;
    }
}
