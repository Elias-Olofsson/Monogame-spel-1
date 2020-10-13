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
    class Player : GameObject
    {
        public PlayerBehavior behavior = PlayerBehavior.Normal;
        public Player(Texture2D texture, Vector2 pos, Point point):base(texture, pos, point)
        {

        }

        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();
            if((int)behavior == 1)
            { 
                if (kstate.IsKeyDown(Keys.W))
                {
                    pos.Y -= 3;
                }
                else if (kstate.IsKeyDown(Keys.A))
                {
                    pos.X -= 3;
                }
                else if (kstate.IsKeyDown(Keys.D))
                {
                    pos.X += 3;
                }
                else if (kstate.IsKeyDown(Keys.S))
                {
                    pos.Y += 3;
                }
            }
            else
            {
                if (kstate.IsKeyDown(Keys.W))
                {
                    pos.Y += 3;
                }
                else if (kstate.IsKeyDown(Keys.A))
                {
                    pos.X += 3;
                }
                else if (kstate.IsKeyDown(Keys.D))
                {
                    pos.X -= 3;
                }
                else if (kstate.IsKeyDown(Keys.S))
                {
                    pos.Y -= 3;
                }
            }

            if (kstate.IsKeyDown(Keys.NumPad0))
            {
                behavior = PlayerBehavior.Normal;
            }
            else if (kstate.IsKeyDown(Keys.NumPad1))
            {
                behavior = PlayerBehavior.Bad;
            }
            else if (kstate.IsKeyDown(Keys.NumPad2))
            {
                behavior = PlayerBehavior.Worst;
            }
            
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(behavior == PlayerBehavior.Normal)
            {
                base.Draw(spriteBatch);
            }
        }
    }

    public enum PlayerBehavior
    {
        Normal,
        Bad,
        Worst
    }
}
