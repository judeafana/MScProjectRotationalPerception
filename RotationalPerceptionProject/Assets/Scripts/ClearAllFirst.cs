using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAllFirst


{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {

        PlayerPrefs.DeleteAll();

        Caching.ClearCache();


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
