using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Innlevering1_XNA
{
    public class Health
    {
        Texture2D healthTexture;
        Vector2 size;
        public int HealthLeft = 5;
        public Health() 
        {
            healthTexture = GameStatus.Content.Load<Texture2D>("Other/Heart");
            size = new Vector2(GameStatus.windowBorder.X / 25, GameStatus.windowBorder.Y / 20);
        }
        public void Draw() 
        {
            for (int i = 0; i < HealthLeft; i++)
            {
                GameStatus.SpriteBatch.Draw(healthTexture, new Rectangle(((int)size.X  + GameStatus.windowBorder.X / 200)* i , 0, (int)size.X, (int)size.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            }
        }
    }
}
