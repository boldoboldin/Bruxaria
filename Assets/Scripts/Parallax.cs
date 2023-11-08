using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpd;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(parallaxSpd * Time.fixedDeltaTime * Vector2.left);
        
        if (transform.position.x <= -24f)
        {
            transform.position = new Vector2(24f, 0f);
        }
    }
}
