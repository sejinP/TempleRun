using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 점수 얻을수있는 오브젝트 스크립트. rotate를 통해서 회전을 하고,
// 콜라이더를 가지고 있으며 어떤 물체와 부딪히게 된다면 UIManager에 있는 점수를 올리고
// 자기 자신을 파괴한다.
public class Candy : MonoBehaviour
{
    public int scorePoints = 100;
    public float rotateSpeed = 50f;
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter(Collider col)
    {
        UIManager.Instance.IncreaseScore(scorePoints);
        Destroy(this.gameObject);
    }
}
