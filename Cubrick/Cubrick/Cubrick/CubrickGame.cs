using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Cubrick
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CubrickGame : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RubicksCube rubicksCube;
        Camera camera = new Camera();

        public CubrickGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferMultiSampling = true;
            Content.RootDirectory = "Content";
            this.Window.Title = "LOL cubes";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize(); 
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rubicksCube = new RubicksCube(3, GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload all content.
        /// </summary>
        protected override void UnloadContent() {}

		private double cameraAngle = 0.0;

        /// <summary>
        /// Allows the game to run logic such as updating the world, checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) this.Exit();

			cameraAngle = (cameraAngle + 0.01) % MathHelper.TwoPi;
            camera.Position = new Vector3((float)(Math.Cos(cameraAngle) * 8), 2, (float)(Math.Sin(cameraAngle) * 8));
            //camera.Position = new Vector3(-4, 4, 4);
			camera.Target = rubicksCube.GetCube(1, 1, 1).Position;
            //camera.Pitch = (float)(Math.Sin(cameraAngle) * .08);
            camera.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            rubicksCube.RenderToDevice(camera);
            //GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };
            base.Draw(gameTime);

        }
    }
}
