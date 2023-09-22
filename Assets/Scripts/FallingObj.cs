using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObj : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float rotationZ;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        rotationZ = Random.Range(-150, 150);

        Vector2 direction = new Vector2((float)Random.Range(-10, 10), (float)Random.Range(-10, 10));
        float force = (float)Random.Range(-20, 20);
        rb2D.AddForce(direction * force);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + rotationZ * Time.deltaTime);
    }
}
