using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Ctrl : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private float spd;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(-spd, 0f);
    }
}
