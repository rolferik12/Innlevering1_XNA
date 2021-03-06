﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Innlevering1_XNA
{
    /// <summary>
    /// This class contains objects that are used by many different classes.
    /// </summary>
    public static class GameStatus
    {
        public static SpriteBatch SpriteBatch;
        public static ContentManager Content;
        public static float GameTimeInSec = 0;
        public static Vector2 MousePosition = new Vector2(0, 0);
        static bool mouseDown = false;
        public static bool MouseDown { get { return mouseDown; } set { MouseLastDown = mouseDown; mouseDown = value; } }
        public static bool MouseLastDown = false;
        public static bool MouseClick { get { return MouseLastDown == true && MouseDown == false; } }
        public static bool MouseNewDown { get { return MouseLastDown == false && MouseDown == true; } }
        public static Point windowBorder;
        public static bool Victory;

        /// <summary>
        /// Collision detection
        /// </summary>
        /// <param name="Position1"></param>
        /// <param name="Size1"></param>
        /// <param name="Position2"></param>
        /// <param name="Size2"></param>
        /// <returns></returns>
        public static bool Collide(Vector2 Position1, Vector2 Size1, Vector2 Position2, Vector2 Size2)
        {
            if (Position1.X + Size1.X >= Position2.X &&
                Position1.X <= Position2.X + Size2.X &&
                Position1.Y + Size1.Y >= Position2.Y &&
                Position1.Y <= Position2.Y + Size2.Y)
            {

                return true;
            }
            return false;
        }
    }
}
