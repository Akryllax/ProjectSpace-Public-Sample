using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static SingletonBehaviour<T> _instance;

    public static SingletonBehaviour<T> GetInstance()
    {
        if(!_instance)
        {
            var go = new GameObject();
            _instance = go.AddComponent<SingletonBehaviour<T>>();
        }

        return _instance;
    }

    private void Awake()
    {
        if (_instance)
        {
            Destroy(this);
        }

        _instance = this;
    }
}