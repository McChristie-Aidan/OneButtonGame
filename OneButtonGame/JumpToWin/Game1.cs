using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spawner;
using Ghost;
using MonoGameLibrary.Sprite;
using System.Collections.Generic;

namespace JumpToWin
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Font;

        PacMan pac;
        GhostSpawner spawner;
        ScrollingBackgound.ScrollingBackground backgound;
        Timer.Timer timer;
        ScoreManager.ScoreManager scoreManager;

        bool GameOver;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);      
            Content.RootDirectory = "Content";

            backgound = new ScrollingBackgound.ScrollingBackground(this);
            backgound.DrawOrder = 0;
            this.Components.Add(backgound);

            spawner = new Spawner.GhostSpawner(this);
            this.Components.Add(spawner);

            pac = new PacMan(this);
            pac.DrawOrder = 1;
            this.Components.Add(pac);

            timer = new Timer.Timer(this);
            timer.DrawOrder = 2;
            this.Components.Add(timer);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

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
            Font = this.Content.Load<SpriteFont>("Font");

            GameOver = false;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (GameComponent gc in Components)
            {
                if (gc is MonogameGhost)
                {
                    if (((MonogameGhost)gc).Intersects(pac))
                    {
                        if (((MonogameGhost)gc).PerPixelCollision(pac))
                        {
                            gc.Enabled = false;
                            pac.Enabled = false;
                            timer.Enabled = false;
                            spawner.Enabled = false;
                            backgound.Enabled = false;
                            timer.isTimeStopped = true;
                        }
                    }
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

            

            base.Draw(gameTime);
        }

        
    }
}
