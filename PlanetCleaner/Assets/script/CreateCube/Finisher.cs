using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finisher : MonoBehaviour
{
    [SerializeField]
    MoveText Text;

    [SerializeField]
    Transform DustManager;

    [SerializeField]
    Transform Cube;

    float rotateSpeed;
    float time;

    bool fadestart;

    bool finish;//ゲームの終了フラグ
    public playermove PlayerMove;
    public FAdeController fadeController;

    bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 1f;
        finish = false;
        fadestart = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((DustManager.childCount == 0 || gameover == true) && PlayerMove.OnPlanet() == true)
        {
            //カメラの角度を補完
            transform.rotation = Quaternion.Lerp(transform.rotation, Cube.rotation, rotateSpeed * Time.deltaTime);
            finish = true;
            time += Time.deltaTime;
        }
        if(time > 3.0f)
        {
            Text.Move(gameover);
        }
        if(time > 8.0f && fadestart == false)
        {
            fadeController.isFadeOut = true;
            fadestart = true; 
        }
        if(fadestart == true && fadeController.isFadeOut == false)
        {
            SceneManager.LoadScene("SelectScene");
        }

    }
    public bool Finish()
    {
        return finish;
    }
    public void setgameover(bool game_state)
    {
        this.gameover = game_state;
    }
    public bool GameClear()
    {
        return gameover;
    }

}
