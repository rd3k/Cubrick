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

        public struct RubicksCubeState
        {
            public MoveState action;
            public float amount;
        }

        private Cube[, ,] cubes;
        private int size;
        private int cubeCount;
        private GraphicsDevice graphicsDevice;
        private RubicksCubeState state;

        private const int rotateRate = 10;

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

            Vector3 rotationAxis = new Vector3(0, 0, 0);
            int iAmount = 0, jAmount = 0, kAmount = 0;
            SByte dir = 1;

            switch (state.action)
            {
                case MoveState.FaceTurnAC_1:
                    rotationAxis = new Vector3(0, 1, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.FaceTurnAC_2:
                    rotationAxis = new Vector3(0, 0, 1);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.FaceTurnAC_3:
                    rotationAxis = new Vector3(0, 1, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = -1;
                    break;
                case MoveState.FaceTurnAC_4:
                    rotationAxis = new Vector3(0, 0, 1);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = -1;
                    break;
                case MoveState.FaceTurnAC_5:
                    rotationAxis = new Vector3(1, 0, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.FaceTurnAC_6:
                    rotationAxis = new Vector3(1, 0, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = -1;
                    break;
                case MoveState.FaceTurnCW_1:
                    rotationAxis = new Vector3(0, 1, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = -1;
                    break;
                case MoveState.FaceTurnCW_2:
                    rotationAxis = new Vector3(0, 0, 1);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.FaceTurnCW_3:
                    rotationAxis = new Vector3(0, 1, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.FaceTurnCW_4:
                    rotationAxis = new Vector3(0, 0, 1);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.FaceTurnCW_5:
                    rotationAxis = new Vector3(1, 0, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = -1;
                    break;
                case MoveState.FaceTurnCW_6:
                    rotationAxis = new Vector3(1, 0, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.MidTurnAC_1:
                    rotationAxis = new Vector3(0, 1, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = -1;
                    break;
                case MoveState.MidTurnAC_2:
                    rotationAxis = new Vector3(0, 0, 1);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.MidTurnAC_3:
                    rotationAxis = new Vector3(1, 0, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = -1;
                    break;
                case MoveState.MidTurnCW_1:
                    rotationAxis = new Vector3(0, 1, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
                case MoveState.MidTurnCW_2:
                    rotationAxis = new Vector3(0, 0, 1);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = -1;
                    break;
                case MoveState.MidTurnCW_3:
                    rotationAxis = new Vector3(1, 0, 0);
                    iAmount = 0; jAmount = 0; kAmount = 0;
                    dir = 1;
                    break;
            }

            for (int i = 0; i < iAmount; i++)
            {
                for (int j = 0; j < jAmount; j++)
                {
                    for (int k = 0; k < kAmount; k++)
                    {
                        GetCube(i, j, k).Position = Vector3.Transform(
                            value: GetCube(i, j, k).Position,
                            rotation: Quaternion.CreateFromAxisAngle(
                                axis: rotationAxis,
                                angle: MathHelper.ToRadians(dir * 9)
                            )
                        );
                    }
                }
            }

            if (state.amount >= 1.0f)
            {
                state.action = MoveState.None;
                state.action = 0.0f;
            }
            else
            {
                state.amount += 0.1f;
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

        public RubicksCubeState State
        {
            get { return state; }
            set { state.action = value.action; state.amount = 0.0f; }
        }

    }
}