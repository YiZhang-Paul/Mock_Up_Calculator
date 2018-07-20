namespace UserControlClassLibrary {
    partial class ConverterDisplay {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.displayLayout = new System.Windows.Forms.TableLayoutPanel();
            this.extraOutputTitleLabel = new System.Windows.Forms.Label();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.inputSymbolLabel = new System.Windows.Forms.Label();
            this.inputUnitBox = new System.Windows.Forms.ComboBox();
            this.inputLabel = new System.Windows.Forms.Label();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.outputUnitBox = new System.Windows.Forms.ComboBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.otherOutputPanel = new System.Windows.Forms.Panel();
            this.extraOutputLabelTwo = new System.Windows.Forms.Label();
            this.extraOutputLabelOne = new System.Windows.Forms.Label();
            this.outputSymbolLabel = new System.Windows.Forms.Label();
            this.displayLayout.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.outputPanel.SuspendLayout();
            this.otherOutputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayLayout
            // 
            this.displayLayout.ColumnCount = 1;
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.displayLayout.Controls.Add(this.extraOutputTitleLabel, 0, 2);
            this.displayLayout.Controls.Add(this.inputPanel, 0, 0);
            this.displayLayout.Controls.Add(this.outputPanel, 0, 1);
            this.displayLayout.Controls.Add(this.otherOutputPanel, 0, 3);
            this.displayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayLayout.Location = new System.Drawing.Point(0, 0);
            this.displayLayout.Margin = new System.Windows.Forms.Padding(0);
            this.displayLayout.Name = "displayLayout";
            this.displayLayout.RowCount = 4;
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.displayLayout.Size = new System.Drawing.Size(337, 148);
            this.displayLayout.TabIndex = 0;
            // 
            // extraOutputTitleLabel
            // 
            this.extraOutputTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.extraOutputTitleLabel.AutoSize = true;
            this.extraOutputTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.extraOutputTitleLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.extraOutputTitleLabel.Location = new System.Drawing.Point(9, 112);
            this.extraOutputTitleLabel.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.extraOutputTitleLabel.Name = "extraOutputTitleLabel";
            this.extraOutputTitleLabel.Size = new System.Drawing.Size(86, 15);
            this.extraOutputTitleLabel.TabIndex = 4;
            this.extraOutputTitleLabel.Text = "About equal to";
            this.extraOutputTitleLabel.Visible = false;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.inputSymbolLabel);
            this.inputPanel.Controls.Add(this.inputUnitBox);
            this.inputPanel.Controls.Add(this.inputLabel);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPanel.Location = new System.Drawing.Point(3, 3);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(331, 48);
            this.inputPanel.TabIndex = 2;
            // 
            // inputSymbolLabel
            // 
            this.inputSymbolLabel.AutoSize = true;
            this.inputSymbolLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 26F, System.Drawing.FontStyle.Bold);
            this.inputSymbolLabel.Location = new System.Drawing.Point(3, 0);
            this.inputSymbolLabel.Name = "inputSymbolLabel";
            this.inputSymbolLabel.Size = new System.Drawing.Size(0, 47);
            this.inputSymbolLabel.TabIndex = 5;
            this.inputSymbolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputUnitBox
            // 
            this.inputUnitBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputUnitBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.inputUnitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputUnitBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inputUnitBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.inputUnitBox.FormattingEnabled = true;
            this.inputUnitBox.Location = new System.Drawing.Point(9, 21);
            this.inputUnitBox.Name = "inputUnitBox";
            this.inputUnitBox.Size = new System.Drawing.Size(104, 25);
            this.inputUnitBox.TabIndex = 4;
            this.inputUnitBox.SelectionChangeCommitted += new System.EventHandler(this.ChangeSelectedUnit);
            this.inputUnitBox.DropDownClosed += new System.EventHandler(this.RemoveFocus);
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 26F, System.Drawing.FontStyle.Bold);
            this.inputLabel.Location = new System.Drawing.Point(3, 0);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(39, 47);
            this.inputLabel.TabIndex = 1;
            this.inputLabel.Text = "0";
            this.inputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.outputSymbolLabel);
            this.outputPanel.Controls.Add(this.outputUnitBox);
            this.outputPanel.Controls.Add(this.outputLabel);
            this.outputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputPanel.Location = new System.Drawing.Point(3, 57);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(331, 48);
            this.outputPanel.TabIndex = 3;
            // 
            // outputUnitBox
            // 
            this.outputUnitBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.outputUnitBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.outputUnitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputUnitBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.outputUnitBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.outputUnitBox.FormattingEnabled = true;
            this.outputUnitBox.Location = new System.Drawing.Point(9, 21);
            this.outputUnitBox.Name = "outputUnitBox";
            this.outputUnitBox.Size = new System.Drawing.Size(104, 25);
            this.outputUnitBox.TabIndex = 3;
            this.outputUnitBox.SelectionChangeCommitted += new System.EventHandler(this.ChangeSelectedUnit);
            this.outputUnitBox.DropDownClosed += new System.EventHandler(this.RemoveFocus);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Segoe UI Light", 26F);
            this.outputLabel.Location = new System.Drawing.Point(3, 0);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(38, 47);
            this.outputLabel.TabIndex = 2;
            this.outputLabel.Text = "0";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // otherOutputPanel
            // 
            this.otherOutputPanel.Controls.Add(this.extraOutputLabelTwo);
            this.otherOutputPanel.Controls.Add(this.extraOutputLabelOne);
            this.otherOutputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherOutputPanel.Location = new System.Drawing.Point(8, 130);
            this.otherOutputPanel.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.otherOutputPanel.Name = "otherOutputPanel";
            this.otherOutputPanel.Size = new System.Drawing.Size(326, 15);
            this.otherOutputPanel.TabIndex = 5;
            // 
            // extraOutputLabelTwo
            // 
            this.extraOutputLabelTwo.AutoSize = true;
            this.extraOutputLabelTwo.Dock = System.Windows.Forms.DockStyle.Left;
            this.extraOutputLabelTwo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.extraOutputLabelTwo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.extraOutputLabelTwo.Location = new System.Drawing.Point(0, 0);
            this.extraOutputLabelTwo.Name = "extraOutputLabelTwo";
            this.extraOutputLabelTwo.Size = new System.Drawing.Size(0, 20);
            this.extraOutputLabelTwo.TabIndex = 1;
            // 
            // extraOutputLabelOne
            // 
            this.extraOutputLabelOne.AutoSize = true;
            this.extraOutputLabelOne.Dock = System.Windows.Forms.DockStyle.Left;
            this.extraOutputLabelOne.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.extraOutputLabelOne.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.extraOutputLabelOne.Location = new System.Drawing.Point(0, 0);
            this.extraOutputLabelOne.Name = "extraOutputLabelOne";
            this.extraOutputLabelOne.Size = new System.Drawing.Size(0, 20);
            this.extraOutputLabelOne.TabIndex = 0;
            // 
            // outputSymbolLabel
            // 
            this.outputSymbolLabel.AutoSize = true;
            this.outputSymbolLabel.Font = new System.Drawing.Font("Segoe UI Light", 26F);
            this.outputSymbolLabel.Location = new System.Drawing.Point(3, 0);
            this.outputSymbolLabel.Name = "outputSymbolLabel";
            this.outputSymbolLabel.Size = new System.Drawing.Size(0, 47);
            this.outputSymbolLabel.TabIndex = 4;
            this.outputSymbolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConverterDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.displayLayout);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConverterDisplay";
            this.Size = new System.Drawing.Size(337, 148);
            this.displayLayout.ResumeLayout(false);
            this.displayLayout.PerformLayout();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.outputPanel.ResumeLayout(false);
            this.outputPanel.PerformLayout();
            this.otherOutputPanel.ResumeLayout(false);
            this.otherOutputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel displayLayout;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.ComboBox inputUnitBox;
        private System.Windows.Forms.ComboBox outputUnitBox;
        private System.Windows.Forms.Label extraOutputTitleLabel;
        private System.Windows.Forms.Panel otherOutputPanel;
        private System.Windows.Forms.Label extraOutputLabelTwo;
        private System.Windows.Forms.Label extraOutputLabelOne;
        private System.Windows.Forms.Label inputSymbolLabel;
        private System.Windows.Forms.Label outputSymbolLabel;
    }
}
