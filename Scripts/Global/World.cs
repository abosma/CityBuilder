using System.Collections.Generic;
using CityBuilder.Scripts.Entities;

namespace CityBuilder.Scripts.Global
{
    public static class World
    {
        private static List<Entity> _entityList = new List<Entity>();

        public static void UpdateEntities()
        {
            for (var i = 0; i < _entityList.Count; i++)
            {
                if (_entityList[i].IsActive)
                {
                    _entityList[i].Update();
                }
            }
        }

        public static void AddEntity(Entity entity)
        {
            if (!_entityList.Contains(entity))
            {
                entity.EntityId = _entityList.Count + 1;
                entity.IsActive = true;

                _entityList.Add(entity);
            }
        }

        public static void RemoveEntity(Entity entity)
        {
            if (_entityList.Contains(entity))
            {
                _entityList.Remove(entity);
            }
        }

        public static void RemoveEntity(int entityId)
        {
            for (var i = 0; i < _entityList.Count; i++)
            {
                if (_entityList[i].EntityId == entityId)
                {
                    _entityList.RemoveAt(i);
                }
            }
        }

        public static List<Entity> GetEntities()
        {
            return _entityList;
        }
    }
}
