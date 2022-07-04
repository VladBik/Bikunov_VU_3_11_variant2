using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var cls = new ClassLibrary1.Class1();
        Debug.Log("test = " + cls.RandomValue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
