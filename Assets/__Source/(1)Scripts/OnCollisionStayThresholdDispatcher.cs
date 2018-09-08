/*
 * OnCollisionStayThreshold.cs
 * by: Cristjan Lazar
 * Date: 2018-08-09
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace roompuzzledemo {

    /// <summary>
    /// Component that invokes events when trigger events exceed a certain threshold.
    /// </summary>
    public class OnCollisionStayThresholdDispatcher : MonoBehaviour {

        #region Fields
        [SerializeField] private int threshold;
        public UnityEvent OnThresholdExceeded;
        public UnityEvent OnThresholdUnder;

        private int triggerCount = 0;
        private bool currentlyExceedingThreshold = false;
        #endregion

        #region Unity Event Functions
        void OnTriggerEnter(Collider other) {
            triggerCount++;
            handleThresholdEvents();
        }

        void OnTriggerExit(Collider other) {
            triggerCount--;
            handleThresholdEvents();
        }
        #endregion

        #region Methods
        private void handleThresholdEvents()
        {
            if (triggerCount >= threshold) {
                if (currentlyExceedingThreshold)
                    return;

                currentlyExceedingThreshold = true;

                if (OnThresholdExceeded != null)
                    OnThresholdExceeded.Invoke();

                Debug.Log("OnThresholdExceeded invoked!");
            }
            else {
                if (!currentlyExceedingThreshold)
                    return;

                currentlyExceedingThreshold = false;

                if (OnThresholdUnder != null)
                    OnThresholdUnder.Invoke();

                Debug.Log("OnThresholdUnder invoked!");
            }
        }
        #endregion
    }

}

