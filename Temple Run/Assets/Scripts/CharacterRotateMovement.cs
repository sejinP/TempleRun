using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class CharacterRotateMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20f;
    private CharacterController controller;
    public float jumpSpeed = 8.0f;
    public float speed = 6.0f;

    IInputDetector inputDetector = null;

    void Start()
    {
        moveDirection = transform.forward;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        UIManager.Instance.ResetScore();
        UIManager.Instance.SetStatus(Constants.StatusTapToStart);

        GameManager.Instance.GameState = GameState.Start;

        inputDetector = GetComponent<IInputDetector>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        switch(GameManager.Instance.GameState)
        {
            case GameState.Start:
                if(Input.GetMouseButtonUp(0))
                {
                    var instance = GameManager.Instance;
                    instance.GameState = GameState.Playing;

                    UIManager.Instance.SetStatus(string.Empty);
                }
                break;
            case GameState.Playing:
                UIManager.Instance.IncreaseScore(0.001f);

                CheckHeight();

                DetectJumpOrSwipeLeftRight();

                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);
                break;
            case GameState.Dead:
                if(Input.GetMouseButtonUp(0))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            default:
                break;
        }
    }

    private void CheckHeight()
    {
        if(transform.position.y < -10)
        {
            GameManager.Instance.Die();
        }
    }

    private void DetectJumpOrSwipeLeftRight()
    {
        var inputDirection = inputDetector.DetectInputDirection();
        if(controller.isGrounded && inputDirection.HasValue && inputDirection == InputDirection.Top)
        {
            moveDirection.y = jumpSpeed;
        }
        if(GameManager.Instance.CanSwipe && inputDirection.HasValue &&
        controller.isGrounded && inputDirection == InputDirection.Right)
        {
            // 회전
            transform.Rotate(0, 90, 0);
            moveDirection = Quaternion.AngleAxis(90, Vector3.up) * moveDirection;
            GameManager.Instance.CanSwipe = false;
        }
        else if(GameManager.Instance.CanSwipe && inputDirection.HasValue &&
        controller.isGrounded && inputDirection == InputDirection.Left)
        {
            transform.Rotate(0, -90, 0);
            moveDirection = Quaternion.AngleAxis(-90, Vector3.up) * moveDirection;
            GameManager.Instance.CanSwipe = false;
        }
    }
}
