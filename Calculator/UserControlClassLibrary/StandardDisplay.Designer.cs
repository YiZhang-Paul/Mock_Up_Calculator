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
            this.expressionLabel = new System.Windows.Forms.Label();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.resultLabel = new System.Windows.Forms.Label();
            this.displayLayout.SuspendLayout();
            this.displayPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayLayout
            // 
            this.displayLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.displayLayout.ColumnCount = 1;
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.Controls.Add(this.expressionLabel, 0, 0);
            this.displayLayout.Controls.Add(this.displayPanel, 0, 1);
            this.displayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayLayout.Location = new System.Drawing.Point(0, 0);
            this.displayLayout.Margin = new System.Windows.Forms.Padding(0);
            this.displayLayout.Name = "displayLayout";
            this.displayLayout.RowCount = 2;
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.displayLayout.Size = new System.Drawing.Size(337, 112);
            this.displayLayout.TabIndex = 0;
            // 
            // expressionLabel
            // 
            this.expressionLabel.AutoSize = true;
            this.expressionLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.expressionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.expressionLabel.Location = new System.Drawing.Point(317, 0);
            this.expressionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.expressionLabel.Name = "expressionLabel";
            this.expressionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.expressionLabel.Size = new System.Drawing.Size(20, 32);
            this.expressionLabel.TabIndex = 2;
            // 
            // displayPanel
            // 
            this.displayPanel.Controls.Add(this.resultLabel);
            this.displayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayPanel.Location = new System.Drawing.Point(0, 32);
            this.displayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(337, 80);
            this.displayPanel.TabIndex = 3;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 35F, System.Drawing.FontStyle.Bold);
            this.resultLabel.Location = new System.Drawing.Point(337, 0);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.resultLabel.Size = new System.Drawing.Size(0, 67);
            this.resultLabel.TabIndex = 2;
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.displayLayout.PerformLayout();
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel displayLayout;
        private System.Windows.Forms.Label expressionLabel;
        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Label resultLabel;

    }
}
