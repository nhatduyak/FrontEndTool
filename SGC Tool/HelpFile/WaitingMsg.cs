using System;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace TOOLChuyenDuLieu.HelpFile
{
    class WaitingMsg
    {
        private WaitDialogForm wait;

        public WaitingMsg()
        {
            this.wait = new WaitDialogForm("Xin vui l\x00f2ng chờ trong gi\x00e2y l\x00e1t", "Đang xử l\x00fd");
        }

        public WaitingMsg(XtraForm main)
        {
            main.Shown += new EventHandler(this.end);
            this.wait = new WaitDialogForm("Xin vui l\x00f2ng chờ trong gi\x00e2y l\x00e1t", "Đang xử l\x00fd", new Size(250, 50), main);
        }

        public WaitingMsg(string title, string caption)
        {
            this.wait = new WaitDialogForm(caption, title);
        }

        public WaitingMsg(string title, string caption, XtraForm main)
        {
            main.Shown += new EventHandler(this.end);
            this.wait = new WaitDialogForm(caption, title, new Size(250, 50), main);
        }

        private void end(object sender, EventArgs e)
        {
            if (this.wait != null)
            {
                this.wait.Close();
            }
        }

        public void Finish()
        {
            if (this.wait != null)
            {
                this.wait.Close();
            }
        }

        public static void LongProcess(DelegationLib.CallFunction_NoIn_NoOut func)
        {
            WaitingMsg msg = new WaitingMsg();
            try
            {
                func();
            }
            catch
            {
            }
            finally
            {
                msg.Finish();
            }
        }
    }
}
