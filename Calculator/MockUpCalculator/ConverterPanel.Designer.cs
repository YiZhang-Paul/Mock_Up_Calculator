namespace MockUpCalculator {
    partial class ConverterPanel {
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.keypadPanel = new System.Windows.Forms.Panel();
            this.basicKeypad = new UserControlClassLibrary.BasicKeypad();
            this.mainLayout.SuspendLayout();
            this.keypadPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.keypadPanel, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.56213F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.43787F));
            this.mainLayout.Size = new System.Drawing.Size(337, 507);
            this.mainLayout.TabIndex = 1;
            // 
            // keypadPanel
            // 
            this.keypadPanel.Controls.Add(this.basicKeypad);
            this.keypadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadPanel.Location = new System.Drawing.Point(0, 230);
            this.keypadPanel.Margin = new System.Windows.Forms.Padding(0);
            this.keypadPanel.Name = "keypadPanel";
            this.keypadPanel.Size = new System.Drawing.Size(337, 277);
            this.keypadPanel.TabIndex = 1;
            // 
            // basicKeypad
            // 
            this.basicKeypad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.basicKeypad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basicKeypad.ExtraKeysSuspended = false;
            this.basicKeypad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.basicKeypad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.basicKeypad.HasMemory = false;
            this.basicKeypad.Location = new System.Drawing.Point(0, 0);
            this.basicKeypad.Margin = new System.Windows.Forms.Padding(0);
            this.basicKeypad.Name = "basicKeypad";
            this.basicKeypad.Size = new System.Drawing.Size(337, 277);
            this.basicKeypad.TabIndex = 0;
            // 
            // ConverterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConverterPanel";
            this.Size = new System.Drawing.Size(337, 507);
            this.mainLayout.ResumeLayout(false);
            this.keypadPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel keypadPanel;
        private UserControlClassLibrary.BasicKeypad basicKeypad;
    }
}
