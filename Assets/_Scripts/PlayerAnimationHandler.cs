using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAnimationHandler : MonoBehaviour
{
    public Rig IKRig;
    private float m_IKWeight = 1f;
    public float IKDampSpeed = 1f;

    public void Reloading (int state)
    {
        if (state == 1) // reloading started
        {
            m_IKWeight = 0f;
            // SmoothRig (1f,0f);
        }
        else if (state == 2) // reloading ended
        {
            m_IKWeight = 1f;
            // SmoothRig (0f,1f);
        }
    }

    void Update()
    {
        IKRig.weight = Mathf.Lerp(IKRig.weight, m_IKWeight, IKDampSpeed * Time.deltaTime);
    }

    IEnumerator SmoothRig(float start, float end)
    {
        float elapsedTime = 0;

        float waitTime = 0.5f;

        while (elapsedTime < waitTime)
        {
            m_IKWeight = Mathf.Lerp(start, end, (elapsedTime / waitTime));

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
