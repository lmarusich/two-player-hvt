using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp2TutorialNoSources
{
    public class RTFScrolledBottom : RichTextBox
    {
        public event EventHandler thumbUp;
        public event EventHandler thumbDown;

        private int eventFired;

        protected override void DefWndProc(ref Message m)
        {
            base.DefWndProc(ref m);
            if (m.Msg == 277)
            {
                eventFired++;
                if (eventFired == 2)
                {
                    thumbDown(this, System.EventArgs.Empty);
                    eventFired = 0;
                }

            }

            if (m.Msg == 277 && (int)m.WParam == 8)

                thumbUp(this, System.EventArgs.Empty);

        }
    }
}
