using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField]
    GameObject Planet1;
    [SerializeField]
    GameObject Planet2;

    public Finisher finisher;

    public EnemyMove enemymove;

    public int jump_power;//jampのパワー
    public float speed;//移動速度
    bool OnGround;    //地面に足がついているかどうか
    int player_state;    //playerが中か外か

    public particle particle;

    SpriteRenderer MainSpriteRenderer;

    Transform myTrans;

    public Sprite player_default;
    public Sprite player_vacume;

    public AudioClip hitSound;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        jump_power = 325;
        speed = 0.1f;
        OnGround = false;
        player_state = 0;

        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myTrans = this.transform;
        audioSource = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(finisher.Finish() == false)
        {
            particle.GoParticle();

            //移動
            if (Input.GetKey(KeyCode.RightArrow))
            {
                myTrans.Translate(speed, 0.0f, 0.0f, Space.Self);
                myTrans.localScale = new Vector3(-0.3f, 0.3f, 1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                myTrans.Translate(speed * -1, 0.0f, 0.0f, Space.Self);
                myTrans.localScale = new Vector3(0.3f, 0.3f, 1);
            }
            //ジャンプ
            if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround == true)
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jump_power);
                OnGround = false;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                ChangeSprite(player_vacume);
            }
            else
            {
                ChangeSprite(player_default);
            }
            speed = (OnGround == false)? 0.05f : 0.1f;
            //if (OnGround == false)
            //{
            //    speed = 0.05f;
            //}
            //else
            //{
            //    speed = 0.1f;
            //}
        }
        //惑星の切り替え
        if (player_state == 0)
        {
            Planet1.layer = LayerMask.NameToLayer("Default");
            Planet2.layer = LayerMask.NameToLayer("PlanetSurface");
        }
        else
        {
            Planet1.layer = LayerMask.NameToLayer("PlanetSurface");
            Planet2.layer = LayerMask.NameToLayer("Default");

        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Planet" || col.gameObject.tag == "Rock")
        {
            OnGround = true;
        }
        if(col.gameObject.tag == "Enemy" && player_state == enemymove.EnemyState())
        {
            finisher.setgameover(true);
        }
        if(col.gameObject.tag == "Dust")
        {
            audioSource.PlayOneShot(hitSound);

        }

    }
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "InPlanet")
        {
            player_state = 1;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "InPlanet")
        {
            player_state = 0;
        }
    }


    public int PlayerState()
    {
        return player_state;
    }

    public bool OnPlanet()
    {
        return OnGround;
    }

    void ChangeSprite(Sprite img)
    {
        MainSpriteRenderer.sprite = img;
    }

    public void TakenAway()
    {
        this.transform.Translate(0.0f, 0.01f, 0.0f, Space.Self);
    }
}
