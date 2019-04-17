using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rasen : MonoBehaviour
{
    int degree;
    float rad;
    Vector3 pos;
    Transform target;
    float radius;
    bool rotate_warp;
    
    // Start is called before the first frame update
    void Start()
    {
        degree = 0;
        rad = 0.0f;
        radius = 1.0f;
        pos = Vector3.zero;
        target = null;
        rotate_warp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //ワープ中の時
            if (target.GetComponent<WarpZone>().FrontReturnHit() == true &&
                target.GetComponent<WarpZone>().BackReturnHit() == true)
            {
                if (radius > 0)
                {
                    radius = radius - 0.005f;
                    rotate_warp = false;
                }
                else
                {
                    rotate_warp = true;
                }
                degree += 3;
                rad = degree * Mathf.PI / 180;
                pos.x = target.position.x + radius * Mathf.Cos(rad);
                pos.y = target.position.y + radius * Mathf.Sin(rad);
                pos.z = this.transform.position.z;
                this.transform.position = pos;
            }
            else if (target.GetComponent<WarpZone>().FrontReturnHit() == false &&
                     target.GetComponent<WarpZone>().BackReturnHit() == false)
            {
                Reset();
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Warp")
        {
            target = col.gameObject.transform;
        }
    }

    public bool Warping()
    {
        return rotate_warp;
    }
    private void Reset()
    {
        target = null;
        radius = 1.0f;
        rotate_warp = false;
    }
}
