using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    // Start is called before the first frame update
    public bool destroyonLoad;
    private static T instance;
    protected static bool _destroyOnLoad;
    public static T Instance{
        get{
            T findObj=FindObjectOfType<T>();
            if(instance==null)
            instance=findObj;
            else if(instance!=findObj)
            Destroy(findObj);
            if(!_destroyOnLoad) DontDestroyOnLoad(findObj);
            return instance;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
