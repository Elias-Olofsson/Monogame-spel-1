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
    class Player : GameObject //klassen ärver från GameObjekt
    {
        public PlayerBehavior behavior = PlayerBehavior.Normal; //gör så att man börjar på läge nr 0
        public Player(Texture2D texture, Vector2 pos, Point point) : base(texture, pos, point) //olika grejer som spelaren ska ha
        {

        }

        public override void Update() //gör så att den inte updateras 
        {
            KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
            if ((int)behavior == 1) //gör så att det andra läget får vanliga wasd kontroller med 3 i hastighet
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
            else //gör så att de andra lägena får wasd kontroller med 3 i hastighet fast motsatta
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

            if (kstate.IsKeyDown(Keys.NumPad0)) //alla här gör så att du kan trycka för att ändra lägen
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

            base.Update(); //gör så att den updatera nu efter istället
        }

        public override void Draw(SpriteBatch spriteBatch) //alla här gör så att bara det första läget ritar ut spelaren
        {
            if (behavior == PlayerBehavior.Normal)
            {
                base.Draw(spriteBatch);
            }
        }
    }    


    public enum PlayerBehavior //gör så att de olika spellägena får siffror så att t.ex normal är läge 0
    {
        Normal,
        Bad,
        Worst
    }
}
