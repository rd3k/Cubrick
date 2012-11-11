using Microsoft.Xna.Framework;

namespace Cubrick
{
    public class Camera
    {

        private Matrix matrix;
        private Vector3 position = Vector3.Zero;
        private Vector3 target = Vector3.UnitY;
        private Vector3 rotation = Vector3.Zero;
        private float yaw = 0.0f;
        private float pitch = 0.0f;
        private float roll = 0.0f;
        private float zoom = 0.0f;

        public Camera()
        {
            Update();
        }

        public static implicit operator Matrix (Camera cam)
        {
            return cam.matrix;
        }

        public Matrix getMatrix()
        {
            return matrix;
        }

        public Camera(Vector3 position)
        {
            Update();
        }

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector3 Target
        {
            get { return target; }
            set { target = value; }
        }

        public float Yaw
        {
	        get { return yaw; }
	        set { yaw = value; }
        }

        public float Pitch
        {
	        get { return pitch; }
	        set { pitch = value; }
        }

        public float Roll
        {
	        get { return roll; }
	        set { roll = value; }
        }

        public float Zoom
        {
            get { return zoom; }
            set { zoom = MathHelper.Clamp(value, 0.0f, 1.0f); }
        }

        public void Update()
        {
            matrix = Matrix.CreateLookAt(position + ((target - position) * zoom), target, Vector3.Up) *
                     Matrix.CreateRotationX(MathHelper.ToRadians(rotation.X)) *
                     Matrix.CreateRotationY(MathHelper.ToRadians(rotation.Y)) *
                     Matrix.CreateRotationZ(MathHelper.ToRadians(rotation.Z)) *
                     Matrix.CreateFromYawPitchRoll(yaw, pitch, roll);
        }
    
    }
}