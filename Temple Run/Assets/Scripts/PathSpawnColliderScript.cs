using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 여기에 닿으면 새로운 길이 생김(무한)
public class PathSpawnColliderScript : MonoBehaviour
{
    // 직선경로에서는 하나, 회전경로에서는 3개를 가짐.
    public Transform[] pathSpawnPoints;
    public GameObject path;
    public GameObject dangerousBorder;

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == Constants.PlayerTag)
        {
            int randomSpawnPoint = Random.Range(0, pathSpawnPoints.Length);
            for(int i = 0; i < pathSpawnPoints.Length; i++)
            {
                // 회전 경로에서 세가지 경로중 랜덤으로 하나를 골라 길을 만듬
                if(i == randomSpawnPoint)
                    Instantiate(path, pathSpawnPoints[i].position, pathSpawnPoints[i].rotation);
                // 나머지는 벽 생성
                else
                {
                    Instantiate(dangerousBorder, pathSpawnPoints[i].position, pathSpawnPoints[i].rotation);
                }
            }
        }
    }
}
