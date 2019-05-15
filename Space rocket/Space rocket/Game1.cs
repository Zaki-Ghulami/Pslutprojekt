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

        private List<Fireball> fireballList;
        private int fireballTimer = 120;
        private System.Random rnd;

        Spacerocket spacerocket;

        Vector2 position;
        Vector2 speed;

        Keys lastHorizontal = Keys.X;
        Keys lastvertical = Keys.Y;
        readonly float angle = 0;
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
            position = new Vector2(300, 300);
            fireballList = new List<Fireball>();
            rnd = new System.Random();

            base.Initialize();
            spacerocket = new Spacerocket(Srocket, position);
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
            spacerocket.Update();
            //fireballs!!
            fireballTimer--;
            if (fireballTimer <= 0)
            {
                fireballTimer = 120;
                if (rnd.Next(2) == 0)
                {
                    fireballList.Add(new Fireball(game1fireballs,new Vector2(rnd.Next(0,750), -40)));
                }
                else 
                {
                    fireballList.Add(new Fireball(game1fireballs, new Vector2(rnd.Next(0, 750), -40)));
                }

            }
            for (int i = 0; i < fireballList.Count; i++)
            {
                fireballList[i].Update();
            }

            foreach (var item in fireballList)
            {
                if (item.Hitbox.Intersects(spacerocket.Hitbox))
                    Exit();
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

            spacerocket.Draw(spriteBatch);
            foreach (var fireballs in fireballList)
            {
                fireballs.Draw(spriteBatch);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}