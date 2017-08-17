using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Submarino1
{
    public class Game1 : Game
    {
        // Declare video graphics card
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        // Declare background image
        Texture2D background;

        public Game1()
        {
            // Instantiate current graphics card
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Set screen width and height
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;

            // Set to fullscreen
            // graphics.IsFullScreen = true;

            // Apply settings
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load background image
            background = Content.Load<Texture2D>("fig_fundo");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Start drawing process
            spriteBatch.Begin();

            // Draw image
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            // End drawing process
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
