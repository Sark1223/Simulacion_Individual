namespace Encuestas_Restaurante
{
    partial class frmNumeros
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNumeros));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.panTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new ns1.BunifuCustomLabel();
            this.btnCerrar = new ns1.BunifuImageButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel4 = new ns1.BunifuCustomLabel();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtM = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtC = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtA = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSemilla = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel3 = new ns1.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.lblSemilla = new ns1.BunifuCustomLabel();
            this.cmdGenerar = new System.Windows.Forms.Button();
            this.tblPseudo = new ns1.BunifuCustomDataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdForma = new ns1.BunifuElipse(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel5.SuspendLayout();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblPseudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(194)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(648, 39);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(4, 383);
            this.panel8.TabIndex = 22;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(194)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 39);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(3, 383);
            this.panel7.TabIndex = 21;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(194)))));
            this.panel5.Controls.Add(this.label19);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 422);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(652, 28);
            this.panel5.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(283, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 16);
            this.label19.TabIndex = 2;
            this.label19.Text = "@Karla Santos";
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(194)))));
            this.panTop.Controls.Add(this.lblTitulo);
            this.panTop.Controls.Add(this.btnCerrar);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(652, 39);
            this.panTop.TabIndex = 20;
            this.panTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mover);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo.Location = new System.Drawing.Point(62, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(242, 23);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "GENERADOR DE NUMEROS ";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.Location = new System.Drawing.Point(611, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(27, 28);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.bunifuCustomLabel4);
            this.panel6.Controls.Add(this.rb10);
            this.panel6.Controls.Add(this.rb5);
            this.panel6.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(188, 254);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(122, 110);
            this.panel6.TabIndex = 39;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(3, -2);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(113, 44);
            this.bunifuCustomLabel4.TabIndex = 21;
            this.bunifuCustomLabel4.Text = "Nivel de \r\nsignificancia:";
            // 
            // rb10
            // 
            this.rb10.AutoSize = true;
            this.rb10.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.rb10.FlatAppearance.BorderSize = 2;
            this.rb10.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rb10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
            this.rb10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.rb10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb10.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb10.Location = new System.Drawing.Point(13, 45);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(61, 25);
            this.rb10.TabIndex = 0;
            this.rb10.Text = "10%";
            this.rb10.UseVisualStyleBackColor = true;
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rb5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rb5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rb5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rb5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb5.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb5.ForeColor = System.Drawing.Color.Black;
            this.rb5.Location = new System.Drawing.Point(13, 74);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(50, 25);
            this.rb5.TabIndex = 0;
            this.rb5.Text = "5%";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 66);
            this.label1.TabIndex = 38;
            this.label1.Text = "Generador de numeros pseudoaleatorios \r\ncon los que se realizara la Simulacion de" +
    " \r\nlas encuestas de un restaurante.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(148)))), ((int)(((byte)(168)))));
            this.panel4.Location = new System.Drawing.Point(188, 233);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(92, 1);
            this.panel4.TabIndex = 37;
            // 
            // txtM
            // 
            this.txtM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtM.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtM.ForeColor = System.Drawing.Color.DimGray;
            this.txtM.Location = new System.Drawing.Point(188, 208);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(92, 25);
            this.txtM.TabIndex = 26;
            this.txtM.Text = "17001";
            this.txtM.TextChanged += new System.EventHandler(this.txtM_TextChanged);
            this.txtM.Validating += new System.ComponentModel.CancelEventHandler(this.txtM_Validating);
            this.txtM.Validated += new System.EventHandler(this.txtM_Validated);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(148)))), ((int)(((byte)(168)))));
            this.panel3.Location = new System.Drawing.Point(55, 347);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(92, 1);
            this.panel3.TabIndex = 36;
            // 
            // txtC
            // 
            this.txtC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtC.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.ForeColor = System.Drawing.Color.DimGray;
            this.txtC.Location = new System.Drawing.Point(55, 322);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(92, 25);
            this.txtC.TabIndex = 25;
            this.txtC.Text = "221";
            this.txtC.TextChanged += new System.EventHandler(this.txtC_TextChanged);
            this.txtC.Validating += new System.ComponentModel.CancelEventHandler(this.txtC_Validating);
            this.txtC.Validated += new System.EventHandler(this.txtC_Validated);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(148)))), ((int)(((byte)(168)))));
            this.panel2.Location = new System.Drawing.Point(55, 287);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 1);
            this.panel2.TabIndex = 32;
            // 
            // txtA
            // 
            this.txtA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtA.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.ForeColor = System.Drawing.Color.DimGray;
            this.txtA.Location = new System.Drawing.Point(55, 262);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(92, 25);
            this.txtA.TabIndex = 24;
            this.txtA.Text = "101";
            this.txtA.TextChanged += new System.EventHandler(this.txtA_TextChanged);
            this.txtA.Validating += new System.ComponentModel.CancelEventHandler(this.txtA_Validating);
            this.txtA.Validated += new System.EventHandler(this.txtA_Validated);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(148)))), ((int)(((byte)(168)))));
            this.panel1.Location = new System.Drawing.Point(55, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 1);
            this.panel1.TabIndex = 31;
            // 
            // txtSemilla
            // 
            this.txtSemilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSemilla.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSemilla.ForeColor = System.Drawing.Color.DimGray;
            this.txtSemilla.Location = new System.Drawing.Point(55, 205);
            this.txtSemilla.Name = "txtSemilla";
            this.txtSemilla.Size = new System.Drawing.Size(94, 25);
            this.txtSemilla.TabIndex = 23;
            this.txtSemilla.Text = "27";
            this.txtSemilla.TextChanged += new System.EventHandler(this.txtSemilla_TextChanged);
            this.txtSemilla.Validating += new System.ComponentModel.CancelEventHandler(this.txtSemilla_Validating);
            this.txtSemilla.Validated += new System.EventHandler(this.txtSemilla_Validated);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(184, 180);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(29, 22);
            this.bunifuCustomLabel3.TabIndex = 35;
            this.bunifuCustomLabel3.Text = "m:";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(50, 294);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(24, 22);
            this.bunifuCustomLabel2.TabIndex = 34;
            this.bunifuCustomLabel2.Text = "c:";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(50, 237);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(25, 22);
            this.bunifuCustomLabel1.TabIndex = 30;
            this.bunifuCustomLabel1.Text = "a:";
            // 
            // lblSemilla
            // 
            this.lblSemilla.AutoSize = true;
            this.lblSemilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(84)))), ((int)(((byte)(142)))));
            this.lblSemilla.Location = new System.Drawing.Point(51, 180);
            this.lblSemilla.Name = "lblSemilla";
            this.lblSemilla.Size = new System.Drawing.Size(73, 22);
            this.lblSemilla.TabIndex = 29;
            this.lblSemilla.Text = "Semilla:";
            // 
            // cmdGenerar
            // 
            this.cmdGenerar.Location = new System.Drawing.Point(91, 380);
            this.cmdGenerar.Name = "cmdGenerar";
            this.cmdGenerar.Size = new System.Drawing.Size(160, 32);
            this.cmdGenerar.TabIndex = 40;
            this.cmdGenerar.Text = "GENERAR";
            this.cmdGenerar.UseVisualStyleBackColor = true;
            this.cmdGenerar.Click += new System.EventHandler(this.cmdGenerar_Click);
            // 
            // tblPseudo
            // 
            this.tblPseudo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(158)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.tblPseudo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tblPseudo.BackgroundColor = System.Drawing.Color.White;
            this.tblPseudo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblPseudo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.tblPseudo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(94)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(190)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblPseudo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tblPseudo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPseudo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tblPseudo.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblPseudo.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblPseudo.DoubleBuffered = true;
            this.tblPseudo.EnableHeadersVisualStyles = false;
            this.tblPseudo.GridColor = System.Drawing.Color.Purple;
            this.tblPseudo.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(94)))), ((int)(((byte)(191)))));
            this.tblPseudo.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.tblPseudo.Location = new System.Drawing.Point(371, 48);
            this.tblPseudo.Margin = new System.Windows.Forms.Padding(1);
            this.tblPseudo.Name = "tblPseudo";
            this.tblPseudo.ReadOnly = true;
            this.tblPseudo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkOrchid;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkOrchid;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblPseudo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tblPseudo.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.tblPseudo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.tblPseudo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tblPseudo.Size = new System.Drawing.Size(266, 365);
            this.tblPseudo.TabIndex = 41;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Numero";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ri";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // rdForma
            // 
            this.rdForma.ElipseRadius = 20;
            this.rdForma.TargetControl = this;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Encuestas_Restaurante.Properties.Resources.restaurante__3_;
            this.pictureBox2.Location = new System.Drawing.Point(135, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // error
            // 
            this.error.ContainerControl = this;
            this.error.Icon = ((System.Drawing.Icon)(resources.GetObject("error.Icon")));
            // 
            // frmNumeros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tblPseudo);
            this.Controls.Add(this.cmdGenerar);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtM);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSemilla);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.lblSemilla);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNumeros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNumeros";
            this.Load += new System.EventHandler(this.frmNumeros_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblPseudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panTop;
        private ns1.BunifuCustomLabel lblTitulo;
        private ns1.BunifuImageButton btnCerrar;
        private System.Windows.Forms.Panel panel6;
        private ns1.BunifuCustomLabel bunifuCustomLabel4;
        public System.Windows.Forms.RadioButton rb10;
        public System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtSemilla;
        private ns1.BunifuCustomLabel bunifuCustomLabel3;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuCustomLabel lblSemilla;
        private System.Windows.Forms.Button cmdGenerar;
        public ns1.BunifuCustomDataGrid tblPseudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private ns1.BunifuElipse rdForma;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ErrorProvider error;
    }
}