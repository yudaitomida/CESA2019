using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectImg : MonoBehaviour
{
    public Sprite WarpText;
    public Sprite EnemyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSprite(GameObject gimmick_type)
    {
        Debug.Log(gimmick_type.tag);
        Sprite GimmickText= null;
        if(gimmick_type.tag == "Warp")
        {
            GimmickText = WarpText;
        }
        else if (gimmick_type.tag == "Enemy")
        {
            GimmickText = EnemyText;
        }
        this.GetComponent<Image>().sprite = GimmickText;
    }
}
