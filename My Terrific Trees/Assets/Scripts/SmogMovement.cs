using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogMovement : MonoBehaviour
{
    public Vector2 speed;
    public float lifeTime = 25;
    float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > lifeTime) Destroy(gameObject);

        Vector2 movement = speed * Time.deltaTime;
        transform.position += new Vector3(movement.x, 0, movement.y);
    }
}
