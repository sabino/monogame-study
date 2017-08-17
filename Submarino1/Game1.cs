using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Submarino1
{
    public class Game1 : Game
    {
        // Declare video graphics card
        GraphicsDeviceManager graphics;

        // Default sprite
        SpriteBatch spriteBatch;

        // Declare background image
        Texture2D background;

        // Declare submarines
        Texture2D blueSubmarine;
        Texture2D redSubmarine;
        Texture2D greenSubmarine;

        // Declare keyboard
        KeyboardState state;

        // Declare submarines positions
        Vector2 centeredPosition;
        Vector2 blueSubmarinePosition;
        Vector2 redSubmarinePosition;
        Vector2 greenSubmarinePosition;

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

            centeredPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            blueSubmarinePosition = centeredPosition;
            redSubmarinePosition = centeredPosition + new Vector2(100, 100);
            greenSubmarinePosition = centeredPosition - new Vector2(100, 100);

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

            // Load images
            background = Content.Load<Texture2D>("fig_fundo");
            blueSubmarine = Content.Load<Texture2D>("fig_subazul");
            redSubmarine = Content.Load<Texture2D>("fig_subvermelho");
            greenSubmarine = Content.Load<Texture2D>("fig_subverde");

            // Instantiate Keyboard
            state = Keyboard.GetState();
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

            // Draw blue submarine
            spriteBatch.Draw(blueSubmarine, blueSubmarinePosition, Color.White);

            // Draw red submarine
            spriteBatch.Draw(redSubmarine, redSubmarinePosition, Color.White);

            // Draw green submarine
            spriteBatch.Draw(greenSubmarine, greenSubmarinePosition, Color.White);

            // End drawing process
            spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}
