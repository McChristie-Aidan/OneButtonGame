using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Timer
{
    public class Timer : DrawableGameComponent
    {
        GameTime gameTime;
        SpriteBatch spriteBatch;
        SpriteFont Font;
        
        public float TimeSurvivedScore;

        public bool isTimeStopped;

        public string result;

        Vector2 timerLocation; 
    
        public Timer(Game game) : base(game)
        {

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            Font = this.Game.Content.Load<SpriteFont>("Font");
            isTimeStopped = false;

            timerLocation = new Vector2(20, 20);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (isTimeStopped == false)
            {
                UpdateGetTimeSurvived(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Font, $"Time: {result}", timerLocation, Color.Black);
            //technical debt this should be in its own class.
            if (isTimeStopped == true)
            {
                spriteBatch.DrawString(Font, $"You survived for {result} seconds!", new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2 - Font.MeasureString($"You survived for {result} seconds!").Length() / 2, GraphicsDevice.Viewport.Bounds.Height / 2), Color.Black);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateGetTimeSurvived(GameTime gameTime)
        {
                TimeSurvivedScore += (float)gameTime.ElapsedGameTime.TotalSeconds;
                result = TimeSurvivedScore.ToString();
        }
    }
}
