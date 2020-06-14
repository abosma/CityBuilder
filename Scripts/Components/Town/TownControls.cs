using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Global;
using SFML.Window;

namespace CityBuilder.Scripts.Components.Town
{
    class TownControls : Component
    {
        private Collider _collider;

        public override void Start()
        {
            _collider = Entity.GetComponent<Collider>();

            InputHandler.MouseLeftDown += InputHandler_MouseLeftDown;
            InputHandler.MouseLeftUp += InputHandler_MouseLeftUp;
        }

        private void InputHandler_MouseLeftUp(object sender, EventArgs e)
        {
            if (_collider.IsMouseOver)
            {
                GlobalConsole.WriteLine($"Unclicked on Town: {Entity.Name}");
            }
        }

        private void InputHandler_MouseLeftDown(object sender, EventArgs e)
        {
            if (_collider.IsMouseOver)
            {
                GlobalConsole.WriteLine($"Clicked on Town: {Entity.Name}");
            }
        }

        public override void Update()
        {
            
        }
    }
}
