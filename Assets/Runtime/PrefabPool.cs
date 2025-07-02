using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace XPool.Runtime
{
    internal class PrefabPool<T> where T: Component
    {
        private readonly T _prototype;
        private readonly Stack<T> _pool = new();

        private GameObject _holder;
        private void CheckHolder()
        {
            if (_holder) return;
            _holder = new GameObject($"PrefabPool<{_prototype.name}>");
            _pool.Clear();
        }

        private static readonly Dictionary<T, PrefabPool<T>> Pools = new();

        private PrefabPool(T prefab) => _prototype = prefab;

        internal static PrefabPool<T> Instance(T prefab)
        {
            if (Pools.TryGetValue(prefab, out var pool)) return pool;
            var result = new PrefabPool<T>(prefab);
            Pools[prefab] = result;
            return result;
        }
        
        internal T Spawn()
        {
            CheckHolder();
            if (_pool.Count < 1) 
                return Object.Instantiate(_prototype, _holder.transform);
            var result = _pool.Pop();
            result.gameObject.SetActive(true);
            return result;
        }

        internal void Remove(T item)
        {
            if (!item) return; 
            
            if (item.transform.parent != _holder.transform) 
                throw new Exception("Couldn't remove reparented objects");
            
            CheckHolder();
            item.gameObject.SetActive(false);
            _pool.Push(item);
        }
    }
}