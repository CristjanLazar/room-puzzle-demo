using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roompuzzledemo {

    public class IkHandPositions : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Transform rightHandPosition;
        [SerializeField] private Transform leftHandPosition;
        #endregion

        #region Methods
        public Transform RightHandPosition { get { return rightHandPosition; } }
        public Transform LeftHandPosition { get { return leftHandPosition; } }
        #endregion
    }

}
