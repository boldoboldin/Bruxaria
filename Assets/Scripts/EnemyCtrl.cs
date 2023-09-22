using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Status Variables")]
    [SerializeField] private int hp, str;
    [SerializeField] private float vel;
    [SerializeField] private string status = "null";

    [SerializeField] protected GameObject explosionFX;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(-vel, 0f);
    }

    public void EnemyHit(int damage)
    {
        hp = -damage;

        if (hp <= 0f)
        {
            Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerCtrl>().PlayerHit(str);
        }
    }
}
