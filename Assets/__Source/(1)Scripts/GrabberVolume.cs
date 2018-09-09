/*
 * BoolAnimatorParameterSetter.cs
 * by: Cristjan Lazar
 * Date: 2018-08-10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace roompuzzledemo {

    public class GrabberVolume : MonoBehaviour {

        #region Fields
        private List<Transform> inGrabberVolumeList = new List<Transform>();
        #endregion

        #region Unity Event Functions
        void OnTriggerEnter(Collider other) {
            if (other.isTrigger)
                return;

            inGrabberVolumeList.Add(other.transform);
            Debug.Log(other.gameObject.name + " entered grab volume!");
        }

        void OnTriggerExit(Collider other) {
            inGrabberVolumeList.Remove(other.transform);
            Debug.Log(other.gameObject.name + " exited grab volume!");
        }
        #endregion

        #region Methods
        public Transform GetClosest() {
            if (inGrabberVolumeList.Count <= 0)
                return null;

            return inGrabberVolumeList
                .OrderBy(t => Vector3.Distance(this.transform.position, t.position))
                .First();

            //inGrabberVolumeList.Remove(first);

            //return first;
        }
        #endregion
    }

}

