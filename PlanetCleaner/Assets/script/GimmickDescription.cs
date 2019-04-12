using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDescription : MonoBehaviour
{
    public Camera camera_object; //カメラを取得
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物

    bool objectDescription;
    static int Gimmick = 11;

    float active_time;
    // Start is called before the first frame update
    void Start()
    {
        active_time = 0.0f;
        this.transform.GetChild(0).gameObject.SetActive(false);
        objectDescription = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //マウスがクリックされたら
        {
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入
            active_time = 0.0f;
            if (Physics.Raycast(ray, out hit))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            {
                if (hit.collider.gameObject.layer == Gimmick)
                {
                    string objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
                    this.transform.GetChild(0).gameObject.SetActive(true);
                    objectDescription = true;
                    this.transform.GetChild(0).gameObject.GetComponent<SelectImg>().ChangeSprite(hit.collider.gameObject);
                    //Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green, 5, false);
                }
            }
        }
        if(objectDescription == true)
        {
            active_time += Time.deltaTime;
        }
        if(active_time > 4.0f)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            objectDescription = false;
        }
    }
}
