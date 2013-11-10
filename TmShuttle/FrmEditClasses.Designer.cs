namespace TmShuttle
{
    partial class FrmEditClasses
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cbox_Box = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_Confrm = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.nud_Relay = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.cbox_Grade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cbox_Box);
            this.kryptonPanel1.Controls.Add(this.label4);
            this.kryptonPanel1.Controls.Add(this.btn_Cancel);
            this.kryptonPanel1.Controls.Add(this.btn_Confrm);
            this.kryptonPanel1.Controls.Add(this.nud_Relay);
            this.kryptonPanel1.Controls.Add(this.cbox_Grade);
            this.kryptonPanel1.Controls.Add(this.label3);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.txt_ClassName);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(292, 242);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cbox_Box
            // 
            this.cbox_Box.FormattingEnabled = true;
            this.cbox_Box.Items.AddRange(new object[] {
            "主机1",
            "主机2",
            "主机3",
            "主机4"});
            this.cbox_Box.Location = new System.Drawing.Point(73, 100);
            this.cbox_Box.Name = "cbox_Box";
            this.cbox_Box.Size = new System.Drawing.Size(190, 20);
            this.cbox_Box.TabIndex = 147;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 146;
            this.label4.Text = "主机";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(173, 188);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(90, 25);
            this.btn_Cancel.TabIndex = 145;
            this.btn_Cancel.Values.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confrm
            // 
            this.btn_Confrm.Location = new System.Drawing.Point(73, 188);
            this.btn_Confrm.Name = "btn_Confrm";
            this.btn_Confrm.Size = new System.Drawing.Size(90, 25);
            this.btn_Confrm.TabIndex = 144;
            this.btn_Confrm.Values.Text = "确定";
            this.btn_Confrm.Click += new System.EventHandler(this.btn_Confrm_Click);
            // 
            // nud_Relay
            // 
            this.nud_Relay.Location = new System.Drawing.Point(73, 137);
            this.nud_Relay.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nud_Relay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Relay.Name = "nud_Relay";
            this.nud_Relay.Size = new System.Drawing.Size(190, 20);
            this.nud_Relay.TabIndex = 143;
            this.nud_Relay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbox_Grade
            // 
            this.cbox_Grade.FormattingEnabled = true;
            this.cbox_Grade.Items.AddRange(new object[] {
            "小班",
            "中班",
            "大班",
            "学前班"});
            this.cbox_Grade.Location = new System.Drawing.Point(73, 63);
            this.cbox_Grade.Name = "cbox_Grade";
            this.cbox_Grade.Size = new System.Drawing.Size(190, 20);
            this.cbox_Grade.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "继电器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "年级";
            // 
            // txt_ClassName
            // 
            this.txt_ClassName.Location = new System.Drawing.Point(73, 25);
            this.txt_ClassName.Name = "txt_ClassName";
            this.txt_ClassName.Size = new System.Drawing.Size(190, 21);
            this.txt_ClassName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "班级名称";
            // 
            // FrmEditClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 242);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEditClasses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑班级";
            this.Load += new System.EventHandler(this.FrmEditClasses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TextBox txt_ClassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_Grade;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nud_Relay;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Cancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Confrm;
        private System.Windows.Forms.ComboBox cbox_Box;
        private System.Windows.Forms.Label label4;
    }
}