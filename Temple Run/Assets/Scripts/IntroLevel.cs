using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLevel : MonoBehaviour
{
    // 맨 처음 시작 부분
    public void StraightLevelClick()
    {
        SceneManager.LoadScene("straightPathsLevel");
    }
    public void RotatedLevelClick()
    {
        SceneManager.LoadScene("rotatePathsLevel");
    }
}
