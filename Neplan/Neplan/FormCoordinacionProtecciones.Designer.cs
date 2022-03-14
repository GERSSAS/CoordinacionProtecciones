namespace Neplan
{
    partial class FormCoordinacionProtecciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCoordinacionProtecciones));
            this.txtProyecto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvElements1 = new System.Windows.Forms.DataGridView();
            this.cb1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Elemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.t_Resistencia1 = new System.Windows.Forms.TextBox();
            this.t_Resistencia2 = new System.Windows.Forms.TextBox();
            this.t_Resistencia3 = new System.Windows.Forms.TextBox();
            this.t_Resistencia4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textVariante = new System.Windows.Forms.TextBox();
            this.txtSearch1 = new System.Windows.Forms.TextBox();
            this.textSearch2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvElements2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiLoading = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProyecto
            // 
            this.txtProyecto.Location = new System.Drawing.Point(92, 28);
            this.txtProyecto.Name = "txtProyecto";
            this.txtProyecto.Size = new System.Drawing.Size(357, 20);
            this.txtProyecto.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(675, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 35);
            this.button2.TabIndex = 30;
            this.button2.Text = "ANALIZAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 35);
            this.button1.TabIndex = 31;
            this.button1.Text = "OBTENER PROYECTO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvElements1
            // 
            this.dgvElements1.AllowUserToAddRows = false;
            this.dgvElements1.AllowUserToDeleteRows = false;
            this.dgvElements1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvElements1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElements1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cb1,
            this.Elemento,
            this.Tipo,
            this.id});
            this.dgvElements1.Location = new System.Drawing.Point(17, 190);
            this.dgvElements1.Name = "dgvElements1";
            this.dgvElements1.Size = new System.Drawing.Size(434, 347);
            this.dgvElements1.TabIndex = 32;
            // 
            // cb1
            // 
            this.cb1.FalseValue = "False";
            this.cb1.HeaderText = "Seleccionar";
            this.cb1.Name = "cb1";
            this.cb1.TrueValue = "True";
            // 
            // Elemento
            // 
            this.Elemento.HeaderText = "Elemento";
            this.Elemento.Name = "Elemento";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 18);
            this.label4.TabIndex = 40;
            this.label4.Text = "Seleccionar elementos en falla:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(465, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "Seleccionar los elementos para ver sus resultados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Proyecto:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(468, 71);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(167, 35);
            this.button5.TabIndex = 43;
            this.button5.Text = "LIMPIAR PROYECTO";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(848, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 44;
            this.label1.Text = "Resistencia Falla 1 (Ohm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(848, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "Resistencia Falla 2 (Ohm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(848, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 18);
            this.label6.TabIndex = 46;
            this.label6.Text = "Resistencia Falla 3 (Ohm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(848, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 18);
            this.label7.TabIndex = 47;
            this.label7.Text = "Resistencia Falla 4 (Ohm)";
            // 
            // t_Resistencia1
            // 
            this.t_Resistencia1.Location = new System.Drawing.Point(1048, 192);
            this.t_Resistencia1.Name = "t_Resistencia1";
            this.t_Resistencia1.Size = new System.Drawing.Size(33, 20);
            this.t_Resistencia1.TabIndex = 48;
            this.t_Resistencia1.Text = "0";
            // 
            // t_Resistencia2
            // 
            this.t_Resistencia2.Location = new System.Drawing.Point(1048, 227);
            this.t_Resistencia2.Name = "t_Resistencia2";
            this.t_Resistencia2.Size = new System.Drawing.Size(33, 20);
            this.t_Resistencia2.TabIndex = 49;
            this.t_Resistencia2.Text = "5";
            // 
            // t_Resistencia3
            // 
            this.t_Resistencia3.Location = new System.Drawing.Point(1048, 256);
            this.t_Resistencia3.Name = "t_Resistencia3";
            this.t_Resistencia3.Size = new System.Drawing.Size(33, 20);
            this.t_Resistencia3.TabIndex = 50;
            this.t_Resistencia3.Text = "10";
            // 
            // t_Resistencia4
            // 
            this.t_Resistencia4.Location = new System.Drawing.Point(1048, 287);
            this.t_Resistencia4.Name = "t_Resistencia4";
            this.t_Resistencia4.Size = new System.Drawing.Size(33, 20);
            this.t_Resistencia4.TabIndex = 51;
            this.t_Resistencia4.Text = "30";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Variante:";
            // 
            // textVariante
            // 
            this.textVariante.Location = new System.Drawing.Point(92, 71);
            this.textVariante.Name = "textVariante";
            this.textVariante.Size = new System.Drawing.Size(357, 20);
            this.textVariante.TabIndex = 54;
            // 
            // txtSearch1
            // 
            this.txtSearch1.Location = new System.Drawing.Point(92, 132);
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.Size = new System.Drawing.Size(357, 20);
            this.txtSearch1.TabIndex = 56;
            this.txtSearch1.TextChanged += new System.EventHandler(this.txtSearch1_TextChanged);
            // 
            // textSearch2
            // 
            this.textSearch2.Location = new System.Drawing.Point(533, 136);
            this.textSearch2.Name = "textSearch2";
            this.textSearch2.Size = new System.Drawing.Size(309, 20);
            this.textSearch2.TabIndex = 57;
            this.textSearch2.TextChanged += new System.EventHandler(this.textSearch2_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 58;
            this.label9.Text = "Buscar:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(464, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 59;
            this.label10.Text = "Buscar:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Neplan_coordinacion.Properties.Resources._1_6;
            this.pictureBox2.Location = new System.Drawing.Point(857, 449);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(215, 88);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Neplan_coordinacion.Properties.Resources.logo_gers_20121221;
            this.pictureBox1.Image = global::Neplan_coordinacion.Properties.Resources.logo_gers_20121221;
            this.pictureBox1.Location = new System.Drawing.Point(857, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // dgvElements2
            // 
            this.dgvElements2.AllowUserToAddRows = false;
            this.dgvElements2.AllowUserToDeleteRows = false;
            this.dgvElements2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvElements2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElements2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvElements2.Location = new System.Drawing.Point(468, 191);
            this.dgvElements2.Name = "dgvElements2";
            this.dgvElements2.Size = new System.Drawing.Size(374, 347);
            this.dgvElements2.TabIndex = 61;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "False";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Seleccionar";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.TrueValue = "True";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Elemento";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // MiLoading
            // 
            this.MiLoading.Enabled = false;
            this.MiLoading.Image = global::Neplan_coordinacion.Properties.Resources.output_onlinepngtools__1_;
            this.MiLoading.Location = new System.Drawing.Point(301, 325);
            this.MiLoading.Name = "MiLoading";
            this.MiLoading.Size = new System.Drawing.Size(334, 60);
            this.MiLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MiLoading.TabIndex = 62;
            this.MiLoading.TabStop = false;
            this.MiLoading.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(857, 389);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2, 20);
            this.label11.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(857, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(2, 20);
            this.label12.TabIndex = 64;
            // 
            // timer1
            // 
           
            // 
            // FormCoordinacionProtecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 550);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.MiLoading);
            this.Controls.Add(this.dgvElements2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textSearch2);
            this.Controls.Add(this.txtSearch1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textVariante);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.t_Resistencia4);
            this.Controls.Add(this.t_Resistencia3);
            this.Controls.Add(this.t_Resistencia2);
            this.Controls.Add(this.t_Resistencia1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvElements1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtProyecto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCoordinacionProtecciones";
            this.Text = "COORDINACIÓN DE PROTECCIONES";
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProyecto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvElements1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox t_Resistencia1;
        private System.Windows.Forms.TextBox t_Resistencia2;
        private System.Windows.Forms.TextBox t_Resistencia3;
        private System.Windows.Forms.TextBox t_Resistencia4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textVariante;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSearch1;
        private System.Windows.Forms.TextBox textSearch2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvElements2;
        private System.Windows.Forms.PictureBox MiLoading;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cb1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Elemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer1;
    }
}