using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cubrick
{

    public class RubicksCube
    {

        private Cube[, ,] cubes;
        private int size;
        private int cubeCount;
        private Boolean inMotion = false;

        public RubicksCube(int size, GraphicsDevice device)
        {
            cubeCount = size * size * size;
            cubes = new Cube[size, size, size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    for(int k = 0; k < size; k++)
                    {
                        cubes[i, j, k] = new Cube(
                            size: new Vector3(0.2f, 0.2f, 0.2f),
                            position: new Vector3(i, j, k),
                            device: device
                        );
                    }
                }
            }
        }

        public Cube GetCube(int x, int y, int z)
        {
            return cubes[x, y, z];
        }

        public void RenderToDevice(GraphicsDevice device, Camera camera)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        cubes[i, j, k].RenderToDevice(device, camera);
                    }
                }
            }
        }

        public int Size
        {
            get { return size; }
        }

        public int CubeCount
        {
            get { return cubeCount; }
        }

    }
}
