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
    //***************************************************************************
    /// <summary>
    /// ビットマップボタンのカスタムコントロール
    /// </summary>
    public partial class cctlBmpBtn : Control
    {
        //***************************************************************************
        // メンバ変数定義
        //***************************************************************************

        // ビットマップ配列のインデックス
        private const int IDX_ORG = 0;  // オリジナルのビットマップ
        private const int IDX_DRAW = 1; // 描画用のビットマップ

        //***************************************************************************
        // メンバ変数定義
        //***************************************************************************

        // ボタン表面に貼るビットマップのパラメータ
        private bool prv_bStretchBmp = false;   // ビットマップの拡大縮小フラグ
                                                // (true指定時、ボタンのサイズに合わせてビットマップを拡大・縮小)

        private Color prv_colorTransparent = Color.White;   // ビットマップの透明色の指定

        private Bitmap[] prv_bmpBtnFaceArray = new Bitmap[] { null, null }; // 通常時に貼るビットマップ (サイズ)
                                                                            // [0] : オリジナルのビットマップ
                                                                            // [1] : 描画用のビットマップ (背景透過、拡大縮小など)

        private Bitmap[] prv_bmpTglFaceArray = new Bitmap[] { null, null }; // ボタン押下時に貼るビットマップ (拡大縮小あり)
                                                                            // [0] : オリジナルのビットマップ
                                                                            // [1] : 描画用のビットマップ (背景透過、拡大縮小など)

        private bool prv_bToggled = false;                      // ボタンの押下フラグ (ボタンが押下されている間にtrue)
        private bool prv_bDrawToggledBtn = false;               // ボタンの描画フラグ (押下されているボタンを描画する時にtrue)
        private Point prv_ptToggleOffsetRB = new Point(0, 0);   // ボタン押下時にビットマップを右下にずらす量

        //***************************************************************************
        /// <summary>
        /// プロパティ定義 : ビットマップの拡大縮小フラグ
        ///                : (true指定時、ボタンのサイズに合わせてビットマップを拡大・縮小)
        /// </summary>
        public bool StretchBmp
        {
            get { return prv_bStretchBmp; }
            set
            {
                prv_bStretchBmp = value;

                // 描画用のビットマップをクリア (OnPaintで再生成される)
                prv_bmpBtnFaceArray[IDX_DRAW] = null;   // 通常時
                prv_bmpTglFaceArray[IDX_DRAW] = null;   // ボタン押下時

                // コントロールを再描画
                this.Invalidate();
            }
        }
        //***************************************************************************
        /// <summary>
        /// プロパティ定義 : ビットマップの透明色の指定
        /// </summary>
        public Color TransparentColor
        {
            get { return prv_colorTransparent; }
            set {
                prv_colorTransparent = value;

                // 描画用のビットマップをクリア (OnPaintで再生成される)
                prv_bmpBtnFaceArray[IDX_DRAW] = null;   // 通常時
                prv_bmpTglFaceArray[IDX_DRAW] = null;   // ボタン押下時

                // コントロールを再描画
                this.Invalidate();
            }
        }
        //***************************************************************************
        /// <summary>
        /// プロパティ定義 : 描画用のビットマップ
        /// </summary>
        public Bitmap bmpBtnFace
        {
            get { return prv_bmpBtnFaceArray[IDX_ORG]; }
            set
            {
                prv_bmpBtnFaceArray[IDX_ORG] = value;   // オリジナルのビットマップ

                // 描画用のビットマップをクリア (OnPaintで再生成される)
                prv_bmpBtnFaceArray[IDX_DRAW] = null;   // 描画用のビットマップをクリア

                // コントロールを再描画
                this.Invalidate();
            }
        }
        //***************************************************************************
        /// <summary>
        /// プロパティ定義 : ボタン押下時に貼るビットマップ
        /// </summary>
        public Bitmap bmpToggledFace
        {
            get { return prv_bmpTglFaceArray[IDX_ORG]; }
            set
            {
                prv_bmpTglFaceArray[IDX_ORG] = value;   // オリジナルのビットマップ

                // 描画用のビットマップをクリア (OnPaintで再生成される)
                prv_bmpTglFaceArray[IDX_DRAW] = null;   // 描画用のビットマップをクリア

                // コントロールを再描画
                this.Invalidate();
            }
        }
        //***************************************************************************
        /// <summary>
        /// プロパティ定義 : ボタン押下時にビットマップを右下にずらす量
        /// </summary>
        public Point ToggledOffsetRB
        {
            get { return prv_ptToggleOffsetRB; }
            set
            {
                prv_ptToggleOffsetRB = value;

                // 描画用のビットマップをクリア (OnPaintで再生成される)
                prv_bmpBtnFaceArray[IDX_DRAW] = null;   // 通常時
                prv_bmpTglFaceArray[IDX_DRAW] = null;   // ボタン押下時

                // コントロールを再描画
                this.Invalidate();
            }
        }
        //***************************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public cctlBmpBtn()
        {
            InitializeComponent();
        }
        //***************************************************************************
        /// <summary>
        /// ビットマップを補間モードを指定して拡大縮小
        /// </summary>
        /// <param name="bmpOrg">元のBitmapクラスオブジェクト</param>
        /// <param name="iResizedW">リサイズ後の幅</param>
        /// <param name="iResizedH">リサイズ後の高さ</param>
        /// <param name="interMode">リサイズの補間モード</param>
        /// <returns>リサイズ後のBitmap</returns>
        private Bitmap ResizeBmp(Bitmap bmpOrg, int iResizedW, int iResizedH, InterpolationMode interMode)
        {
            Graphics g = null;

            try
            {
                // ビットマップが24ビットRGB形式かどうかチェック
                if (bmpOrg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                {
                    Debug.WriteLine("ビットマップが24ビットRGB形式ではありません");
                    return bmpOrg;
                }

                Debug.WriteLine($"iResizedW={iResizedW}, iResizedH={iResizedH}");

                // ビットマップを指定サイズに引き延ばす
                Bitmap bmpResized = new Bitmap(iResizedW, iResizedH, bmpOrg.PixelFormat);

                Rectangle dstRect = new Rectangle(0, 0, iResizedW, iResizedH);
                Rectangle srcRect = new Rectangle(0, 0, bmpOrg.Width, bmpOrg.Height);

                g = Graphics.FromImage(bmpResized); // リサイズ後のビットマップの Graphics を取得

                g.Clear(Color.Transparent);         // ビットマップ領域をクリア
                g.InterpolationMode = interMode;    // 補完モードの指定

                g.DrawImage(bmpOrg, dstRect, srcRect, GraphicsUnit.Pixel);

                return bmpResized;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return bmpOrg;
            }
            finally
            {
                if (g != null) g.Dispose();
            }
        }
        //***************************************************************************
        /// <summary>
        /// 描画用ビットマップの更新
        /// </summary>
        /// <param name="bmpArray">ビットマップの配列 ([0]:オリジナル、[1]:描画用)</param>
        /// <param name="interMode">リサイズの補間モード</param>
        /// <returns>成功=true、失敗=false</returns>
        private bool UpdateDrawBmp(Bitmap[] bmpArray, InterpolationMode interMode = InterpolationMode.NearestNeighbor)
        {
            try
            {
                // 既に描画用のビットマップが存在していれば何もしない
                if (null != bmpArray[IDX_DRAW]) return true;

                // オリジナルのビットマップをクローン
                Bitmap bmpClone = (Bitmap)bmpArray[IDX_ORG].Clone();

                // 画像の透明色を指定
                bmpClone.MakeTransparent(prv_colorTransparent);

                // 拡大／縮小フラグが立っていなければ、ここで終了
                if (true != prv_bStretchBmp)
                {
                    bmpArray[IDX_DRAW] = bmpClone;
                    return true;
                }

                // リサイズ後のビットマップの幅／高さを計算 (押下時に右下にオフセットする値を減ずる)
                int iResizedW = this.Width - prv_ptToggleOffsetRB.X;
                int iResizedH = this.Height - prv_ptToggleOffsetRB.Y;

                // リサイズ後のビットマップを再生成
                bmpArray[IDX_DRAW] = ResizeBmp(bmpClone, iResizedW, iResizedH, interMode);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
        //***************************************************************************
        /// <summary>
        /// 描画イベント
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            try
            {
                Graphics g = pe.Graphics;   // 短い名前で読み替え

                // ボタン表面の描画
                if (null != prv_bmpBtnFaceArray[IDX_ORG])   // ボタン表面に貼るビットマップが設定されている
                {
                    if (true != prv_bDrawToggledBtn)    // 通常のボタンを描画
                    {
                        // 通常のビットマップを描画
                        if (true == UpdateDrawBmp(prv_bmpBtnFaceArray)) // 描画用ビットマップの更新
                        {
                            g.DrawImage(prv_bmpBtnFaceArray[IDX_DRAW], 0, 0);
                        }
                    }
                    else    // 押下されているボタンを描画
                    {
                        if (null == prv_bmpTglFaceArray[IDX_ORG])   // ボタン押下時のビットマップが設定されていない
                        {
                            // 通常時のビットマップを、ボタン押下時も使用する
                            prv_bmpTglFaceArray[IDX_DRAW] = prv_bmpBtnFaceArray[IDX_DRAW];
                        }
                        else
                        {
                            // ボタン押下時の描画用ビットマップを更新
                            UpdateDrawBmp(prv_bmpTglFaceArray);
                        }

                        // ボタン押下時のビットマップを描画 (右下にオフセットして描画)
                        g.DrawImage(prv_bmpTglFaceArray[IDX_DRAW], prv_ptToggleOffsetRB);
                    }
                }
                else
                {
                    // ビットマップを貼れないので、とりあえず外枠を描画
                    Rectangle rectDraw = this.ClientRectangle;

                    rectDraw.Width -= 1;    // 領域からはみ出すの減じる
                    rectDraw.Height -= 1;   //          〃

                    g.DrawRectangle(Pens.Black, rectDraw);

                    // 適当なフォントで枠の中央にコントロール名を描画
                    StringFormat fmtDrawStr = new StringFormat
                    {
                        Alignment = StringAlignment.Center,     // 中揃え (水平方向)
                        LineAlignment = StringAlignment.Center, // 中揃え (垂直方向)
                    };

                    using (Font fontDraw = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
                    {
                        g.DrawString(this.Name, fontDraw, Brushes.Black, rectDraw, fmtDrawStr);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        //***************************************************************************
        /// <summary>
        /// コントロールのサイズが変更された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            try
            {
                if (true == prv_bStretchBmp)    // 拡大縮小あり
                {
                    // 描画用のビットマップをクリア (OnPaintで再生成される)
                    prv_bmpBtnFaceArray[IDX_DRAW] = null;   // 通常時
                    prv_bmpTglFaceArray[IDX_DRAW] = null;   // ボタン押下時
                }
                this.Invalidate();  // コントロールを再描画

                // 基底クラスの OnSizeChanged を呼ぶ
                base.OnSizeChanged(e);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        //***************************************************************************
        /// <summary>
        /// ボタンに貼り付けたビットマップの有効領域がクリックされたか判定
        /// </summary>
        /// <param name="bmpHitTest">判定に使用するビットマップ (描画用のビットマップ)</param>
        /// <param name="ptCursor">ボタン座標系のカーソル位置</param>
        /// <param name="ptOffsetRB">ボタン押下時に右下にオフセットする値</param>
        /// <returns>ボタンがクリックされた=true、クリックされていない=false</returns>
        private bool HitTest(Bitmap bmpHitTest, Point ptCursor, Point ptOffsetRB)
        {
            try
            {
                // ヒットテスト用ビットマップが無ければ何もしない
                if (null == bmpHitTest)
                {
                    Debug.WriteLine("ヒットテスト用ビットマップが無い");
                    return false;
                }

                // ビットマップを右下にオフセットしている分だけ、カーソル位置を移動
                ptCursor.X -= ptOffsetRB.X;
                ptCursor.Y -= ptOffsetRB.Y;

                // カーソル位置が描画用ビットマップの範囲外なら無視
                GraphicsUnit gunit = GraphicsUnit.Pixel;
                RectangleF rectBmp = bmpHitTest.GetBounds(ref gunit);   // ビットマップ領域のRectを取得

                if (true != rectBmp.Contains(ptCursor)) return false;   // カーソルが領域のRectの範囲外なら無視

                // カーソル位置の色を取得して、Alpha が 0 でなければ(つまり透明でなければ)ヒットした
                Color c = bmpHitTest.GetPixel(ptCursor.X, ptCursor.Y);

                if (0 != c.A)   // クリックした位置は透明ではない
                {
                    //Console.WriteLine($"ヒットした : {c}");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
        //***************************************************************************
        /// <summary>
        /// ボタンがクリックされた
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            try
            {
                // ボタン表面にビットマップが描画されていなければ、親フォームにクリックイベントを通知
                if (null == prv_bmpBtnFaceArray[IDX_DRAW])
                {
                    base.OnClick(e);
                    return;
                }

                // ビットマップの有効領域がクリックされていれば、親フォームにクリックイベントを通知
                Point ptCursor = PointToClient(MousePosition);  // ボタン座標系のカーソル位置
                Point ptOffsetRB = new Point(0, 0);

                if (true == HitTest(prv_bmpBtnFaceArray[IDX_DRAW], ptCursor, ptOffsetRB))   // ビットマップの有効領域がクリックされた
                {
                    base.OnClick(e);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        //***************************************************************************
        /// <summary>
        /// コントロール上でマウスボタンが押された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                // ボタン表面に貼るビットマップが設定されていなければ、基底クラスのメソッドを呼んで終了
                if (null == prv_bmpBtnFaceArray[IDX_ORG])
                {
                    // 基底クラスの OnMouseDown を呼ぶ
                    base.OnMouseDown(e);
                    return;
                }

                // ビットマップの有効領域がクリックされたか判定
                Point ptCursor = new Point(e.X, e.Y);   // ボタン座標系のカーソル位置
                Point ptOffsetRB = new Point(0, 0);

                if (true == HitTest(prv_bmpBtnFaceArray[IDX_DRAW], ptCursor, ptOffsetRB))   // ビットマップの有効領域がクリックされた
                {
                    // マウスカーソルがコントロールの領域外に出てもMouseUpを受け取れるように、マウスカーソルをキャプチャする
                    this.Capture = true;    // マウスカーソルをキャプチャ

                    prv_bToggled = true;        // ボタンの押下フラグを立てる
                    prv_bDrawToggledBtn = true; // ボタンの描画フラグを「押下ボタン」に変更
                    this.Invalidate();          // コントロールを再描画

                    // 基底クラスの OnMouseDown を呼ぶ
                    base.OnMouseDown(e);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        //***************************************************************************
        /// <summary>
        /// マウスカーソルが移動中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            try
            {
                if (true == prv_bToggled)   // ボタン押下中
                {
                    // カーソル位置がビットマップの有効領域かヒットテスト
                    bool bRet1 = HitTest(prv_bmpBtnFaceArray[IDX_DRAW], new Point(e.X, e.Y), new Point(0, 0));      // 通常のビットマップ
                    bool bRet2 = HitTest(prv_bmpTglFaceArray[IDX_DRAW], new Point(e.X, e.Y), prv_ptToggleOffsetRB); // ボタン押下時のビットマップ
                    bool bHitTestResult = bRet1 || bRet2;

                    if (prv_bDrawToggledBtn != bHitTestResult)
                    {
                        prv_bDrawToggledBtn = bHitTestResult;   // ボタンの描画フラグを変更
                        this.Invalidate();                      // コントロールを再描画
                    }
                }

                // 基底クラスの OnMouseDown を呼ぶ
                base.OnMouseMove(e);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        //***************************************************************************
        /// <summary>
        /// マウスボタンが離された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                // ボタン表面に貼るビットマップが設定されていなければ、基底クラスのメソッドを呼んで終了
                if (null == prv_bmpBtnFaceArray[IDX_ORG])
                {
                    // 基底クラスの OnMouseUp を呼ぶ
                    base.OnMouseUp(e);
                    return;
                }

                if (true == prv_bToggled)   // ボタン押下中
                {
                    this.Capture = false;   // マウスカーソルのキャプチャを解除

                    prv_bToggled = false;           // ボタンの押下フラグを落とす
                    prv_bDrawToggledBtn = false;    // ボタンの描画フラグを「通常ボタン」に変更
                    this.Invalidate();              // コントロールを再描画

                    // 基底クラスの OnMouseUp を呼ぶ
                    base.OnMouseUp(e);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
