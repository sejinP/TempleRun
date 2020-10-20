using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts
{
    // 인터페이스로 구현
    public interface IInputDetector
    {
        InputDirection? DetectInputDirection();
    }

    public enum InputDirection
    {
        Left,
        Right,
        Top,
        Bottom
    }
}
