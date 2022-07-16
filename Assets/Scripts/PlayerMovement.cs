using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator  animator;
    float horizontal;
    float vertical;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        animator.SetBool("isWalking", horizontal != 0.0f || vertical != 0.0f);

        //face the right direction
        if(horizontal < 0) transform.localScale = new Vector3(-1.0f, 1.0f ,1.0f);
        else transform.localScale = new Vector3(1.0f, 1.0f ,1.0f);

    }

    void FixedUpdate() {
        ProcessMovement();
    }

    void ProcessMovement(){ 
        rb.velocity =  new Vector2(horizontal, vertical) * speed;
    }
}
