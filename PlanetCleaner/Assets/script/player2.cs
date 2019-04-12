using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{

    [SerializeField]
    Transform CenterOfBalance;  // 重心

    // Start is called before the first frame update

    void Start()
    {
    }
    // Update is called once per frame

    void Update()
    {


        // キーボード入力で移動、回転
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Space.Selfはローカル座標
            transform.Rotate(new Vector3(0, 0, -3f), Space.Self);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, 3f), Space.Self);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.forward は ゲームオブジェクトが向いている方向
            //Time.fixedDeltaTime は 固定フレーム秒を返す
            transform.position = transform.position + (transform.forward * 3 * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (transform.forward * 3 * Time.fixedDeltaTime);
        }

        RaycastHit hit;
        // Transformの真下の地形の法線を調べる
        //if(ワールド座標でのレイの開始地点,レイの方向,レイで当たったオブジェクト情報,レイが衝突を検知する最大距離)
        //float.PositiveInfinity は　無限
        if (Physics.Raycast(CenterOfBalance.position, -transform.up, out hit, float.PositiveInfinity))
        {
            // 傾きの差を求める
            //Quaternion.FromToRotationは
            Quaternion q = Quaternion.FromToRotation(transform.up, hit.normal);

            // 自分を回転させる
            transform.rotation *= q;
            Debug.DrawRay(CenterOfBalance.position, -transform.up, Color.red);

            //// 地面から一定距離離れていたら落下
            //if (hit.distance > 0.05f)
            //{
            //    transform.position = transform.position +(-transform.up * Physics.gravity.magnitude * Time.fixedDeltaTime);
            //}
        }

    }
}
