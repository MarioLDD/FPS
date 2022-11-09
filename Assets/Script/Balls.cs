using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public float TimeD = 3f;
    void Start()
    {
        Invoke("Destroy", TimeD);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Destroy()
    {
        Destroy(gameObject);
    }
}
