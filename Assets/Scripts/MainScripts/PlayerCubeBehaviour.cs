using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCubeBehaviour : MonoBehaviour
{
    readonly float speed = 10.0f;
    readonly float jumpSpeed = 8.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    float GetDistanceBetweenTwoPoints(float x1, float y1, float x2, float y2) {
        return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2.0f) + Mathf.Pow(y2 - y1, 2.0f));
    }

    void UpdatePosition()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;

        transform.Translate(velocity * Time.deltaTime, Space.World);

         if (Input.GetKeyDown("space")) {
             rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
         }
    }
}
