namespace MockUpCalculator {
    partial class ScientificCalculatorPanel {
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
            this.standardDisplay = new UserControlClassLibrary.StandardDisplay();
            this.keypadPanel = new System.Windows.Forms.Panel();
            this.scientificKeypad = new UserControlClassLibrary.ScientificKeypad();
            this.memoryPanel = new UserControlClassLibrary.MemoryPanel();
            this.mainLayout.SuspendLayout();
            this.keypadPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.standardDisplay, 0, 0);
            this.mainLayout.Controls.Add(this.keypadPanel, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.mainLayout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.12F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.88F));
            this.mainLayout.Size = new System.Drawing.Size(337, 507);
            this.mainLayout.TabIndex = 0;
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
            // keypadPanel
            // 
            this.keypadPanel.Controls.Add(this.scientificKeypad);
            this.keypadPanel.Controls.Add(this.memoryPanel);
            this.keypadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypadPanel.Location = new System.Drawing.Point(0, 102);
            this.keypadPanel.Margin = new System.Windows.Forms.Padding(0);
            this.keypadPanel.Name = "keypadPanel";
            this.keypadPanel.Size = new System.Drawing.Size(337, 405);
            this.keypadPanel.TabIndex = 1;
            // 
            // scientificKeypad
            // 
            this.scientificKeypad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.scientificKeypad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scientificKeypad.ExtraKeysSuspended = false;
            this.scientificKeypad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.scientificKeypad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scientificKeypad.HasMemory = false;
            this.scientificKeypad.Location = new System.Drawing.Point(0, 0);
            this.scientificKeypad.Margin = new System.Windows.Forms.Padding(0);
            this.scientificKeypad.Name = "scientificKeypad";
            this.scientificKeypad.Size = new System.Drawing.Size(337, 405);
            this.scientificKeypad.TabIndex = 0;
            // 
            // memoryPanel
            // 
            this.memoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.memoryPanel.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.memoryPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.memoryPanel.Location = new System.Drawing.Point(0, 323);
            this.memoryPanel.Margin = new System.Windows.Forms.Padding(0);
            this.memoryPanel.Name = "memoryPanel";
            this.memoryPanel.Size = new System.Drawing.Size(337, 82);
            this.memoryPanel.TabIndex = 1;
            // 
            // StandardCalculatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "StandardCalculatorPanel";
            this.Size = new System.Drawing.Size(337, 507);
            this.mainLayout.ResumeLayout(false);
            this.keypadPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private UserControlClassLibrary.StandardDisplay standardDisplay;
        private System.Windows.Forms.Panel keypadPanel;
        private UserControlClassLibrary.ScientificKeypad scientificKeypad;
        private UserControlClassLibrary.MemoryPanel memoryPanel;
    }
}
