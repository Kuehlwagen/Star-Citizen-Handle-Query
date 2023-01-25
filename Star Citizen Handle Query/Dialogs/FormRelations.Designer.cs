﻿namespace Star_Citizen_Handle_Query.Dialogs {
  partial class FormRelations {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelations));
      this.PanelHeader = new System.Windows.Forms.Panel();
      this.PictureBoxClearAll = new System.Windows.Forms.PictureBox();
      this.LabelTitle = new System.Windows.Forms.Label();
      this.PanelRelations = new System.Windows.Forms.FlowLayoutPanel();
      this.PanelHeader.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxClearAll)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelHeader
      // 
      this.PanelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
      this.PanelHeader.Controls.Add(this.PictureBoxClearAll);
      this.PanelHeader.Controls.Add(this.LabelTitle);
      this.PanelHeader.Location = new System.Drawing.Point(1, 1);
      this.PanelHeader.Name = "PanelHeader";
      this.PanelHeader.Size = new System.Drawing.Size(238, 29);
      this.PanelHeader.TabIndex = 0;
      // 
      // PictureBoxClearAll
      // 
      this.PictureBoxClearAll.Image = global::Star_Citizen_Handle_Query.Properties.Resources.ClearAll_Deactivated;
      this.PictureBoxClearAll.Location = new System.Drawing.Point(219, 7);
      this.PictureBoxClearAll.Name = "PictureBoxClearAll";
      this.PictureBoxClearAll.Size = new System.Drawing.Size(12, 15);
      this.PictureBoxClearAll.TabIndex = 2;
      this.PictureBoxClearAll.TabStop = false;
      // 
      // LabelTitle
      // 
      this.LabelTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelTitle.Location = new System.Drawing.Point(4, 7);
      this.LabelTitle.Name = "LabelTitle";
      this.LabelTitle.Size = new System.Drawing.Size(213, 15);
      this.LabelTitle.TabIndex = 0;
      this.LabelTitle.Text = "Beziehungen";
      this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.LabelTitle.MouseCaptureChanged += new System.EventHandler(this.LabelTitle_MouseCaptureChanged);
      this.LabelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelTitle_MouseDown);
      this.LabelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelTitle_MouseMove);
      // 
      // PanelRelations
      // 
      this.PanelRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PanelRelations.BackColor = System.Drawing.Color.Lime;
      this.PanelRelations.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.PanelRelations.Location = new System.Drawing.Point(1, 30);
      this.PanelRelations.Margin = new System.Windows.Forms.Padding(0);
      this.PanelRelations.Name = "PanelRelations";
      this.PanelRelations.Size = new System.Drawing.Size(238, 29);
      this.PanelRelations.TabIndex = 1;
      this.PanelRelations.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.PanelRelations_ControlAdded);
      this.PanelRelations.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.PanelRelations_ControlRemoved);
      // 
      // FormRelations
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Lime;
      this.ClientSize = new System.Drawing.Size(240, 60);
      this.Controls.Add(this.PanelRelations);
      this.Controls.Add(this.PanelHeader);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormRelations";
      this.ShowInTaskbar = false;
      this.Text = "Star Citizen Handle Query";
      this.TopMost = true;
      this.TransparencyKey = System.Drawing.Color.Lime;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRelations_FormClosing);
      this.Shown += new System.EventHandler(this.FormRelations_Shown);
      this.PanelHeader.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBoxClearAll)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Panel PanelHeader;
    private Label LabelTitle;
    private FlowLayoutPanel PanelRelations;
        private PictureBox PictureBoxClearAll;
    }
}