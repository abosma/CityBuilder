using CityBuilder.Scripts.Entities;
using CityBuilder.Scripts.Handlers;
using SFML.Window;

namespace CityBuilder.Scripts.Components
{
    class InputComponent : IComponent
    {
        public Entity Entity { get; set; }

        public void Start()
        {
            WindowHandler.GetWindow().KeyReleased += InputComponent_KeyReleased;
        }

        private void InputComponent_KeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Space)
            {

            }
        }

        public void Update()
        {
            
        }
    }
}
