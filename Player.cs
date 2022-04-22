using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Player : MonoBehaviour
{
    public Animator myAnimator;

    [SerializeField] IsGround IsGround;

    // 玩家跳躍控制器
    public bool jumpp = true;

    // flowchart外部變數名稱需要與腳本內的一致
    [SerializeField] Flowchart flowchart;
    string TalkBool = "玩家對話中"; // 玩家對話中

    // 角色面向:角色大小，必須跟遊戲人物一致，否則翻轉後大小會不同
    public float CharacterSizeX =1f;

    // 調用Enemy腳本的敵人生命值
    public Enemy EnemyP;

    // 角色基本參數，移動速度和跳躍力量
    [SerializeField] float speed = 1f;
    [SerializeField] float Jumpforce = 1f;
    private Rigidbody2D rb;

    // 生成物:如魔法或子彈
    public GameObject magic;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private bool talk
    {
        get 
        {
            return flowchart.GetBooleanVariable(TalkBool); // 回傳 flowchart 的變數"玩家對話中"
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (talk == false) // 把talk設為true就不會執行，功能為判斷玩家現在是否在說話
        {
            walk(); // 玩家移動
            jump(); // 玩家跳躍

            // 當在地板時才能跳躍，在空中不能跳躍
            if(IsGround.isground==true)
            {
                jumpp = true;
            }
            else
            {
                jumpp = false;
            }

            // 生成物測試
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                // 玩家前方產生魔法 待解決:如何在玩家前方產生，而不是看世界座標
                Vector2 MagicPosition = new Vector2(transform.position.x+20, transform.position.y);
                Instantiate(magic, MagicPosition, transform.rotation);
            }
        }
    }

    void walk()  // 玩家移動方式
    {
        float h = Input.GetAxis("Horizontal"); // 水平移動
        transform.Translate(new Vector2(h, 0) * speed * Time.deltaTime); // 速度
        myAnimator.SetFloat("Walk",Mathf.Abs(h)); // "Walk"為Animator的變數名稱，兩者需要一致，Walk的值會等於角色速度

        if (h < 0f) 
        {
            transform.localScale = new Vector2(-CharacterSizeX, 1f);
        }
        if (h > 0f) 
        {
            transform.localScale = new Vector2(CharacterSizeX, 1f);
        }
    }

    void jump()
    {
        if (jumpp == true) // 跳躍控制器
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * Jumpforce);
            }
        }  
    }

}
