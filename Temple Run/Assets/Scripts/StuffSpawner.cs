using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 장애물과 보너스점수 얻을 수 있는 상자 생성해주는 스포너
public class StuffSpawner : MonoBehaviour
{
    public Transform[] stuffSpawnPoints;
    public GameObject bonus;
    public GameObject obstacles;

    public bool RandomX = false;
    public float minX = -1f, maxX = 2f;

    void Start()
    {
        bool placeObastacle = Random.Range(0, 2) == 0;
        int obstacleIndex = -1;
        if(placeObastacle)
        {
            obstacleIndex = Random.Range(0, stuffSpawnPoints.Length);
            CreateObject(stuffSpawnPoints[obstacleIndex].position, obstacles);
        }

        for(int i = 0; i < stuffSpawnPoints.Length; i++)
        {
            // 보너스랑 장애물이 겹치지 않게
            if(i == obstacleIndex) continue;
            if(Random.Range(0, 3) == 0)
            {
                CreateObject(stuffSpawnPoints[i].position, bonus);
            }
        }
    }

    void CreateObject(Vector3 position, GameObject prefab)
    {
        // 직선경로에서는 RandomX가 true 이므로 적용됨.
        // 가로 기준으로 랜덤하게 생성한다는 뜻.
        if(RandomX)
            position += new Vector3(0, 0, Random.Range(minX, maxX));
        Instantiate(prefab, position, Quaternion.identity);
    }
}