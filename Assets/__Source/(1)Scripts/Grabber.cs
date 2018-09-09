/*
 * Grabber.cs
 * by: Cristjan Lazar
 * Date: 2018-08-10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roompuzzledemo {

    /// <summary>
    /// Grabs an object by setting it's position to grabPosition and reparenting it.
    /// </summary>
    public class Grabber : MonoBehaviour {

        private const string GRAB_BUTTON = "Grab";

        #region Fields
        [SerializeField] private Animator animator;
        [SerializeField] private Transform grabPosition;
        [SerializeField] private GrabberVolume grabberVolume;
        public bool ikActive = false;

        private Transform rightHandTransform;
        private Transform leftHandTransform;
        private Transform carryObject;

        public Transform target;
        #endregion

        #region Unity Event Functions
        void OnAnimatorIK(int layerIndex) {
            if (animator) {
                if (ikActive) {
                    if (rightHandTransform != null) {
                        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTransform.position);
                        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTransform.rotation);
                    }

                    if (leftHandTransform != null)
                    {
                        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTransform.position);
                        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTransform.rotation);
                    }
                }

                else {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                }
            }
        }

        void Update() {
            if(Input.GetButtonDown(GRAB_BUTTON)) {
                if (IsGrabbing())
                    Release();
                else
                    Grab(grabberVolume.GetClosest());
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Grab an object, assuming an object isn't already held.
        /// </summary>
        /// <param name="target">Object to be grabbed</param>
        public void Grab (Transform target) {
            if (carryObject != null || target == null)
                return;

            carryObject = target;
            SetCarryObjectToGrabPosition();
            SetIkHandPositions();

            carryObject.GetComponent<Rigidbody>().isKinematic = true;
            carryObject.GetComponent<Collider>().isTrigger = true;

            ikActive = true;
        }

        /// <summary>
        /// Release an object being held.
        /// </summary>
        public void Release () {
            if (carryObject == null)
                return;

            carryObject.GetComponent<Rigidbody>().isKinematic = false;
            carryObject.GetComponent<Collider>().isTrigger = false;

            carryObject.transform.parent = null;
            rightHandTransform = null;
            leftHandTransform = null;
            ikActive = false;
            carryObject = null;
        }

        private bool IsGrabbing() {
            return carryObject != null;
        }

        private void SetCarryObjectToGrabPosition() {
            carryObject.transform.position = grabPosition.transform.position;
            carryObject.transform.rotation = grabPosition.transform.rotation;
            carryObject.transform.parent = this.transform;
        }

        private void SetIkHandPositions() {
            IkHandPositions handPositions = carryObject.GetComponent<IkHandPositions>();
            rightHandTransform = handPositions.RightHandPosition;
            leftHandTransform = handPositions.LeftHandPosition;
        }
        #endregion
    }

}


