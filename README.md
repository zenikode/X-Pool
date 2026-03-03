# X-Pool - Extension-Based Pooling for Unity
<img src="https://img.shields.io/badge/Unity-2021.3+-blue.svg" alt="Unity Version"> <img src="https://img.shields.io/badge/License-MIT-green.svg" alt="License">
## 🚀 Overview

X-Pool is a minimalistic object pooling solution that works entirely through extension methods. Just add it to your project and start pooling with your existing prefabs - no setup required.

```csharp
// Spawn an object
var bullet = bulletPrefab.SpawnPoolable();

// Return it later  
bulletPrefab.RemovePoolable(bullet);
```
## ✨ Features

✔ Zero-configuration - Works out of the box

✔ Component-based - Pools any MonoBehaviour

✔ Clean API - Just two main extension methods

✔ Auto-cleanup - Manages hierarchy for you

✔ ParticleSystem support - Built-in one-shot effects

## 📦 Installation

Via Git URL: Add this to your Unity project's Packages/manifest.json:

```json
"com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask", //if not referenced 
"com.zeni.x-pool": "https://github.com/zenikode/X-Pool.git?path=Assets",
```

## ⚙️ API Reference

```csharp
T SpawnPoolable<T>(this T prefab)	//Gets an instance from pool
void RemovePoolable<T>(this T prefab, T instance)	//Returns instance to pool
void PlayOneShot(this ParticleSystem prefab, Vector3 position)	//Plays and auto-recycles VFX
Task PlayOneShot(this ParticleSystem prefab, Vector3 pos, Quaternion rot, Vector3 scale)	//Advanced VFX with await
```

## 🛠️ Basic Usage

Spawning Objects

```csharp
public class Spawner : MonoBehaviour 
{
    public Enemy enemyPrefab;
    
    void Start() 
    {
        var enemy = enemyPrefab.SpawnPoolable();
        enemy.transform.position = spawnPoint.position;
    }
}
```
Returning Objects

```csharp
public class Enemy : MonoBehaviour 
{
    public Enemy enemyPrefab;
    
    void OnDefeated() 
    {
        enemyPrefab.RemovePoolable(this);
    }
}
```
Particle Effects

```csharp
public class Explosion : MonoBehaviour 
{
    public ParticleSystem explosionVFX;
    
    void OnDestroy() 
    {
        explosionVFX.PlayOneShot(transform.position);
    }
}
```
## 💡 Tips

1. Keep prefab references for returning objects
2. Use PlayOneShot for temporary effects
3. Objects must remain in their original hierarchy

## 📜 License

MIT - Free to use in any project
