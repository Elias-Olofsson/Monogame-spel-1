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
        private PlayerBehavior behavior;
        public Player(Texture2D texture, Vector2 pos, Point point):base(texture, pos, point)
        {

        }

        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();
                if()
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

            base.Update();
        }
    }

    public enum PlayerBehavior
    {
        Normal,
        Bad
    }
}
