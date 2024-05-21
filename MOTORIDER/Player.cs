using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace MOTORIDER
{
    public class Player : GameComponent
    {
        private SpriteBatch spriteBatch;
        public Vector2 posicao = new Vector2(Game1.screenWidth / 2, Game1.screenHeight / 2);
        public Texture2D textura;
        public Vector2 velocidade = new Vector2(50.0f, 50.0f);
        public Vector2 Origin;
        public double score;
        public double rounded;

        public Player(Game game, Texture2D texture, Vector2 position) : base(game)
        {
            this.posicao = position;
            this.textura = texture;

            Origin = new Vector2(textura.Width / 2, textura.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {

            bool allowMove = true;
            Vector2 newPosition = posicao;
            KeyboardState keyboardState = Keyboard.GetState();
            score += gameTime.ElapsedGameTime.TotalSeconds * 100;
            rounded = Math.Round(score, 0, MidpointRounding.ToEven);
            if (keyboardState.IsKeyDown(Keys.A))
            {
                newPosition.X -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                newPosition.X += 5;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                newPosition.Y += 5;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {

                newPosition.Y -= 5;
            }

            if (newPosition.X + (textura.Width / 1f) > Game1.screenWidth)
            {
                allowMove = false; // direita
            }

            if (newPosition.X < Game1.screenWidth / 6.5f)
            {
                allowMove = false; // esquerda
            }

            if (newPosition.Y < 10)
            {
                allowMove = false; 
            }
            if (newPosition.Y + (textura.Height / 5f) > Game1.screenHeight)
            {
                allowMove = false; 
            }

            if (allowMove)
            {
                posicao = newPosition;
            }



            base.Update(gameTime);
        }








        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(textura, posicao, Color.White);
        }


    }
}
