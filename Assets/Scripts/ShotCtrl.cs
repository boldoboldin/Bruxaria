using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float shotSpd, accelerating;
    [SerializeField] private int shotStr;
    [SerializeField] private bool isBoomerang;
    [SerializeField] private GameObject shotImpactXF;
    [SerializeField] private bool isLeft, isAccelerating;

    private float currentShotSpd;
    private string dir = "Left";


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(shotSpd, 0f);

        currentShotSpd = shotSpd;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 9f);

        if (isBoomerang)
        {
            if (dir == "Left")
            {
                transform.position = new Vector2(transform.position.x + currentShotSpd, transform.position.y);
                if (isAccelerating)
                {
                    currentShotSpd += accelerating;

                    if (currentShotSpd >= shotSpd)
                    {
                        isAccelerating = false;
                    }
                }
                else if (!isAccelerating)
                {
                    currentShotSpd -= accelerating;

                    if (currentShotSpd <= 0f)
                    {
                        isAccelerating = true;
                        dir = "Right";
                    }
                }
            }

            if (dir == "Right")
            {
                transform.position = new Vector2(transform.position.x - currentShotSpd, transform.position.y);

                if (isAccelerating)
                {
                    currentShotSpd += accelerating;

                    if (currentShotSpd >= shotSpd/2)
                    {
                        isAccelerating = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && gameObject.tag == "Shot")
        {
            other.GetComponent<EnemyCtrl>().EnemyHit(shotStr);

            Destroy(gameObject);
            Instantiate(shotImpactXF, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Trunk") && gameObject.tag == "Axe")
        {
            other.GetComponent<EnemyCtrl>().EnemyHit(shotStr);

            Destroy(gameObject);
            Instantiate(shotImpactXF, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Rock") && gameObject.tag == "Pickaxe")
        {
            other.GetComponent<EnemyCtrl>().EnemyHit(shotStr);

            Destroy(gameObject);
            Instantiate(shotImpactXF, transform.position, Quaternion.identity);
        }
    }
}
