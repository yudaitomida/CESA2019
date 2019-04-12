using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.Translate(0.1f, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(0.0f, 400.0f, 0.0f);
        }

    }
}
