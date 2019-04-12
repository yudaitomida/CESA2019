using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImgManager : MonoBehaviour
{
    [SerializeField]
    GameObject DustManager;


    bool dustbreak;
    int delete_object_num;
    //GameObject[] go_storage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (DustManager.transform.childCount < 3)
        {
            this.transform.GetChild(DustManager.transform.childCount).gameObject.SetActive(false);
        }
        
    }
}
