using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveText : MonoBehaviour
{

    public Sprite clear;
    public Sprite gameover;
    private Vector2 DownPosition;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        y = 180.0f;
        DownPosition = Vector2.zero;
    }

    // Update is  called once per frame
    void Update()
    {

    }
    public void Move(bool game_over)
    {
        if(game_over == false)
        {
            this.GetComponent<Image>().sprite = clear;
        }
        else
        {
            this.GetComponent<Image>().sprite = gameover;
        }
        if (y >= 0)
        {
            y -= 1.0f;
        }
        DownPosition = new Vector2(0.0f, y);

        this.gameObject.GetComponent<RectTransform>().localPosition = DownPosition;


    }
}