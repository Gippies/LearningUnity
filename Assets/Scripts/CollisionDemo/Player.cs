using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly float speed = 6f;

    Vector3 velocity;
    int coinCount;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        velocity = direction * speed;
    }

    void FixedUpdate()
    {
        // Note that deltaTime here automatically recognizes it's inside of FixedUpdate
        myRigidbody.position += velocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.tag == "Coin")
        {
            Destroy(triggerCollider.gameObject);
            coinCount++;
            print("Coin Count: " + coinCount);
        }
    }
}
