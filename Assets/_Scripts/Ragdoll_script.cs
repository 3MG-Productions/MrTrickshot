using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Ragdoll_script : MonoBehaviour
{
    public static Ragdoll_script ins;
    public List<Rigidbody> m_Rigidbodies;
    public Collider bodyCollider;

    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        m_Rigidbodies = new List<Rigidbody>(gameObject.GetComponentsInChildren<Rigidbody>());

        foreach (Rigidbody rbody in m_Rigidbodies)
        {
            rbody.isKinematic = true;
            rbody.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }

    public void OnRagdoll_func()
    {
        bodyCollider.enabled = false;

        foreach (Rigidbody rbody in m_Rigidbodies)
        {
            rbody.isKinematic = false;
            rbody.useGravity = true;
        }
    }
}
