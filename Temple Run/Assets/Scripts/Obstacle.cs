using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // 플레이어 태그 가진 물체에 충돌 시 die
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == Constants.PlayerTag)
        {
            GameManager.Instance.Die();
        }
    }
}
