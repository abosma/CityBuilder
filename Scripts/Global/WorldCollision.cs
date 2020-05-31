using System.Collections.Generic;
using CityBuilder.Scripts.Components.Colliders;

namespace CityBuilder.Scripts.Global
{
    public static class WorldCollision
    {
        private static List<Collider> _colliderList = new List<Collider>();

        public static void CheckCollision()
        {
            for (int i = 0, j = 1; i < _colliderList.Count; i++, j++)
            {
                if (!_colliderList[i].Entity.IsActive)
                {
                    return;
                }

                if (j < _colliderList.Count && i != j)
                {
                    _colliderList[i].CheckCollision(_colliderList[j]);
                }

                _colliderList[i].CheckCollisionWithMouse();
            }
        }

        public static void AddCollider(Collider collider)
        {
            if (!_colliderList.Contains(collider))
            {
                _colliderList.Add(collider);
            }
        }

        public static void RemoveCollider(Collider collider)
        {
            if (_colliderList.Contains(collider))
            {
                _colliderList.Remove(collider);
            }
        }
    }
}
