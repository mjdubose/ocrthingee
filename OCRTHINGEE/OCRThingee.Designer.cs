using System.ComponentModel;
using System.Windows.Forms;

namespace OCRTHINGEE
{
    partial class OCRThingee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.button20 = new System.Windows.Forms.Button();
            this.btn_DeleteRow = new System.Windows.Forms.Button();
            this.btn_AddRowToDatabase = new System.Windows.Forms.Button();
            this.dg_OCRRows = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.r1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.r2 = new System.Windows.Forms.NumericUpDown();
            this.g1 = new System.Windows.Forms.NumericUpDown();
            this.g2 = new System.Windows.Forms.NumericUpDown();
            this.b1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.b2 = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.CreditsTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.productsIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buypriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastupdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeitemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eliteDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eliteDataSet = new OCRTHINGEE.EliteDataSet();
            this.label13 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.itemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.stationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.sysId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.systemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsTableAdapter = new OCRTHINGEE.EliteDataSetTableAdapters.itemsTableAdapter();
            this.systemsTableAdapter = new OCRTHINGEE.EliteDataSetTableAdapters.systemsTableAdapter();
            this.stationsTableAdapter = new OCRTHINGEE.EliteDataSetTableAdapters.stationsTableAdapter();
            this.tradeitemsTableAdapter = new OCRTHINGEE.EliteDataSetTableAdapters.tradeitemsTableAdapter();
            this.tabPage3.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_OCRRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeitemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.buttonPanel);
            this.tabPage3.Controls.Add(this.dg_OCRRows);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.pb2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.pb1);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.r1);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.r2);
            this.tabPage3.Controls.Add(this.g1);
            this.tabPage3.Controls.Add(this.g2);
            this.tabPage3.Controls.Add(this.b1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.b2);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.button17);
            this.tabPage3.Controls.Add(this.button16);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1251, 476);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "OCR";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "File Name:";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanel.Controls.Add(this.button20);
            this.buttonPanel.Controls.Add(this.btn_DeleteRow);
            this.buttonPanel.Controls.Add(this.btn_AddRowToDatabase);
            this.buttonPanel.Location = new System.Drawing.Point(810, 339);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(283, 129);
            this.buttonPanel.TabIndex = 34;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(24, 74);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(226, 23);
            this.button20.TabIndex = 2;
            this.button20.Text = "Clear Data Grid View";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // btn_DeleteRow
            // 
            this.btn_DeleteRow.Location = new System.Drawing.Point(24, 44);
            this.btn_DeleteRow.Name = "btn_DeleteRow";
            this.btn_DeleteRow.Size = new System.Drawing.Size(226, 23);
            this.btn_DeleteRow.TabIndex = 1;
            this.btn_DeleteRow.Text = "Delete Row";
            this.btn_DeleteRow.UseVisualStyleBackColor = true;
            this.btn_DeleteRow.Click += new System.EventHandler(this.btn_DeleteRow_Click);
            // 
            // btn_AddRowToDatabase
            // 
            this.btn_AddRowToDatabase.Location = new System.Drawing.Point(24, 15);
            this.btn_AddRowToDatabase.Name = "btn_AddRowToDatabase";
            this.btn_AddRowToDatabase.Size = new System.Drawing.Size(226, 23);
            this.btn_AddRowToDatabase.TabIndex = 0;
            this.btn_AddRowToDatabase.Text = "Add Data To Database";
            this.btn_AddRowToDatabase.UseVisualStyleBackColor = true;
            this.btn_AddRowToDatabase.Click += new System.EventHandler(this.btn_AddRowToDatabase_Click);
            // 
            // dg_OCRRows
            // 
            this.dg_OCRRows.AllowUserToAddRows = false;
            this.dg_OCRRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dg_OCRRows.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dg_OCRRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_OCRRows.Location = new System.Drawing.Point(15, 339);
            this.dg_OCRRows.Name = "dg_OCRRows";
            this.dg_OCRRows.RowHeadersVisible = false;
            this.dg_OCRRows.Size = new System.Drawing.Size(789, 129);
            this.dg_OCRRows.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(810, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Filter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pb2
            // 
            this.pb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb2.Location = new System.Drawing.Point(810, 261);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(180, 72);
            this.pb2.TabIndex = 28;
            this.pb2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(810, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Invert";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pb1
            // 
            this.pb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb1.Location = new System.Drawing.Point(15, 69);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(789, 264);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb1.TabIndex = 8;
            this.pb1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(163, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Reload";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // r1
            // 
            this.r1.Location = new System.Drawing.Point(940, 16);
            this.r1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(120, 20);
            this.r1.TabIndex = 10;
            this.r1.Value = new decimal(new int[] {
            115,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(977, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Red";
            // 
            // r2
            // 
            this.r2.Location = new System.Drawing.Point(940, 42);
            this.r2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(120, 20);
            this.r2.TabIndex = 11;
            this.r2.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // g1
            // 
            this.g1.Location = new System.Drawing.Point(940, 88);
            this.g1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.g1.Name = "g1";
            this.g1.Size = new System.Drawing.Size(120, 20);
            this.g1.TabIndex = 12;
            this.g1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // g2
            // 
            this.g2.Location = new System.Drawing.Point(940, 114);
            this.g2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.g2.Name = "g2";
            this.g2.Size = new System.Drawing.Size(120, 20);
            this.g2.TabIndex = 13;
            this.g2.Value = new decimal(new int[] {
            159,
            0,
            0,
            0});
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(940, 161);
            this.b1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(120, 20);
            this.b1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(977, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Green";
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(940, 188);
            this.b2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(120, 20);
            this.b2.TabIndex = 15;
            this.b2.Value = new decimal(new int[] {
            124,
            0,
            0,
            0});
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(82, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(977, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Blue";
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(810, 122);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(111, 23);
            this.button17.TabIndex = 27;
            this.button17.Text = "Rip sub images";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(810, 93);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(111, 23);
            this.button16.TabIndex = 26;
            this.button16.Text = "Row Finder";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(810, 64);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(111, 23);
            this.button14.TabIndex = 24;
            this.button14.Text = "Crop";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(6, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1259, 502);
            this.tabControl2.TabIndex = 34;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.CreditsTextBox);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtCargo);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.comboBox4);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1251, 476);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Market Searches";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(786, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Credits";
            // 
            // CreditsTextBox
            // 
            this.CreditsTextBox.Location = new System.Drawing.Point(831, 19);
            this.CreditsTextBox.Name = "CreditsTextBox";
            this.CreditsTextBox.Size = new System.Drawing.Size(100, 20);
            this.CreditsTextBox.TabIndex = 13;
            this.CreditsTextBox.Text = "1000";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Eurostile", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Eurostile", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1032, 394);
            this.dataGridView1.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(551, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Cargo Spaces";
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(631, 19);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(100, 20);
            this.txtCargo.TabIndex = 10;
            this.txtCargo.Text = "1";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(631, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Search";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.DisplayMember = "sysId";
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(50, 47);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 7;
            this.comboBox4.ValueMember = "sysId";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "System";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(258, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(189, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "sysId";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(50, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.ValueMember = "sysId";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Station";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "System";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView5);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Controls.Add(this.dataGridView4);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.button15);
            this.tabPage2.Controls.Add(this.button13);
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1251, 476);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Database CRUD";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView5.AutoGenerateColumns = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productsIdDataGridViewTextBoxColumn,
            this.stationidDataGridViewTextBoxColumn1,
            this.itemidDataGridViewTextBoxColumn1,
            this.buypriceDataGridViewTextBoxColumn,
            this.sellpriceDataGridViewTextBoxColumn,
            this.supplyDataGridViewTextBoxColumn,
            this.lastupdateDataGridViewTextBoxColumn});
            this.dataGridView5.DataSource = this.tradeitemsBindingSource;
            this.dataGridView5.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView5.Location = new System.Drawing.Point(28, 275);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView5.Size = new System.Drawing.Size(747, 150);
            this.dataGridView5.TabIndex = 20;
            // 
            // productsIdDataGridViewTextBoxColumn
            // 
            this.productsIdDataGridViewTextBoxColumn.DataPropertyName = "ProductsId";
            this.productsIdDataGridViewTextBoxColumn.HeaderText = "ProductsId";
            this.productsIdDataGridViewTextBoxColumn.Name = "productsIdDataGridViewTextBoxColumn";
            this.productsIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stationidDataGridViewTextBoxColumn1
            // 
            this.stationidDataGridViewTextBoxColumn1.DataPropertyName = "stationid";
            this.stationidDataGridViewTextBoxColumn1.HeaderText = "stationid";
            this.stationidDataGridViewTextBoxColumn1.Name = "stationidDataGridViewTextBoxColumn1";
            // 
            // itemidDataGridViewTextBoxColumn1
            // 
            this.itemidDataGridViewTextBoxColumn1.DataPropertyName = "itemid";
            this.itemidDataGridViewTextBoxColumn1.HeaderText = "itemid";
            this.itemidDataGridViewTextBoxColumn1.Name = "itemidDataGridViewTextBoxColumn1";
            // 
            // buypriceDataGridViewTextBoxColumn
            // 
            this.buypriceDataGridViewTextBoxColumn.DataPropertyName = "buyprice";
            this.buypriceDataGridViewTextBoxColumn.HeaderText = "buyprice";
            this.buypriceDataGridViewTextBoxColumn.Name = "buypriceDataGridViewTextBoxColumn";
            // 
            // sellpriceDataGridViewTextBoxColumn
            // 
            this.sellpriceDataGridViewTextBoxColumn.DataPropertyName = "sellprice";
            this.sellpriceDataGridViewTextBoxColumn.HeaderText = "sellprice";
            this.sellpriceDataGridViewTextBoxColumn.Name = "sellpriceDataGridViewTextBoxColumn";
            // 
            // supplyDataGridViewTextBoxColumn
            // 
            this.supplyDataGridViewTextBoxColumn.DataPropertyName = "supply";
            this.supplyDataGridViewTextBoxColumn.HeaderText = "supply";
            this.supplyDataGridViewTextBoxColumn.Name = "supplyDataGridViewTextBoxColumn";
            // 
            // lastupdateDataGridViewTextBoxColumn
            // 
            this.lastupdateDataGridViewTextBoxColumn.DataPropertyName = "lastupdate";
            this.lastupdateDataGridViewTextBoxColumn.HeaderText = "lastupdate";
            this.lastupdateDataGridViewTextBoxColumn.Name = "lastupdateDataGridViewTextBoxColumn";
            // 
            // tradeitemsBindingSource
            // 
            this.tradeitemsBindingSource.DataMember = "tradeitems";
            this.tradeitemsBindingSource.DataSource = this.eliteDataSetBindingSource;
            // 
            // eliteDataSetBindingSource
            // 
            this.eliteDataSetBindingSource.DataSource = this.eliteDataSet;
            this.eliteDataSetBindingSource.Position = 0;
            // 
            // eliteDataSet
            // 
            this.eliteDataSet.DataSetName = "EliteDataSet";
            this.eliteDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 258);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Trade Items";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.AutoSize = true;
            this.button9.Location = new System.Drawing.Point(619, 429);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 27);
            this.button9.TabIndex = 18;
            this.button9.Text = "Delete";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.AutoSize = true;
            this.button10.Location = new System.Drawing.Point(700, 429);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 27);
            this.button10.TabIndex = 17;
            this.button10.Text = "Save";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(658, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Goods";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(810, 208);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 14;
            this.button11.Text = "Delete";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(891, 208);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 13;
            this.button12.Text = "Save";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn2});
            this.dataGridView4.DataSource = this.itemsBindingSource;
            this.dataGridView4.Location = new System.Drawing.Point(661, 52);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(305, 150);
            this.dataGridView4.TabIndex = 12;
            // 
            // itemIdDataGridViewTextBoxColumn
            // 
            this.itemIdDataGridViewTextBoxColumn.DataPropertyName = "itemId";
            this.itemIdDataGridViewTextBoxColumn.HeaderText = "itemId";
            this.itemIdDataGridViewTextBoxColumn.Name = "itemIdDataGridViewTextBoxColumn";
            this.itemIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIdDataGridViewTextBoxColumn.Width = 60;
            // 
            // nameDataGridViewTextBoxColumn2
            // 
            this.nameDataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn2.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn2.Name = "nameDataGridViewTextBoxColumn2";
            this.nameDataGridViewTextBoxColumn2.Width = 58;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "items";
            this.itemsBindingSource.DataSource = this.eliteDataSetBindingSource;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(336, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Space Station";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Solar System";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(488, 208);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 9;
            this.button15.Text = "Delete";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button9_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(569, 208);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 8;
            this.button13.Text = "Save";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button10_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stationIdDataGridViewTextBoxColumn,
            this.sysidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn1});
            this.dataGridView3.DataSource = this.stationsBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(339, 52);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(305, 150);
            this.dataGridView3.TabIndex = 7;
            this.dataGridView3.SelectionChanged += new System.EventHandler(this.dataGridView3_SelectionChanged);
            // 
            // stationIdDataGridViewTextBoxColumn
            // 
            this.stationIdDataGridViewTextBoxColumn.DataPropertyName = "stationId";
            this.stationIdDataGridViewTextBoxColumn.HeaderText = "stationId";
            this.stationIdDataGridViewTextBoxColumn.Name = "stationIdDataGridViewTextBoxColumn";
            this.stationIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.stationIdDataGridViewTextBoxColumn.Width = 72;
            // 
            // sysidDataGridViewTextBoxColumn
            // 
            this.sysidDataGridViewTextBoxColumn.DataPropertyName = "sysid";
            this.sysidDataGridViewTextBoxColumn.HeaderText = "sysid";
            this.sysidDataGridViewTextBoxColumn.Name = "sysidDataGridViewTextBoxColumn";
            this.sysidDataGridViewTextBoxColumn.Width = 55;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.Width = 58;
            // 
            // stationsBindingSource
            // 
            this.stationsBindingSource.DataMember = "stations";
            this.stationsBindingSource.DataSource = this.eliteDataSetBindingSource;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(163, 208);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "Delete";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(244, 208);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 1;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sysId,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.systemsBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(25, 52);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(294, 150);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // sysId
            // 
            this.sysId.DataPropertyName = "sysId";
            this.sysId.HeaderText = "sysId";
            this.sysId.Name = "sysId";
            this.sysId.ReadOnly = true;
            this.sysId.Width = 56;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 58;
            // 
            // systemsBindingSource
            // 
            this.systemsBindingSource.DataMember = "systems";
            this.systemsBindingSource.DataSource = this.eliteDataSetBindingSource;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // systemsTableAdapter
            // 
            this.systemsTableAdapter.ClearBeforeFill = true;
            // 
            // stationsTableAdapter
            // 
            this.stationsTableAdapter.ClearBeforeFill = true;
            // 
            // tradeitemsTableAdapter
            // 
            this.tradeitemsTableAdapter.ClearBeforeFill = true;
            // 
            // OCRThingee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1128, 514);
            this.Controls.Add(this.tabControl2);
            this.Name = "OCRThingee";
            this.Text = "Screen Ripper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_OCRRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeitemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TabPage tabPage3;
        private Panel buttonPanel;
        private Button button20;
        private Button btn_DeleteRow;
        private Button btn_AddRowToDatabase;
        private DataGridView dg_OCRRows;
        private Button button1;
        private Button button2;
        private PictureBox pb2;
        private Button button3;
        private PictureBox pb1;
        private Button button4;
        private NumericUpDown r1;
        private Label label1;
        private NumericUpDown r2;
        private NumericUpDown g1;
        private NumericUpDown g2;
        private NumericUpDown b1;
        private Label label2;
        private NumericUpDown b2;
        private Button button5;
        private Label label3;
        private Button button17;
        private Button button16;
        private Button button14;
        private TabControl tabControl2;
        private TabPage tabPage1;
        private Label label5;
        private Label label4;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox4;
        private Label label7;
        private Label label8;
        private TextBox txtCargo;
        private Button button6;
        private DataGridView dataGridView1;
        private Label label9;
        private Label label6;
        private TabPage tabPage2;
        private DataGridView dataGridView2;
        private Button button7;
        private Button button8;
        private DataGridView dataGridView3;
        private Label label11;
        private Label label10;
        private Label label12;
        private Button button11;
        private Button button12;
        private DataGridView dataGridView4;
      
        private Button button15;
        private Button button13;
        private Button button9;
        private Button button10;
        private Label label13;
        private DataGridView dataGridView5;
        private Label label14;
        private TextBox CreditsTextBox;
        private BindingSource eliteDataSetBindingSource;
        private EliteDataSet eliteDataSet;
        private BindingSource itemsBindingSource;
        private EliteDataSetTableAdapters.itemsTableAdapter itemsTableAdapter;
        private BindingSource systemsBindingSource;
        private EliteDataSetTableAdapters.systemsTableAdapter systemsTableAdapter;
        private BindingSource stationsBindingSource;
        private EliteDataSetTableAdapters.stationsTableAdapter stationsTableAdapter;
        private DataGridViewTextBoxColumn stationIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sysidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private BindingSource tradeitemsBindingSource;
        private EliteDataSetTableAdapters.tradeitemsTableAdapter tradeitemsTableAdapter;
        private DataGridViewTextBoxColumn productsIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stationidDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn buypriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sellpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn supplyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastupdateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sysId;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
    }
}

