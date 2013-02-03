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

        //defines the array names and the "base" used to define the arrays. 
        Vector2 stoneBase;
        Vector2[] stoneArray = new Vector2[7];
        Vector2 roofBase;
        Vector2[] roofSArray = new Vector2[7];
        Vector2 wallBase;
        Vector2[] wallArray = new Vector2[7];

        //Texture vairables to load pictures
        Texture2D stoneBlock;
        Texture2D wallBlock;
        Texture2D doorClosed;
        Texture2D roofSouth;
        Texture2D roofSouthEast;
        Texture2D roofSoutWest;
        Texture2D windowTall;

        //Sets the variable for the scale size.
        float size;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game 

            float xcord = (float)(Window.ClientBounds.Width / 7);

            //Loads the stoneblock pictures
            stoneBlock = this.Content.Load<Texture2D>("Building/Stone Block");

            //Loads the wall and door pictures
            wallBlock = this.Content.Load<Texture2D>("Building/Wall BLock Tall");
            doorClosed = this.Content.Load<Texture2D>("Building/Door Tall CLosed");

            //Loads the roof pictures
            roofSouth = this.Content.Load<Texture2D>("Building/Roof South");
            roofSouthEast = this.Content.Load<Texture2D>("Building/Roof South East");
            roofSoutWest = this.Content.Load<Texture2D>("Building/Roof South West");
            windowTall = this.Content.Load<Texture2D>("Building/Window Tall");


            //Sets the Y coordinates for the base vector2's.
            stoneBase.Y = (float)Window.ClientBounds.Height - (float)stoneBlock.Height;
            wallBase.Y = stoneBase.Y - stoneBase.Y / 2.35f;
            roofBase.Y = wallBase.Y - wallBase.Y / 5 * 2.82f;

            for (int coords = 0; coords < 7; coords++)
            {
                //Sets the coordinates for the Vector2 stone array
                stoneArray[coords] = new Vector2(stoneBase.X, stoneBase.Y);
                stoneBase.X += xcord;

                //sets the coordinates for the Vector2 wall Array
                wallArray[coords] = new Vector2(wallBase.X, wallBase.Y);
                wallBase.X += xcord;

                if (wallArray[coords] == wallArray[5])
                {
                    wallArray[5].Y = stoneBlock.Height / 0.85f;
                }

                //sets the coordinates for the vector2 roofSouth array.
                roofSArray[coords] = new Vector2(roofBase.X, roofBase.Y);
                roofBase.X += xcord;
            }



            //Sets the scale
            size = (float)(Window.ClientBounds.Width / 7) / (float)stoneBlock.Width;

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
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

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

            spriteBatch.Begin();


            for (int drawPicture = 0; drawPicture < 7; drawPicture++)
            {

                //Draws the stone patio
                spriteBatch.Draw(stoneBlock, stoneArray[drawPicture], null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0);

                //Draws the wall
                if (wallArray[drawPicture] == wallArray[5])
                {
                    spriteBatch.Draw(doorClosed, wallArray[5], null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0.5f);
                }
                else
                    spriteBatch.Draw(wallBlock, wallArray[drawPicture], null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0.4f);


                //Draws the south roof
                if (roofSArray[drawPicture] == roofSArray[0])
                {
                    spriteBatch.Draw(roofSoutWest, roofSArray[0], null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0);
                }
                else if (roofSArray[drawPicture] == roofSArray[6])
                {
                    spriteBatch.Draw(roofSouthEast, roofSArray[6], null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0);
                }
                else if (roofSArray[drawPicture] == roofSArray[5])
                {
                    spriteBatch.Draw(windowTall, roofSArray[5], null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0);
                }
                else
                    spriteBatch.Draw(roofSouth, roofSArray[drawPicture], null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
