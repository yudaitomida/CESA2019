using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectScene : MonoBehaviour
{
    int count;
    int count_past;
    public static string scene_name;
    int side;
    int max_playscene;

    float time;

    public Cameramoving camera_move;
    GameObject selectObject;
    bool start_fadeout, start_fadein;
    public FAdeController fadeController;

    bool flag;
    bool flag1;
    // Start is called before the first frame update
    void Start()
    {
        max_playscene = 6;
        side = 3;
        count = 0;
        count_past = count;
        start_fadeout = false;
        fadeController.isFadeIn = true;
        start_fadein = true;
        time = 0.0f;
        flag = false;
        flag1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start_fadein == true)
        {
            start_fadein = false;
        }
        if (flag == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && count < max_playscene - 1)
            {
                count++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && count > 0)
            {
                count--;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && count < side)
            {
                count += side;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && count > max_playscene - side - 1)
            {
                count -= side;
            }

            this.transform.GetChild(count).GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.9f, 0.0f);

            if (Input.anyKeyDown)
            {
                this.transform.GetChild(count_past).GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            }
        }
        count_past = count;

        scene_name = "Scene" + count;
        if (Input.GetKeyDown(KeyCode.Space) && start_fadeout == false)
        {
            flag = true;
        }
        if (flag == true && camera_move.TransformCamera(this.transform.GetChild(count).gameObject) == true)
        {
            time += Time.deltaTime;
            camera_move.GetCloseCamera(this.transform.GetChild(count).gameObject);
        }
        if (time > 2 && flag1 == false)
        {
            fadeController.isFadeOut = true;
            start_fadeout = true;
            flag1 = true;
        }
        if (start_fadeout == true && fadeController.isFadeOut == false)
        {
            OnStageSelect();
        }
    }
    void OnStageSelect()
    {
        SceneManager.LoadScene(scene_name);
    }
    public int SelectImg()
    {
        return count;
    }
    public static string Scene()
    {
        return scene_name;
    }
}