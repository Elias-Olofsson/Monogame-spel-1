using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        List<GameObject> gameObjects;

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Vector2 rödLådaPos = new Vector2(500, 0);
            gameObjects = new List<GameObject>();
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D redBox = Content.Load<Texture2D>("RödLåda"); //laddar in den röda färgen
            Texture2D blueBox = Content.Load<Texture2D>("BlåLåda"); //laddar in de blå färgen
            player = new Player(redBox, new Vector2(10, 10), new Point(25, 25)); //bestämmer position, storlek och att den ska ha utseendet av den röda lådan

            gameObjects.Add(player); 

            gameObjects.Add(new Wall(blueBox, new Vector2(0, 0), new Point(700, 10))); //alla till radbytet är väggar med deras storlekar och positioner
            gameObjects.Add(new Wall(blueBox, new Vector2(0, 10), new Point(10, 400)));
            gameObjects.Add(new Wall(blueBox, new Vector2(700, 0), new Point(10, 410)));
            gameObjects.Add(new Wall(blueBox, new Vector2(10, 400), new Point(650, 10)));
            gameObjects.Add(new Wall(blueBox, new Vector2(35, 10), new Point(20, 200)));
            gameObjects.Add(new Wall(blueBox, new Vector2(10, 250), new Point(25, 25)));
            gameObjects.Add(new Wall(blueBox, new Vector2(100, 10), new Point(40, 10)));
            gameObjects.Add(new Wall(blueBox, new Vector2(100, 50), new Point(20, 321)));
            gameObjects.Add(new Wall(blueBox, new Vector2(100, 396), new Point(225, 4)));
            gameObjects.Add(new Wall(blueBox, new Vector2(120, 270), new Point(500, 20)));
            gameObjects.Add(new Wall(blueBox, new Vector2(400, 330), new Point(220, 45)));
            gameObjects.Add(new Wall(blueBox, new Vector2(150, 10), new Point(20, 100)));
            gameObjects.Add(new Wall(blueBox, new Vector2(150, 140), new Point(20, 130)));
            gameObjects.Add(new Wall(blueBox, new Vector2(200, 34), new Point(20, 200)));
            gameObjects.Add(new Wall(blueBox, new Vector2(220, 34), new Point(400, 20)));
            gameObjects.Add(new Wall(blueBox, new Vector2(265, 89), new Point(20, 181)));
            gameObjects.Add(new Wall(blueBox, new Vector2(320, 54), new Point(20, 181)));

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kstate = Keyboard.GetState(); //kollar vilka knappar som trycks innan updateringen

            foreach (GameObject gameObject in gameObjects) //updaterar alla spelobjekt
            {
                gameObject.Update();
            }

            Player player = gameObjects[0] as Player; //gör så att spelaren/den röda lådan får position 1 i listan

            for (int i = 1; i < gameObjects.Count; i++) //för alla utom spelaren så avslutas programmet om spelaren nuddar den
            {
                if (player.Rectangle.Intersects(gameObjects[i].Rectangle)) 
                {
                    Exit();
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.Black); //gör bakgrunden svart

            // TODO: Add your drawing code here.
            spriteBatch.Begin();
            foreach (GameObject gameObject in gameObjects) //för varje gameobjekt i listan rita ut dem
            {
                gameObject.Draw(spriteBatch); 
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
