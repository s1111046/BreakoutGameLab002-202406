using System;
using System.Drawing;

namespace BreakoutGameLab001
{
    // 定義一個抽象類別 Drawable
    internal abstract class Drawable
    {
        // 定義一個抽象方法 Draw
        public abstract void Draw(Graphics g);
    }
}
