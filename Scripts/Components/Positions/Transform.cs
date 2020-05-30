using System;
using CityBuilder.Scripts.Entities;
using SFML.System;
using GameTime = CityBuilder.Scripts.Game.GameTime;

namespace CityBuilder.Scripts.Components.Positions
{
    class Transform : IComponent
    {
        public event EventHandler ReachedPosition;

        public Entity Entity { get; set; }
        public Vector2f Position;

        private bool _isMoving;
        private Vector2f _newPosition;
        private float _moveSpeed;

        public Transform(int x, int y)
        {
            Position = new Vector2f(x, y);
        }

        public void Start()
        {
            _newPosition = Position;
        }

        public void Update()
        {
            if (_isMoving)
            {
                Position = Lerp(Position, _newPosition, _moveSpeed * GameTime.deltaTime);

                if (IsSamePosition(Position, _newPosition))
                {
                    _isMoving = false;
                    OnReachedPosition();
                }
            }
        }

        public Vector2f GetPosition()
        {
            return Position;
        }

        public void SetPosition(Vector2f newPosition)
        {
            Position = newPosition;
        }

        public void SetPosition(float x, float y)
        {
            Position = new Vector2f(x, y);
        }

        public void Translate(Vector2f newPosition, float moveSpeed)
        {
            _newPosition = newPosition;
            _isMoving = true;
            _moveSpeed = moveSpeed;
        }

        public void Translate(float x, float y, float moveSpeed)
        {
            _newPosition = new Vector2f(x, y);
            _isMoving = true;
            _moveSpeed = moveSpeed;
        }

        private Vector2f Lerp(Vector2f firstPosition, Vector2f secondPosition, float by)
        {
            var ToReturnX = Lerp(firstPosition.X, secondPosition.X, by);
            var ToReturnY = Lerp(firstPosition.Y, secondPosition.Y, by);

            return new Vector2f(ToReturnX, ToReturnY);
        }

        private float Lerp(float firstPosition, float secondPosition, float by)
        {
            return firstPosition + (secondPosition - firstPosition) * by;
        }

        protected virtual void OnReachedPosition()
        {
            ReachedPosition?.Invoke(this, EventArgs.Empty);
        }

        private bool IsSamePosition(Vector2f firstPosition, Vector2f secondPosition)
        {
            var FirstPosX = (int)Math.Round(firstPosition.X);
            var FirstPosY = (int)Math.Round(firstPosition.Y);
            var SecondPosX = (int)Math.Round(secondPosition.X);
            var SecondPosY = (int)Math.Round(secondPosition.Y);

            return FirstPosX == SecondPosX && FirstPosY == SecondPosY;
        }
    }
}
