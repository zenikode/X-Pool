using UnityEngine;

namespace XPool.Runtime
{
    public static class PoolingX
    {
        public static T SpawnPoolable<T>(this T prefab) where T : Component
        {
            var pool = PrefabPool<T>.Instance(prefab);
            return pool.Spawn();
        }

        public static void RemovePoolable<T>(this T prefab, T poolable) where T : Component
        {
            var pool = PrefabPool<T>.Instance(prefab);
            pool.Remove(poolable);
        }
    }
}