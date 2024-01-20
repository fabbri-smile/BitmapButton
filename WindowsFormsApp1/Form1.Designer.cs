namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.cctlBmpBtn3 = new WindowsFormsApp1.cctlBmpBtn();
            this.cctlBmpBtn1 = new WindowsFormsApp1.cctlBmpBtn();
            this.chkStretchBmp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cctlBmpBtn3
            // 
            this.cctlBmpBtn3.bmpBtnFace = null;
            this.cctlBmpBtn3.bmpToggledFace = null;
            this.cctlBmpBtn3.Location = new System.Drawing.Point(414, 114);
            this.cctlBmpBtn3.Name = "cctlBmpBtn3";
            this.cctlBmpBtn3.Size = new System.Drawing.Size(146, 65);
            this.cctlBmpBtn3.StretchBmp = false;
            this.cctlBmpBtn3.TabIndex = 1;
            this.cctlBmpBtn3.Text = "cctlBmpBtn2";
            this.cctlBmpBtn3.ToggledOffsetRB = new System.Drawing.Point(0, 0);
            this.cctlBmpBtn3.TransparentColor = System.Drawing.Color.White;
            // 
            // cctlBmpBtn1
            // 
            this.cctlBmpBtn1.bmpBtnFace = global::WindowsFormsApp1.Properties.Resources.BtnFace;
            this.cctlBmpBtn1.bmpToggledFace = global::WindowsFormsApp1.Properties.Resources.ToggledFace;
            this.cctlBmpBtn1.Location = new System.Drawing.Point(12, 12);
            this.cctlBmpBtn1.Name = "cctlBmpBtn1";
            this.cctlBmpBtn1.Size = new System.Drawing.Size(219, 107);
            this.cctlBmpBtn1.StretchBmp = true;
            this.cctlBmpBtn1.TabIndex = 0;
            this.cctlBmpBtn1.Text = "cctlBmpBtn1";
            this.cctlBmpBtn1.ToggledOffsetRB = new System.Drawing.Point(2, 2);
            this.cctlBmpBtn1.TransparentColor = System.Drawing.Color.White;
            this.cctlBmpBtn1.Click += new System.EventHandler(this.cctlBmpBtn1_Click);
            this.cctlBmpBtn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cctlBmpBtn1_MouseDown);
            this.cctlBmpBtn1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cctlBmpBtn1_MouseMove);
            this.cctlBmpBtn1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cctlBmpBtn1_MouseUp);
            // 
            // chkStretchBmp
            // 
            this.chkStretchBmp.AutoSize = true;
            this.chkStretchBmp.Location = new System.Drawing.Point(432, 63);
            this.chkStretchBmp.Name = "chkStretchBmp";
            this.chkStretchBmp.Size = new System.Drawing.Size(84, 16);
            this.chkStretchBmp.TabIndex = 2;
            this.chkStretchBmp.Text = "StretchBmp";
            this.chkStretchBmp.UseVisualStyleBackColor = true;
            this.chkStretchBmp.CheckedChanged += new System.EventHandler(this.chkStretchBmp_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkStretchBmp);
            this.Controls.Add(this.cctlBmpBtn3);
            this.Controls.Add(this.cctlBmpBtn1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cctlBmpBtn cctlBmpBtn1;
        private cctlBmpBtn cctlBmpBtn3;
        private System.Windows.Forms.CheckBox chkStretchBmp;
    }
}

