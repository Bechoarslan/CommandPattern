using System;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Signals
{
    public class CoreGameSignals : MonoBehaviour
    {
        #region Singleton

        public static CoreGameSignals Instance;

        private void Awake()
        {
            if(Instance !=null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }


        public UnityAction onWaypointSettled = delegate {  };

        #endregion

    }
}