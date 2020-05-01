using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;

    Animator animator;
    Rigidbody2D rigidbody2d;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        // Set look direction
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        // Move Player
        Vector2 position = rigidbody2d.position;

        position = position + move * speed * Time.deltaTime;

        Teleport(position, Vector2.zero);

        // Check for input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Interact");

            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.1f, lookDirection, 1.5f, LayerMask.GetMask("Breakable"));
            
            if (hit.collider != null)
            {
                TreeObject treeObject = hit.collider.GetComponent<TreeObject>();
                if (treeObject != null)
                {
                    treeObject.Break();
                }
            }
        }
    }

    public void Teleport(Vector2 position, Vector2 velocity)
    {
        rigidbody2d.MovePosition(position);
        rigidbody2d.velocity = velocity;
    }
}
