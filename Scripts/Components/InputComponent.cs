using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Entities;
using CityBuilder.Scripts.Global;
using SFML.Window;

namespace CityBuilder.Scripts.Components
{
    class InputComponent : Component
    {
        public Entity Entity { get; set; }

        public override void Start()
        {
            WindowHandler.GetWindow().KeyReleased += InputComponent_KeyReleased;
        }

        public override void Update()
        {
            
        }

        private void InputComponent_KeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Space)
            {

            }
        }
    }
}
