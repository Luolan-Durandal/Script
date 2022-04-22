
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public bool GameStart;
    [SerializeField] GameObject DestroyUI;

    public static float EnemyCurrentHp = 100;
    public static float EnemyHpMax = 100;

    // 用一張圖的fillamount來縮減圖片，底下墊原圖就能達成生命值減少
    public static float PlayerCurrentHp = 100;
    public static float PlayerHpMax = 100;

    // 玩家攻擊力
    public static float PlayerATK = 10;
    public Image EnemyHpBar;

    // 敵人攻擊力
    public static float EnemyATK = 10;
    // public Image PlayerHpBar;

    void Awake()
    {
        EnemyCurrentHp = EnemyHpMax;
        PlayerCurrentHp = PlayerHpMax;
    }

    void FixedUpdate()
    {
        // 生命值填充值=當前生命值/最大生命值
        EnemyHpBar.fillAmount = EnemyCurrentHp / EnemyHpMax;

        if (EnemyCurrentHp <= 0)
        {
            //GameObject.Destroy(child.gameObject);
            Destroy(DestroyUI.gameObject);
        }
    }

}



