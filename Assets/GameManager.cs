using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private void Awake()
    {
        if(_instance)
        {
            DestroyImmediate(this);
        } else {
            _instance = this;
        }
    }

    public KeyValuePair<string,V> GetValuePair<V>()
    {
        KeyValuePair<string, V> result = default(KeyValuePair<string, V>);

        return result;
    }
}
