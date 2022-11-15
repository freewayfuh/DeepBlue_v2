using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {
    public void ChangeScene(string _SceneName) {
        //Application.LoadLevel(_SceneName);
        SceneManager.LoadScene(_SceneName, LoadSceneMode.Additive);
    }
}
