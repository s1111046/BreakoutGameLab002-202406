using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace BreakoutGameLab001
{
    class CustomizedPanel : Panel
    {
        // 定義 Timer 控制項，用於定時更新遊戲畫面
        private Timer timer = new Timer();

        // 建構子，設置面板的大小和背景顏色
        public CustomizedPanel(int width, int height)
        {
            // this.DoubleBuffered = true;
            this.BackColor = Color.Yellow;
            this.Size = new Size(width, height);
        }

        // 初始化方法，用於設置 Timer 的間隔和觸發事件
        public void Initialize()
        {
            // Timer : 每 20 毫秒觸發一次 Timer_Tick 事件 ==> 更新遊戲畫面
            // 也可以利用 Thread 類別來實現 類似的功能!!
            // timer.Interval = 20;
            // timer.Tick += Timer_Tick;
            // timer.Start();
        }

        // Timer 觸發事件，用於更新遊戲狀態
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 更新遊戲狀態
            // 例如：移動球的位置, 檢查碰撞事件等

            // 要求遊戲畫面重繪
            Invalidate(); // --> 觸發 OnPaint 事件
            //
        }

        // 處理畫面的重繪事件
        protected override void OnPaint(PaintEventArgs e)
        {
            // 呼叫基底類別的 OnPaint 方法 --> 這樣才能正確繪製 Panel 控制項
            base.OnPaint(e);

            // 取得 Graphics 物件，用於繪製圖形
            Graphics gr = e.Graphics;

            // 繪製遊戲畫面
            // 這裡是示範如何繪製一個紅色的圓形，可以根據需求修改
            gr.FillEllipse(new SolidBrush(Color.Red), 100, 100, 50, 50);
        }
    }
}
