using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;

namespace Cubrick
{
    class Cube
    {

        public Vector3 Size { get; set; }
        public Vector3 Position { get; set; }
        private VertexPositionNormalTexture[] vertices;
        public Texture2D[] FaceTextures = new Texture2D[3];

        public Cube (Vector3 size, Vector3 position)
        {
            Size = size;
            Position = position;
            create();
        }

        private void create ()
        {
            vertices = new VertexPositionNormalTexture[36];
            Vector3 topLeftFront = Position + new Vector3(-1.0f, 1.0f, -1.0f) * Size;
            Vector3 topLeftBack = Position + new Vector3(-1.0f, 1.0f, 1.0f) * Size;
            Vector3 topRightFront = Position + new Vector3(1.0f, 1.0f, -1.0f) * Size;
            Vector3 topRightBack = Position + new Vector3(1.0f, 1.0f, 1.0f) * Size;
            Vector3 bottomLeftFront = Position + new Vector3(-1.0f, -1.0f, -1.0f) * Size;
            Vector3 bottomLeftBack = Position + new Vector3(-1.0f, -1.0f, 1.0f) * Size;
            Vector3 bottomRightFront = Position + new Vector3(1.0f, -1.0f, -1.0f) * Size;
            Vector3 bottomRightBack = Position + new Vector3(1.0f, -1.0f, 1.0f) * Size;

            Vector2 textureTopLeft = new Vector2(1.0f * Size.X, 0.0f * Size.Y);
            Vector2 textureTopRight = new Vector2(0.0f * Size.X, 0.0f * Size.Y);
            Vector2 textureBottomLeft = new Vector2(1.0f * Size.X, 1.0f * Size.Y);
            Vector2 textureBottomRight = new Vector2(0.0f * Size.X, 1.0f * Size.Y);

            Vector3 normalFront = new Vector3(0.0f, 0.0f, 1.0f) * Size;
            Vector3 normalBack = new Vector3(0.0f, 0.0f, -1.0f) * Size;
            Vector3 normalTop = new Vector3(0.0f, 1.0f, 0.0f) * Size;
            Vector3 normalBottom = new Vector3(0.0f, -1.0f, 0.0f) * Size;
            Vector3 normalLeft = new Vector3(-1.0f, 0.0f, 0.0f) * Size;
            Vector3 normalRight = new Vector3(1.0f, 0.0f, 0.0f) * Size;

            vertices[0] = new VertexPositionNormalTexture(topLeftFront, normalFront, textureTopLeft);
            vertices[1] = new VertexPositionNormalTexture(bottomLeftFront, normalFront, textureBottomLeft);
            vertices[2] = new VertexPositionNormalTexture(topRightFront, normalFront, textureTopRight);
            vertices[3] = new VertexPositionNormalTexture(bottomLeftFront, normalFront, textureBottomLeft);
            vertices[4] = new VertexPositionNormalTexture(bottomRightFront, normalFront, textureBottomRight);
            vertices[5] = new VertexPositionNormalTexture(topRightFront, normalFront, textureTopRight);
            vertices[6] = new VertexPositionNormalTexture(topLeftBack, normalBack, textureTopRight);
            vertices[7] = new VertexPositionNormalTexture(topRightBack, normalBack, textureTopLeft);
            vertices[8] = new VertexPositionNormalTexture(bottomLeftBack, normalBack, textureBottomRight);
            vertices[9] = new VertexPositionNormalTexture(bottomLeftBack, normalBack, textureBottomRight);
            vertices[10] = new VertexPositionNormalTexture(topRightBack, normalBack, textureTopLeft);
            vertices[11] = new VertexPositionNormalTexture(bottomRightBack, normalBack, textureBottomLeft);
            vertices[12] = new VertexPositionNormalTexture(topLeftFront, normalTop, textureBottomLeft);
            vertices[13] = new VertexPositionNormalTexture(topRightBack, normalTop, textureTopRight);
            vertices[14] = new VertexPositionNormalTexture(topLeftBack, normalTop, textureTopLeft);
            vertices[15] = new VertexPositionNormalTexture(topLeftFront, normalTop, textureBottomLeft);
            vertices[16] = new VertexPositionNormalTexture(topRightFront, normalTop, textureBottomRight);
            vertices[17] = new VertexPositionNormalTexture(topRightBack, normalTop, textureTopRight);
            vertices[18] = new VertexPositionNormalTexture(bottomLeftFront, normalBottom, textureTopLeft);
            vertices[19] = new VertexPositionNormalTexture(bottomLeftBack, normalBottom, textureBottomLeft);
            vertices[20] = new VertexPositionNormalTexture(bottomRightBack, normalBottom, textureBottomRight);
            vertices[21] = new VertexPositionNormalTexture(bottomLeftFront, normalBottom, textureTopLeft);
            vertices[22] = new VertexPositionNormalTexture(bottomRightBack, normalBottom, textureBottomRight);
            vertices[23] = new VertexPositionNormalTexture(bottomRightFront, normalBottom, textureTopRight);
            vertices[24] = new VertexPositionNormalTexture(topLeftFront, normalLeft, textureTopRight);
            vertices[25] = new VertexPositionNormalTexture(bottomLeftBack, normalLeft, textureBottomLeft);
            vertices[26] = new VertexPositionNormalTexture(bottomLeftFront, normalLeft, textureBottomRight);
            vertices[27] = new VertexPositionNormalTexture(topLeftBack, normalLeft, textureTopLeft);
            vertices[28] = new VertexPositionNormalTexture(bottomLeftBack, normalLeft, textureBottomLeft);
            vertices[29] = new VertexPositionNormalTexture(topLeftFront, normalLeft, textureTopRight);
            vertices[30] = new VertexPositionNormalTexture(topRightFront, normalRight, textureTopLeft);
            vertices[31] = new VertexPositionNormalTexture(bottomRightFront, normalRight, textureBottomLeft);
            vertices[32] = new VertexPositionNormalTexture(bottomRightBack, normalRight, textureBottomRight);
            vertices[33] = new VertexPositionNormalTexture(topRightBack, normalRight, textureTopRight);
            vertices[34] = new VertexPositionNormalTexture(topRightFront, normalRight, textureTopLeft);
            vertices[35] = new VertexPositionNormalTexture(bottomRightBack, normalRight, textureBottomRight);
        }

        public void RenderToDevice(GraphicsDevice device)
        {
            VertexBuffer buffer = new VertexBuffer(device, VertexPositionNormalTexture.VertexDeclaration, 36, BufferUsage.WriteOnly);
            buffer.SetData(vertices);
            device.SetVertexBuffer(buffer);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 12);
        } 

    }
}