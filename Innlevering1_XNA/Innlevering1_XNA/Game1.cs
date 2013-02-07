using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Innlevering1_XNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        
        SpriteBatch spriteBatch;

        //defines the array names and array lenght.
        static int _arrayLenght = 7;

        arrayData[] texturePosAndLayerArray;

        Vector2[] stoneArray;
        Vector2[] wallArray;
        Vector2[] roofSouthArray;
        Vector2[] roofMiddleArray;
        Vector2[] roofNorthArray;

        //The "base" used to define the arrays. 
        Vector2 wallBase;
        Vector2 stoneBase;
        Vector2 roofSouthBase;
        Vector2 roofMiddleBase;
        Vector2 roofNorthBase;


        //Texture vairables to load pictures
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

        // Characters
        Texture2D Character_Boy2;
        Texture2D Character_Cat_Girl2;
        Texture2D Character_Horn_Girl2;
        Texture2D Character_Pink_Girl2;
        Texture2D Character_Princess_Girl2;

        // Cursor Texture Method.
        private Texture2D cursorTex;


        Texture2D BackgroundTexture;


        //Sets the variable for the scale size.
        float size;
        float xcord;


      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";

        }

        

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            stoneArray = new Vector2[_arrayLenght];
            roofSouthArray = new Vector2[_arrayLenght];
            wallArray = new Vector2[_arrayLenght];
            roofMiddleArray = new Vector2[_arrayLenght];
            roofNorthArray = new Vector2[_arrayLenght];

            texturePosAndLayerArray = new arrayData[35];

            //Defines how many pixels the width is.
            xcord = (float)(Window.ClientBounds.Width / 7);
          
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        
        protected override void LoadContent()
        {
            
           
                           
            //Defines Cursor Texture
                        cursorTex = Content.Load<Texture2D>("Crosshair/Crosshairs2");

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game 

            //Loads the picture content
            loadPictures();

            //calls on the array data
            arrayData();
            
            //Sets static variables in gameStatus
            GameStatus.Content = Content;
            GameStatus.SpriteBatch = spriteBatch;
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        Vector2 mousePosition;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

           // Set Mouse Position
            var mouse = Mouse.GetState();
            mousePosition.X = mouse.X;
            mousePosition.Y = mouse.Y;


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            // Draws mouse position, texture, vector etc.
            spriteBatch.Draw(cursorTex, mousePosition - new Vector2(cursorTex.Width, cursorTex.Height) / 2, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);


            for (int i = 0; i < texturePosAndLayerArray.Length; i++)
            {
                if (texturePosAndLayerArray[i] != null) drawPictures(texturePosAndLayerArray[i].Pic, texturePosAndLayerArray[i].Pos, texturePosAndLayerArray[i].Layer);
            }
                
            
            spriteBatch.End();

            base.Draw(gameTime);
        }



        /// <summary>
        /// Loads the specified pictures
        /// </summary>
        void loadPictures()
        {
            //Loads the stoneblock pictures
            stoneBlock = this.Content.Load<Texture2D>("Building/Stone Block");

            //Loads the wall and door pictures
            wallBlock = this.Content.Load<Texture2D>("Building/Wall BLock Tall");
            doorClosed = this.Content.Load<Texture2D>("Building/Door Tall CLosed");

            //Loads the south roof pictures
            roofSouth = this.Content.Load<Texture2D>("Building/Roof South");
            roofSouthEast = this.Content.Load<Texture2D>("Building/Roof South East");
            roofSouthWest = this.Content.Load<Texture2D>("Building/Roof South West");
            windowTall = this.Content.Load<Texture2D>("Building/Window Tall");

            //Loads the middle roof pictures
            roofWest = this.Content.Load<Texture2D>("Building/Roof West");
            brownBlock = this.Content.Load<Texture2D>("Building/Brown Block");
            roofEast = this.Content.Load<Texture2D>("Building/Roof East");
            roofNorth = this.Content.Load<Texture2D>("Building/Roof North");

            //Loads the north roof pictures
            roofNorthWest = this.Content.Load<Texture2D>("Building/Roof North West");
            roofNorthEast = this.Content.Load<Texture2D>("Building/Roof North East");

            //Sets the scale for the images
            size = (float)(Window.ClientBounds.Width / 7) / (float)stoneBlock.Width;


        }

        /// <summary>
        /// Sets the array coordinates for all arrays and sets the Y coordinate.
        /// </summary>
        void arrayData()
        {
            float windowHeight = (float)Window.ClientBounds.Height;

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    int i = y * 7 + x;

                    //Stone path data
                    if (y == 4)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)stoneBlock.Height / 0.89f, stoneBlock, 1f);
                    }

                    //Wall data
                    if (y == 3 && x == 5)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)wallBlock.Height * 1.75f, doorClosed, 0.5f);
                    }
                    else if (y == 3)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)wallBlock.Height * 1.88f, wallBlock, 0.5f);
                    }

                    //Roof south data
                    if (y == 2 && x == 0)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)roofSouth.Height * 2.45f, roofSouthWest, 0.2f);
                    }
                    else if (y == 2 && x == 5)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)roofSouth.Height * 2.45f, windowTall, 0.2f);
                    }
                    else if (y == 2 && x == 6)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)roofSouth.Height * 2.45f, roofSouthEast, 0.2f);
                    }
                    else if (y == 2)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)roofSouth.Height * 2.45f, roofSouth, 0.2f);
                    }

                    //Roof middle data
                    if (y == 1 && x == 0)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)brownBlock.Height * 3f, roofWest, 0.4f);
                    }
                    else if (y == 1 && x == 5)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)brownBlock.Height * 3.25f, roofNorth, 0.4f);
                    }
                    else if (y == 1 && x == 6)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)brownBlock.Height * 3f, roofEast, 0.4f);
                    }
                    else if (y == 1)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)brownBlock.Height * 3f, brownBlock, 0.4f);
                    }

                    //Roof north data
                    if (y == 0 && x == 0)
                    {
                    }

                }

            }

            //Sets the Y coordinates for the base vector2's.


            //      stoneBase.Y = windowHeight - (float)stoneBlock.Height / 0.89f;
            roofMiddleBase.Y = windowHeight - (float)brownBlock.Height * 3f;
            roofNorthBase.Y = windowHeight - (float)roofNorth.Height * 3.5f;

            for (int coords = 0; coords < _arrayLenght; coords++)
            {

                //stoneArray vector2 coordinates
                //          stoneArray[coords] = new Vector2(stoneBase.X, stoneBase.Y);
                //          stoneBase.X += xcord;

                //wallArray coordinates
                wallArray[coords] = new Vector2(wallBase.X, wallBase.Y);
                wallBase.X += xcord;

                if (wallArray[coords] == wallArray[5])
                {
                    wallArray[5].Y = wallBase.Y * 1.09f;
                }

                //roofSouthArray vector2 coordinates.
                roofSouthArray[coords] = new Vector2(roofSouthBase.X, roofSouthBase.Y);
                roofSouthBase.X += xcord;

                //roofMiddleArray vector2 coordinates.
                roofMiddleArray[coords] = new Vector2(roofMiddleBase.X, roofMiddleBase.Y);
                roofMiddleBase.X += xcord;

                if (roofMiddleArray[coords] == roofMiddleArray[5])
                {
                    roofMiddleArray[5].Y = roofMiddleBase.Y * 0.5f;
                }

                //roofNorthArray vector2 coordinates
                roofNorthArray[coords] = new Vector2(roofNorthBase.X, roofNorthBase.Y);
                roofNorthBase.X += xcord;


            }

        }

        /// <summary>
        /// creates a spritebatch draw, drawing the desired picture with the coordinates from the desired array.
        /// </summary>
        /// <param name="pictureName">The texture2d name of the content file</param>
        /// <param name="arrayName">name and optionally the array position where the picture is to be drawn</param>
        /// <param name="layerDepth">Sets the layer depth of the picture</param>
        void drawPictures(Texture2D pictureName, Vector2 arrayName, float layerDepth)
        {
            spriteBatch.Draw(pictureName, arrayName, null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, layerDepth);
        }
    }
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
