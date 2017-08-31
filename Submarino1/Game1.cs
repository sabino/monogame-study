using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

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

        // Declare submarines positions
        Vector2 centeredPosition;
        Vector2 blueSubmarinePosition;
        Vector2 redSubmarinePosition;
        Vector2 greenSubmarinePosition;

        // Declare keyboard
        KeyboardState keyboard;

        // Declare music
        Song music;

        // Declare torpedo and its position
        Texture2D torpedo;
        Vector2 torpedoPosition;

        int torpedoMaxPosition;

        Boolean isShooting;
        Boolean isTorpedoVisible;
        Boolean createEnemy;

        List<Torpedo> Torpedos;

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

            torpedoPosition = centeredPosition;
            isShooting = false;
            isTorpedoVisible = false;
            torpedoMaxPosition = graphics.PreferredBackBufferWidth;

            Torpedos = new List<Torpedo>();


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
            torpedo = Content.Load<Texture2D>("fig_torpedo");

            // Load and play background music
            music = Content.Load<Song>("mus_sonar");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(music);


        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Instantiate Keyboard
            keyboard = Keyboard.GetState();

            //Random rnd = new Random();
            //redSubmarinePosition.X += rnd.Next(-5, 5);
            //redSubmarinePosition.Y += rnd.Next(-5, 5);
            
            if (isShooting)
            {
                isTorpedoVisible = true;
                torpedoPosition.X += 10;
                if (torpedoPosition.X >= torpedoMaxPosition)
                {
                    isTorpedoVisible = false;
                    isShooting = false;
                }
            }
            else
            {
                torpedoPosition.X = blueSubmarinePosition.X;
                torpedoPosition.Y = blueSubmarinePosition.Y + 15;
            }

            if(keyboard.IsKeyDown(Keys.N)) {
                createEnemy = true;
            }

            if (createEnemy) {
                // Create some enemies
                for (int i = 0; i < 5; i++)
                {
                    torpedoPosition.X = blueSubmarinePosition.X;
                    torpedoPosition.Y = blueSubmarinePosition.Y + 10;
                    Torpedos.Add(new Torpedo(i, torpedoPosition, torpedo, torpedoMaxPosition, true, spriteBatch));
                }
            }

            if (keyboard.IsKeyDown(Keys.Space))
                isShooting = true;

            if (keyboard.IsKeyDown(Keys.P))
                MediaPlayer.Pause();

            if (keyboard.IsKeyDown(Keys.Up))
                blueSubmarinePosition.Y -= 10;
     
            if (keyboard.IsKeyDown(Keys.Down))
                blueSubmarinePosition.Y += 10;

            if (keyboard.IsKeyDown(Keys.Right))
                blueSubmarinePosition.X += 10;

            if (keyboard.IsKeyDown(Keys.Left))
                blueSubmarinePosition.X -= 10;

            if (blueSubmarinePosition.X > 1024)
                blueSubmarinePosition.X = -97;

            if (blueSubmarinePosition.X < -97)
                blueSubmarinePosition.X = 1024;

            if (blueSubmarinePosition.Y < 0)
                blueSubmarinePosition.Y = 0;

            if (blueSubmarinePosition.Y > 720)
                blueSubmarinePosition.Y = 720;

            if (blueSubmarinePosition.X < 0)
                blueSubmarinePosition.X = 0;

            if (blueSubmarinePosition.X > 927)
                blueSubmarinePosition.X = 927;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Start drawing process
            spriteBatch.Begin();

            for (int i = 0; i < Torpedos.Count; i++)
            {
                Torpedos[i].Draw(spriteBatch);
                Torpedos.Remove(Torpedos[i]);
            }



            // End drawing process
            spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}
