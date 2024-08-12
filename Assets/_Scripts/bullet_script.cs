using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class bullet_script : MonoBehaviour
{
    public float bulletMoveSpeed_float;

    void Update()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * bulletMoveSpeed_float, Space.World);
        transform.Translate(Time.deltaTime * bulletMoveSpeed_float, 0, 0);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "normal")
        {
            Destroy(gameObject);
            //GameManager.ins.InstantiateBullet_func();
        }
        else if (coll.tag == "bounce")
        {
            transform.DORotate(new Vector3(0, 0, coll.gameObject.GetComponent<turnBulletAngle_script>().bulletTurningAngle_float), 0);
        }
        else if (coll.tag == "delaybounce")
        {
            transform.DORotate(new Vector3(0, 0, coll.gameObject.GetComponent<turnBulletAngle_script>().bulletTurningAngle_float), 0.4f);
        }

        if (coll.tag == "player" || coll.tag == "hostage")
        {
            coll.gameObject.GetComponent<Animator>().enabled = false;
            coll.gameObject.GetComponent<Ragdoll_script>().OnRagdoll_func();
            Destroy(gameObject);
            GameManager.ins.GameoverLose_func();
        }
        else if (coll.tag == "enemy")
        {
            coll.gameObject.GetComponent<Animator>().enabled = false;
            coll.gameObject.GetComponent<Ragdoll_script>().OnRagdoll_func();
            Destroy(gameObject);
            GameManager.ins.GameoverWin_func();
        }
    }

}

