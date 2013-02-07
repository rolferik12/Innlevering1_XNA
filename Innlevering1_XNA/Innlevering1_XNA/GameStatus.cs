using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Innlevering1_XNA
{
    public static class GameStatus
    {
        public static SpriteBatch SpriteBatch;
        public static ContentManager Content;
        public static float GameTimeInSec = 0;
        public static Vector2 MousePosition = new Vector2(0, 0);
        public static bool MouseDown = false;
        public static Point windowBorder;
    }
}
