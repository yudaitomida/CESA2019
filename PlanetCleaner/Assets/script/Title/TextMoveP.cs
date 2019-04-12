using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMoveP : MonoBehaviour
{
    float speed;
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed, 0.0f, 0.0f);
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "StopObject")
        {
            speed = 0.0f;
            col.gameObject.GetComponent<ParticleSystem>().Stop();
            hit = true;
        }
    }
    public bool ImgHit()
    {
        return hit;
    }
    
}
