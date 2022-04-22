using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D Dam)
    {
        if(Dam.gameObject.tag=="Enemy")
        {
            Panel.EnemyCurrentHp -= Panel.PlayerATK;
        }
    }
}
