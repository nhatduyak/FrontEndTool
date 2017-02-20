using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Diagnostics;

namespace TOOLChuyenDuLieu
{
    public sealed class SplashScreen : Control
    {
        // Fields
        private const int HWND_TOPMOST = -1;
        private static SplashScreen m_Instance = null;
        private static object m_LockObject = new object();
        private int m_nLeading;
        private int m_nTextOffsetX;
        private int m_nTextOffsetY;
        private string m_strCommentaryString;
        private StringFormat m_stringFormat;
        private string m_strTitleString;
        private const uint SWP_NOMOVE = 2;
        private const uint SWP_NOSIZE = 1;
        private const int WS_EX_TOOLWINDOW = 0x80;
        private const int WS_EX_TOPMOST = 8;

        // Methods
        private SplashScreen()
        {
            this.TitleString = string.Empty;
            this.CommentaryString = string.Empty;
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.m_stringFormat = new StringFormat();
            this.m_stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
            this.m_stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            this.m_nTextOffsetY = 0;
            this.m_nTextOffsetX = 0x2d;
            this.m_nLeading = 6;
            base.Visible = false;
            base.Width = 420;
            base.Height = 320;
        }

        public static void BeginDisplay()
        {
            Instance.Reorient();
            Instance.Visible = true;
            if (!Instance.Created)
            {
                Instance.CreateControl();
            }
            SetWindowPos(Instance.Handle, (IntPtr)(-1), 0, 0, 0, 0, 3);
            Instance.Refresh();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public static void EndDisplay()
        {
            Instance.Visible = false;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();
        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            if (this.BackgroundImage != null)
            {
                base.Width = this.BackgroundImage.Width;
                base.Height = this.BackgroundImage.Height;
                this.Reorient();
            }
            this.Refresh();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (base.Handle != IntPtr.Zero)
            {
                IntPtr desktopWindow = GetDesktopWindow();
                SetParent(base.Handle, desktopWindow);
            }
            base.OnHandleCreated(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (((base.Bounds.Width > 0) && (base.Bounds.Height > 0)) && base.Visible)
            {
                try
                {
                    SizeF ef;
                    RectangleF ef2;
                    SolidBrush brush;
                    Graphics graphics = e.Graphics;
                    graphics.SetClip(e.ClipRectangle);
                    graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    float height = base.ClientRectangle.Height;
                    this.m_nTextOffsetY = Convert.ToInt32(Math.Ceiling((double)((height / 3f) * 2f))) + this.m_nLeading;
                    if (this.TitleString != string.Empty)
                    {
                        Font font = new Font(this.Font, FontStyle.Bold);
                        ef = graphics.MeasureString(this.TitleString, font, base.ClientRectangle.Width, this.m_stringFormat);
                        this.m_nTextOffsetY += Convert.ToInt32(Math.Ceiling((double)ef.Height));
                        ef2 = new RectangleF((float)(base.ClientRectangle.Left + this.m_nTextOffsetX), (float)(base.ClientRectangle.Top + this.m_nTextOffsetY), ef.Width, ef.Height);
                        brush = new SolidBrush(this.ForeColor);
                        graphics.DrawString(this.TitleString, font, brush, ef2, this.m_stringFormat);
                        brush.Dispose();
                        font.Dispose();
                        this.m_nTextOffsetY += this.m_nLeading;
                    }
                    if (this.CommentaryString != string.Empty)
                    {
                        ef = graphics.MeasureString(this.CommentaryString, this.Font, base.ClientRectangle.Width, this.m_stringFormat);
                        this.m_nTextOffsetY += Convert.ToInt32(Math.Ceiling((double)ef.Height));
                        ef2 = new RectangleF((float)(base.ClientRectangle.Left + this.m_nTextOffsetX), (float)(base.ClientRectangle.Top + this.m_nTextOffsetY), ef.Width, ef.Height);
                        brush = new SolidBrush(this.ForeColor);
                        graphics.DrawString(this.CommentaryString, this.Font, brush, ef2, this.m_stringFormat);
                        brush.Dispose();
                    }
                }
                catch (Exception exception)
                {
                    StackFrame frame = new StackFrame(true);
                    Console.WriteLine("\nException: {0}, \n\t{1}, \n\t{2}, \n\t{3}\n", new object[] { base.GetType().ToString(), frame.GetMethod().ToString(), frame.GetFileLineNumber(), exception.Message });
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (((base.Bounds.Width > 0) && (base.Bounds.Height > 0)) && base.Visible)
            {
                try
                {
                    Rectangle rect = new Rectangle(0, 0, base.Bounds.Width, base.Bounds.Height);
                    Graphics graphics = e.Graphics;
                    graphics.SetClip(e.ClipRectangle);
                    if (this.BackgroundImage == null)
                    {
                        SolidBrush brush = new SolidBrush(this.BackColor);
                        graphics.FillRectangle(brush, rect);
                        brush.Dispose();
                    }
                    else
                    {
                        graphics.DrawImage(this.BackgroundImage, rect, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height, GraphicsUnit.Pixel);
                    }
                }
                catch (Exception exception)
                {
                    StackFrame frame = new StackFrame(true);
                    Console.WriteLine("\nException: {0}, \n\t{1}, \n\t{2}, \n\t{3}\n", new object[] { base.GetType().ToString(), frame.GetMethod().ToString(), frame.GetFileLineNumber(), exception.Message });
                }
            }
        }

        private void Reorient()
        {
            Rectangle workingArea = SystemInformation.WorkingArea;
            int x = (workingArea.Width - base.Width) / 2;
            int y = (workingArea.Height - base.Height) / 2;
            base.Location = new Point(x, y);
        }

        public static void SetBackgroundImage(Image image)
        {
            Instance.BackgroundImage = image;
        }

        public static void SetCommentaryString(string commentary)
        {
            Instance.CommentaryString = commentary;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        public static void SetTitleString(string title)
        {
            Instance.TitleString = title;
        }

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // Properties
        private string CommentaryString
        {
            get
            {
                return this.m_strCommentaryString;
            }
            set
            {
                this.m_strCommentaryString = value;
                this.Refresh();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x88;
                createParams.Parent = IntPtr.Zero;
                return createParams;
            }
        }

        public static SplashScreen Instance
        {
            get
            {
                lock (m_LockObject)
                {
                    if ((m_Instance == null) || m_Instance.IsDisposed)
                    {
                        m_Instance = new SplashScreen();
                    }
                    return m_Instance;
                }
            }
        }

        private string TitleString
        {
            get
            {
                return this.m_strTitleString;
            }
            set
            {
                this.m_strTitleString = value;
                this.Refresh();
            }
        }
    }


}
