using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

// IInputDetector인터페이스를 상속받음.
// 방향키를 통해서 방향을 리턴함.
public class ArrowKeysDetector : MonoBehaviour, IInputDetector
{
    public InputDirection? DetectInputDirection()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
            return InputDirection.Top;
        else if(Input.GetKeyUp(KeyCode.DownArrow))
            return InputDirection.Bottom;
        else if(Input.GetKeyUp(KeyCode.RightArrow))
            return InputDirection.Right;
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
            return InputDirection.Left;
        else
            return null;
    }
}