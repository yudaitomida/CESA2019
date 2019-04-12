using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramoving : MonoBehaviour
{
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool TransformCamera(GameObject target)
    {
        Vector3 offset = (target.transform.position - this.transform.position) / 40;

        offset.z = 0;
        this.transform.Translate(offset);
        if ((Mathf.Abs(target.transform.position.y) - 0.2f) < Mathf.Abs(this.transform.position.y))
        {
            return true;
        }
        return false;
    }
    public void GetCloseCamera(GameObject target)
    {
        this.transform.Translate(new Vector3(0.0f, 0.0f, 0.1f));
    }
}
