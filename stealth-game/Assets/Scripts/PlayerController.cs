using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float FootStepCooldown;
    public GameObject FootStep;

    public bool Moving { get { return movementVelocity.sqrMagnitude > 0; } }

    private Rigidbody rb;
    private Vector3 movementVelocity;
    private float FootStepTimer;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        FootStepTimer = FootStepCooldown;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movementVelocity = movementDirection.normalized * Speed;

        FootStepTimer -= Time.deltaTime;

        if (Moving && FootStepTimer < 0)
        {
            Instantiate(FootStep, transform.position, Quaternion.identity);
            FootStepTimer = FootStepCooldown;
        }
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