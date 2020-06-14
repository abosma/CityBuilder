using System;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Entities;
using CityBuilder.Scripts.Global;
using Transform = CityBuilder.Scripts.Components.Positions.Transform;

namespace CityBuilder.Scripts.Components.Colliders
{
    public class Collider : Component
    {
        #region Variables
        public float Width;
        public float Height;

        public event Action<Entity> CollidedWithEntity;

        public event EventHandler MouseEnter;
        public event EventHandler MouseOver;
        public event EventHandler MouseExit;

        public bool IsMouseOver;
        #endregion

        #region Initialization
        public Collider(float width, float height)
        {
            WorldCollision.AddCollider(this);

            Width = width;
            Height = height;
        }
        #endregion

        #region Overrides
        public override void Start()
        {

        }

        public override void Update()
        {

        }
        #endregion

        #region Entity Collision
        public void CheckCollision(Collider collider)
        {
            if (IsCollidingWithEntity(collider.Entity))
            {
                OnCollidedWithEntity(collider.Entity);
            }
        }

        private bool IsCollidingWithEntity(Entity entity)
        {
            var Transform = Entity.Transform;

            try
            {
                var ExternalEntityTransform = entity.GetComponent<Transform>();
                var ExternalEntityCollider = entity.GetComponent<Collider>();

                return Transform.Position.X < ExternalEntityTransform.Position.X + ExternalEntityCollider.Width &&
                       Transform.Position.X + Width > ExternalEntityTransform.Position.X &&
                       Transform.Position.Y < ExternalEntityTransform.Position.Y + ExternalEntityCollider.Height &&
                       Transform.Position.Y + Height > ExternalEntityTransform.Position.Y;
            }
            catch (Exception e)
            {
                GlobalConsole.WriteLine(e.Message);
            }

            return false;
        }

        private void OnCollidedWithEntity(Entity obj)
        {
            CollidedWithEntity?.Invoke(obj);
        }
        #endregion

        #region Mouse Collision
        public void CheckCollisionWithMouse()
        {
            if (!IsMouseOver)
            {
                if (!IsCollidingWithMouse())
                {
                    return;
                }

                IsMouseOver = true;
                OnMouseEnter();
            }
            else
            {
                if (IsCollidingWithMouse())
                {
                    OnMouseOver();
                }
                else
                {
                    IsMouseOver = false;
                    OnMouseExit();
                }
            }
        }

        private bool IsCollidingWithMouse()
        {
            var MousePosition = WindowHandler.GetMousePositionRelativeToWindow();
            var Position = Entity.Transform.Position;

            return MousePosition.X > Position.X &&
                   MousePosition.X < Position.X + Width &&
                   MousePosition.Y > Position.Y &&
                   MousePosition.Y < Position.Y + Height;
        }

        private void OnMouseEnter()
        {
            MouseEnter?.Invoke(this, EventArgs.Empty);
        }

        private void OnMouseOver()
        {
            MouseOver?.Invoke(this, EventArgs.Empty);
        }

        private void OnMouseExit()
        {
            MouseExit?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
