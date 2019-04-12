using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject Stage;
    // 基準点
    Vector2 StagePos = Vector2.zero;
    // 目標点
    Vector2 playerPos = Vector2.zero;
    // Start is called before the first frame update
    //xとyの力の向き
    private int x_vel;
    private int y_vel;
    //xとyのかける力
    private float x_gravity;
    private float y_gravity;
    //ステージとプレイヤーの角度
    private float degree;
    private float degree_angle;
    private int enemy_state;
    public EnemyMove enemy_move;
    Rigidbody rd;

    void Start()
    {
        rd = this.GetComponent<Rigidbody>();
        rd.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        enemy_state = enemy_move.EnemyState();

        StagePos = new Vector2(Stage.transform.position.x, Stage.transform.position.y);
        playerPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        Vector2 dif = playerPos - StagePos;

        // ラジアン
        float radian = Mathf.Atan2(dif.y, dif.x);

        // 角度
        degree = radian * Mathf.Rad2Deg;


        if (Mathf.Abs(degree) > 0)
        {
            if (Mathf.Abs(degree) > 90)
            {
                DegreeToGravity(1);
            }
            else
            {
                DegreeToGravity(2);
            }
        }

        GravityVel();
        //デグリーから自分のrotationに当てはめる
        if (degree > 90)
        {
            degree_angle = degree - 90f + (enemy_state * 180);
        }
        else
        {
            degree_angle = degree + 270f + (enemy_state * 180);
        }
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, degree_angle);


        //Physics.gravity = new Vector3(x_gravity * x_vel, y_gravity * y_vel, 0.0f);
        this.GetComponent<Rigidbody>().AddForce(new Vector3(x_gravity * x_vel, y_gravity * y_vel, 0.0f), ForceMode.Acceleration);

    }
    //角度から重力の力を変える
    private void DegreeToGravity(int angle_pattern)
    {
        if (angle_pattern == 1)
        {
            x_gravity = ((Mathf.Abs(degree) - 90) / 90) * 9.81f;
            y_gravity = 9.81f - x_gravity;
        }
        else
        {
            y_gravity = (Mathf.Abs(degree) / 90) * 9.81f;
            x_gravity = 9.81f - y_gravity;
        }
    }
    //角度から重力のvelを作る
    private void GravityVel()
    {
        if (degree >= 0)
        {
            y_vel = -1;
        }
        else
        {
            y_vel = 1;
        }
        if (Mathf.Abs(degree) <= 90)
        {
            x_vel = -1;
        }
        else
        {
            x_vel = 1;
        }
        if (enemy_state == 1)
        {
            x_vel *= -1;
            y_vel *= -1;
        }
    }
    public float GetAngle()
    {
        return degree_angle;
    }
}
