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
        //Variables
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

        /// <summary>
        /// Loads content
        /// </summary>
        public void Load() 
        {
            building.Load();
            CharacterClass.Load();
            health = new Health();
            ladybug.Load();
            gameOvertexture = GameStatus.Content.Load<Texture2D>("Other/you are dead");
            victoryTexture = GameStatus.Content.Load<Texture2D>("Other/victory screen");
        }
        /// <summary>
        /// Updates all the interactive parts of the game
        /// </summary>
        public void Update() 
        {
            if (!gameOver && !GameStatus.Victory) //Only update if you're still is playing
            {
                if (GameStatus.MouseNewDown) //Every time the mousebutton is clicked then increase the difficulty
                {
                    difficulty += 0.02f;
                }
                ladybug.Update(); //Updates everything related to Ladybug nad gems
                bool hasKilld = false; //Stores if you have killd someone this update. Can only kill one pr frame
                nextSpawn -= GameStatus.GameTimeInSec;
                if (nextSpawn <= 0) //If nextSpawn <= 0 then spawn a new enemy
                {
                    characters.Add(new Character(CharacterClass.GetRandom()));
                    nextSpawn = (float)(rnd.NextDouble() * characterSpawnTimeMax + 0.1f) / difficulty;
                }
                for (int i = 0; i < characters.Count; i++) //Check if a character is shot and if it have taken a life from you
                {
                    if (!hasKilld && GameStatus.MouseNewDown && GameStatus.Collide(characters[i].Position, characters[i].Size, GameStatus.MousePosition, Vector2.One))
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
        /// <summary>
        /// Draws everything belonging to WorldInteraction
        /// </summary>
        public void Draw() 
        {
            building.Draw();

            if (!gameOver) //If game over Then dont draw characters or bugs
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    characters[i].Draw();
                }
                ladybug.Draw();
                health.Draw();
            }
            else //If game over
            {
                GameStatus.SpriteBatch.Draw(gameOvertexture, new Rectangle(0, 0, (int)GameStatus.windowBorder.X, (int)GameStatus.windowBorder.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0f);
            }
            if (GameStatus.Victory) //If you have won
            {
                GameStatus.SpriteBatch.Draw(victoryTexture, new Rectangle(0, 0, (int)GameStatus.windowBorder.X, (int)GameStatus.windowBorder.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0f);
            }
        }
    }
}
