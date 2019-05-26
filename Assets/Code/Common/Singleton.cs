using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    protected Singleton<T> instance;

    protected void Awake()
    {
        if(instance)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }
}
