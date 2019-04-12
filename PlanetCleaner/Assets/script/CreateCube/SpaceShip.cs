using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    float speed;

    GameObject parentObj;
    public Finisher finisher;
    // Start is called before the first frame update
    void Start()
    {
        speed = -0.1f;
        parentObj = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = parentObj.transform.rotation;
        if(finisher.GameClear() == true &&finisher.Finish() == true)
        {

            this.transform.Translate(0.0f, speed, 0.0f, Space.Self);
            if (Mathf.Abs(Vector3.Distance(this.transform.position, parentObj.transform.position)) < 3)
            {
                speed = 0.0f;
                this.transform.Translate(0.0f, -0.01f, 0.0f);
                this.transform.GetChild(0).gameObject.SetActive(true);
                parentObj.GetComponent<physicsgravity>().CancelGravity(true);
                this.transform.parent.gameObject.GetComponent<playermove>().TakenAway();
            }
        }

    }
    
}
