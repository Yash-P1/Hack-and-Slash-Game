using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    // reference animator
    public Animator animator;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // direction for player
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // check if player pressed down a key
        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            animator.SetBool("moving", true); // animator state change
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("moving", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("running", true);
            speed = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("running", false);
            speed = 2f;
        }
    }
}
