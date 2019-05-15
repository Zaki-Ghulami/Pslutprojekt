using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_rocket
{
    class Fireball
    {
        Vector2 position;
        Texture2D texture;
        float speed = 5;

        public Rectangle Hitbox
        {
            get { return new Rectangle(position.ToPoint(), new Point(50, 50)); }
        }

        public Fireball(Texture2D Texture, Vector2 position)
        {
            this.texture = Texture;
            this.position = position;
        }
        public void Update()
        {
            position.Y += speed;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Hitbox, Color.White);

        }
    }
}
