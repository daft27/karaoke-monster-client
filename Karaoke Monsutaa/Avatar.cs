using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Karaoke_Monsutaa
{
    public partial class Avatar : UserControl
    {
        public enum MODE
        {
            INTERESTED,
            WAITING,
            DANCING,
            SINGING
        }

        private MODE mode = MODE.WAITING;
        private int singingCounter = 0;
        private int singingStartCounter = 0;

        public Avatar()
        {
            InitializeComponent();
        }

        public void SetMode(float musicdb, float voicedb)
        {
            if (musicdb < 25 && voicedb < 25)
            {
                this.Mode = Avatar.MODE.WAITING;
                singingCounter = 0;
                singingStartCounter--;
            }
            /*
            else if (voicedb >= 60) // 15 // 25
            {

                if (singingStartCounter < 0)
                    singingStartCounter = 0;

                if (singingCounter <= 0)
                    singingStartCounter++;
                else
                    singingCounter++;

                if (singingStartCounter > 5)
                {
                    this.Mode = Avatar.MODE.SINGING;
                    singingCounter = 20;
                }
                if (singingCounter > 20)
                    singingCounter = 20;
            }
            */
            else if (musicdb >= 65)
            {
                if (singingCounter <= 0)
                {
                    this.Mode = Avatar.MODE.DANCING;

                    if (singingStartCounter < 0)
                        singingStartCounter = 0;
                }

                singingCounter--;
                singingStartCounter--;
            }

        }

        private void Avatar_Load(object sender, EventArgs e)
        {
            idleMiku.Dock = DockStyle.Fill;
            dancingMiku.Dock = DockStyle.Fill;
        }

        private void Sing()
        {
            idleMiku.Visible = false;
            singingMiku.Visible = true;
            dancingMiku.Visible = false;
            //singingMiku.Refresh();
        }

        private void Look()
        {
            idleMiku.Visible = false;
            singingMiku.Visible = false;
            dancingMiku.Visible = false;
        }

        private void Dance()
        {
            idleMiku.Visible = false;
            singingMiku.Visible = false;
            dancingMiku.Visible = true;
        }

        private void Wait()
        {
            idleMiku.Visible = true;
            singingMiku.Visible = false;
            dancingMiku.Visible = false;
        }

        public override void Refresh()
        {
            base.Refresh();
            switch (mode)
            {
                case MODE.DANCING:
                    dancingMiku.Refresh();
                    break;
                case MODE.SINGING:
                    singingMiku.Refresh();
                    break;
            }
        }

        public MODE Mode
        {
            set
            {
                switch (value)
                {
                    case MODE.DANCING:
                        Dance();
                        break;
                    case MODE.INTERESTED:
                        Look();
                        break;
                    case MODE.SINGING:
                        Sing();
                        break;
                    case MODE.WAITING:
                        Wait();
                        break;
                }

            }
        }
    }
}
