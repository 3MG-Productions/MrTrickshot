using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fanButton_script : MonoBehaviour
{
    public GameObject[] fansAttached_ar;
    public GameObject[] delaybounceWalls_ar;
    public GameObject[] particleFan;
    public bool fanWireAttached_bool;
    public float fanRotateSpeed_float;

    private void Update()
    {
        if(fanWireAttached_bool)
        {
            for(int i=0; i<=fansAttached_ar.Length-1; i++)
            {
                fansAttached_ar[i].gameObject.transform.Rotate(0, 0, fanRotateSpeed_float * Time.deltaTime);
            }

        }
    }


    public void OnAllFans_func()
    {
        fanWireAttached_bool = true;
        toggleFanParticle(fanWireAttached_bool);
        ////for (int i = 0; i <= fansAttached_ar.Length - 1; i++)
        ////{ 
        ////    gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.green, 0.2f);
        ////
        ////    for (int j = 0; j <= fansAttached_ar[i].transform.childCount - 1; j++)
        ////    {
        ////        fansAttached_ar[i].gameObject.transform.GetChild(j).GetComponent<MeshRenderer>().material.DOColor(Color.green, 0.2f);
        ////    }
        ////}   
        for (int i = 0; i <= delaybounceWalls_ar.Length - 1; i++)
        {
            delaybounceWalls_ar[i].SetActive(true);
        }
    }

    public void OffAllFans_func()
    {
        fanWireAttached_bool = false;
        toggleFanParticle(fanWireAttached_bool);
        ////for (int i = 0; i <= fansAttached_ar.Length - 1; i++)
        ////{
        ////    gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.2f);
        ////
        ////    for (int j = 0; j <= fansAttached_ar[i].transform.childCount - 1; j++)
        ////    {
        ////        fansAttached_ar[i].gameObject.transform.GetChild(j).GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.2f);
        ////    }
        ////}
        for (int i = 0; i <= delaybounceWalls_ar.Length - 1; i++)
        {
            delaybounceWalls_ar[i].SetActive(false);
        }
    }

    private void toggleFanParticle (bool active)
    {
        for(int i=0; i<=particleFan.Length-1; i++)
        {
            particleFan[i].SetActive(active);
        }
    }
}
