using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove: MonoBehaviour
{

    public Finisher finisher;

    public int jump_power;//jampのパワー
    public float speed;//移動速度
    bool OnGround;    //地面に足がついているかどうか
    int enemy_state;    //playerが中か外か




    // Start is called before the first frame update
    void Start()
    {
        jump_power = 325;
        speed = 0.05f;
        OnGround = false;
        enemy_state = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (finisher.Finish() == false)
        {
            //移動
            this.gameObject.transform.Translate(speed, 0.0f, 0.0f, Space.Self);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Planet" || col.gameObject.tag == "Rock")
        {
            OnGround = true;
        }

    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "InPlanet")
        {
            enemy_state = 1;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "InPlanet")
        {
            enemy_state = 0;
        }
    }

    public int EnemyState()
    {
        return enemy_state;
    }

}
