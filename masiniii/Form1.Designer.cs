
namespace masiniii
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            butonSterge = new Button();
            butonAdauga = new Button();
            combo1 = new ComboBox();
            label3 = new Label();
            lista1 = new ListBox();
            lista2 = new ListBox();
            panel1 = new Panel();
            label6 = new Label();
            combo2 = new ComboBox();
            label5 = new Label();
            butonCalculeaza = new Button();
            labelTotal = new Label();
            dataGridView1 = new DataGridView();
            plaseazaComanda = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Teal;
            label1.ForeColor = Color.Black;
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Teal;
            label2.ForeColor = Color.Black;
            label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = Color.Black;
            label4.Name = "label4";
            label4.Click += label4_Click;
            // 
            // textBox2
            // 
            resources.ApplyResources(textBox2, "textBox2");
            textBox2.Name = "textBox2";
            // 
            // textBox3
            // 
            resources.ApplyResources(textBox3, "textBox3");
            textBox3.Name = "textBox3";
            // 
            // butonSterge
            // 
            resources.ApplyResources(butonSterge, "butonSterge");
            butonSterge.Name = "butonSterge";
            butonSterge.UseVisualStyleBackColor = true;
            butonSterge.Click += butonSterge_Click;
            // 
            // butonAdauga
            // 
            resources.ApplyResources(butonAdauga, "butonAdauga");
            butonAdauga.Name = "butonAdauga";
            butonAdauga.UseVisualStyleBackColor = true;
            butonAdauga.Click += butonAdauga_Click;
            // 
            // combo1
            // 
            resources.ApplyResources(combo1, "combo1");
            combo1.Cursor = Cursors.IBeam;
            combo1.DropDownStyle = ComboBoxStyle.DropDownList;
            combo1.FormattingEnabled = true;
            combo1.Name = "combo1";
            combo1.SelectedIndexChanged += combo1_SelectedIndexChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = Color.Teal;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.Crimson;
            label3.Name = "label3";
            label3.Click += label3_Click;
            // 
            // lista1
            // 
            resources.ApplyResources(lista1, "lista1");
            lista1.BackColor = SystemColors.InactiveCaption;
            lista1.FormattingEnabled = true;
            lista1.Name = "lista1";
            lista1.SelectionMode = SelectionMode.MultiExtended;
            lista1.SelectedIndexChanged += lista1_SelectedIndexChanged;
            // 
            // lista2
            // 
            resources.ApplyResources(lista2, "lista2");
            lista2.BackColor = SystemColors.InactiveCaption;
            lista2.ForeColor = SystemColors.WindowText;
            lista2.FormattingEnabled = true;
            lista2.Name = "lista2";
            lista2.SelectionMode = SelectionMode.MultiExtended;
            lista2.UseWaitCursor = true;
            lista2.SelectedIndexChanged += lista2_SelectedIndexChanged;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(combo2);
            panel1.Controls.Add(lista1);
            panel1.Controls.Add(combo1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Name = "panel1";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.Crimson;
            label6.Name = "label6";
            // 
            // combo2
            // 
            resources.ApplyResources(combo2, "combo2");
            combo2.Cursor = Cursors.IBeam;
            combo2.DropDownStyle = ComboBoxStyle.DropDownList;
            combo2.FormattingEnabled = true;
            combo2.Name = "combo2";
            combo2.SelectedIndexChanged += combo2_SelectedIndexChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.ForeColor = Color.Tan;
            label5.Name = "label5";
            label5.Click += label5_Click;
            // 
            // butonCalculeaza
            // 
            resources.ApplyResources(butonCalculeaza, "butonCalculeaza");
            butonCalculeaza.Name = "butonCalculeaza";
            butonCalculeaza.UseVisualStyleBackColor = true;
            butonCalculeaza.Click += butonCalculeaza_Click;
            // 
            // labelTotal
            // 
            resources.ApplyResources(labelTotal, "labelTotal");
            labelTotal.ForeColor = Color.Crimson;
            labelTotal.Name = "labelTotal";
            labelTotal.Click += labelTotal_Click;
            // 
            // dataGridView1
            // 
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // plaseazaComanda
            // 
            resources.ApplyResources(plaseazaComanda, "plaseazaComanda");
            plaseazaComanda.AutoEllipsis = true;
            plaseazaComanda.ForeColor = Color.Crimson;
            plaseazaComanda.Name = "plaseazaComanda";
            plaseazaComanda.UseVisualStyleBackColor = true;
            plaseazaComanda.Click += plaseazaComanda_Click;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            Controls.Add(button1);
            Controls.Add(plaseazaComanda);
            Controls.Add(dataGridView1);
            Controls.Add(labelTotal);
            Controls.Add(butonCalculeaza);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(lista2);
            Controls.Add(label3);
            Controls.Add(butonAdauga);
            Controls.Add(butonSterge);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Cursor = Cursors.Cross;
            ForeColor = Color.Blue;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion


        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button butonSterge;
        private Button butonAdauga;
        private ComboBox combo1;
        private Label label3;
        private ListBox lista1;
        private ListBox lista2;
        private Panel panel1;
        private Label label5;
        private ComboBox combo2;
        private Button butonCalculeaza;
        private Label labelTotal;
        private DataGridView dataGridView1;
        private Button plaseazaComanda;
        private Label label6;
        private Button button1;
    }
}
