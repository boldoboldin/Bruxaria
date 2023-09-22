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

        float force = (float)Random.Range(1, 300);
        rb2D.AddForce(Vector2.up * force);
        rb2D.AddForce(Vector2.left * force);
        rotationZ = Random.Range(-force, force);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + rotationZ * Time.deltaTime);
        Destroy(gameObject, 5f);
    }
}
