using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustVacum : MonoBehaviour
{

    bool destoryObject;
    [SerializeField]
    Transform target;

    private float speed;

    bool hit;//吸い込みの成功フラグ



    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        hit = false;
        destoryObject = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(hit == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);

            //targetに向かって進む
            transform.position += transform.forward * speed;
        }
        if(destoryObject == true)
        {
            destoryObject = false;
        }
    }
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "VacumCleaner" && Input.GetKey(KeyCode.Space))
        {
            hit = true;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player" && hit == true)
        {
            Destroy(this.gameObject);
            destoryObject = true;

        }
    }
    public bool DestoroyDust()
    {
        return destoryObject;
    }
}
