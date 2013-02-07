﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Innlevering1_XNA
{
    public class Ladybug
    {
        Texture2D DM1;
        Texture2D DM2;
        Texture2D DM3;
        Texture2D Enemy_Bug_Troll;
        Texture2D Enemy_Bug_Troll_Down;
        Vector2 bugPosition;
        Vector2 bugSize;
        Vector2 DMPosition;
        Vector2 DMSize;
        bool showDM = false;
        Vector2[] possiblePositions;
        int teller = 20;
        int Score = 0;
        Random rnd = new Random();
        float timer = float.NaN;

        public void BugNewPosition() 
        {
            teller = 20;
            bugPosition = possiblePositions[rnd.Next(5)];
        }
        public void DMNewPossition()
        {
            DMPosition = bugPosition;
        }

        public void Load() 
        {
            float x = GameStatus.windowBorder.X / 7;
            possiblePositions = new Vector2[] { new Vector2(x * 2, 0), new Vector2(x * 3, 0), new Vector2(x * 4, 0), new Vector2(x * 2, 0), new Vector2(x * 6, 0) };
            Enemy_Bug_Troll = GameStatus.Content.Load<Texture2D>("Character/Enemy_Bug_roll");
            Enemy_Bug_Troll_Down = GameStatus.Content.Load<Texture2D>("Character/Enemy BugTrollClick");
            DM1 = GameStatus.Content.Load<Texture2D>("Other/Gem Blue");
            DM2 = GameStatus.Content.Load<Texture2D>("Other/Gem Green");
            DM3 = GameStatus.Content.Load<Texture2D>("Other/Gem Orange");
            bugSize = new Vector2(GameStatus.windowBorder.X / 10, GameStatus.windowBorder.X / 10);
            DMSize = new Vector2(GameStatus.windowBorder.X / 10, GameStatus.windowBorder.X / 10);

            BugNewPosition();
            
        }
        public void Update()
        {
            if (!timer.Equals(float.NaN))
            {
                timer -= GameStatus.GameTimeInSec;
                if (timer < 0) 
                {
                    timer = float.NaN;
                    showDM = !showDM;
                }
            }
            else
            {
                if (GameStatus.MouseNewDown && GameStatus.Collide(bugPosition, bugSize, GameStatus.MousePosition, Vector2.One) && showDM == false)
                {
                    teller--;
                    if (teller == 0)
                    {
                        DMNewPossition();
                        timer = 0.5f;
                    }

                }
                else if (GameStatus.MouseNewDown && GameStatus.Collide(DMPosition, DMSize, GameStatus.MousePosition, Vector2.One) && showDM == true)
                {
                    Score++;
                    if (Score == 3)
                    {
                        //end game *Du har vunnet TROLOLOLOL!*
                    }
                    else
                    {

                        BugNewPosition();
                        timer = 5;
                    }
                } 
            }
        }
        public void Draw()
        {
            if (timer.Equals(float.NaN))
            {
                if (showDM == true)
                {
                    GameStatus.SpriteBatch.Draw(DM1, new Rectangle((int)DMPosition.X, (int)DMPosition.Y, (int)DMSize.X, (int)DMSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                }
                else
                {
                    if (GameStatus.MouseDown && GameStatus.Collide(bugPosition, bugSize, GameStatus.MousePosition, Vector2.One)) GameStatus.SpriteBatch.Draw(Enemy_Bug_Troll_Down, new Rectangle((int)bugPosition.X, (int)bugPosition.Y, (int)bugSize.X, (int)bugSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                    else GameStatus.SpriteBatch.Draw(Enemy_Bug_Troll, new Rectangle((int)bugPosition.X, (int)bugPosition.Y, (int)bugSize.X, (int)bugSize.Y), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
                } 
            }
        }
    }
}