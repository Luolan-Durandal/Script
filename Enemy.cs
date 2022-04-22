using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //敵人跟隨玩家

    [SerializeField] Transform Target;
    [SerializeField] Transform MyTransform;
    [SerializeField] float EnemySpeed = 5f;
    [SerializeField] float MaxRange = 3f;
    private bool look = true;
    
    void FixedUpdate()
    {
        if(look)
        {
            if (Vector2.Distance(Target.position, MyTransform.position) > MaxRange) 
            {
            
            }

            // 兩者距離不超過MaxRange時，會跟隨目標，並在自己與目標之間畫出一條線，
            if (Vector2.Distance(Target.position, MyTransform.position) < MaxRange) 
            {
                Debug.DrawLine(MyTransform.position, Target.position, Color.red);
                // 在2D用y軸會翻轉90度，mytransform.LookAt(target.position);
                enemyfollow();
            }

            if (Panel.EnemyCurrentHp <= 0 )  
            {
                Destroy(gameObject);
            } 
        }
        
    }

    // MyTransform.position, Target.position自己到目標之間的距離，
    // Time.deltaTime * EnemySpeed 這是速度，
    // lerp 測量兩者之間的距離，並回傳向量值，後面乘上速度就會使自己朝目標移動

    void enemyfollow()
    {
        transform.position = Vector2.Lerp(MyTransform.position, Target.position, Time.deltaTime * EnemySpeed);
    }

    /*
    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "Player")
        {
            Debug.DrawLine(target.position, mytransform.position, Color.red);
            transform.LookAt(target.transform);
            mytransform.position += mytransform.forward * EnemySpeed * Time.deltaTime;
        }
    }
    
    */
}
