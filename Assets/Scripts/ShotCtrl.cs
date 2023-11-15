using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float shotSpd;
    [SerializeField] private int shotStr;
    [SerializeField] private GameObject shotImpactXF;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(shotSpd, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 9f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyCtrl>().EnemyHit(shotStr);

            Destroy(gameObject);
            Instantiate(shotImpactXF, transform.position, Quaternion.identity);
        }      
    }
}
