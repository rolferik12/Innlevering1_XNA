using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Innlevering1_XNA
{   

    public class Building
    {

        //Texture vairables to building pictures
        Texture2D stoneBlock;

        Texture2D wallBlock;
        Texture2D doorClosed;

        Texture2D roofSouth;
        Texture2D roofSouthEast;
        Texture2D roofSouthWest;
        Texture2D windowTall;

        Texture2D roofWest;
        Texture2D brownBlock;
        Texture2D roofEast;
        Texture2D roofNorth;

        Texture2D roofNorthWest;
        Texture2D roofNorthEast;

        //Array data for the building grid
        arrayData[] texturePosAndLayerArray;

        //Sets the variable for the scale size and the x coordinate for the pictures.
        float scale;
        float xcoord;

        public Building()
        {
        }
        
        /// <summary>
        /// Loads the pictures and defines the variables
        /// </summary>
        public void Load()
        {

            //Sets the scale for the images
            xcoord = (float)(GameStatus.windowBorder.X / 7);
            texturePosAndLayerArray = new arrayData[35];


            //Loads the stoneblock pictures
            stoneBlock = GameStatus.Content.Load<Texture2D>("Building/Stone Block");

            //Loads the wall and door pictures
            wallBlock = GameStatus.Content.Load<Texture2D>("Building/Wall BLock Tall");
            doorClosed = GameStatus.Content.Load<Texture2D>("Building/Door Tall CLosed");

            //Loads the south roof pictures
            roofSouth = GameStatus.Content.Load<Texture2D>("Building/Roof South");
            roofSouthEast = GameStatus.Content.Load<Texture2D>("Building/Roof South East");
            roofSouthWest = GameStatus.Content.Load<Texture2D>("Building/Roof South West");
            windowTall = GameStatus.Content.Load<Texture2D>("Building/Window Tall");

            //Loads the middle roof pictures
            roofWest = GameStatus.Content.Load<Texture2D>("Building/Roof West");
            brownBlock = GameStatus.Content.Load<Texture2D>("Building/Brown Block");
            roofEast = GameStatus.Content.Load<Texture2D>("Building/Roof East");
            roofNorth = GameStatus.Content.Load<Texture2D>("Building/Roof North");

            //Loads the north roof pictures
            roofNorthWest = GameStatus.Content.Load<Texture2D>("Building/Roof North West");
            roofNorthEast = GameStatus.Content.Load<Texture2D>("Building/Roof North East");

            scale = (float)(GameStatus.windowBorder.X / 7) / (float)stoneBlock.Width;

            //Loads arrayData() which is the array data.
            arrayData();
        }

        /// <summary>
        /// Draws the data from the texturePosAndLayerArray grid and draws it.
        /// </summary>
        public void Draw()
        {
            for (int i = 0; i < texturePosAndLayerArray.Length; i++)
            {
                if (texturePosAndLayerArray[i] != null)
                {
                    GameStatus.SpriteBatch.Draw(texturePosAndLayerArray[i].Pic, texturePosAndLayerArray[i].Pos, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, texturePosAndLayerArray[i].Layer);
                } 
            }
        }

        /// <summary>
        /// Defines the arraydata to later be drawn by the Draw() function.
        /// 
        /// When X = 0 and Y = 0 you are in the top left corner of the grid.
        /// The array has stored the position data accordingly
        /// </summary>
        void arrayData()
        {
            float windowHeight = (float)GameStatus.windowBorder.Y;

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    int i = y * 7 + x;

                //Stone path data
                    if (y == 4)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 3.1f, stoneBlock, 1f);
                    }

                //Wall data
                    if (y == 3 && x == 5)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 2.02f, doorClosed, 0.5f);
                    }
                    else if (y == 3)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.84f, wallBlock, 0.5f);
                    }

                //Roof south data
                    if (y == 2 && x == 0)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.43f, roofSouthWest, 0.2f);
                    }
                    else if (y == 2 && x == 5)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.43f, windowTall, 0.2f);
                    }
                    else if (y == 2 && x == 6)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.43f, roofSouthEast, 0.2f);
                    }
                    else if (y == 2)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.43f, roofSouth, 0.2f);
                    }

                //Roof middle data
                    if (y == 1 && x == 0)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.19f, roofWest, 0.4f);
                    }
                    else if (y == 1 && x == 5)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.09f, roofNorth, 0.4f);
                    }
                    else if (y == 1 && x == 6)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.19f, roofEast, 0.4f);
                    }
                    else if (y == 1)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.19f, brownBlock, 0.4f);
                    }

                //Roof north data
                    if (y == 0 && x == 0)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.005f, roofNorthWest, 0.5f);
                    }
                    else if (y == 0 && x == 6)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.005f, roofNorthEast, 0.5f);
                    }
                    else if (y == 0)
                        texturePosAndLayerArray[i] = new arrayData(xcoord * x, windowHeight - windowHeight / 1.005f, roofNorth, 0.5f);


                }

            }
        }
    }

    /// <summary>
    /// Stores the arrayData
    /// </summary>
    public class arrayData
    {
        public Vector2 Pos;
        public Texture2D Pic;
        public float Layer;

        public arrayData(float X, float Y, Texture2D Pic, float Layer)
        {
            this.Pos.X = X;
            this.Pos.Y = Y;
            this.Pic = Pic;
            this.Layer = Layer;
        }
    }
}
