using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Camera cam;
    private float moveSpeed = 3f;
    public Vector2 movement, mousePos;
    public bool attacking = false;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ControllerInputs();
        Animate();
    }

    void FixedUpdate(){
        Move();
        MeleeAttack();
    }
    private void ControllerInputs(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    private void MeleeAttack(){
        if(Input.GetKeyDown(KeyCode.X)){
            anim.SetTrigger("Melee");
        }
    }
    private void Animate()
    {
        anim.SetFloat("x", movement.x);
        anim.SetFloat("y", movement.y);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }
}
