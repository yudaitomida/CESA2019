using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    private float rotate_y;
    public physicsgravity physicsgravity;
    private float angle;
    private int angle_vel;
    //public AudioClip vacumeSound;
    //private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rotate_y = 270.0f;
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    public void GoParticle()
    {
        angle = physicsgravity.GetAngle();
        if (Input.GetKey(KeyCode.Space))
        {
            this.gameObject.GetComponent<ParticleSystem>().Play();
            //audioSource.PlayOneShot(vacumeSound);
        }
        else
        {
            this.gameObject.GetComponent<ParticleSystem>().Stop();
        }
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    rotate_y = 270.0f;
        //    angle_vel = 1;
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    rotate_y = 90.0f;
        //    angle_vel = -1;
        //}
        //this.gameObject.transform.rotation = Quaternion.Euler(angle * angle_vel - 10, rotate_y, 0.0f);

    }
}
