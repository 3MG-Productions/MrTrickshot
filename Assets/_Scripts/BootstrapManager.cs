using UnityEngine;
using Facebook.Unity;
using UnityEngine.SceneManagement;

namespace ThreeMG.Trickshot
{
    public class BootstrapManager : MonoBehaviour
    {
        private void Awake()
        {
            initSystems();
        }

        private void initSystems ()
        {
            // SDK initializations and others go here
            if (!FB.IsInitialized)
            {
                FB.Init(OnFBInit);
            }
            else
            {
                FB.ActivateApp();
                Debug.Log ("[FB] App Activating");
                OnLoadFinished();
            }
        }

        private void OnFBInit()
        {
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
                Debug.Log ("[FB] Initialized properly");
                Debug.Log ("[FB] App Activating");
            }
            else
            {
                Debug.Log ("[FB] Not Initialized properly");
            }

            OnLoadFinished();
        }

        private void OnLoadFinished()
        {
            SceneManager.LoadScene (1);
        }
    }
}