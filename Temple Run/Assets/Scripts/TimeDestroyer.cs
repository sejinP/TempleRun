using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정 시간이 지나면 파괴함.
public class TimeDestroyer : MonoBehaviour
{
    public float lifeTime = 10f;
    void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }

    void DestroyObject()
    {
        if(GameManager.Instance.GameState != GameState.Dead && GameManager.Instance.GameState != GameState.Start)
            Destroy(gameObject);
    }
}
