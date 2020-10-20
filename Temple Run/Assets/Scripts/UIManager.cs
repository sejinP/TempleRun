using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI관리해주는 매니저
public class UIManager : MonoBehaviour
{
    // 인스턴스화
    private static UIManager instance;
    
    private float score = 0;

    public Text scoreText, statusText;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
                instance = new UIManager();
            return instance;
        }
    }

    protected UIManager()
    {
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    public void SetScore(float value)
    {
        score = value;
        UpdateScoreText();
    }

    public void IncreaseScore(float value)
    {
        score += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void SetStatus(string text)
    {
        statusText.text = text;
    }
}
