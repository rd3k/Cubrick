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

        Texture2D cubeTexture;
        BasicEffect cubeEffect;

        Cube cube = new Cube(new Vector3(1, 1, 1), Vector3.Zero);
        Vector3 cameraPosition = new Vector3(0, 3, 4);
        Vector3 modelPosition = Vector3.Zero;
        float rotation = 0.0f;
        float aspectRatio = 0.0f;

        public CubrickGame()
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
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cubeTexture = Content.Load<Texture2D>("testTexture");
            aspectRatio = GraphicsDevice.Viewport.AspectRatio;
            cubeEffect = new BasicEffect(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world, checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            rotation += 0.5f;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Set the World matrix which defines the position of the cube
            cubeEffect.World = Matrix.CreateRotationY(MathHelper.ToRadians(rotation)) * Matrix.CreateTranslation(modelPosition);

            // Set the View matrix which defines the camera and what it's looking at
            cubeEffect.View = Matrix.CreateLookAt(cameraPosition, modelPosition, Vector3.Up);

            // Set the Projection matrix which defines how we see the scene (Field of view)
            cubeEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1.0f, 1000.0f);

            // Enable textures on the Cube Effect. this is necessary to texture the model
            cubeEffect.TextureEnabled = true;
            var t = new Texture2D(GraphicsDevice, 1, 1);
            t.SetData(new[] { Color.Red });

            cubeEffect.Texture = t;//cubeTexture;

            // Enable some pretty lights
            cubeEffect.EnableDefaultLighting();

            // apply the effect and render the cube
            foreach (EffectPass pass in cubeEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                cube.RenderToDevice(GraphicsDevice);
            }

            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            base.Draw(gameTime);

        }
    }
}
