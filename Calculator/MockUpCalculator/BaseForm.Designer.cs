namespace MockUpCalculator {
    partial class BaseForm {
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
            this.zoomTimer = new System.Windows.Forms.Timer(this.components);
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            //
            // zoomTimer
            //
            this.zoomTimer.Interval = 16;
            //
            // closeTimer
            //
            this.closeTimer.Interval = 1;
            //
            // BaseForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.ResizeBegin += new System.EventHandler(this.FormResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.FormResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer zoomTimer;
        private System.Windows.Forms.Timer closeTimer;
    }
}