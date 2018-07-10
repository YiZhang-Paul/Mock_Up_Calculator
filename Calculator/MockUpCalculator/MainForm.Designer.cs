namespace MockUpCalculator {
    partial class MainForm {
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
            this.topPanel = new UserControlClassLibrary.TopPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.uiLayout = new System.Windows.Forms.TableLayoutPanel();
            this.menuBarLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnHistory = new System.Windows.Forms.Button();
            this.currentLabel = new System.Windows.Forms.Label();
            this.switchPanel = new System.Windows.Forms.Panel();
            this.btnChangeCalculator = new System.Windows.Forms.Button();
            this.sidePanel = new UserControlClassLibrary.SidePanel();
            this.zoomTimer = new System.Windows.Forms.Timer(this.components);
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            this.openTimer = new System.Windows.Forms.Timer(this.components);
            this.mainLayout.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.uiLayout.SuspendLayout();
            this.menuBarLayout.SuspendLayout();
            this.switchPanel.SuspendLayout();
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
            // bottomPanel
            //
            this.bottomPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bottomPanel.Controls.Add(this.uiLayout);
            this.bottomPanel.Controls.Add(this.sidePanel);
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
            this.uiLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLayout.Location = new System.Drawing.Point(0, 0);
            this.uiLayout.Margin = new System.Windows.Forms.Padding(0);
            this.uiLayout.Name = "uiLayout";
            this.uiLayout.RowCount = 2;
            this.uiLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.uiLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiLayout.Size = new System.Drawing.Size(337, 557);
            this.uiLayout.TabIndex = 1;
            //
            // menuBarLayout
            //
            this.menuBarLayout.ColumnCount = 3;
            this.menuBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.menuBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.menuBarLayout.Controls.Add(this.btnHistory, 2, 0);
            this.menuBarLayout.Controls.Add(this.currentLabel, 1, 0);
            this.menuBarLayout.Controls.Add(this.switchPanel, 0, 0);
            this.menuBarLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBarLayout.Location = new System.Drawing.Point(0, 0);
            this.menuBarLayout.Margin = new System.Windows.Forms.Padding(0);
            this.menuBarLayout.Name = "menuBarLayout";
            this.menuBarLayout.RowCount = 1;
            this.menuBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuBarLayout.Size = new System.Drawing.Size(337, 50);
            this.menuBarLayout.TabIndex = 0;
            //
            // btnHistory
            //
            this.btnHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnHistory.FlatAppearance.BorderSize = 2;
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
            this.btnHistory.Click += new System.EventHandler(this.ToggleHistoryPanel);
            this.btnHistory.MouseEnter += new System.EventHandler(this.KeypadButtonMouseEnter);
            this.btnHistory.MouseLeave += new System.EventHandler(this.KeypadButtonMouseLeave);
            //
            // calculatorLabel
            //
            this.currentLabel.AutoSize = true;
            this.currentLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.currentLabel.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.currentLabel.Location = new System.Drawing.Point(50, 0);
            this.currentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.currentLabel.Name = "calculatorLabel";
            this.currentLabel.Size = new System.Drawing.Size(0, 50);
            this.currentLabel.TabIndex = 3;
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // switchPanel
            //
            this.switchPanel.Controls.Add(this.btnChangeCalculator);
            this.switchPanel.Location = new System.Drawing.Point(0, 0);
            this.switchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.switchPanel.Name = "switchPanel";
            this.switchPanel.Size = new System.Drawing.Size(50, 50);
            this.switchPanel.TabIndex = 4;
            //
            // btnChangeCalculator
            //
            this.btnChangeCalculator.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangeCalculator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeCalculator.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnChangeCalculator.FlatAppearance.BorderSize = 2;
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
            this.btnChangeCalculator.TabIndex = 2;
            this.btnChangeCalculator.Text = "≡";
            this.btnChangeCalculator.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChangeCalculator.UseVisualStyleBackColor = true;
            this.btnChangeCalculator.Click += new System.EventHandler(this.ChangeMenuClick);
            this.btnChangeCalculator.MouseEnter += new System.EventHandler(this.KeypadButtonMouseEnter);
            this.btnChangeCalculator.MouseLeave += new System.EventHandler(this.KeypadButtonMouseLeave);
            //
            // sidePanel
            //
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sidePanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.sidePanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(240, 557);
            this.sidePanel.TabIndex = 0;
            //
            // zoomTimer
            //
            this.zoomTimer.Interval = 16;
            //
            // closeTimer
            //
            this.closeTimer.Interval = 1;
            //
            // openTimer
            //
            this.openTimer.Interval = 1;
            //
            // MainForm
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
            this.MinimumSize = new System.Drawing.Size(320, 500);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.Deactivate += new System.EventHandler(this.DeactivateBackPanel);
            this.Load += new System.EventHandler(this.LoadUI);
            this.ResizeBegin += new System.EventHandler(this.FormResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.FormResizeEnd);
            this.mainLayout.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.uiLayout.ResumeLayout(false);
            this.menuBarLayout.ResumeLayout(false);
            this.menuBarLayout.PerformLayout();
            this.switchPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private UserControlClassLibrary.TopPanel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Timer zoomTimer;
        private System.Windows.Forms.Timer closeTimer;
        private System.Windows.Forms.TableLayoutPanel uiLayout;
        private System.Windows.Forms.TableLayoutPanel menuBarLayout;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Panel switchPanel;
        private System.Windows.Forms.Button btnChangeCalculator;
        private UserControlClassLibrary.SidePanel sidePanel;
        private System.Windows.Forms.Timer openTimer;
    }
}

