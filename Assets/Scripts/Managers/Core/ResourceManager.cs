using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");

        if (original == null)
        {
            Debug.Log($"Failed to Load Prefab : {path}");
            return null;
        }

        if (original.GetComponent<Poolable>() != null) // 없다면 무시하고 원래대로 돌아가면 될것이다.
            return Managers.Pool.Pop(original, parent).gameObject;


        GameObject go = UnityEngine.Object.Instantiate(original, parent);

        go.name = original.name;
        return go;
    }

    public ParticleSystem InstantiateParticle(string path, Transform parent = null)
    {
        ParticleSystem original = Load<ParticleSystem>($"Prefabs/{path}");

        if (original == null)
        {
            Debug.Log($"Failed to Load Prefab Particle : {path}");
            return null;
        }

        ParticleSystem go = UnityEngine.Object.Instantiate(original, parent);

        go.name = original.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
}
