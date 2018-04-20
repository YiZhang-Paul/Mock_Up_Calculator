namespace MockUpCalculator {
    partial class MainCalculator {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.uiLayout = new System.Windows.Forms.TableLayoutPanel();
            this.menuBarLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnChangeCalculator = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomTimer = new System.Windows.Forms.Timer(this.components);
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            this.topPanel = new UserControlClassLibrary.topPanel();
            this.standardDisplay = new UserControlClassLibrary.standardDisplay();
            this.mainLayout.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.uiLayout.SuspendLayout();
            this.menuBarLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.topPanel, 0, 0);
            this.mainLayout.Controls.Add(this.bottomPanel, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(1, 1);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.Size = new System.Drawing.Size(337, 589);
            this.mainLayout.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bottomPanel.Controls.Add(this.uiLayout);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(0, 32);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(337, 557);
            this.bottomPanel.TabIndex = 1;
            // 
            // uiLayout
            // 
            this.uiLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiLayout.ColumnCount = 1;
            this.uiLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiLayout.Controls.Add(this.menuBarLayout, 0, 0);
            this.uiLayout.Controls.Add(this.standardDisplay, 0, 1);
            this.uiLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLayout.Location = new System.Drawing.Point(0, 0);
            this.uiLayout.Margin = new System.Windows.Forms.Padding(0);
            this.uiLayout.Name = "uiLayout";
            this.uiLayout.RowCount = 3;
            this.uiLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.uiLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.11834F));
            this.uiLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.88166F));
            this.uiLayout.Size = new System.Drawing.Size(337, 557);
            this.uiLayout.TabIndex = 0;
            // 
            // menuBarLayout
            // 
            this.menuBarLayout.ColumnCount = 3;
            this.menuBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.menuBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.menuBarLayout.Controls.Add(this.btnChangeCalculator, 0, 0);
            this.menuBarLayout.Controls.Add(this.btnHistory, 2, 0);
            this.menuBarLayout.Controls.Add(this.label1, 1, 0);
            this.menuBarLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBarLayout.Location = new System.Drawing.Point(0, 0);
            this.menuBarLayout.Margin = new System.Windows.Forms.Padding(0);
            this.menuBarLayout.Name = "menuBarLayout";
            this.menuBarLayout.RowCount = 1;
            this.menuBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuBarLayout.Size = new System.Drawing.Size(337, 50);
            this.menuBarLayout.TabIndex = 0;
            // 
            // btnChangeCalculator
            // 
            this.btnChangeCalculator.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangeCalculator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeCalculator.FlatAppearance.BorderSize = 0;
            this.btnChangeCalculator.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnChangeCalculator.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.btnChangeCalculator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeCalculator.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnChangeCalculator.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnChangeCalculator.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChangeCalculator.Location = new System.Drawing.Point(0, 0);
            this.btnChangeCalculator.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangeCalculator.Name = "btnChangeCalculator";
            this.btnChangeCalculator.Size = new System.Drawing.Size(50, 50);
            this.btnChangeCalculator.TabIndex = 1;
            this.btnChangeCalculator.Text = "≡";
            this.btnChangeCalculator.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChangeCalculator.UseVisualStyleBackColor = true;
            this.btnChangeCalculator.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnChangeCalculator.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnHistory
            // 
            this.btnHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btnHistory.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnHistory.Location = new System.Drawing.Point(287, 0);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(50, 50);
            this.btnHistory.TabIndex = 2;
            this.btnHistory.Text = "⏲";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnHistory.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 17.25F);
            this.label1.Location = new System.Drawing.Point(50, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Scientific";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zoomTimer
            // 
            this.zoomTimer.Interval = 16;
            // 
            // closeTimer
            // 
            this.closeTimer.Interval = 1;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.topPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(337, 32);
            this.topPanel.TabIndex = 0;
            // 
            // standardDisplay
            // 
            this.standardDisplay.AutoSize = true;
            this.standardDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.standardDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.standardDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standardDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.standardDisplay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.standardDisplay.Location = new System.Drawing.Point(0, 50);
            this.standardDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.standardDisplay.Name = "standardDisplay";
            this.standardDisplay.Size = new System.Drawing.Size(337, 101);
            this.standardDisplay.TabIndex = 1;
            // 
            // MainCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(339, 591);
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(270, 510);
            this.Name = "MainCalculator";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.mainLayout.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.uiLayout.ResumeLayout(false);
            this.uiLayout.PerformLayout();
            this.menuBarLayout.ResumeLayout(false);
            this.menuBarLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private UserControlClassLibrary.topPanel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Timer zoomTimer;
        private System.Windows.Forms.Timer closeTimer;
        private System.Windows.Forms.TableLayoutPanel uiLayout;
        private System.Windows.Forms.TableLayoutPanel menuBarLayout;
        private System.Windows.Forms.Button btnChangeCalculator;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label label1;
        private UserControlClassLibrary.standardDisplay standardDisplay;
    }
}

