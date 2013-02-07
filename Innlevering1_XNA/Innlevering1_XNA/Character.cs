using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Innlevering1_XNA
{
    public class CharacterClass 
    {
        public Texture2D Texture;
        public float Speed;

        public static CharacterClass[] Classes;
        public static Random rnd = new Random();
        public static void Load() 
        {
            Classes = new CharacterClass[] 
            {
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character_Boy2"), Speed = 95f},
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character_Cat_Girl2"), Speed = 80f},
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character_Horn_Girl2"), Speed = 150f},
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character_Pink_Girl2"), Speed = 100f},
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character_Princess_Girl2"), Speed = 130f}
            };
        }
        public static CharacterClass GetRandom() 
        {
            return Classes[rnd.Next(5)];
        }
    }
    public class Character
    {
        CharacterClass charClass;
        Vector2 position;
        Vector2 size;
        public Character(CharacterClass Class) 
        {
            this.charClass = Class;
        }

        public void Update() 
        {
            position.X += charClass.Speed * GameStatus.GameTimeInSec;
        }
        public void Draw() 
        {
            GameStatus.SpriteBatch.Draw(charClass.Texture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);
        }
    }
}
