using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    public RecycleGameObject prefab; // specific instance of a prefab type;

    private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();

    private RecycleGameObject CreateInstance(Vector3 pos)
    {
        var clone = GameObject.Instantiate(prefab);// new intance
        clone.transform.position = pos;// position of the clone
        clone.transform.parent = transform;// nests clone into objectpool game object;


        poolInstances.Add(clone);

        return clone;
    }

    public RecycleGameObject NextObject(Vector3 pos)// returns a recycled game object from the pool;
    {
        RecycleGameObject instance = null;


        foreach(var go in poolInstances)
        {
            if(go.gameObject.activeSelf != true)
            {
                instance = go;
                instance.transform.position = pos;
            }
        }

        if (instance == null)
        {
            instance = CreateInstance(pos);
        }
        
        instance.Restart();

        return instance;
    }


}
