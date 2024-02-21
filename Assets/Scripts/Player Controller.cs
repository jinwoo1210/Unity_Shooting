using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;
    [SerializeField] WeaponHolder weaponHolder;


    [Header("Spec")]
    [SerializeField] float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float normalSpeed, runSpeed;
    [SerializeField] float jumpSpeed;

    private Vector3 moveDir;
    private float ySpeed;
    private bool isWalk;


    private bool isZoomIn = false;
    public CinemachineVirtualCamera tpsCamera;
    public CinemachineVirtualCamera fpsCamera;

    private void Update()
    {
        Move();
        JumpMove();
    }

    private void Move()
    {
        if (isWalk)
        {
            controller.Move(transform.right * moveDir.x * walkSpeed * Time.deltaTime);
            controller.Move(transform.forward * moveDir.z * walkSpeed * Time.deltaTime);
            animator.SetFloat("XSpeed", moveDir.x * walkSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("YSpeed", moveDir.z * walkSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("MoveSpeed", moveDir.magnitude * walkSpeed, 0.1f, Time.deltaTime);
        }
        else
        {
            controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
            controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
            animator.SetFloat("XSpeed", moveDir.x * moveSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("YSpeed", moveDir.z * moveSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("MoveSpeed", moveDir.magnitude * moveSpeed, 0.1f, Time.deltaTime);
        }
    }

    private void JumpMove()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            ySpeed = 0;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void Fire()
    {
        animator.SetTrigger("Fire");
        weaponHolder.Fire();
    }

    public void Reload()
    {
        animator.SetTrigger("Reload");
    }

    private void OnRun(InputValue value)
    {
        if (value.isPressed)
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = normalSpeed;
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
    }

    private void OnJump(InputValue value)
    {
        ySpeed = jumpSpeed;
    }

    private void OnWalk(InputValue value)
    {
        if (value.isPressed)
        {
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
    }

    private void OnFire()
    {
        Fire();
    }

    private void OnReload(InputValue value)
    {
        Reload();
    }
    private void OnZoom(InputValue value)
    {

        if (value.isPressed)
        {
            if (isZoomIn == true)
            {
                Debug.Log("Zoom out");
                isZoomIn = false;
                fpsCamera.Priority = 1;
                //fpsCamera.MoveToTopOfPrioritySubqueue();
            }
            else
            {
                Debug.Log("Zoom in");
                isZoomIn = true;
                fpsCamera.Priority = 50;
                //tpsCamera.MoveToTopOfPrioritySubqueue();
            }
        }
    }
}
