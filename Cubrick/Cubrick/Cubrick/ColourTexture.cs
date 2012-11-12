using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Cubrick
{
    public class ColourTexture
    {

        private Texture2D texture;
        private Color textureColour;
        private Random r = new Random();

        public ColourTexture(GraphicsDevice device, Color colour)
        {
            this.texture = new Texture2D(device, 1, 1);
            this.Colour = colour;
        }

        public static implicit operator Texture2D(ColourTexture colourTexture)
        {
            return colourTexture.texture;
        }

        public Color Colour
        {
            get { return textureColour; }
            set { textureColour = value; texture.SetData(new[] { value }); }
        }

        public Texture2D Randomise()
        {
            this.Colour = new Color((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255));
            return this;
        }   

    }
}