namespace UserControlClassLibrary {
    partial class StandardDisplay {
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
            this.resultPanel = new System.Windows.Forms.Panel();
            this.resultLabel = new System.Windows.Forms.Label();
            this.expressionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.expressionPanel = new System.Windows.Forms.Panel();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.expressionLabel = new System.Windows.Forms.Label();
            this.rightArrowPanel = new System.Windows.Forms.Panel();
            this.leftArrowPanel = new System.Windows.Forms.Panel();
            this.leftArrowLabel = new System.Windows.Forms.Label();
            this.rightArrowLabel = new System.Windows.Forms.Label();
            this.displayLayout.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.expressionLayout.SuspendLayout();
            this.expressionPanel.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.rightArrowPanel.SuspendLayout();
            this.leftArrowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayLayout
            // 
            this.displayLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.displayLayout.ColumnCount = 1;
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.Controls.Add(this.resultPanel, 0, 1);
            this.displayLayout.Controls.Add(this.expressionLayout, 0, 0);
            this.displayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayLayout.Location = new System.Drawing.Point(0, 0);
            this.displayLayout.Margin = new System.Windows.Forms.Padding(0);
            this.displayLayout.Name = "displayLayout";
            this.displayLayout.RowCount = 2;
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.03571F));
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.96429F));
            this.displayLayout.Size = new System.Drawing.Size(337, 112);
            this.displayLayout.TabIndex = 0;
            // 
            // resultPanel
            // 
            this.resultPanel.Controls.Add(this.resultLabel);
            this.resultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPanel.Location = new System.Drawing.Point(0, 36);
            this.resultPanel.Margin = new System.Windows.Forms.Padding(0);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(337, 76);
            this.resultPanel.TabIndex = 3;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 35F, System.Drawing.FontStyle.Bold);
            this.resultLabel.Location = new System.Drawing.Point(337, 0);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 62);
            this.resultLabel.TabIndex = 2;
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // expressionLayout
            // 
            this.expressionLayout.ColumnCount = 3;
            this.expressionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.expressionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expressionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.expressionLayout.Controls.Add(this.expressionPanel, 1, 0);
            this.expressionLayout.Controls.Add(this.rightArrowPanel, 2, 0);
            this.expressionLayout.Controls.Add(this.leftArrowPanel, 0, 0);
            this.expressionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expressionLayout.Location = new System.Drawing.Point(0, 0);
            this.expressionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.expressionLayout.Name = "expressionLayout";
            this.expressionLayout.RowCount = 1;
            this.expressionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expressionLayout.Size = new System.Drawing.Size(337, 36);
            this.expressionLayout.TabIndex = 4;
            // 
            // expressionPanel
            // 
            this.expressionPanel.Controls.Add(this.scrollPanel);
            this.expressionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expressionPanel.Location = new System.Drawing.Point(25, 0);
            this.expressionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.expressionPanel.Name = "expressionPanel";
            this.expressionPanel.Size = new System.Drawing.Size(287, 36);
            this.expressionPanel.TabIndex = 5;
            // 
            // scrollPanel
            // 
            this.scrollPanel.Controls.Add(this.expressionLabel);
            this.scrollPanel.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel.Margin = new System.Windows.Forms.Padding(0);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(297, 36);
            this.scrollPanel.TabIndex = 8;
            this.scrollPanel.MouseHover += new System.EventHandler(this.scrollPanel_MouseHover);
            // 
            // expressionLabel
            // 
            this.expressionLabel.AutoSize = true;
            this.expressionLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.expressionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.expressionLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.expressionLabel.Location = new System.Drawing.Point(272, 0);
            this.expressionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.expressionLabel.Name = "expressionLabel";
            this.expressionLabel.Padding = new System.Windows.Forms.Padding(0, 5, 25, 0);
            this.expressionLabel.Size = new System.Drawing.Size(25, 24);
            this.expressionLabel.TabIndex = 13;
            this.expressionLabel.MouseHover += new System.EventHandler(this.expressionLabel_MouseHover);
            // 
            // rightArrowPanel
            // 
            this.rightArrowPanel.Controls.Add(this.rightArrowLabel);
            this.rightArrowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightArrowPanel.Location = new System.Drawing.Point(312, 0);
            this.rightArrowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightArrowPanel.Name = "rightArrowPanel";
            this.rightArrowPanel.Size = new System.Drawing.Size(25, 36);
            this.rightArrowPanel.TabIndex = 5;
            // 
            // leftArrowPanel
            // 
            this.leftArrowPanel.Controls.Add(this.leftArrowLabel);
            this.leftArrowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftArrowPanel.Location = new System.Drawing.Point(0, 0);
            this.leftArrowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftArrowPanel.Name = "leftArrowPanel";
            this.leftArrowPanel.Size = new System.Drawing.Size(25, 36);
            this.leftArrowPanel.TabIndex = 4;
            // 
            // leftArrowLabel
            // 
            this.leftArrowLabel.AutoSize = true;
            this.leftArrowLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.leftArrowLabel.Font = new System.Drawing.Font("Courier Prime Code", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftArrowLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.leftArrowLabel.Location = new System.Drawing.Point(-2, 0);
            this.leftArrowLabel.Margin = new System.Windows.Forms.Padding(0);
            this.leftArrowLabel.Name = "leftArrowLabel";
            this.leftArrowLabel.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.leftArrowLabel.Size = new System.Drawing.Size(27, 28);
            this.leftArrowLabel.TabIndex = 0;
            this.leftArrowLabel.Text = "<";
            this.leftArrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.leftArrowLabel.Visible = false;
            // 
            // rightArrowLabel
            // 
            this.rightArrowLabel.AutoSize = true;
            this.rightArrowLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.rightArrowLabel.Font = new System.Drawing.Font("Courier Prime Code", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightArrowLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.rightArrowLabel.Location = new System.Drawing.Point(0, 0);
            this.rightArrowLabel.Margin = new System.Windows.Forms.Padding(0);
            this.rightArrowLabel.Name = "rightArrowLabel";
            this.rightArrowLabel.Padding = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.rightArrowLabel.Size = new System.Drawing.Size(27, 28);
            this.rightArrowLabel.TabIndex = 0;
            this.rightArrowLabel.Text = ">";
            this.rightArrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rightArrowLabel.Visible = false;
            // 
            // StandardDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.displayLayout);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "StandardDisplay";
            this.Size = new System.Drawing.Size(337, 112);
            this.displayLayout.ResumeLayout(false);
            this.resultPanel.ResumeLayout(false);
            this.resultPanel.PerformLayout();
            this.expressionLayout.ResumeLayout(false);
            this.expressionPanel.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.rightArrowPanel.ResumeLayout(false);
            this.rightArrowPanel.PerformLayout();
            this.leftArrowPanel.ResumeLayout(false);
            this.leftArrowPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel displayLayout;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Panel rightArrowPanel;
        private System.Windows.Forms.Panel leftArrowPanel;
        private System.Windows.Forms.TableLayoutPanel expressionLayout;
        private System.Windows.Forms.Panel expressionPanel;
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.Label expressionLabel;
        private System.Windows.Forms.Label leftArrowLabel;
        private System.Windows.Forms.Label rightArrowLabel;

    }
}
