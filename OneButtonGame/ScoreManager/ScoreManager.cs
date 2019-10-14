using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Timer;

namespace ScoreManager
{
    public class ScoreManager : DrawableGameComponent
    {
        int scoreInt;
        float scoreFloat;
        string scoreString;

        public bool ShowFinalScore;

        Timer.Timer timer;

        SpriteFont Font;
        SpriteBatch spriteBatch;

        public ScoreManager(Game game) : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            scoreString = timer.result;

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = this.Game.Content.Load<SpriteFont>("Font");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            

            base.Draw(gameTime);
        }

    }
}
