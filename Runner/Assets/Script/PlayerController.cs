using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        { 
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed;
            animator.SetBool("Run",true);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
            animator.SetTrigger("Jump");
        }


    }
}
