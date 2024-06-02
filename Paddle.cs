using System;
using System.Drawing;

namespace BreakoutGameLab001
{
    // 擋板類別
    class Paddle : Brick
    {
        // 建構子
        public Paddle(int x, int y, int width, int height, Color color) : base(x, y, width, height, color)
        {
        }

        // 左右移動擋板
        public void Move(int vx)
        {
            X += vx;
        }
    }
}
