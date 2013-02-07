using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Innlevering1_XNA
{
    public class Ladybug
    {
        Texture2D Enemy_Bug_Troll;
        Vector2 position;
        Vector2 size;
        Vector2[] possiblePositions;


        public void Load() 
        {
            float x = GameStatus.windowBorder.X / 7;
            possiblePositions = new Vector2[] { new Vector2(x * 2, 0), new Vector2(x * 3, 0), new Vector2(x * 4, 0), new Vector2(x * 2, 0), new Vector2(x * 6, 0) };
            GameStatus.Content.Load<Texture2D>("Charcter/Enemy_Bug_Troll");
            size = new Vector2(GameStatus.windowBorder.X / 10, GameStatus.windowBorder.X / 10);
            
        }
        public void Update()
        { 
            //GameStatus
        }
        public void Draw()
        { 
        
        }
    }
}
