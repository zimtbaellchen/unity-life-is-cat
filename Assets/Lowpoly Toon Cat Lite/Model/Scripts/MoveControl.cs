/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        Vector3 movement = Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Vector3 movement2 = Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(movement2, Space.World);

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            if (this.anim != null)
            {
                this.anim.Play("Base Layer.Walk");
                //this.anim.ResetTrigger("Idle_A");
                //this.anim.SetTrigger("Entry");
            }
        }
    }

}
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveControl : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public Vector3 jump;
    public float jumpForce;
    public bool isGrounded;
    public float angle;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jumpForce = 8.0f;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        angle = Math.Abs(transform.rotation.eulerAngles.y);

        if (rightKeyPressed())
        {
            moveRight();
            rotateRight();
            startWalkAnim();
        } else
        {
            stopWalkAnim();
        }

        if (leftKeyPressed())
        {
            moveLeft();
            rotateLeft();
            startWalkAnim();
        }
        else
        {
            stopWalkAnim();
        }

        if (spaceKeyPressed() && isGrounded)
        {
            startJumpAnim();
            isGrounded = false;
        }

        Camera.main.transform.position = transform.position + new Vector3(0, 2f, -5f);
    }

    bool rightKeyPressed()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    void moveRight()
    {
        rb.velocity = new Vector3(rb.velocity.x + 0.05f, rb.velocity.y, rb.velocity.z);
    }

    void rotateRight()
    {
        if (angle > 90)
        {
            transform.Rotate(new Vector3(rb.angularVelocity.x, -90, rb.angularVelocity.z) * Time.deltaTime * 5.0f);
        }
    }

    void startWalkAnim()
    {
        anim.SetFloat("Blend", 1.0f, 0.1f, Time.deltaTime);
    }

    void stopWalkAnim()
    {
        anim.SetFloat("Blend", 0.0f, 0.1f, Time.deltaTime);
    }

    bool leftKeyPressed()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    void moveLeft()
    {
        rb.velocity = new Vector3(rb.velocity.x - 0.05f, rb.velocity.y, rb.velocity.z);
    }

    void rotateLeft()
    {
        if (angle <= 90 || angle >= 270) 
        {
            transform.Rotate(new Vector3(rb.angularVelocity.x, -90, rb.angularVelocity.z) * Time.deltaTime * 5.0f);
        }
    }

    bool spaceKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    void startJumpAnim()
    {
        anim.SetTrigger("Jump");
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    }
}





