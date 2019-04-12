using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnBottun : MonoBehaviour
{
    string scene_name;
    // Start is called before the first frame update
    void Start()
    {
        scene_name = SelectScene.Scene();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            OnStart();
        }
    }
    private void OnStart()
    {
        SceneManager.LoadScene(scene_name);
    }
}
