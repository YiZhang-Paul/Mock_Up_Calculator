namespace UserControlClassLibrary {
    partial class StandardKeypad {
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
            this.extraKeysLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnMemory = new System.Windows.Forms.Button();
            this.btnMemorySave = new System.Windows.Forms.Button();
            this.btnMemoryMinus = new System.Windows.Forms.Button();
            this.btnMemoryClear = new System.Windows.Forms.Button();
            this.btnMemoryRecall = new System.Windows.Forms.Button();
            this.btnMemoryPlus = new System.Windows.Forms.Button();
            this.baseKeyLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnNegate = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnNine = new System.Windows.Forms.Button();
            this.btnEight = new System.Windows.Forms.Button();
            this.btnSeven = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnReciprocal = new System.Windows.Forms.Button();
            this.btnXSquare = new System.Windows.Forms.Button();
            this.btnSquareRoot = new System.Windows.Forms.Button();
            this.btnModulos = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            this.extraKeysLayout.SuspendLayout();
            this.baseKeyLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Controls.Add(this.extraKeysLayout, 0, 0);
            this.mainLayout.Controls.Add(this.baseKeyLayout, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.59113F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.40887F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.Size = new System.Drawing.Size(894, 687);
            this.mainLayout.TabIndex = 0;
            // 
            // extraKeysLayout
            // 
            this.extraKeysLayout.ColumnCount = 6;
            this.extraKeysLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.extraKeysLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.extraKeysLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.extraKeysLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.extraKeysLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.extraKeysLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.extraKeysLayout.Controls.Add(this.btnMemory, 5, 0);
            this.extraKeysLayout.Controls.Add(this.btnMemorySave, 4, 0);
            this.extraKeysLayout.Controls.Add(this.btnMemoryMinus, 3, 0);
            this.extraKeysLayout.Controls.Add(this.btnMemoryClear, 0, 0);
            this.extraKeysLayout.Controls.Add(this.btnMemoryRecall, 1, 0);
            this.extraKeysLayout.Controls.Add(this.btnMemoryPlus, 2, 0);
            this.extraKeysLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extraKeysLayout.Location = new System.Drawing.Point(3, 3);
            this.extraKeysLayout.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.extraKeysLayout.Name = "extraKeysLayout";
            this.extraKeysLayout.RowCount = 1;
            this.extraKeysLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.extraKeysLayout.Size = new System.Drawing.Size(888, 69);
            this.extraKeysLayout.TabIndex = 0;
            // 
            // btnMemory
            // 
            this.btnMemory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemory.FlatAppearance.BorderSize = 2;
            this.btnMemory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMemory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnMemory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemory.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMemory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMemory.Location = new System.Drawing.Point(738, 3);
            this.btnMemory.Name = "btnMemory";
            this.btnMemory.Size = new System.Drawing.Size(147, 63);
            this.btnMemory.TabIndex = 15;
            this.btnMemory.Text = "M▾";
            this.btnMemory.UseVisualStyleBackColor = false;
            this.btnMemory.Click += new System.EventHandler(this.MemoryToggleClick);
            this.btnMemory.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnMemory.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnMemorySave
            // 
            this.btnMemorySave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMemorySave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemorySave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemorySave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemorySave.FlatAppearance.BorderSize = 2;
            this.btnMemorySave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMemorySave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnMemorySave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemorySave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMemorySave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMemorySave.Location = new System.Drawing.Point(591, 3);
            this.btnMemorySave.Name = "btnMemorySave";
            this.btnMemorySave.Size = new System.Drawing.Size(141, 63);
            this.btnMemorySave.TabIndex = 14;
            this.btnMemorySave.Text = "MS";
            this.btnMemorySave.UseVisualStyleBackColor = false;
            this.btnMemorySave.Click += new System.EventHandler(this.MemoryStoreClick);
            this.btnMemorySave.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnMemorySave.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnMemoryMinus
            // 
            this.btnMemoryMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMemoryMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemoryMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemoryMinus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemoryMinus.FlatAppearance.BorderSize = 2;
            this.btnMemoryMinus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMemoryMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnMemoryMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemoryMinus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMemoryMinus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMemoryMinus.Location = new System.Drawing.Point(444, 3);
            this.btnMemoryMinus.Name = "btnMemoryMinus";
            this.btnMemoryMinus.Size = new System.Drawing.Size(141, 63);
            this.btnMemoryMinus.TabIndex = 13;
            this.btnMemoryMinus.Text = "M-";
            this.btnMemoryMinus.UseVisualStyleBackColor = false;
            this.btnMemoryMinus.Click += new System.EventHandler(this.MemorySubtractClick);
            this.btnMemoryMinus.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnMemoryMinus.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnMemoryClear
            // 
            this.btnMemoryClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMemoryClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemoryClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemoryClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemoryClear.FlatAppearance.BorderSize = 2;
            this.btnMemoryClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMemoryClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnMemoryClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemoryClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMemoryClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMemoryClear.Location = new System.Drawing.Point(3, 3);
            this.btnMemoryClear.Name = "btnMemoryClear";
            this.btnMemoryClear.Size = new System.Drawing.Size(141, 63);
            this.btnMemoryClear.TabIndex = 6;
            this.btnMemoryClear.Text = "MC";
            this.btnMemoryClear.UseVisualStyleBackColor = false;
            this.btnMemoryClear.Click += new System.EventHandler(this.MemoryClearClick);
            this.btnMemoryClear.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnMemoryClear.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnMemoryRecall
            // 
            this.btnMemoryRecall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMemoryRecall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemoryRecall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemoryRecall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemoryRecall.FlatAppearance.BorderSize = 2;
            this.btnMemoryRecall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMemoryRecall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnMemoryRecall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemoryRecall.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMemoryRecall.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMemoryRecall.Location = new System.Drawing.Point(150, 3);
            this.btnMemoryRecall.Name = "btnMemoryRecall";
            this.btnMemoryRecall.Size = new System.Drawing.Size(141, 63);
            this.btnMemoryRecall.TabIndex = 11;
            this.btnMemoryRecall.Text = "MR";
            this.btnMemoryRecall.UseVisualStyleBackColor = false;
            this.btnMemoryRecall.Click += new System.EventHandler(this.MemoryRecallClick);
            this.btnMemoryRecall.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnMemoryRecall.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnMemoryPlus
            // 
            this.btnMemoryPlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMemoryPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemoryPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemoryPlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMemoryPlus.FlatAppearance.BorderSize = 2;
            this.btnMemoryPlus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMemoryPlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnMemoryPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemoryPlus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMemoryPlus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMemoryPlus.Location = new System.Drawing.Point(297, 3);
            this.btnMemoryPlus.Name = "btnMemoryPlus";
            this.btnMemoryPlus.Size = new System.Drawing.Size(141, 63);
            this.btnMemoryPlus.TabIndex = 12;
            this.btnMemoryPlus.Text = "M+";
            this.btnMemoryPlus.UseVisualStyleBackColor = false;
            this.btnMemoryPlus.Click += new System.EventHandler(this.MemoryAddClick);
            this.btnMemoryPlus.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnMemoryPlus.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // baseKeyLayout
            // 
            this.baseKeyLayout.ColumnCount = 4;
            this.baseKeyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.baseKeyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.baseKeyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.baseKeyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.baseKeyLayout.Controls.Add(this.btnEqual, 3, 5);
            this.baseKeyLayout.Controls.Add(this.btnDot, 2, 5);
            this.baseKeyLayout.Controls.Add(this.btnZero, 1, 5);
            this.baseKeyLayout.Controls.Add(this.btnNegate, 0, 5);
            this.baseKeyLayout.Controls.Add(this.btnPlus, 3, 4);
            this.baseKeyLayout.Controls.Add(this.btnThree, 2, 4);
            this.baseKeyLayout.Controls.Add(this.btnTwo, 1, 4);
            this.baseKeyLayout.Controls.Add(this.btnOne, 0, 4);
            this.baseKeyLayout.Controls.Add(this.btnMinus, 3, 3);
            this.baseKeyLayout.Controls.Add(this.btnSix, 2, 3);
            this.baseKeyLayout.Controls.Add(this.btnFive, 1, 3);
            this.baseKeyLayout.Controls.Add(this.btnFour, 0, 3);
            this.baseKeyLayout.Controls.Add(this.btnMultiply, 3, 2);
            this.baseKeyLayout.Controls.Add(this.btnNine, 2, 2);
            this.baseKeyLayout.Controls.Add(this.btnEight, 1, 2);
            this.baseKeyLayout.Controls.Add(this.btnSeven, 0, 2);
            this.baseKeyLayout.Controls.Add(this.btnDivide, 3, 1);
            this.baseKeyLayout.Controls.Add(this.btnDelete, 2, 1);
            this.baseKeyLayout.Controls.Add(this.btnClearAll, 1, 1);
            this.baseKeyLayout.Controls.Add(this.btnUndo, 0, 1);
            this.baseKeyLayout.Controls.Add(this.btnReciprocal, 3, 0);
            this.baseKeyLayout.Controls.Add(this.btnXSquare, 2, 0);
            this.baseKeyLayout.Controls.Add(this.btnSquareRoot, 1, 0);
            this.baseKeyLayout.Controls.Add(this.btnModulos, 0, 0);
            this.baseKeyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseKeyLayout.Location = new System.Drawing.Point(3, 72);
            this.baseKeyLayout.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.baseKeyLayout.Name = "baseKeyLayout";
            this.baseKeyLayout.RowCount = 6;
            this.baseKeyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.baseKeyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.baseKeyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.baseKeyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.baseKeyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.baseKeyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.baseKeyLayout.Size = new System.Drawing.Size(888, 612);
            this.baseKeyLayout.TabIndex = 1;
            // 
            // btnEqual
            // 
            this.btnEqual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEqual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEqual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEqual.FlatAppearance.BorderSize = 2;
            this.btnEqual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnEqual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqual.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnEqual.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEqual.Location = new System.Drawing.Point(669, 508);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(216, 101);
            this.btnEqual.TabIndex = 34;
            this.btnEqual.Tag = "=";
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = false;
            this.btnEqual.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnEqual.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnEqual.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnDot
            // 
            this.btnDot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnDot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnDot.FlatAppearance.BorderSize = 2;
            this.btnDot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnDot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDot.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDot.Location = new System.Drawing.Point(447, 508);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(216, 101);
            this.btnDot.TabIndex = 33;
            this.btnDot.Tag = ".";
            this.btnDot.Text = "∙";
            this.btnDot.UseVisualStyleBackColor = false;
            this.btnDot.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnDot.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnDot.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnZero
            // 
            this.btnZero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZero.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnZero.FlatAppearance.BorderSize = 2;
            this.btnZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZero.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnZero.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnZero.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnZero.Location = new System.Drawing.Point(225, 508);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(216, 101);
            this.btnZero.TabIndex = 32;
            this.btnZero.Tag = "0";
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnZero.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnZero.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnNegate
            // 
            this.btnNegate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNegate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnNegate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNegate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnNegate.FlatAppearance.BorderSize = 2;
            this.btnNegate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnNegate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnNegate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNegate.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnNegate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNegate.Location = new System.Drawing.Point(3, 508);
            this.btnNegate.Name = "btnNegate";
            this.btnNegate.Size = new System.Drawing.Size(216, 101);
            this.btnNegate.TabIndex = 31;
            this.btnNegate.Tag = "negate";
            this.btnNegate.Text = "±";
            this.btnNegate.UseVisualStyleBackColor = false;
            this.btnNegate.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnNegate.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnNegate.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnPlus
            // 
            this.btnPlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnPlus.FlatAppearance.BorderSize = 2;
            this.btnPlus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnPlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnPlus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPlus.Location = new System.Drawing.Point(669, 407);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(216, 95);
            this.btnPlus.TabIndex = 30;
            this.btnPlus.Tag = "+";
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnPlus.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnPlus.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnThree
            // 
            this.btnThree.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThree.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnThree.FlatAppearance.BorderSize = 2;
            this.btnThree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnThree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnThree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThree.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnThree.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThree.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThree.Location = new System.Drawing.Point(447, 407);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(216, 95);
            this.btnThree.TabIndex = 29;
            this.btnThree.Tag = "3";
            this.btnThree.Text = "3";
            this.btnThree.UseVisualStyleBackColor = false;
            this.btnThree.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnThree.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnThree.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnTwo
            // 
            this.btnTwo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTwo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnTwo.FlatAppearance.BorderSize = 2;
            this.btnTwo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnTwo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwo.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnTwo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTwo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTwo.Location = new System.Drawing.Point(225, 407);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(216, 95);
            this.btnTwo.TabIndex = 28;
            this.btnTwo.Tag = "2";
            this.btnTwo.Text = "2";
            this.btnTwo.UseVisualStyleBackColor = false;
            this.btnTwo.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnTwo.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnTwo.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnOne
            // 
            this.btnOne.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOne.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnOne.FlatAppearance.BorderSize = 2;
            this.btnOne.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnOne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOne.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnOne.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOne.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOne.Location = new System.Drawing.Point(3, 407);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(216, 95);
            this.btnOne.TabIndex = 27;
            this.btnOne.Tag = "1";
            this.btnOne.Text = "1";
            this.btnOne.UseVisualStyleBackColor = false;
            this.btnOne.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnOne.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnOne.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnMinus
            // 
            this.btnMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMinus.FlatAppearance.BorderSize = 2;
            this.btnMinus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinus.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnMinus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMinus.Location = new System.Drawing.Point(669, 306);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(216, 95);
            this.btnMinus.TabIndex = 26;
            this.btnMinus.Tag = "−";
            this.btnMinus.Text = "−";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnMinus.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnMinus.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnSix
            // 
            this.btnSix.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnSix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSix.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnSix.FlatAppearance.BorderSize = 2;
            this.btnSix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnSix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnSix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSix.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnSix.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSix.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSix.Location = new System.Drawing.Point(447, 306);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(216, 95);
            this.btnSix.TabIndex = 25;
            this.btnSix.Tag = "6";
            this.btnSix.Text = "6";
            this.btnSix.UseVisualStyleBackColor = false;
            this.btnSix.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnSix.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnSix.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnFive
            // 
            this.btnFive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnFive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnFive.FlatAppearance.BorderSize = 2;
            this.btnFive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnFive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnFive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFive.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnFive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFive.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFive.Location = new System.Drawing.Point(225, 306);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(216, 95);
            this.btnFive.TabIndex = 24;
            this.btnFive.Tag = "5";
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = false;
            this.btnFive.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnFive.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnFive.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnFour
            // 
            this.btnFour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFour.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnFour.FlatAppearance.BorderSize = 2;
            this.btnFour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnFour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnFour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFour.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnFour.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFour.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFour.Location = new System.Drawing.Point(3, 306);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(216, 95);
            this.btnFour.TabIndex = 23;
            this.btnFour.Tag = "4";
            this.btnFour.Text = "4";
            this.btnFour.UseVisualStyleBackColor = false;
            this.btnFour.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnFour.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnFour.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnMultiply
            // 
            this.btnMultiply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMultiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMultiply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMultiply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMultiply.FlatAppearance.BorderSize = 2;
            this.btnMultiply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMultiply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiply.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnMultiply.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMultiply.Location = new System.Drawing.Point(669, 205);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(216, 95);
            this.btnMultiply.TabIndex = 22;
            this.btnMultiply.Tag = "×";
            this.btnMultiply.Text = "×";
            this.btnMultiply.UseVisualStyleBackColor = false;
            this.btnMultiply.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnMultiply.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnMultiply.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnNine
            // 
            this.btnNine.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnNine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnNine.FlatAppearance.BorderSize = 2;
            this.btnNine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnNine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnNine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNine.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnNine.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNine.Location = new System.Drawing.Point(447, 205);
            this.btnNine.Name = "btnNine";
            this.btnNine.Size = new System.Drawing.Size(216, 95);
            this.btnNine.TabIndex = 21;
            this.btnNine.Tag = "9";
            this.btnNine.Text = "9";
            this.btnNine.UseVisualStyleBackColor = false;
            this.btnNine.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnNine.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnNine.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnEight
            // 
            this.btnEight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnEight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnEight.FlatAppearance.BorderSize = 2;
            this.btnEight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnEight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnEight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEight.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnEight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEight.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEight.Location = new System.Drawing.Point(225, 205);
            this.btnEight.Name = "btnEight";
            this.btnEight.Size = new System.Drawing.Size(216, 95);
            this.btnEight.TabIndex = 20;
            this.btnEight.Tag = "8";
            this.btnEight.Text = "8";
            this.btnEight.UseVisualStyleBackColor = false;
            this.btnEight.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnEight.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnEight.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnSeven
            // 
            this.btnSeven.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSeven.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnSeven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSeven.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.btnSeven.FlatAppearance.BorderSize = 2;
            this.btnSeven.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnSeven.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnSeven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeven.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.btnSeven.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeven.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeven.Location = new System.Drawing.Point(3, 205);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(216, 95);
            this.btnSeven.TabIndex = 19;
            this.btnSeven.Tag = "7";
            this.btnSeven.Text = "7";
            this.btnSeven.UseVisualStyleBackColor = false;
            this.btnSeven.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnSeven.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnSeven.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnDivide
            // 
            this.btnDivide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDivide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnDivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDivide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnDivide.FlatAppearance.BorderSize = 2;
            this.btnDivide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnDivide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivide.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnDivide.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDivide.Location = new System.Drawing.Point(669, 104);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(216, 95);
            this.btnDivide.TabIndex = 18;
            this.btnDivide.Tag = "÷";
            this.btnDivide.Text = "÷";
            this.btnDivide.UseVisualStyleBackColor = false;
            this.btnDivide.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnDivide.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnDivide.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(447, 104);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(216, 95);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Tag = "⌫";
            this.btnDelete.Text = "⌫";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnDelete.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnClearAll
            // 
            this.btnClearAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClearAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClearAll.FlatAppearance.BorderSize = 2;
            this.btnClearAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnClearAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.btnClearAll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClearAll.Location = new System.Drawing.Point(225, 104);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(216, 95);
            this.btnClearAll.TabIndex = 16;
            this.btnClearAll.Tag = "C";
            this.btnClearAll.Text = "C";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnClearAll.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnClearAll.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnUndo
            // 
            this.btnUndo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUndo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnUndo.FlatAppearance.BorderSize = 2;
            this.btnUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.btnUndo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUndo.Location = new System.Drawing.Point(3, 104);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(216, 95);
            this.btnUndo.TabIndex = 15;
            this.btnUndo.Tag = "CE";
            this.btnUndo.Text = "CE";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnUndo.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnUndo.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnReciprocal
            // 
            this.btnReciprocal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReciprocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnReciprocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReciprocal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnReciprocal.FlatAppearance.BorderSize = 2;
            this.btnReciprocal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnReciprocal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnReciprocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReciprocal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnReciprocal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReciprocal.Location = new System.Drawing.Point(669, 3);
            this.btnReciprocal.Name = "btnReciprocal";
            this.btnReciprocal.Size = new System.Drawing.Size(216, 95);
            this.btnReciprocal.TabIndex = 14;
            this.btnReciprocal.Tag = "¹⁄x";
            this.btnReciprocal.Text = "¹⁄ x";
            this.btnReciprocal.UseVisualStyleBackColor = false;
            this.btnReciprocal.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnReciprocal.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnReciprocal.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnXSquare
            // 
            this.btnXSquare.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXSquare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnXSquare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXSquare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnXSquare.FlatAppearance.BorderSize = 2;
            this.btnXSquare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnXSquare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnXSquare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXSquare.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnXSquare.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnXSquare.Location = new System.Drawing.Point(447, 3);
            this.btnXSquare.Name = "btnXSquare";
            this.btnXSquare.Size = new System.Drawing.Size(216, 95);
            this.btnXSquare.TabIndex = 13;
            this.btnXSquare.Tag = "sqr";
            this.btnXSquare.Text = "x²";
            this.btnXSquare.UseVisualStyleBackColor = false;
            this.btnXSquare.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnXSquare.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnXSquare.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnSquareRoot
            // 
            this.btnSquareRoot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSquareRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSquareRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSquareRoot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSquareRoot.FlatAppearance.BorderSize = 2;
            this.btnSquareRoot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnSquareRoot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnSquareRoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSquareRoot.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSquareRoot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSquareRoot.Location = new System.Drawing.Point(225, 3);
            this.btnSquareRoot.Name = "btnSquareRoot";
            this.btnSquareRoot.Size = new System.Drawing.Size(216, 95);
            this.btnSquareRoot.TabIndex = 12;
            this.btnSquareRoot.Tag = "√";
            this.btnSquareRoot.Text = "√";
            this.btnSquareRoot.UseVisualStyleBackColor = false;
            this.btnSquareRoot.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnSquareRoot.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnSquareRoot.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // btnModulos
            // 
            this.btnModulos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModulos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnModulos.FlatAppearance.BorderSize = 2;
            this.btnModulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnModulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnModulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModulos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnModulos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModulos.Location = new System.Drawing.Point(3, 3);
            this.btnModulos.Name = "btnModulos";
            this.btnModulos.Size = new System.Drawing.Size(216, 95);
            this.btnModulos.TabIndex = 9;
            this.btnModulos.Tag = "Mod";
            this.btnModulos.Text = "%";
            this.btnModulos.UseVisualStyleBackColor = false;
            this.btnModulos.Click += new System.EventHandler(this.ButtonMouseClick);
            this.btnModulos.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.btnModulos.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            // 
            // StandardKeypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayout);
            this.Name = "StandardKeypad";
            this.Size = new System.Drawing.Size(894, 687);
            this.mainLayout.ResumeLayout(false);
            this.extraKeysLayout.ResumeLayout(false);
            this.baseKeyLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel extraKeysLayout;
        private System.Windows.Forms.TableLayoutPanel baseKeyLayout;
        private System.Windows.Forms.Button btnMemoryClear;
        private System.Windows.Forms.Button btnMemoryRecall;
        private System.Windows.Forms.Button btnMemoryPlus;
        private System.Windows.Forms.Button btnMemoryMinus;
        private System.Windows.Forms.Button btnMemorySave;
        private System.Windows.Forms.Button btnMemory;
        private System.Windows.Forms.Button btnModulos;
        private System.Windows.Forms.Button btnSquareRoot;
        private System.Windows.Forms.Button btnXSquare;
        private System.Windows.Forms.Button btnReciprocal;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.Button btnEight;
        private System.Windows.Forms.Button btnNine;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnNegate;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnEqual;
    }
}
