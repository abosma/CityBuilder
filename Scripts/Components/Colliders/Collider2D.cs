using System;
using System.Collections.Generic;
using CityBuilder.Scripts.Components.Positions;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Entities;

namespace CityBuilder.Scripts.Components.Colliders
{
    class Collider2D : IComponent
    {
        public event Action<Entity> CollidedWithEntity;

        public Entity Entity { get; set; }
        
        public int Width;
        public int Height;

        private Transform _transform;

        private List<Entity> _collisionList = new List<Entity>();

        public Collider2D(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Start()
        {
            _transform = Entity.GetComponent<Transform>();
        }

        public void Update()
        {
            for (var i = 0; i < _collisionList.Count; i++)
            {
                var checkedEntity = _collisionList[i];

                if (IsCollidingWithEntity(checkedEntity))
                {
                    OnCollidedWithEntity(checkedEntity);
                }
            }
        }

        public void AddEntityToCollisionList(Entity entity)
        {
            if (!_collisionList.Contains(entity))
            {
                _collisionList.Add(entity);
            }
        }

        private bool IsCollidingWithEntity(Entity entity)
        {
            try
            {
                var ExternalEntityTransform = entity.GetComponent<Transform>();
                var ExternalEntityCollider = entity.GetComponent<Collider2D>();

                return _transform.Position.X < ExternalEntityTransform.Position.X + ExternalEntityCollider.Width &&
                       _transform.Position.X + Width > ExternalEntityTransform.Position.X &&
                       _transform.Position.Y < ExternalEntityTransform.Position.Y + ExternalEntityCollider.Height &&
                       _transform.Position.Y + Height > ExternalEntityTransform.Position.Y;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        private void OnCollidedWithEntity(Entity obj)
        {
            CollidedWithEntity?.Invoke(obj);
        }
    }
}
