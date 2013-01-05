namespace LagerMan
{
    partial class GetFromInv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetFromInv));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.funktionerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hjælpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeOut = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.commitToSQL = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.customerOut = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.prodCodeOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lagermanNr = new System.Windows.Forms.Label();
            this.customerNameValue = new System.Windows.Forms.Label();
            this.streetName = new System.Windows.Forms.Label();
            this.outStreet = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.outPostCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.outCity = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funktionerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // funktionerToolStripMenuItem
            // 
            this.funktionerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hjælpToolStripMenuItem});
            this.funktionerToolStripMenuItem.Name = "funktionerToolStripMenuItem";
            this.funktionerToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.funktionerToolStripMenuItem.Text = "Funktioner";
            // 
            // hjælpToolStripMenuItem
            // 
            this.hjælpToolStripMenuItem.Name = "hjælpToolStripMenuItem";
            this.hjælpToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.hjælpToolStripMenuItem.Text = "Hjælp";
            this.hjælpToolStripMenuItem.Click += new System.EventHandler(this.hjælpToolStripMenuItem_Click);
            // 
            // barcodeOut
            // 
            this.barcodeOut.Location = new System.Drawing.Point(15, 205);
            this.barcodeOut.Name = "barcodeOut";
            this.barcodeOut.Size = new System.Drawing.Size(211, 20);
            this.barcodeOut.TabIndex = 1;
            this.barcodeOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.barcodeOut_KeyDown);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(15, 322);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(211, 159);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tips";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stregkode";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(436, 69);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(345, 415);
            this.dataGridView1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Scannede vare";
            // 
            // commitToSQL
            // 
            this.commitToSQL.Location = new System.Drawing.Point(15, 461);
            this.commitToSQL.Name = "commitToSQL";
            this.commitToSQL.Size = new System.Drawing.Size(117, 23);
            this.commitToSQL.TabIndex = 7;
            this.commitToSQL.Text = "Udfør";
            this.commitToSQL.UseVisualStyleBackColor = true;
            this.commitToSQL.Click += new System.EventHandler(this.commitToSQL_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(804, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kunde nr. / kunde";
            // 
            // customerOut
            // 
            this.customerOut.Location = new System.Drawing.Point(15, 113);
            this.customerOut.Name = "customerOut";
            this.customerOut.Size = new System.Drawing.Size(185, 20);
            this.customerOut.TabIndex = 10;
            this.customerOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customerOut_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Produkt Nr.:";
            // 
            // prodCodeOut
            // 
            this.prodCodeOut.Location = new System.Drawing.Point(15, 160);
            this.prodCodeOut.Name = "prodCodeOut";
            this.prodCodeOut.Size = new System.Drawing.Size(185, 20);
            this.prodCodeOut.TabIndex = 14;
            this.prodCodeOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.prodCodeOut_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Valgt kunde:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "lagerMan nr.:";
            // 
            // lagermanNr
            // 
            this.lagermanNr.AutoSize = true;
            this.lagermanNr.Location = new System.Drawing.Point(302, 69);
            this.lagermanNr.Name = "lagermanNr";
            this.lagermanNr.Size = new System.Drawing.Size(0, 13);
            this.lagermanNr.TabIndex = 19;
            // 
            // customerNameValue
            // 
            this.customerNameValue.AutoSize = true;
            this.customerNameValue.Location = new System.Drawing.Point(86, 70);
            this.customerNameValue.Name = "customerNameValue";
            this.customerNameValue.Size = new System.Drawing.Size(0, 13);
            this.customerNameValue.TabIndex = 20;
            // 
            // streetName
            // 
            this.streetName.AutoSize = true;
            this.streetName.Location = new System.Drawing.Point(229, 97);
            this.streetName.Name = "streetName";
            this.streetName.Size = new System.Drawing.Size(33, 13);
            this.streetName.TabIndex = 21;
            this.streetName.Text = "Gade";
            // 
            // outStreet
            // 
            this.outStreet.Location = new System.Drawing.Point(229, 112);
            this.outStreet.Name = "outStreet";
            this.outStreet.Size = new System.Drawing.Size(177, 20);
            this.outStreet.TabIndex = 22;
            this.outStreet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.outStreet_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(229, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Post nr.:";
            // 
            // outPostCode
            // 
            this.outPostCode.Location = new System.Drawing.Point(229, 159);
            this.outPostCode.Name = "outPostCode";
            this.outPostCode.Size = new System.Drawing.Size(64, 20);
            this.outPostCode.TabIndex = 24;
            this.outPostCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.outPostCode_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "By";
            // 
            // outCity
            // 
            this.outCity.Location = new System.Drawing.Point(229, 205);
            this.outCity.Name = "outCity";
            this.outCity.Size = new System.Drawing.Size(177, 20);
            this.outCity.TabIndex = 26;
            this.outCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.outCity_KeyDown);
            // 
            // GetFromInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 512);
            this.Controls.Add(this.outCity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.outPostCode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.outStreet);
            this.Controls.Add(this.streetName);
            this.Controls.Add(this.customerNameValue);
            this.Controls.Add(this.lagermanNr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.prodCodeOut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customerOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.commitToSQL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.barcodeOut);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GetFromInv";
            this.Text = "Pluk fra lager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem funktionerToolStripMenuItem;
        private System.Windows.Forms.TextBox barcodeOut;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button commitToSQL;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem hjælpToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox customerOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox prodCodeOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lagermanNr;
        private System.Windows.Forms.Label customerNameValue;
        private System.Windows.Forms.Label streetName;
        private System.Windows.Forms.TextBox outStreet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox outPostCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox outCity;
    }
}