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

        // Cursor Texture Method.
        private Texture2D cursorTex;
        private Vector2 offsetPos;

        //Variables for recoil
        bool recoil;
        float recoilAcceleration = 1500;
        float recoilHeight = 400;
        float recoilSpeedY;


      
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
            mousePosition.X = mouse.X + offsetPos.X;
            mousePosition.Y = mouse.Y + offsetPos.Y;

            GameStatus.GameTimeInSec = (float)gameTime.ElapsedGameTime.TotalSeconds;
            GameStatus.MousePosition = mousePosition;
            GameStatus.MouseDown = mouse.LeftButton == ButtonState.Pressed;

            worldInteraction.Update();

            if (GameStatus.MouseNewDown)
            {
                recoil = true;
                recoilSpeedY = recoilHeight;
            }

            if (recoil)
            {
                if (0 >= offsetPos.Y)
                {
                    recoilSpeedY -= recoilAcceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    offsetPos.Y -= recoilSpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    offsetPos.Y = 0;
                    recoil = false;
                }
            }

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

            worldInteraction.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
