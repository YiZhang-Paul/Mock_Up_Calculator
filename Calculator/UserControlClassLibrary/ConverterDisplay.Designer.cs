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
            this.inputPanel = new System.Windows.Forms.Panel();
            this.inputLabel = new System.Windows.Forms.Label();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.outputLabel = new System.Windows.Forms.Label();
            this.displayLayout.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.outputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayLayout
            // 
            this.displayLayout.ColumnCount = 1;
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.Controls.Add(this.inputPanel, 0, 0);
            this.displayLayout.Controls.Add(this.outputPanel, 0, 1);
            this.displayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayLayout.Location = new System.Drawing.Point(0, 0);
            this.displayLayout.Margin = new System.Windows.Forms.Padding(0);
            this.displayLayout.Name = "displayLayout";
            this.displayLayout.RowCount = 2;
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.Size = new System.Drawing.Size(337, 148);
            this.displayLayout.TabIndex = 0;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.inputLabel);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPanel.Location = new System.Drawing.Point(3, 3);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(331, 68);
            this.inputPanel.TabIndex = 2;
            // 
            // inputLabel
            // 
            this.inputLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.inputLabel.AutoSize = true;
            this.inputLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.inputLabel.Location = new System.Drawing.Point(0, 10);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(38, 45);
            this.inputLabel.TabIndex = 1;
            this.inputLabel.Text = "0";
            this.inputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.outputLabel);
            this.outputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputPanel.Location = new System.Drawing.Point(3, 77);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(331, 68);
            this.outputPanel.TabIndex = 3;
            // 
            // outputLabel
            // 
            this.outputLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.outputLabel.Location = new System.Drawing.Point(0, 11);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(38, 45);
            this.outputLabel.TabIndex = 2;
            this.outputLabel.Text = "0";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.outputPanel.ResumeLayout(false);
            this.outputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel displayLayout;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.Label outputLabel;
    }
}
