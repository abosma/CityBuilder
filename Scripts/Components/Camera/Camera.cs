using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Global;
using SFML.Graphics;
using SFML.System;

namespace CityBuilder.Scripts.Components.Camera
{
    class Camera : Component
    {
        public View CameraView;

        public Camera(View cameraView)
        {
            CameraView = cameraView;
        }

        public override void Start()
        {
            WindowHandler.GetWindow().Resized += Camera_Resized;
        }

        private void Camera_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            CameraView.Size = new Vector2f(e.Width, e.Height);
        }

        public override void Update()
        {
            CameraView.Center = Entity.Transform.Position;

            WindowHandler.GetWindow().SetView(CameraView);
        }

        public void SetSize(float viewWidth, float viewHeight)
        {
            CameraView.Size = new Vector2f(viewWidth, viewHeight);
        }

        public void SetSize(Vector2f viewSize)
        {
            CameraView.Size = viewSize;
        }

        public Vector2f GetSize()
        {
            return CameraView.Size;
        }
    }
}
