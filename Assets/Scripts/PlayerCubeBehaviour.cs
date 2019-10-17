using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCubeBehaviour : MonoBehaviour
{
    private float speed = 10.0f;
    private float jumpSpeed = 8.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;

        transform.Translate(velocity * Time.deltaTime);

         if (Input.GetKeyDown("space")) {
             rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
         }
    }
}
