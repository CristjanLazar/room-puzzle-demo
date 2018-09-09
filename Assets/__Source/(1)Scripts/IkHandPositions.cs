/*
 * IKHandPositions.cs
 * by: Cristjan Lazar
 * Date: 2018-08-10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roompuzzledemo {

    /// <summary>
    /// Contains IKTarget transforms for hands.
    /// </summary>
    public class IkHandPositions : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Transform rightHandPosition;
        [SerializeField] private Transform leftHandPosition;
        #endregion

        #region Properties
        public Transform RightHandPosition { get { return rightHandPosition; } }
        public Transform LeftHandPosition { get { return leftHandPosition; } }
        #endregion
    }

}
