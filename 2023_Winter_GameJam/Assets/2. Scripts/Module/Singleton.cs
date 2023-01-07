using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _Instance;

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType<T>();

                if (_Instance == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    _Instance = singleton.AddComponent<T>();
                }
            }
            return _Instance;
        }
    }

    public virtual void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
