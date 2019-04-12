using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMoveR : MonoBehaviour
{
    public TextMoveP text_move;
    float speed;
    bool hit;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        speed = -0.1f;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        hit = text_move.ImgHit();
        if(hit == true)
        {
            this.transform.Translate(speed, 0.0f, 0.0f);
            particle.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            particle.GetComponent<ParticleSystem>().Stop();
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "StopObject")
        {
            speed = 0.0f;
            particle.GetComponent<ParticleSystem>().Stop();

        }
    }
}
