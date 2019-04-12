using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    int speed;
    bool hit;
    public AudioClip warpSound;
    private AudioSource audioSource;

    public Finisher finifher;


    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        hit = false;
        audioSource = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //回す
        this.transform.Rotate(new Vector3(0.0f, 0.0f, speed));
    }

    void OnTriggerEnter(Collider col) 
    {

        if (col.gameObject.tag == "Player")
        {
            if (hit == false && finifher.Finish() == false)
            {
                hit = true;
                target.GetComponent<WarpZone>().hit = true;//ワープ後のヒット判定
                col.gameObject.transform.position = target.transform.position;//ワープ
                col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;//力をゼロにさせる
                audioSource.PlayOneShot(warpSound);
            }
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            hit = false;
        }
    }
}