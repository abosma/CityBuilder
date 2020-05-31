using System;
using System.Collections.Generic;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Positions;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Entities;

namespace CityBuilder.Scripts.Components.Colliders
{
    class Collider2D : Collider
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public event Action<Entity> CollidedWithEntity;

        private Transform _transform;

        public Collider2D(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override void Start()
        {
            _transform = Entity.GetComponent<Transform>();
        }

        public override void Update()
        {

        }

        public override bool IsCollidingWithEntity(Entity entity)
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

        public override void OnCollidedWithEntity(Entity obj)
        {
            CollidedWithEntity?.Invoke(obj);
        }
    }
}
