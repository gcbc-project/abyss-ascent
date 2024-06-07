using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggetTest : MonoBehaviour
{
    public LayerMask PlayerLayer;
    Scene curScene;
    string curScenename;
    private void Start()
    {
        curScene = gameObject.scene;
        curScenename = curScene.name;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == PlayerLayer)
        {
            SceneChangeManager.Instance.ActiveScene(curScenename);
        }
    }
}
