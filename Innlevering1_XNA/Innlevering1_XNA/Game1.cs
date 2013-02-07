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

        WorldIntreractions worldInteraction = new WorldIntreractions();

        //defines the array names and array lenght.
        arrayData[] texturePosAndLayerArray;

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
        float scale;
        float xcord;


      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";

            IsMouseVisible = true;

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
            GameStatus.windowBorder = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);

            worldInteraction.Load();
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
            if (Keyboard.GetState().IsKeyDown(Keys.F11)) graphics.ToggleFullScreen();

            // TODO: Add your update logic here

           // Set Mouse Position
            var mouse = Mouse.GetState();
            mousePosition.X = mouse.X;
            mousePosition.Y = mouse.Y;

            GameStatus.GameTimeInSec = (float)gameTime.ElapsedGameTime.TotalSeconds;
            GameStatus.MousePosition = mousePosition;
            GameStatus.MouseDown = mouse.LeftButton == ButtonState.Pressed;

            worldInteraction.Update();

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

            worldInteraction.Draw();
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
            scale = (float)(Window.ClientBounds.Width / 7) / (float)stoneBlock.Width;


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
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)roofNorth.Height * 3.5f, roofNorthWest, 0.5f);
                    }
                    else if (y == 0 && x == 6)
                    {
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)roofNorth.Height * 3.5f, roofNorthEast, 0.5f);
                    }
                    else if (y == 0)
                        texturePosAndLayerArray[i] = new arrayData(xcord * x, windowHeight - (float)roofNorth.Height * 3.5f, roofNorth, 0.5f);


                }

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
            spriteBatch.Draw(pictureName, arrayName, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
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
