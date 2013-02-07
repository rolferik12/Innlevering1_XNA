using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Innlevering1_XNA
{
    public class WorldIntreractions
    {
        Building building = new Building();
        Health health;
        Ladybug ladybug = new Ladybug();
        List<Character> characters = new List<Character>();
        float characterSpawnTimeMax = 4;
        float nextSpawn = 2;
        Random rnd = new Random();
        Texture2D gameOvertexture;
        Texture2D victoryTexture;
        bool gameOver = false;
        float difficulty = 1;

        public void Load() 
        {
            building.Load();
            CharacterClass.Load();
            health = new Health();
            ladybug.Load();
            gameOvertexture = GameStatus.Content.Load<Texture2D>("Other/you are dead");
            victoryTexture = GameStatus.Content.Load<Texture2D>("Other/victory screen");
        }
        public void Update() 
        {
            if (!gameOver && !GameStatus.Victory)
            {
                if (GameStatus.MouseNewDown) 
                {
                    difficulty += 0.02f;
                }
                ladybug.Update();
                bool hasKilld = false;
                nextSpawn -= GameStatus.GameTimeInSec;
                if (nextSpawn <= 0)
                {
                    characters.Add(new Character(CharacterClass.GetRandom()));
                    nextSpawn = (float)(rnd.NextDouble() * characterSpawnTimeMax + 0.1f) / difficulty;
                }
                for (int i = 0; i < characters.Count; i++)
                {
                    if (!hasKilld && GameStatus.MouseNewDown && collide(characters[i].Position, characters[i].Size, GameStatus.MousePosition, Vector2.One))
                    {
                        hasKilld = true;
                        characters.RemoveAt(i);
                        i--;
                        continue;
                    }
                    else if (characters[i].Position.X > GameStatus.windowBorder.X)
                    {
                        health.HealthLeft--;
                        characters.RemoveAt(i);
                        i--;
                        continue;
                    }
                    characters[i].Update();
                }
                if (health.HealthLeft == 0) gameOver = true;
            }
        }
        public void Draw() 
        {
            building.Draw();

            if (!gameOver)
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    characters[i].Draw();
                }
                ladybug.Draw();
                health.Draw();
            }
            else 
            {
                GameStatus.SpriteBatch.Draw(gameOvertexture, new Rectangle(0, 0, (int)GameStatus.windowBorder.X, (int)GameStatus.windowBorder.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0f);
            }
            if (GameStatus.Victory) 
            {
                GameStatus.SpriteBatch.Draw(victoryTexture, new Rectangle(0, 0, (int)GameStatus.windowBorder.X, (int)GameStatus.windowBorder.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0f);
            }
        }
        bool collide(Vector2 Position1, Vector2 Size1, Vector2 Position2, Vector2 Size2) 
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
