using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    public float velocidade = 5f;
    public Rigidbody2D playerRb;
    public Animator animator;

    Vector2 movimento;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxis("Vertical");

        animator.SetFloat("horizontal", movimento.x);
        animator.SetFloat("vertical", movimento.y);
        animator.SetFloat("velocidade", movimento.sqrMagnitude);

        if(movimento != Vector2.zero)
        {

            animator.SetFloat("horizontalIdle", movimento.x);
            animator.SetFloat("verticalIdle", movimento.y);
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movimento * velocidade * Time.fixedDeltaTime);
    }
}
