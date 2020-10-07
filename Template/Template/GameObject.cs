using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class GameObject
    {
        protected Texture2D texture;
        protected Vector2 pos;
        protected Rectangle rectangle;

        public GameObject(Texture2D texture, Vector2 pos, Point size)
        {
            this.texture = texture;
            this.pos = pos;
            rectangle = new Rectangle(pos.ToPoint(), size);
        }

        public virtual void Update()
        {
            rectangle.Location = pos.ToPoint();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
