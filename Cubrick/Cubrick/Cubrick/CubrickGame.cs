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
        //Cube[] cubes = new Cube[3];
        Camera camera = new Camera();

        public CubrickGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferMultiSampling = true;
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
            // TargetElapsedTime = TimeSpan.FromTicks(666666);
            base.Initialize(); 
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
			//for (int i = 0; i < cubes.Length; i++)
	        //    cubes[i] = new Cube(new Vector3(0.2f, 0.2f, 0.2f), new Vector3(i - 1, 0, 0), GraphicsDevice);
            //aspectRatio = GraphicsDevice.Viewport.AspectRatio;
            rubicksCube = new RubicksCube(3, GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload all content.
        /// </summary>
        protected override void UnloadContent() {}

		private double angle = 0.0;
		private double cameraAngle = 0.0;

        /// <summary>
        /// Allows the game to run logic such as updating the world, checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) this.Exit();

			angle = (angle + 0.05) % MathHelper.TwoPi;

            for (int i = 0; i < rubicksCube.Size; i++)
            {
                for (int j = 0; j < rubicksCube.Size; j++)
                {
                    for (int k = 0; k < rubicksCube.Size; k++)
                    {
                        rubicksCube.GetCube(i, j, k).Position = new Vector3((float)(Math.Sin(angle) * 1.4 * (i * 0.9f)), (float)(Math.Cos(angle) * 0.5 * (i * 1.2f)), 0);
                        rubicksCube.GetCube(i, j, k).rotationY += 1.5f + (i * 0.7f);
                    }
                }
            }

			//for (int i = 0; i < cubes.Length; i++) {
			//	cubes[i].Position = new Vector3((float)(Math.Sin(angle) * 1.4 * (i * 0.9f)), (float)(Math.Cos(angle) * 0.5 * (i * 1.2f)), 0);
			//	cubes[i].rotationY += 1.5f + (i * 0.7f);
				// cube.rotationZ += 2.5f;
				// cube.rotationY += 0.5f;
			//}

			cameraAngle = (cameraAngle + 0.01) % MathHelper.TwoPi;
            camera.Position = new Vector3((float)(Math.Cos(cameraAngle) * 8), 2, (float)(Math.Sin(cameraAngle) * 8));
            camera.Target = Vector3.Zero;
            camera.Zoom =  (float)(Math.Sin(cameraAngle) * .8);
            //camera.Pitch = (float)(Math.Sin(cameraAngle) * .8);
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

			//foreach (Cube cube in cubes)
	        //    cube.RenderToDevice(GraphicsDevice, camera);

            rubicksCube.RenderToDevice(GraphicsDevice, camera);

            //GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            base.Draw(gameTime);

        }
    }
}
