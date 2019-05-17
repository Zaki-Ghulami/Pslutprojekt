using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_rocket
{
    class Spacerocket
    {
        //typen,position och hastighet!
        Vector2 position;
        Texture2D texture;
        Vector2 speed;

        Keys lastHorizontal = Keys.X;
        Keys lastvertical = Keys.Y;
        readonly float angle = 0;

    
        public Rectangle Hitbox
        {
            get { return new Rectangle(position.ToPoint(), new Point(150, 150)); }
        }

        public Spacerocket(Texture2D Texture, Vector2 position)
        {
            this.texture = Texture;
            this.position = position;
        }
        public void Update()
        {
            //Här skrivs all logik och vilka knappar som  ska användas!
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.W))
            {
                speed += new Vector2(0, -0.1f);
            }
            else
            {
                speed += new Vector2(0, 0.1f);
                if (speed.Y > 0)
                    speed.Y = 0;
            }


            if (state.IsKeyDown(Keys.D))
            {
                speed += new Vector2(0.012f, 0);
                lastHorizontal = Keys.D;
            }
            else if (lastHorizontal == Keys.D)
            {
                speed += new Vector2(-0.02f, 0);
                if (speed.X < 0)
                    speed.X = 0;
            }

            if (state.IsKeyDown(Keys.A))
            {
                speed += new Vector2(-0.02f, 0);
                lastHorizontal = Keys.A;
            }

            else if (lastHorizontal == Keys.A)
            {
                speed += new Vector2(0.02f, 0);
                if (speed.X > 0)
                    speed.X = 0;
            }
            if (state.IsKeyDown(Keys.S))
            {
                speed += new Vector2(0, 0.2f);
                lastvertical = Keys.S;
            }
            else if (lastvertical == Keys.S)
            {
                speed += new Vector2(0, -0.2f);
                if (speed.Y > 0)
                    speed.Y = 0;
            }
            position += speed;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 150, 150), null, Color.White, MathHelper.ToRadians(angle), new Vector2(texture.Width, texture.Height) / 2, SpriteEffects.None, 0);

        }
    }
}
