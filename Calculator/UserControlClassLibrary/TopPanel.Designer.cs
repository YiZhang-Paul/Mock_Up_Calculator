namespace UserControlClassLibrary {
    partial class mainPanel {
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
            this.btnLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSizeToggle = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.mainLayout.SuspendLayout();
            this.btnLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.mainLayout.Controls.Add(this.btnLayout, 1, 0);
            this.mainLayout.Controls.Add(this.nameLabel, 0, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(353, 32);
            this.mainLayout.TabIndex = 0;
            this.mainLayout.DoubleClick += new System.EventHandler(this.btnSizeToggle_Click);
            this.mainLayout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GetPointerLocation);
            this.mainLayout.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag);
            // 
            // btnLayout
            // 
            this.btnLayout.ColumnCount = 3;
            this.btnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.btnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.btnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.btnLayout.Controls.Add(this.btnExit, 2, 0);
            this.btnLayout.Controls.Add(this.btnSizeToggle, 1, 0);
            this.btnLayout.Controls.Add(this.btnMinimize, 0, 0);
            this.btnLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLayout.Location = new System.Drawing.Point(210, 0);
            this.btnLayout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.RowCount = 1;
            this.btnLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.btnLayout.Size = new System.Drawing.Size(143, 32);
            this.btnLayout.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnExit.Location = new System.Drawing.Point(94, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "✕";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSizeToggle
            // 
            this.btnSizeToggle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSizeToggle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSizeToggle.FlatAppearance.BorderSize = 0;
            this.btnSizeToggle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnSizeToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.btnSizeToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSizeToggle.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSizeToggle.Location = new System.Drawing.Point(47, 0);
            this.btnSizeToggle.Margin = new System.Windows.Forms.Padding(0);
            this.btnSizeToggle.Name = "btnSizeToggle";
            this.btnSizeToggle.Size = new System.Drawing.Size(47, 32);
            this.btnSizeToggle.TabIndex = 1;
            this.btnSizeToggle.Text = "⬜";
            this.btnSizeToggle.UseVisualStyleBackColor = true;
            this.btnSizeToggle.Click += new System.EventHandler(this.btnSizeToggle_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnMinimize.Location = new System.Drawing.Point(0, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(47, 32);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Text = "➖";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.nameLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Padding = new System.Windows.Forms.Padding(9, 6, 6, 6);
            this.nameLabel.Size = new System.Drawing.Size(83, 32);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Calculator";
            this.nameLabel.DoubleClick += new System.EventHandler(this.btnSizeToggle_Click);
            this.nameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GetPointerLocation);
            this.nameLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag);
            // 
            // mainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "mainPanel";
            this.Size = new System.Drawing.Size(353, 32);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.btnLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel btnLayout;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSizeToggle;
    }
}
