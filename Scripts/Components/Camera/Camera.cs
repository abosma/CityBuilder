using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Global;
using SFML.Graphics;
using SFML.System;

namespace CityBuilder.Scripts.Components.Camera
{
    class Camera : Component
    {
        private View _cameraView;

        public Camera(View cameraView)
        {
            _cameraView = cameraView;
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            _cameraView.Center = Entity.Transform.Position;

            WindowHandler.GetWindow().SetView(_cameraView);
        }

        public void SetSize(float viewWidth, float viewHeight)
        {
            _cameraView.Size = new Vector2f(viewWidth, viewHeight);
        }

        public void SetSize(Vector2f viewSize)
        {
            _cameraView.Size = viewSize;
        }
    }
}
