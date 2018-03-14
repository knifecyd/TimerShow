using System.ComponentModel;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MouseKeyboardLibrary;

namespace TimerShow
{
    class GoldenFinger
    {

        /*
     上面的5个类编译成Dll引用,使用例子
    */
        public partial class HookTestWinForm : Form
        {
            //将枚举作为位域处理
            [Flags]
            enum MouseEventFlag : uint //设置鼠标动作的键值
            {
                Move = 0x0001,               //发生移动
                LeftDown = 0x0002,           //鼠标按下左键
                LeftUp = 0x0004,             //鼠标松开左键
                RightDown = 0x0008,          //鼠标按下右键
                RightUp = 0x0010,            //鼠标松开右键
                MiddleDown = 0x0020,         //鼠标按下中键
                MiddleUp = 0x0040,           //鼠标松开中键
                XDown = 0x0080,
                XUp = 0x0100,
                Wheel = 0x0800,              //鼠标轮被移动
                VirtualDesk = 0x4000,        //虚拟桌面
                Absolute = 0x8000
            }

            //设置鼠标位置
            [DllImport("user32.dll")]
            static extern bool SetCursorPos(int X, int Y);

            //设置鼠标按键和动作
            [DllImport("user32.dll")]
            static extern void mouse_event(MouseEventFlag flags,
                int dx, int dy,
                uint data,
                UIntPtr extraInfo); //UIntPtr指针多句柄类型


            MouseHook mouseHook = new MouseHook();
            KeyboardHook keyboardHook = new KeyboardHook();



            private void HookTestWinForm_Load(object sender, EventArgs e)
            {

                mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
                //mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
                //mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);
                //mouseHook.MouseWheel += new MouseEventHandler(mouseHook_MouseWheel);

                keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
                keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);
                keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);

                mouseHook.Start();
                keyboardHook.Start();

                SetXYLabel(MouseSimulator.X, MouseSimulator.Y);

            }

            void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
            {

                AddKeyboardEvent(
                    "KeyPress",
                    "",
                    e.KeyChar.ToString(),
                    "",
                    "",
                    ""
                    );

            }

            void keyboardHook_KeyUp(object sender, KeyEventArgs e)
            {

                AddKeyboardEvent(
                    "KeyUp",
                    e.KeyCode.ToString(),
                    "",
                    e.Shift.ToString(),
                    e.Alt.ToString(),
                    e.Control.ToString()
                    );

            }

            void keyboardHook_KeyDown(object sender, KeyEventArgs e)
            {


                AddKeyboardEvent(
                    "KeyDown",
                    e.KeyCode.ToString(),
                    "",
                    e.Shift.ToString(),
                    e.Alt.ToString(),
                    e.Control.ToString()
                    );

            }

            void mouseHook_MouseWheel(object sender, MouseEventArgs e)
            {

                AddMouseEvent(
                    "MouseWheel",
                    "",
                    "",
                    "",
                    e.Delta.ToString()
                    );

            }

            void mouseHook_MouseUp(object sender, MouseEventArgs e)
            {


                AddMouseEvent(
                    "MouseUp",
                    e.Button.ToString(),
                    e.X.ToString(),
                    e.Y.ToString(),
                    ""
                    );

            }

            void mouseHook_MouseDown(object sender, MouseEventArgs e)
            {


                AddMouseEvent(
                    "MouseDown",
                    e.Button.ToString(),
                    e.X.ToString(),
                    e.Y.ToString(),
                    ""
                    );


            }

            void mouseHook_MouseMove(object sender, MouseEventArgs e)
            {

                SetXYLabel(e.X, e.Y);

            }

            void SetXYLabel(int x, int y)
            {
                /*
                curXYLabel.Text = String.Format("Current Mouse Point: X={0}, y={1}", x, y);
                */

            }

            void AddMouseEvent(string eventType, string button, string x, string y, string delta)
            {
                /*
                listView1.Items.Insert(0,
                    new ListViewItem(
                        new string[]{
                        eventType,
                        button,
                        x,
                        y,
                        delta
                        }));
                        */

            }

            void AddKeyboardEvent(string eventType, string keyCode, string keyChar, string shift, string alt, string control)
            {
                /* 
                listView2.Items.Insert(0,
                     new ListViewItem(
                         new string[]{
                        eventType,
                        keyCode,
                        keyChar,
                        shift,
                        alt,
                        control
                    }));*/
                if (keyCode == Keys.Enter.ToString())
                {
                    int x, y = 0;
                    //x = 777;
                    //y = 500;

                    x = Properties.Settings.Default.xhook;
                    y = Properties.Settings.Default.yhook;

                    SetCursorPos(x, y);
                    mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                    Thread.Sleep(10);
                    mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

                }
                if (keyCode == Keys.Add.ToString())
                {
                    global.yzm_flag = true; ;

                }
                if (keyCode == Keys.OemMinus.ToString())
                {
                    global.yzm_flag = true; ;

                }

            }



        }
    }
}

