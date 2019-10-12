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
        
        float TimeSurvivedScore;

        public bool isTimeStopped;

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
            spriteBatch.DrawString(Font, $"Time: {TimeSurvivedScore}", timerLocation, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateGetTimeSurvived(GameTime gameTime)
        {
                TimeSurvivedScore += (float)gameTime.ElapsedGameTime.TotalSeconds;
                TimeSurvivedScore.ToString();
        }
    }
}
