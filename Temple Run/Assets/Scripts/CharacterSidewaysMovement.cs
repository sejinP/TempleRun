using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;
public class CharacterSidewaysMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20f;
    private CharacterController controller;

    private bool isChangingLane = false;
    private Vector3 locationAfterChangingLane;
    private Vector3 sidewaysMovementDistance = Vector3.forward;

    public float sidewaysSpeed = 5.0f;

    public float jumpSpeed = 8.0f;
    public float speed = 6.0f;


    public IInputDetector inputDetector;

    void Start()
    {
        // 앞으로 이동 구현.
        moveDirection = transform.right;
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
            // 시작하기 전 상태
            case GameState.Start:
                if(Input.GetMouseButtonUp(0))
                {
                    var instance = GameManager.Instance;
                    instance.GameState = GameState.Playing;

                    UIManager.Instance.SetStatus(string.Empty);
                }
                break;
            // 게임 중 상태
            case GameState.Playing:
                UIManager.Instance.IncreaseScore(0.001f);
                
                CheckHeight();

                DetectJumpOrSwipeLeftRight();

                moveDirection.y -= gravity * Time.deltaTime;
                if(isChangingLane)
                {
                    if(Mathf.Abs(transform.position.z - locationAfterChangingLane.z) < 0.1f)
                    {
                        isChangingLane = false;
                        moveDirection.z = 0;
                    }
                }
                controller.Move(moveDirection * Time.deltaTime);
                break;
            // 죽은 상태
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

    // 바닥으로 떨어지면 Die
    private void CheckHeight()
    {
        if(transform.position.y < -10)
        {
            GameManager.Instance.Die();
        }
    }

    private void DetectJumpOrSwipeLeftRight()
    {
        // 어느쪽 방향키(혹은 스와이프)를 향하는지 반환
        var inputDirection = inputDetector.DetectInputDirection();
        if(controller.isGrounded && inputDirection.HasValue && inputDirection == InputDirection.Top && !isChangingLane)
        {
            moveDirection.y = jumpSpeed;
        }
        if(controller.isGrounded && inputDirection.HasValue && !isChangingLane)
        {
            isChangingLane = true;
            if(inputDirection == InputDirection.Left)
            {
                locationAfterChangingLane = transform.position + sidewaysMovementDistance;
                moveDirection.z = sidewaysSpeed;
            }
            else if(inputDirection == InputDirection.Right)
            {
                locationAfterChangingLane = transform.position - sidewaysMovementDistance;
                moveDirection.z = -sidewaysSpeed;
            }
        }
    }

    // 오른쪽 벽이나 왼쪽 벽가까이에서 그 방향으로 이동한다면 update의 게임중 상태에서
    // Mathf.Abs(transform.position.z - locationAfterChangingLane.z)(현재 포지션에서 최종 이동 포지션의 차이)
    // 가 0.1보다 작아지지 않으므로 벽에 닿았을때를 구현해준다.
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == Constants.WidePathBorderTag)
        {
            isChangingLane = false;
            moveDirection.z = 0;
        }
    }
}
