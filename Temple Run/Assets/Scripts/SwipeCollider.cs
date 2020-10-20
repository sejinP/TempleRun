using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCollider : MonoBehaviour
{
    // 스와이프 할수있는 공간에 들어서면 CanSwipe = true
    // 빠져나온다면 false
    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == Constants.PlayerTag)
            GameManager.Instance.CanSwipe = true;
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == Constants.PlayerTag)
            GameManager.Instance.CanSwipe = false;
    }
}
