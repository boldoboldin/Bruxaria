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
    //[SerializeField] private int def;
    [SerializeField] private float vel;
    //[SerializeField] private string status = "null";
    public float hp, maxHP;

    [Header("Shot Variables")]
    //[SerializeField] private GameObject playerShot;
    //[SerializeField] private Transform firePoint;
    [SerializeField] private float shotSpeed, maxShotTime;
    private float currentShotTime;
    //public string shotType = "null";


    [Header("Inventory/Crafting Variables")]
    [SerializeField] private GameObject hudInventory;
    [SerializeField] private GameObject hudCrafting;
    private InventoryCtrl inventory;
    public UI_Inventory uiInventory;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentShotTime = maxShotTime;
        inventory = new InventoryCtrl(UseItem); //antes no awake
        uiInventory.SetInventory(inventory); //antes no awake
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //Shot();
    }

    private void Movement()
    {
        float moveY = Input.GetAxis("Vertical");

        Vector2 playerVel = new Vector2(0, moveY);

        rb2D.velocity = playerVel * vel;

        if (Input.GetMouseButton(0) && Time.timeScale == 1)
        {
            Vector2 destination = Input.mousePosition;
            Vector2 correctedDest = Camera.main.ScreenToWorldPoint(destination);
            Vector2 finalDest = new Vector2(transform.position.x, correctedDest.y);
            transform.position = Vector2.MoveTowards(transform.position, finalDest, vel * 0.002f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            hudInventory.SetActive(true);
            hudCrafting.SetActive(true);

            Time.timeScale = 0.01f;
        }

        if (Input.GetMouseButton(1))
        {
            hudInventory.SetActive(true);
            hudCrafting.SetActive(true);

            Time.timeScale = 1;
        }
    }

    //private void Shot()
    //{
    //    currentShotTime -= Time.deltaTime;

    //    if (Input.GetKey(KeyCode.Space) && currentShotTime <= 0 && shotType != "null")
    //    {
    //        Fire();
    //    }
    //}

    //void Fire()
    //{
    //    if (shotType == "Fire Ball")
    //    {
    //        Instantiate(playerShot, firePoint.transform.position, Quaternion.identity);
    //    }
        
    //    currentShotTime = maxShotTime;
    //}

    private void UseItem(ItensCtrl item)
    {
        switch (item.itemType)
        {
            case ItensCtrl.ItemType.HP_PotionL:
                hp = maxHP;
                inventory.RemoveItem(new ItensCtrl { itemType = ItensCtrl.ItemType.HP_PotionL, amount = 1 });
                break;
            case ItensCtrl.ItemType.HP_PotionS:
                hp = hp + 4;
                inventory.RemoveItem(new ItensCtrl { itemType = ItensCtrl.ItemType.HP_PotionS, amount = 1 });
                break;
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();

        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
