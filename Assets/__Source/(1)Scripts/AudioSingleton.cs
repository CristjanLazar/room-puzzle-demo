/*
 * AudioSingleton.cs
 * by: Cristjan Lazar
 * Date: 2018-08-10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roompuzzledemo {

    /// <summary>
    /// Plays a continuous loop of music, even when loading a scene.
    /// </summary>
    public class AudioSingleton : MonoBehaviour {

        #region Fields
        [SerializeField] private bool dontDestroyOnLoad;

        private static AudioSingleton singleton;
        #endregion

        #region Unity Event Functiona
        void Awake() {
            if (singleton != null) {
                Destroy(this.gameObject);
                return;
            }

            singleton = this;

            if (dontDestroyOnLoad)
                DontDestroyOnLoad(this.gameObject);
        }
        #endregion

    }

}
