namespace MockUpCalculator {
    partial class StandardCalculatorPanel {
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
            this.keypadPanel = new System.Windows.Forms.Panel();
            this.standardKeypad = new UserControlClassLibrary.StandardKeypad();
            this.standardDisplay = new UserControlClassLibrary.StandardDisplay();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.keypadPanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // keypadPanel
            // 
            this.keypadPanel.Controls.Add(this.standardKeypad);
            this.keypadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadPanel.Location = new System.Drawing.Point(0, 102);
            this.keypadPanel.Margin = new System.Windows.Forms.Padding(0);
            this.keypadPanel.Name = "keypadPanel";
            this.keypadPanel.Size = new System.Drawing.Size(337, 405);
            this.keypadPanel.TabIndex = 1;
            // 
            // standardKeypad
            // 
            this.standardKeypad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.standardKeypad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standardKeypad.ExtraKeysSuspended = false;
            this.standardKeypad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.standardKeypad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.standardKeypad.HasMemory = false;
            this.standardKeypad.Location = new System.Drawing.Point(0, 0);
            this.standardKeypad.Margin = new System.Windows.Forms.Padding(0);
            this.standardKeypad.Name = "standardKeypad";
            this.standardKeypad.Size = new System.Drawing.Size(337, 405);
            this.standardKeypad.TabIndex = 0;
            // 
            // standardDisplay
            // 
            this.standardDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.standardDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.standardDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standardDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.standardDisplay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.standardDisplay.Location = new System.Drawing.Point(0, 0);
            this.standardDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.standardDisplay.Name = "standardDisplay";
            this.standardDisplay.Size = new System.Drawing.Size(337, 102);
            this.standardDisplay.TabIndex = 0;
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.standardDisplay, 0, 0);
            this.mainLayout.Controls.Add(this.keypadPanel, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.12F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.88F));
            this.mainLayout.Size = new System.Drawing.Size(337, 507);
            this.mainLayout.TabIndex = 0;
            // 
            // StandardCalculatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.mainLayout);
            this.Name = "StandardCalculatorPanel";
            this.keypadPanel.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel keypadPanel;
        private UserControlClassLibrary.StandardKeypad standardKeypad;
        private UserControlClassLibrary.StandardDisplay standardDisplay;
        private System.Windows.Forms.TableLayoutPanel mainLayout;

    }
}
