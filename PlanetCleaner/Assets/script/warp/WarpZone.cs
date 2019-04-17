using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    int speed;
    [SerializeField]
    bool hit;
    public AudioClip warpSound;
    private AudioSource audioSource;

    public Finisher finifher;

    public Rasen rasen;

    [SerializeField]
    private GameObject hitObject;


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
        if (hit == true && rasen.Warping() == true)
        {
            if (hitObject)
            {
                hitObject.transform.position = target.transform.position;//ワープ
                hitObject.GetComponent<Rigidbody>().velocity = Vector3.zero;//力をゼロにさせる
                audioSource.PlayOneShot(warpSound);
            }
        }
    }
    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.tag == "Player")
        {
            if (finifher.Finish() == false)
            {
                if (hit == false)
                {
                    hitObject = col.gameObject;
                    hit = true;
                    target.GetComponent<WarpZone>().hit = true;//ワープ後のヒット判定
                }
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
    public bool FrontReturnHit()
    {
        return hit;
    }
    public bool BackReturnHit()
    {
        return target.GetComponent<WarpZone>().hit;//ワープ後のヒット判定
    }

}