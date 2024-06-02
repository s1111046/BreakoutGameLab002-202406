using System;
using System.Drawing;

namespace BreakoutGameLab001
{
    // 球類別
    class Ball : Drawable
    {
        // 屬性
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        // 建構子
        public Ball(int x, int y, int radius, int vx, int vy, Color color)
        {
            X = x;
            Y = y;
            Radius = radius;
            Color = color;
            // 初始化球的速度
            VelocityX = vx;
            VelocityY = vy;
        }

        // 繪製球
        public override void Draw(Graphics gr)
        {
            gr.FillEllipse(new SolidBrush(this.Color), X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }

        // 移動球
        public void Move(int left, int top, int right, int bottom)
        {
            // 根據速度更新球的位置
            X += VelocityX;
            Y += VelocityY;

            // 水平方向: 檢查球是否碰到牆壁
            if (X - Radius <= left)
            {
                VelocityX = -VelocityX; // 球反彈
                X = left + Radius; // 避免球超出邊界
            }
            else if (X + Radius >= right)
            {
                VelocityX = -VelocityX; // 球反彈
                X = right - Radius; // 避免球超出邊界
            }

            // 垂直方向: 檢查球是否碰到牆壁
            if (Y - Radius <= top)
            {
                VelocityY = -VelocityY;
                Y = top + Radius;
            }
            else if (Y + Radius >= bottom)
            {
                VelocityY = -VelocityY;
                Y = bottom - Radius;
            }
        }

        // 檢查碰撞事件 : 球是否與任一磚塊或擋板發生碰撞
        public void CheckCollision(Paddle paddle, List<Drawable> gameObjects)
        {
            // 檢查: 球是否與所有的磚塊發生碰撞
            foreach (Drawable drawable in gameObjects)
            {
                if (drawable is Brick && !(drawable is Paddle))
                {
                    Brick brick = (Brick)drawable;
                    if (X + Radius >= brick.X && X - Radius <= brick.X + brick.Width &&
                        Y + Radius >= brick.Y && Y - Radius <= brick.Y + brick.Height)
                    {
                        VelocityY = -VelocityY; // 球反彈
                        gameObjects.Remove(brick); // 移除磚塊

                        // 檢查是否所有磚塊都消失 ==> 遊戲結束

                        // 一次只讓一個磚塊消失 
                        break;
                    }
                }
            }

            // 檢查球是否與擋板發生碰撞
            if (X + Radius >= paddle.X && X - Radius <= paddle.X + paddle.Width &&
                Y + Radius >= paddle.Y && Y - Radius <= paddle.Y + paddle.Height)
            {
                // 球反彈
                VelocityY = -VelocityY;

                // 確保球不會黏在擋板上
                if (Y < paddle.Y)
                    Y = paddle.Y - Radius - 1;
                else if (Y > paddle.Y + paddle.Height)
                    Y = paddle.Y + paddle.Height + Radius + 1;
            }
        }
    }
}
