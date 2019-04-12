using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROckManager : MonoBehaviour
{
    public Transform Stage;
    public Transform RockTrans;
    Vector2 StagePos;
    Vector2 MyPos;
    // Start is called before the first frame update
    void Start()
    {
        StagePos = new Vector2(Stage.transform.position.x, Stage.transform.position.y);
        MyPos = new Vector2(RockTrans.transform.position.x, RockTrans.transform.position.y);

        Vector2 dif = MyPos - StagePos;

        // ラジアン
        float radian = Mathf.Atan2(dif.y, dif.x);

        // 角度
        float degree = radian * Mathf.Rad2Deg;
        float degree_angle;
        if (degree > 90)
        {
            degree_angle = degree - 90f;
        }
        else
        {
            degree_angle = degree + 270f;
        }
        RockTrans.rotation = Quaternion.Euler(0.0f, 0.0f, degree_angle);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
