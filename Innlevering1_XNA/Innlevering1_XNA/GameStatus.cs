using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Innlevering1_XNA
{
    public static class GameStatus
    {
        public static Vector2 MousePosition = new Vector2(0, 0);
        public static bool MouseDown = false;
        public static SpriteBatch SpriteBatch;
        public static float GameTimeInSec = 0;
    }
}
