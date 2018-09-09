/*
 * AudioSingleton.cs
 * by: Cristjan Lazar
 * Date: 2018-08-10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace roompuzzledemo {

    /// <summary>
    /// Component that handles scene loading.
    /// </summary>
    public class SceneLoader : MonoBehaviour {

        #region Fields
        [SerializeField] private string scene;
        #endregion

        /// <summary>
        /// Loads the assigned scene.
        /// </summary>
        #region Methods
        public void LoadScene() {
            SceneManager.LoadScene(scene);
        }
        #endregion

    }

}

