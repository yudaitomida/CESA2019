using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 axis;

    bool StopRotate;
    float time;
    void Start()
    {
        axis = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f).normalized;
        StopRotate = false;
        Debug.Log(axis);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (StopRotate == false)
        {
            transform.RotateAround(Vector3.zero, transform.right, 20 * Time.deltaTime);
        }
        if (StopRotate == true)
        {
            time += Time.deltaTime;
        }
        if (time > 5.0f)
        {
            StopRotate = false;
            time = 0.0f;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            StopRotate = true;
        }
    }
}
