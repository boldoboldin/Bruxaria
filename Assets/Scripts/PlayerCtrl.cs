using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static event Action OnPlayerDamage;
    
    private Rigidbody2D rb2D;

    [SerializeField] private GameObject witchFalling, bagFalling, broomFalling;
    [SerializeField] private GameObject fullHeartFalling, threeQuartHeartFalling, halfHeartFalling, quarterHeartFalling;

    [Header("Status Variables")]
    [SerializeField] private int def;
    [SerializeField] private float vel;
    [SerializeField] private string status = "null";
    public float hp, maxHP;

    [Header("Shot Variables")]
    [SerializeField] private GameObject playerShot;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shotSpeed, maxShotTime;
    private float currentShotTime;
    public string shotType = "null";

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentShotTime = maxShotTime;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shot();
    }

    private void Movement()
    {
        float moveY = Input.GetAxis("Vertical");

        Vector2 playerVel = new Vector2(0, moveY);

        rb2D.velocity = playerVel * vel;

        if (Input.GetMouseButton(0))
        {
            Vector2 destination = Input.mousePosition;
            Vector2 correctedDest = Camera.main.ScreenToWorldPoint(destination);
            Vector2 finalDest = new Vector2(transform.position.x, correctedDest.y);
            transform.position = Vector2.MoveTowards(transform.position, finalDest, vel * 0.002f);
        }
    }

    private void Shot()
    {
        currentShotTime -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && currentShotTime <= 0 && shotType != "null")
        {
            Fire();
        }
    }

    void Fire()
    {
        if (shotType == "Fire Ball")
        {
            Instantiate(playerShot, firePoint.transform.position, Quaternion.identity);
        }
        
        currentShotTime = maxShotTime;
    }

    public void PlayerHit(int damage)
    {
        hp -= damage;

        switch (damage)
        {
            case 1:
                Instantiate(quarterHeartFalling, transform.position, Quaternion.identity);
                break;
            case 2:
               Instantiate(halfHeartFalling, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(threeQuartHeartFalling, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(fullHeartFalling, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(fullHeartFalling, transform.position, Quaternion.identity);
                Instantiate(quarterHeartFalling, transform.position, Quaternion.identity);
                break;
        }

        OnPlayerDamage?.Invoke();

        if (hp <= 0)
        {
            Instantiate(witchFalling, transform.position, Quaternion.identity);
            Instantiate(bagFalling, transform.position, Quaternion.identity);
            Instantiate(broomFalling, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
