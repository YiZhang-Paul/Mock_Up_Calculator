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
            this.resultLabel = new System.Windows.Forms.Label();
            this.expressionLabel = new System.Windows.Forms.Label();
            this.displayLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayLayout
            // 
            this.displayLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.displayLayout.ColumnCount = 1;
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayLayout.Controls.Add(this.resultLabel, 0, 1);
            this.displayLayout.Controls.Add(this.expressionLabel, 0, 0);
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
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 35F, System.Drawing.FontStyle.Bold);
            this.resultLabel.Location = new System.Drawing.Point(284, 31);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.resultLabel.Size = new System.Drawing.Size(53, 81);
            this.resultLabel.TabIndex = 1;
            this.resultLabel.Text = "0";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // expressionLabel
            // 
            this.expressionLabel.AutoSize = true;
            this.expressionLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.expressionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.expressionLabel.Location = new System.Drawing.Point(337, 0);
            this.expressionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.expressionLabel.Name = "expressionLabel";
            this.expressionLabel.Size = new System.Drawing.Size(0, 31);
            this.expressionLabel.TabIndex = 2;
            // 
            // standardDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.displayLayout);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "standardDisplay";
            this.Size = new System.Drawing.Size(337, 112);
            this.displayLayout.ResumeLayout(false);
            this.displayLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel displayLayout;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label expressionLabel;

    }
}
