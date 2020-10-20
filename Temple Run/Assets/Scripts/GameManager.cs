using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인스턴스화
public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameState GameState { get; set; }
    public bool CanSwipe { get; set; }
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

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    protected GameManager()
    {
        GameState = GameState.Start;
        CanSwipe = false;
    }
    public void Die()
    {
        UIManager.Instance.SetStatus(Constants.StatusDeadTapToStart);
        this.GameState = GameState.Dead;
    }
}
