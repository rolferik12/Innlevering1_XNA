﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Innlevering1_XNA
{
    public class CharacterClass 
    {
        //Variables
        public Texture2D Texture;
        public float Speed;

        public static CharacterClass[] Classes; //Stores all the different CharacterClasses
        public static Random rnd = new Random();
        /// <summary>
        /// Loads the CharacterClasses. Must be done before using GetRandom
        /// </summary>
        public static void Load() 
        {
            Classes = new CharacterClass[] 
            {
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character/Character_Boy2"), Speed = 95f},
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character/Character_Cat_Girl2"), Speed = 80f},
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character/Character_Horn_Girl2"), Speed = 150f},
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character/Character_Pink_Girl2"), Speed = 100f},
                new CharacterClass(){Texture = GameStatus.Content.Load<Texture2D>("Character/Character_Princess_Girl2"), Speed = 130f}
            };
        }
        /// <summary>
        /// Gets a random CharacterClass
        /// </summary>
        /// <returns></returns>
        public static CharacterClass GetRandom() 
        {
            return Classes[rnd.Next(5)];
        }
    }
    public class Character
    {
        //Variables
        CharacterClass charClass;
        public Vector2 Position;
        public Vector2 Size;
        public Character(CharacterClass Class) 
        {
            this.charClass = Class;
            Size = new Vector2(GameStatus.windowBorder.X / 11, GameStatus.windowBorder.Y / 6);
            Position = new Vector2(-Size.X, GameStatus.windowBorder.Y - Size.Y - GameStatus.windowBorder.Y / 15);
        }

        public void Update() 
        {
            Position.X += charClass.Speed * GameStatus.GameTimeInSec; //Moves this character
        }
        public void Draw() 
        {
            GameStatus.SpriteBatch.Draw(charClass.Texture, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
        }
    }
}
