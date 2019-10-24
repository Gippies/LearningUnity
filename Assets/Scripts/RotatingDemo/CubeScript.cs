using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Transform sphereTransform;
    // Acts as an offset
    readonly float PiOver2 = Mathf.PI / 2f;

    // Start is called before the first frame update
    void Start()
    {
        // sphereTransform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 180 * Time.deltaTime, Space.World);
        sphereTransform.localScale = Vector3.one * (Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad + PiOver2) + 2.0f);
    }
}
