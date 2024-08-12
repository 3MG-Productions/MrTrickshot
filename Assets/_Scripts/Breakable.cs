using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject intactBody;
    public GameObject rubbleParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            intactBody.SetActive(false);
            rubbleParent.SetActive(true);
        }
    }
}