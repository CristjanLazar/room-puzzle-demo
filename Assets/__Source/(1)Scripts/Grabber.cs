using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roompuzzledemo {

    public class Grabber : MonoBehaviour {

        #region Fields
        [SerializeField] private Animator animator;
        [SerializeField] private Transform grabPosition;
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

        private void Update() {
            if (Input.GetKeyDown(KeyCode.I))
                Grab(target);
            if (Input.GetKeyDown(KeyCode.O))
                Release();
        }
        #endregion

        #region Methods
        public void Grab (Transform target) {
            if (carryObject != null)
                return;

            carryObject = target;

            carryObject.transform.position = grabPosition.transform.position;
            carryObject.transform.rotation = grabPosition.transform.rotation;
            carryObject.transform.parent = this.transform;

            IkHandPositions handPositions = carryObject.GetComponent<IkHandPositions>();
            rightHandTransform = handPositions.RightHandPosition;
            leftHandTransform = handPositions.LeftHandPosition;

            carryObject.GetComponent<Rigidbody>().isKinematic = true;
            carryObject.GetComponent<Collider>().isTrigger = true;

            ikActive = true;
        }

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
        #endregion
    }

}


