using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Innlevering1_XNA
{
    public class WorldIntreractions
    {
        List<Character> characters = new List<Character>();
        float characterSpawnTimeMax = 5;
        float nextSpawn = 5;
        Random rnd = new Random();

        public void Load() { }
        public void Update() 
        {
            nextSpawn -= GameStatus.GameTimeInSec;
            if (nextSpawn <= 0) 
            {
                //characters.Add(new Character());
                nextSpawn = (float)rnd.NextDouble() * characterSpawnTimeMax + 0.1f;
            }
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].Update();
            }
        }
        public void Draw() 
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].Draw();
            }
        }
    }
}
