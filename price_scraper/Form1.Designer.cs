namespace price_scraper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            fileStatusLabel = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            comboBoxWorksheet = new MaterialSkin.Controls.MaterialComboBox();
            comboBoxCurrency = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            comboBoxProductColumn = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            comboBoxPPP = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(178, 483);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(336, 50);
            materialButton1.TabIndex = 0;
            materialButton1.Text = "Start";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialButton2
            // 
            materialButton2.AutoSize = false;
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(314, 120);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(200, 49);
            materialButton2.TabIndex = 1;
            materialButton2.Text = "Load excel file";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(60, 136);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(247, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Load excel file with product names";
            // 
            // fileStatusLabel
            // 
            fileStatusLabel.AutoSize = true;
            fileStatusLabel.Depth = 0;
            fileStatusLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            fileStatusLabel.Location = new Point(521, 136);
            fileStatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            fileStatusLabel.Name = "fileStatusLabel";
            fileStatusLabel.Size = new Size(1, 0);
            fileStatusLabel.TabIndex = 3;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(47, 206);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(260, 19);
            materialLabel2.TabIndex = 4;
            materialLabel2.Text = "Which worksheet contains products?";
            // 
            // comboBoxWorksheet
            // 
            comboBoxWorksheet.AutoResize = false;
            comboBoxWorksheet.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxWorksheet.Depth = 0;
            comboBoxWorksheet.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxWorksheet.DropDownHeight = 174;
            comboBoxWorksheet.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWorksheet.DropDownWidth = 121;
            comboBoxWorksheet.Enabled = false;
            comboBoxWorksheet.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxWorksheet.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxWorksheet.FormattingEnabled = true;
            comboBoxWorksheet.IntegralHeight = false;
            comboBoxWorksheet.ItemHeight = 43;
            comboBoxWorksheet.Location = new Point(314, 190);
            comboBoxWorksheet.MaxDropDownItems = 4;
            comboBoxWorksheet.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxWorksheet.Name = "comboBoxWorksheet";
            comboBoxWorksheet.Size = new Size(200, 49);
            comboBoxWorksheet.StartIndex = 0;
            comboBoxWorksheet.TabIndex = 5;
            comboBoxWorksheet.SelectedIndexChanged += comboBoxWorksheet_SelectedIndexChanged;
            // 
            // comboBoxCurrency
            // 
            comboBoxCurrency.AutoResize = false;
            comboBoxCurrency.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxCurrency.Depth = 0;
            comboBoxCurrency.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxCurrency.DropDownHeight = 174;
            comboBoxCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCurrency.DropDownWidth = 121;
            comboBoxCurrency.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxCurrency.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxCurrency.FormattingEnabled = true;
            comboBoxCurrency.IntegralHeight = false;
            comboBoxCurrency.ItemHeight = 43;
            comboBoxCurrency.Items.AddRange(new object[] { "PLN", "USD", "EUR", "GBP" });
            comboBoxCurrency.Location = new Point(314, 330);
            comboBoxCurrency.MaxDropDownItems = 4;
            comboBoxCurrency.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxCurrency.Name = "comboBoxCurrency";
            comboBoxCurrency.Size = new Size(200, 49);
            comboBoxCurrency.StartIndex = 0;
            comboBoxCurrency.TabIndex = 6;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(189, 346);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(118, 19);
            materialLabel3.TabIndex = 7;
            materialLabel3.Text = "Desired currency";
            // 
            // comboBoxProductColumn
            // 
            comboBoxProductColumn.AutoResize = false;
            comboBoxProductColumn.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxProductColumn.Depth = 0;
            comboBoxProductColumn.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxProductColumn.DropDownHeight = 174;
            comboBoxProductColumn.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductColumn.DropDownWidth = 121;
            comboBoxProductColumn.Enabled = false;
            comboBoxProductColumn.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxProductColumn.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxProductColumn.FormattingEnabled = true;
            comboBoxProductColumn.IntegralHeight = false;
            comboBoxProductColumn.ItemHeight = 43;
            comboBoxProductColumn.Location = new Point(314, 260);
            comboBoxProductColumn.MaxDropDownItems = 4;
            comboBoxProductColumn.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxProductColumn.Name = "comboBoxProductColumn";
            comboBoxProductColumn.Size = new Size(200, 49);
            comboBoxProductColumn.StartIndex = 0;
            comboBoxProductColumn.TabIndex = 8;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(23, 276);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(285, 19);
            materialLabel4.TabIndex = 9;
            materialLabel4.Text = "Which column contains product names?";
            // 
            // comboBoxPPP
            // 
            comboBoxPPP.AutoResize = false;
            comboBoxPPP.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxPPP.Depth = 0;
            comboBoxPPP.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxPPP.DropDownHeight = 174;
            comboBoxPPP.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPPP.DropDownWidth = 121;
            comboBoxPPP.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxPPP.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxPPP.FormattingEnabled = true;
            comboBoxPPP.IntegralHeight = false;
            comboBoxPPP.ItemHeight = 43;
            comboBoxPPP.Items.AddRange(new object[] { "20", "50", "100" });
            comboBoxPPP.Location = new Point(314, 400);
            comboBoxPPP.MaxDropDownItems = 4;
            comboBoxPPP.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxPPP.Name = "comboBoxPPP";
            comboBoxPPP.Size = new Size(200, 49);
            comboBoxPPP.StartIndex = 0;
            comboBoxPPP.TabIndex = 10;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(178, 416);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(129, 19);
            materialLabel5.TabIndex = 11;
            materialLabel5.Text = "Products per page";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 588);
            Controls.Add(materialLabel5);
            Controls.Add(comboBoxPPP);
            Controls.Add(materialLabel4);
            Controls.Add(comboBoxProductColumn);
            Controls.Add(materialLabel3);
            Controls.Add(comboBoxCurrency);
            Controls.Add(comboBoxWorksheet);
            Controls.Add(materialLabel2);
            Controls.Add(fileStatusLabel);
            Controls.Add(materialLabel1);
            Controls.Add(materialButton2);
            Controls.Add(materialButton1);
            Name = "Form1";
            Text = "TME Price scraper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel fileStatusLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox comboBoxWorksheet;
        private MaterialSkin.Controls.MaterialComboBox comboBoxCurrency;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialComboBox comboBoxProductColumn;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialComboBox comboBoxPPP;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}