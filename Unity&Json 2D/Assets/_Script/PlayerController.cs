using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("velocidad y salto")]
    public float velMovement = 5f;//Velocidad movimiento
    public float fuerzaJump = 7f; //Fuerza de salto

    [Header("RigiBody y Animator")]
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Movimiento Player")]
    public float movimientoH;

    [Header("Posicion del player")]
    public Transform playerTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Debug de los componentes
        if (rb == null)
        {
            Debug.Log("No se encontro el componente Rigidbody2d" + gameObject.name);
        }

        if (animator == null)
        {
            Debug.Log("No se encontro el componente Animator en el objeto" + gameObject.name);
        }


        void Update()
        {
            //Movimiento Horizontal del player
            movimientoH = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(movimientoH * velMovement, rb.velocity.y);
            animator.SetFloat("Horizontal", Mathf.Abs(movimientoH));

            //Flip
            if(movimientoH >0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movimientoH <0)
            {
                playerTransform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
