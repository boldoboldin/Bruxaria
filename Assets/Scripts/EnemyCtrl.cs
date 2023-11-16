using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Status Variables")]
    [SerializeField] private int hp, str, numDrops;
    [SerializeField] private float spdX, spdY, fluctuation;
    [SerializeField] private string status = "null";
    [SerializeField] private bool isUp, isAccelerating, canGoUp, canGoDown, hasDied;

    private float currentSpdY, maxYPos, minYPos;
    private string fluctuationDir;
    private string[] fluctuationDirRnd = { "Up", "Down" };

    [SerializeField] protected GameObject explosionFX;
    [SerializeField] protected GameObject[] dropItemList;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(-spdX, 0f);

        currentSpdY = spdY;

        fluctuationDir = fluctuationDirRnd[Random.Range(0, fluctuationDirRnd.Length)];
    }

    private void FixedUpdate()
    {
        if (fluctuationDir == "Up" && canGoUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + currentSpdY);
            if (isAccelerating)
            {
                currentSpdY += fluctuation;

                if (currentSpdY >= spdY)
                {
                    isAccelerating = false;
                }
            }
            else if (!isAccelerating)
            {
                currentSpdY -= fluctuation;

                if (currentSpdY <= 0f)
                {
                    isAccelerating = true;
                    fluctuationDir = "Down";
                }
            }            
        }

        if (fluctuationDir == "Down" && canGoDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - currentSpdY);

            if (isAccelerating)
            {
                currentSpdY += fluctuation;

                if (currentSpdY >= spdY)
                {
                    isAccelerating = false;
                }
            }
            else if (!isAccelerating)
            {
                currentSpdY -= fluctuation;

                if (currentSpdY <= 0f)
                {
                    isAccelerating = true;
                    fluctuationDir = "Up";
                }
            }
        }
    }

    public void EnemyHit(int damage)
    {
        hp -= damage;

        if (hp <= 0f && !hasDied)
        {

            hasDied = true;

            for (int i = 0; i < numDrops; i++)
            {
                float rndX = Random.Range(-1f, 1f);
                float rndY = Random.Range(-1f, 1f);

                int dropItem = Random.Range(0, dropItemList.Length);

                Instantiate(dropItemList[dropItem], new Vector3(transform.position.x + rndX, transform.position.y + rndY, 0f), Quaternion.identity) ;
            }

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
