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
            this.chkStretchBmp = new System.Windows.Forms.CheckBox();
            this.cctlBmpBtn1 = new WindowsFormsApp1.cctlBmpBtn();
            this.cctlBmpBtn2 = new WindowsFormsApp1.cctlBmpBtn();
            this.cctlBmpBtn3 = new WindowsFormsApp1.cctlBmpBtn();
            this.SuspendLayout();
            // 
            // chkStretchBmp
            // 
            this.chkStretchBmp.AutoSize = true;
            this.chkStretchBmp.Location = new System.Drawing.Point(12, 38);
            this.chkStretchBmp.Name = "chkStretchBmp";
            this.chkStretchBmp.Size = new System.Drawing.Size(84, 16);
            this.chkStretchBmp.TabIndex = 2;
            this.chkStretchBmp.Text = "StretchBmp";
            this.chkStretchBmp.UseVisualStyleBackColor = true;
            this.chkStretchBmp.CheckedChanged += new System.EventHandler(this.chkStretchBmp_CheckedChanged);
            // 
            // cctlBmpBtn1
            // 
            this.cctlBmpBtn1.bmpBtnFace = global::WindowsFormsApp1.Properties.Resources.BtnFace;
            this.cctlBmpBtn1.bmpToggledFace = global::WindowsFormsApp1.Properties.Resources.ToggledFace;
            this.cctlBmpBtn1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cctlBmpBtn1.Location = new System.Drawing.Point(27, 88);
            this.cctlBmpBtn1.Name = "cctlBmpBtn1";
            this.cctlBmpBtn1.Size = new System.Drawing.Size(168, 122);
            this.cctlBmpBtn1.StretchBmp = true;
            this.cctlBmpBtn1.TabIndex = 3;
            this.cctlBmpBtn1.Text = "cctlBmpBtn1";
            this.cctlBmpBtn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cctlBmpBtn1.ToggledOffsetRB = new System.Drawing.Point(2, 2);
            this.cctlBmpBtn1.TransparentColor = System.Drawing.Color.White;
            this.cctlBmpBtn1.Click += new System.EventHandler(this.cctlBmpBtn1_Click);
            this.cctlBmpBtn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cctlBmpBtn1_MouseDown);
            this.cctlBmpBtn1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cctlBmpBtn1_MouseMove);
            this.cctlBmpBtn1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cctlBmpBtn1_MouseUp);
            // 
            // cctlBmpBtn2
            // 
            this.cctlBmpBtn2.bmpBtnFace = global::WindowsFormsApp1.Properties.Resources.BtnFace;
            this.cctlBmpBtn2.bmpToggledFace = null;
            this.cctlBmpBtn2.Location = new System.Drawing.Point(229, 112);
            this.cctlBmpBtn2.Name = "cctlBmpBtn2";
            this.cctlBmpBtn2.Size = new System.Drawing.Size(100, 37);
            this.cctlBmpBtn2.StretchBmp = true;
            this.cctlBmpBtn2.TabIndex = 4;
            this.cctlBmpBtn2.Text = "cctlBmpBtn2";
            this.cctlBmpBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cctlBmpBtn2.ToggledOffsetRB = new System.Drawing.Point(2, 2);
            this.cctlBmpBtn2.TransparentColor = System.Drawing.Color.White;
            // 
            // cctlBmpBtn3
            // 
            this.cctlBmpBtn3.bmpBtnFace = null;
            this.cctlBmpBtn3.bmpToggledFace = null;
            this.cctlBmpBtn3.Location = new System.Drawing.Point(360, 101);
            this.cctlBmpBtn3.Name = "cctlBmpBtn3";
            this.cctlBmpBtn3.Size = new System.Drawing.Size(141, 81);
            this.cctlBmpBtn3.StretchBmp = false;
            this.cctlBmpBtn3.TabIndex = 5;
            this.cctlBmpBtn3.Text = "cctlBmpBtn3";
            this.cctlBmpBtn3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cctlBmpBtn3.ToggledOffsetRB = new System.Drawing.Point(2, 2);
            this.cctlBmpBtn3.TransparentColor = System.Drawing.Color.White;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cctlBmpBtn3);
            this.Controls.Add(this.cctlBmpBtn2);
            this.Controls.Add(this.cctlBmpBtn1);
            this.Controls.Add(this.chkStretchBmp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkStretchBmp;
        private cctlBmpBtn cctlBmpBtn1;
        private cctlBmpBtn cctlBmpBtn2;
        private cctlBmpBtn cctlBmpBtn3;
    }
}

