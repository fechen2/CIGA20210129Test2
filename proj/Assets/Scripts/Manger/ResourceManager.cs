using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{

    public GameObject InstanceObjByName(string name)
    {
        GameObject prefab = Resources.Load(name) as GameObject;
        return GameObject.Instantiate(prefab);
    }
    public T Load<T>(string filePath) where T : Object
    {
        return Resources.Load<T>(filePath);
    }

    private static ResourceManager instance;
    public ResourceManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ResourceManager();
            }
            return instance;
        }
    }


}
