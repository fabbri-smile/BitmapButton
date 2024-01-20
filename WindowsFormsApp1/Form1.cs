using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // 参考 : フォームやコントロールの形を変える
            //      :   https://dobon.net/vb/dotnet/form/formregion.html

#if false
            //フォームのサイズを適当に変更
            this.SetBounds(this.Left, this.Top, 201, 101, BoundsSpecified.Size);

            //多角形の頂点の位置を設定
            Point[] points = {new Point(0, 0)
                            , new Point(100, 100)
                            , new Point(200, 100)
                            , new Point(100, 0)};
            byte[] types = {  (byte)PathPointType.Line
                            , (byte)PathPointType.Line
                            , (byte)PathPointType.Line
                            , (byte)PathPointType.Line };

            //GraphicsPathの作成
            GraphicsPath path = new GraphicsPath(points, types);

            //形を変更
            this.Region = new Region(path);
#elif false
            this.SetBounds(this.Left, this.Top, 301, 301, BoundsSpecified.Size);

            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(new Rectangle(0, 0, 300, 300));     //丸を描く
            path.AddEllipse(new Rectangle(100, 100, 100, 100)); //真ん中を丸くくりぬく

            this.Region = new Region(path);
#endif
        }


        private void cctlBmpBtn1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Click");
        }
        private void cctlBmpBtn1_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"MouseDown (e.Button={e.Button})");
        }

        private void cctlBmpBtn1_MouseMove(object sender, MouseEventArgs e)
        {
            //Debug.WriteLine("MouseMove (e.Button={e.Button})");
        }

        private void cctlBmpBtn1_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"MouseUp (e.Button={e.Button})");
        }

        private void chkStretchBmp_CheckedChanged(object sender, EventArgs e)
        {
            cctlBmpBtn1.StretchBmp = chkStretchBmp.Checked;
        }
    }
}
