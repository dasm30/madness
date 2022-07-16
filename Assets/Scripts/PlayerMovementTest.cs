using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D), typeof (SpriteRenderer))]
public class PlayerMovementTest : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator  animator;
    float horizontal;
    float vertical;
    public float speed;

    void OnEnable() {
        EventManager.TimedEvent += ChangeColor;
    }

    void OnDisable() {
        EventManager.TimedEvent -= ChangeColor;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal < 0) transform.localScale = new Vector3(-1.0f, 1.0f ,1.0f);
        else transform.localScale = new Vector3(1.0f, 1.0f ,1.0f);

        if (InputManager.Instance.Punch) print("Punch");
        if (InputManager.Instance.Kick) print("Kick");
        if (InputManager.Instance.DiveKick) print("DiveKick");
        if (InputManager.Instance.Jump) print("Jump");

    }

    void FixedUpdate() {
        ProcessMovement();
    }

    void ProcessMovement(){ 
        rb.velocity =  new Vector2(horizontal, vertical) * speed;
    }

    void ChangeColor() {
        sp.color = ColorManager.Instance.GetCurrentColor();
    }
}
