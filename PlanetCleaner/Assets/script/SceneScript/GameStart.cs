using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public FAdeController fadeController;
    bool fadestart;
    // Start is called before the first frame update
    void Start()
    {
        fadestart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && fadestart == false)
        {
            fadeController.isFadeOut = true;
            fadestart = true;
        }
        if(fadestart == true && fadeController.isFadeOut == false)
        {
            SceneManager.LoadScene("SelectScene");
        }
    }


}
