using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSpawner : MonoBehaviour
{

    public GameObject chairPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
            Vector3 randomRotation = Vector3.up * Random.Range(0f, 360f);

            GameObject newChair = (GameObject) Instantiate(chairPrefab, randomSpawnPosition, Quaternion.Euler(randomRotation));
            newChair.transform.parent = transform;
        }
    }
}
