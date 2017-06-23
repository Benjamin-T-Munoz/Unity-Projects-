using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// Used to rout destroy and instantiate calls throught. Helps recycle prefabs
public class GameObjectUtil {


    private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();


    public static GameObject Instantiate(GameObject prefab,Vector3 pos)
    {
        GameObject instance = null;

        var recycledScript = prefab.GetComponent<RecycleGameObject>();

        if(recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject(pos).gameObject;
        }

        else
        {
        instance = GameObject.Instantiate(prefab);
        instance.transform.position = pos;

        
        }

        return instance;

    }

    public static void Destroy(GameObject gameObject)
    {

        var recyleGameObject = gameObject.GetComponent<RecycleGameObject>();

        if(recyleGameObject != null)
        {
            recyleGameObject.Shutdown();
        }

        else
        {
            GameObject.Destroy(gameObject);
        }
        
    }

    private static ObjectPool GetObjectPool(RecycleGameObject refrence)
    {
        ObjectPool pool = null; 
        if(pools.ContainsKey(refrence))
        {

            pool = pools[refrence];
        }
        else
        {
            var poolContainer = new GameObject(refrence.gameObject.name + "ObjectPool");
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefab = refrence;
            pools.Add(refrence, pool);
        }

        return pool;
    }

}
