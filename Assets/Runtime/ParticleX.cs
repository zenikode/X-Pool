using System.Threading.Tasks;
using UnityEngine;

namespace XPool.Runtime
{
    public static class ParticleX
    {
        public static async void PlayOneShot(this ParticleSystem prefab, Vector3 position)
        {
            var pool = PrefabPool<ParticleSystem>.Instance(prefab);
            var result = pool.Spawn();
            result.transform.position = position;
            result.Play();
            await Awaitable.WaitForSecondsAsync(prefab.main.duration);
            pool.Remove(result);
        }

        public static async Task PlayOneShot(this ParticleSystem prefab, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            var pool = PrefabPool<ParticleSystem>.Instance(prefab);
            var result = pool.Spawn();
            var tf = result.transform;
            tf.position = position;
            tf.rotation = rotation;
            tf.localScale = scale;
            result.Play();
            await Awaitable.WaitForSecondsAsync(prefab.main.duration);
            pool.Remove(result);
        }
    }
}