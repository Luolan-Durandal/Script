using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{

    public bool isground = true;

    void Start()
    {
        isground = true;
    }
    // 在地上
    private void OnTriggerEnter2D(Collider2D ground)
    {
        if (ground.gameObject.tag == "Ground")
        {
            isground = true;
        }
    }

    // 在空中
    private void OnTriggerExit2D(Collider2D ground)
    {
        if (ground.gameObject.tag == "Ground")
        {
            isground = false;
        }
    }

    

}
