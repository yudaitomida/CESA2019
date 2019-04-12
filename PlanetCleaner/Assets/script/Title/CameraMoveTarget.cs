using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTarget : MonoBehaviour
{
    public GameObject target;
    private float smoothing = 5f;

    private Vector3 offset;
    bool flag;
    private void Start()
    {
        this.offset = this.transform.position - target.transform.position;
        flag = false;
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            flag = true;

        }
        if(flag == true)
        {
            Vector3 currentPosition = this.target.transform.position + this.offset;
            currentPosition = currentPosition + new Vector3(0.0f, 0.0f, 20.0f);
            this.transform.position = Vector3.Lerp(this.transform.position, currentPosition, Time.deltaTime * this.smoothing);
        }

    }
}
