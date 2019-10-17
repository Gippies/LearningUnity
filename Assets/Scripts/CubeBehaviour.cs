using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeBehaviour : MonoBehaviour
{
    private readonly float speed = 10.0f;
    private readonly float jumpSpeed = 8.0f;
    private Vector3 jumpVector;
    private Vector3 leftVector;
    private Vector3 rightVector;
    private Vector3 forwardVector;
    private Vector3 backwardVector;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpVector = new Vector3(0.0f, jumpSpeed, 0.0f);
        leftVector = new Vector3(-speed, 0.0f, 0.0f);
        rightVector = new Vector3(speed, 0.0f, 0.0f);
        forwardVector = new Vector3(0.0f, 0.0f, speed);
        backwardVector = new Vector3(0.0f, 0.0f, -speed);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdatePosition();
    }

    private float GetDistanceBetweenTwoPoints(float x1, float y1, float x2, float y2) {
        return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2.0f) + Mathf.Pow(y2 - y1, 2.0f));
    }

    private void UpdatePosition()
    {
        Vector3 pos = this.transform.position;
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey("w")) {
             moveDirection += forwardVector;
         }
         if (Input.GetKey("s")) {
             moveDirection += backwardVector;
         }
         if (Input.GetKey("d")) {
             moveDirection += rightVector;
         }
         if (Input.GetKey("a")) {
             moveDirection += leftVector;
         }

        rb.MovePosition(pos + (moveDirection * Time.deltaTime));

         if (Input.GetKeyDown("space")) {
             rb.AddForce(jumpVector, ForceMode.Impulse);
         }
         transform.position = pos;
    }
}
