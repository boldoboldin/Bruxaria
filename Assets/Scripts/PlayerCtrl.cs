using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class PlayerCtrl : MonoBehaviour
{
    public static event Action OnPlayerDamage;
    
    private Rigidbody2D rb2D;

    [SerializeField] private GameObject witchFalling, bagFalling, broomFalling;
    [SerializeField] private GameObject fullHeartFalling, threeQuartHeartFalling, halfHeartFalling, quarterHeartFalling;

    [Header("Status Variables")]
    //[SerializeField] private int def;
    [SerializeField] private float vel;
    private bool canMove;
    //[SerializeField] private string status = "null";
    public float hp, maxHP;

    [Header("Shot Variables")]
    //[SerializeField] private GameObject playerShot;
    //[SerializeField] private Transform firePoint;
    [SerializeField] private float shotSpeed, maxShotTime;
    private float currentShotTime;
    //public string shotType = "null";

    [Header("Inventory/Crafting Variables")]
    [SerializeField] private Vector2 inventoryVisiblePos;
    [SerializeField] private Vector2 inventoryHiddenPos;
    private InventoryCtrl inventory;
    public GameObject hudInventory, hudCrafting, pauseBttn, resumeBttn, settingsBttn, fogPanel, delBttn, useBttn, resumeDelBttn, resumeUseBttn;
    public bool canCollect = true;
    public string inventoryMode = "OrgMode";
    
    private void Awake() 
    {
        inventory = new InventoryCtrl(UseItem, 7);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentShotTime = maxShotTime;
       
        HideInventory();
    }

    // Update is called once per frame
    void Update()
    {
        //Shot();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float moveY = Input.GetAxis("Vertical");

        Vector2 playerVel = new Vector2(0, moveY);

        rb2D.velocity = playerVel * vel;

        if (Input.GetMouseButton(0) && canMove)
        {
            Vector2 destination = Input.mousePosition;
            Vector2 correctedDest = Camera.main.ScreenToWorldPoint(destination);
            Vector2 finalDest = new Vector2(transform.position.x, correctedDest.y);
            transform.position = Vector2.MoveTowards(transform.position, finalDest, vel * 0.002f);
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
        if (inventoryMode == "UseMode")
        {
            switch (item.itemType)
            {
                case ItensCtrl.ItemType.HP_PotionL:
                    PlayerHit(-4);
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.HP_PotionS:
                    PlayerHit(-2);
                    inventory.RemoveItem(item);
                    break;
            }
        }

        if (inventoryMode == "DelMode")
        {
            inventory.RemoveItem(item);
        }



    }

    public InventoryCtrl GetInventory()
    {
        return inventory;
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

    public void ShowInventory()
    {
        hudInventory.transform.position = inventoryVisiblePos;

        resumeBttn.SetActive(true);
        settingsBttn.SetActive(true);
        fogPanel.SetActive(true);
        pauseBttn.SetActive(false);

        OrgMode();

        canMove = false;

        Time.timeScale = 0.1f;
    }

    public void HideInventory()
    {
        hudInventory.transform.position = inventoryHiddenPos;

        resumeBttn.SetActive(false);
        settingsBttn.SetActive(false);
        useBttn.SetActive(false);
        delBttn.SetActive(false);
        resumeUseBttn.SetActive(false);
        resumeDelBttn.SetActive(false);
        fogPanel.SetActive(false);
        pauseBttn.SetActive(true);

        canMove = true;

        Time.timeScale = 1;
    }

    public void UseMode()
    {
        fogPanel.GetComponent<Image>().color = new Color32(168, 202, 88, 100);
        useBttn.SetActive(false);
        resumeUseBttn.SetActive(true);

        inventoryMode = "UseMode";
    }

    public void DelMode()
    {
        fogPanel.GetComponent<Image>().color = new Color32(207, 87, 60, 100);
        delBttn.SetActive(false);
        resumeDelBttn.SetActive(true);

        inventoryMode = "DelMode";
    }

    public void OrgMode()
    {
        fogPanel.GetComponent<Image>().color = new Color32(250, 250, 250, 100);

        useBttn.SetActive(true);
        delBttn.SetActive(true);
        resumeUseBttn.SetActive(false);
        resumeDelBttn.SetActive(false);

        inventoryMode = "OrgMode";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();

        if (itemWorld != null && canCollect)
        {
            inventory.AddItem(itemWorld.GetItem()); //olhar aqui mais tarde
            itemWorld.DestroySelf();
        }
    }
}
