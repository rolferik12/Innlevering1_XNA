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
        Health health;
        List<Character> characters = new List<Character>();
        float characterSpawnTimeMax = 4;
        float nextSpawn = 2;
        Random rnd = new Random();

        public void Load() 
        {
            CharacterClass.Load();
            health = new Health();
        }
        public void Update() 
        {
            nextSpawn -= GameStatus.GameTimeInSec;
            if (nextSpawn <= 0) 
            {
                characters.Add(new Character(CharacterClass.GetRandom()));
                nextSpawn = (float)rnd.NextDouble() * characterSpawnTimeMax + 0.1f;
            }
            for (int i = 0; i < characters.Count; i++)
            {
                if (GameStatus.MouseDown && collide(characters[i].Position, characters[i].Size, GameStatus.MousePosition, Vector2.One))
                {
                    characters.RemoveAt(i);
                    i--;
                    continue;
                }
                else if (characters[i].Position.X > GameStatus.windowBorder.X) 
                {
                    health.Health--;
                    characters.RemoveAt(i);
                    i--;
                    continue;
                }
                characters[i].Update();
            }
        }
        public void Draw() 
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].Draw();
            }
            health.Draw();
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
