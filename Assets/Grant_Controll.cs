using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grant_Controll : MonoBehaviour
{
    public float moveForce;
    public float jumpForce;
    Animator animator;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = gameObject.transform.localScale;
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("jump");
            body.AddForce(Vector3.up * jumpForce);
            animator.SetBool("isGrounded", !animator.GetBool("isGrounded"));

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
        {
            body.AddForce(Vector3.left * moveForce);
            gameObject.transform.localScale = new Vector3(-1, scale.y, scale.z);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
        {
            body.AddForce(Vector3.right * moveForce);
            gameObject.transform.localScale = new Vector3(1, scale.y, scale.z);
        }

        float veloclty = body.velocity.magnitude;
        animator.SetFloat("veloclty", veloclty);

    }
}
