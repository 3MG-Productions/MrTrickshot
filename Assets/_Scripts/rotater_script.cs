using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater_script : MonoBehaviour
{
    public float rotateSpeed_float;
    public GameObject load_gm;
    
    void Update()
    {
        gameObject.transform.Rotate(0, 0, rotateSpeed_float * Time.deltaTime);
    }
}
