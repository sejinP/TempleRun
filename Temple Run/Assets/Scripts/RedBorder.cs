using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBorder : MonoBehaviour
{
    // 플레이어태그 갖고있는 물체에 닿으면 die
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == Constants.PlayerTag)
            GameManager.Instance.Die();
    }
}
