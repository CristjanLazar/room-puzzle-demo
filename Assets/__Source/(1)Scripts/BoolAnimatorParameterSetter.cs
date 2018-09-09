/*
 * BoolAnimatorParameterSetter.cs
 * by: Cristjan Lazar
 * Date: 2018-08-10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roompuzzledemo {

    /// <summary>
    /// Component that sets an animators bool parameter.
    /// </summary>
    public class BoolAnimatorParameterSetter : MonoBehaviour {

        #region Fields
        [SerializeField] private Animator animator;
        [SerializeField] private string parameter;
        #endregion

        #region Methods
        /// <summary>
        /// Sets the assigned parameter to a value.
        /// </summary>
        /// <param name="value">Parameter value</param>
        public void SetParameter(bool value) {
            animator.SetBool(parameter, value);
        }
        #endregion
    }

}

    
