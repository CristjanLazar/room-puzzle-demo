/*
 * AudioPlayer.cs
 * by: Cristjan Lazar
 * Date: 2018-08-10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roompuzzledemo {

    /// <summary>
    /// Component that plays an audiosource.
    /// </summary>
    public class AudioPlayer : MonoBehaviour {

        #region Fields
        [SerializeField] private AudioSource audioSource;
        #endregion

        #region Methods
        /// <summary>
        /// Play assigned audiosource.
        /// </summary>
        public void Play() {
            audioSource.Play();
        }
        #endregion

    }

}
