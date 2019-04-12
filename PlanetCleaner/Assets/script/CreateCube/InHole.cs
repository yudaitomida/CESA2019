using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHole : MonoBehaviour
{
    public int speed;
    [SerializeField]
    GameObject Target;

    bool ThroughCollider;
    float time;

    int player_state;
    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        player_state = 0;
        ThroughCollider = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, speed));
        if(ThroughCollider == true)
        {
            time += Time.deltaTime;
        }
        if(time >= 1.0f)
        {
            Target.gameObject.GetComponent<SphereCollider>().enabled = true;
            ThroughCollider = false;
            time = 0.0f;
        }
    }
    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Player")
        {
            Target.gameObject.GetComponent<SphereCollider>().enabled = false;
            ThroughCollider = true;
            col.gameObject.transform.position = Target.gameObject.transform.position;
            player_state =  (player_state + 1) % 2;

        }
    }
    public int PlayerState()
    {
        return player_state;
    }
}