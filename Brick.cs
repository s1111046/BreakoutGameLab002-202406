using System;
using System.Drawing;

namespace BreakoutGameLab001
{
    // 磚塊類別
    class Brick : Drawable
    {
        // 屬性
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }

        // 建構子
        public Brick(int x, int y, int width, int height, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
        }

        // 繪製磚塊
        public override void Draw(Graphics gr)
        {
            gr.FillRectangle(new SolidBrush(this.Color), X, Y, Width, Height);
            gr.DrawRectangle(new Pen(Color.Black, 1), X, Y, Width, Height);
        }
    }
}
