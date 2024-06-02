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
    internal class BrickGamePanel : Panel
    {
        // 定義遊戲元件
        private List<Ball> balls = new List<Ball>();
        private Paddle paddle;
        // 定義遊戲對象列表
        private List<Drawable> gameObjects = new List<Drawable>();

        // 定義 Timer 控制項
        private Timer timer = new Timer();

        public BrickGamePanel(int width, int height)
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Yellow;
            this.Size = new Size(width, height);
        }

        public void Initialize()
        {
            // 初始化遊戲元件
            Ball b1 = new Ball(Width / 2, Height / 2, 15, 3, -3, Color.Red);
            balls.Add(b1);
            gameObjects.Add(b1);
            //balls.Add(new Ball(Width / 3, Height / 2, 30, -2, -2, Color.Green));
            //balls.Add(new Ball(Width / 2, Height / 3, 10, -10, 10, Color.Blue));

            paddle = new Paddle(Width / 2 - 50, Height - 50, 120, 20, Color.Blue);
            gameObjects.Add(paddle);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Brick bb = new Brick(25 + j * 80, 25 + this.Location.Y + i * 30, 80, 30, Color.Green);
                    gameObjects.Add(bb);
                }
            }

            // 設定遊戲的背景控制流程: 每 20 毫秒觸發一次 Timer_Tick 事件 ==> 更新遊戲畫面
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 定時移動球的位置, 檢查碰撞事件
            foreach (Ball ball in balls)
            {
                ball.Move(0, 61, Width, Height);
                ball.CheckCollision(paddle, gameObjects);
            }

            // 重繪遊戲畫面
            Invalidate(); // --> 觸發 OnPaint 事件
        }

        // 處理畫面的重繪事件
        protected override void OnPaint(PaintEventArgs e)
        {
            // 呼叫基底類別的 OnPaint 方法 --> 這樣才能正確繪製 Panel 控制項
            base.OnPaint(e);

            // 取得 Graphics 物件
            Graphics gr = e.Graphics;

            // 繪製球，擋板，磚塊
            foreach (Drawable drawable in gameObjects)
            {
                drawable.Draw(gr);
            }
        }

        public void paddleMoveLeft()
        {
            paddle.Move(-30);
        }

        public void paddleMoveRight()
        {
            paddle.Move(30);
        }
    }
}
