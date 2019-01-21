using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody rb;
    private Vector3 movementVelocity;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movementVelocity = movementDirection.normalized * Speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVelocity * Time.fixedDeltaTime);
    }

    public void Die()
    {
        Debug.Log("You dead!!");
        Destroy(gameObject);
    }
}