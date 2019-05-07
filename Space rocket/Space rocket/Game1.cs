using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Space_rocket
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D Srocket;
        Texture2D game1fireballs;

        private List<Vector2>  fireballList;
        private int fireballTimer = 120;


        Vector2 position;
        Vector2 speed;

        Keys lastHorizontal = Keys.X;
        readonly float angle = 0;
        private readonly object Game1fiereballs;
        private readonly Texture2D fireballsTexture;
        //private Vector2? game1fireballs;
        //private Vector2? game1fireballs;

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
            position = new Vector2(300, 200);
            fireballList = new List<Vector2>();

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

            // TODO: use this.Content to load your game content here
            Srocket = Content.Load<Texture2D>("Srocket");
            game1fireballs = Content.Load<Texture2D>("fireballspng");
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
                speed += new Vector2(0.01f, 0);
                lastHorizontal = Keys.D;
            }
            else if (lastHorizontal == Keys.D)
            {
                speed += new Vector2(-0.01f, 0);
                if (speed.X < 0)
                    speed.X = 0;
            }

            if (state.IsKeyDown(Keys.A))
            {
                speed += new Vector2(-0.01f, 0);
                lastHorizontal = Keys.A;
            }

            else if (lastHorizontal == Keys.A)
            {
                speed += new Vector2(0.01f, 0);
                if (speed.X > 0)
                    speed.X = 0;
            }





            position += speed;
            //fireballs!!
            fireballTimer--;
            if (fireballTimer <= 0) 
            {
                fireballTimer = 120;
                fireballList.Add(new Vector2(200, -20));
              
            }
            for (int i = 0; i < fireballList.Count; i++)
            {
                fireballList[i] = fireballList[i] + new Vector2(0, 2);
            }
            base.Update(gameTime);

        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //spriteBatch.Draw(Srocket,new Rectangle((int)position.X,(int)position.Y,150,150), Color.White);
            spriteBatch.Draw(Srocket, new Rectangle((int)position.X, (int)position.Y, 150, 150), null, Color.White, MathHelper.ToRadians(angle), new Vector2(Srocket.Width, Srocket.Height) / 2, SpriteEffects.None, 0);
            {
                foreach (var fireballs in fireballList) 
                {
                    spriteBatch.Draw(game1fireballs, fireballs, Color.White);
                }
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}