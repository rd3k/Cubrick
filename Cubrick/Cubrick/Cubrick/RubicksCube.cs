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

        public enum MoveState
        {
            None,
            FaceTurnCW_1, FaceTurnCW_2, FaceTurnCW_3, FaceTurnCW_4, FaceTurnCW_5, FaceTurnCW_6,
            FaceTurnAC_1, FaceTurnAC_2, FaceTurnAC_3, FaceTurnAC_4, FaceTurnAC_5, FaceTurnAC_6,
            MidTurnCW_1, MidTurnCW_2, MidTurnCW_3,
            MidTurnAC_1, MidTurnAC_2, MidTurnAC_3
        }

        private struct State
        {
            public MoveState action = MoveState.None;
            public int amount = 0;
        }

        private Cube[, ,] cubes;
        private int size;
        private int cubeCount;
        private GraphicsDevice graphicsDevice;
        private State state;
        private int moveAmount;

        public RubicksCube(int size, GraphicsDevice device)
        {
			this.size = size;
            this.graphicsDevice = device;
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
							position: new Vector3(0.201f * i, 0.201f * j, 0.201f * k),
                            device: device
                        );
                    }
                }
            }
        }

        private void Update()
        {

            if (state.action == MoveState.None) return;

            switch (state.action)
            {
                case MoveState.FaceTurnAC_1:
                    // something == another * state.amount
                    break;
                case MoveState.FaceTurnAC_2: break;
                case MoveState.FaceTurnAC_3: break;
                case MoveState.FaceTurnAC_4: break;
                case MoveState.FaceTurnAC_5: break;
                case MoveState.FaceTurnAC_6: break;
                case MoveState.FaceTurnCW_1: break;
                case MoveState.FaceTurnCW_2: break;
                case MoveState.FaceTurnCW_3: break;
                case MoveState.FaceTurnCW_4: break;
                case MoveState.FaceTurnCW_5: break;
                case MoveState.FaceTurnCW_6: break;
                case MoveState.MidTurnAC_1: break;
                case MoveState.MidTurnAC_2: break;
                case MoveState.MidTurnAC_3: break;
                case MoveState.MidTurnCW_1: break;
                case MoveState.MidTurnCW_2: break;
                case MoveState.MidTurnCW_3: break;
            }

        }

        public Cube GetCube(int x, int y, int z)
        {
            return cubes[x, y, z];
        }

        public void RenderToDevice(Camera camera)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        cubes[i, j, k].RenderToDevice(this.graphicsDevice, camera);
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

        public State State
        {
            get { return state; }
            set { state.action = value.action; state.amount = 0; }
        }

    }
}
