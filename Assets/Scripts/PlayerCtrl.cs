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
    [SerializeField] private List<GameObject> playerShot;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shotSpeed, maxShotTime;
    private float currentShotTime;
    private string shotType = "null";

    [Header("Inventory/Crafting Variables")]
    [SerializeField] private Vector2 inventoryVisiblePos;
    [SerializeField] private Vector2 inventoryHiddenPos;
    [SerializeField] private Animator paternAnim;
    private InventoryCtrl inventory;
    public GameObject hudInventory, hudCrafting, pauseBttn, resumeBttn, settingsBttn, fogPanel, delBttn, useBttn, resumeDelBttn, resumeUseBttn, shotBttns, boomerangBttn, arrowBttn, poisonArrowBttn, flamingArrowBttn, frozenArrowBttn, fireBallBttn;
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

    public void Fire()
    {
        currentShotTime -= Time.deltaTime;

        if (shotType == "Boomerang")
        {
           Instantiate(playerShot[0], firePoint.transform.position, Quaternion.identity);
        }

        if (shotType == "Arrow")
        {
            Instantiate(playerShot[1], firePoint.transform.position, Quaternion.identity);
        }

        if (shotType == "Poison Arrow")
        {
            Instantiate(playerShot[2], firePoint.transform.position, Quaternion.identity);
        }

        if (shotType == "Flaming Arrow")
        {
            Instantiate(playerShot[3], firePoint.transform.position, Quaternion.identity);
        }

        if (shotType == "Frozen Arrow")
        {
            Instantiate(playerShot[4], firePoint.transform.position, Quaternion.identity);
        }

        if (shotType == "Fire Ball")
        {
            Instantiate(playerShot[5], firePoint.transform.position, Quaternion.identity);
        }

        currentShotTime = maxShotTime;
    }

    private void UseItem(ItensCtrl item)
    {
        if (inventoryMode == "UseMode")
        {
            // Itens Func
            switch (item.itemType)
            {
                case ItensCtrl.ItemType.Heart:
                    maxHP += 4;
                    PlayerHit(0); //1
                    inventory.RemoveItem(item);
                    break;

                case ItensCtrl.ItemType.HP_PotionL:
                    if (hp < maxHP)
                    {
                        PlayerHit(-10); //2.5
                        inventory.RemoveItem(item);
                    }
                    break;

                case ItensCtrl.ItemType.HP_PotionS:
                    if (hp < maxHP)
                    {
                        PlayerHit(-4); //1
                        inventory.RemoveItem(item);
                    }
                    break;

                case ItensCtrl.ItemType.GoldPotionL:
                    if (hp < maxHP)
                    {
                        PlayerHit(28); //7
                        inventory.RemoveItem(item);
                    }
                    break;

                case ItensCtrl.ItemType.GoldPotionS:
                    if (hp < maxHP)
                    {
                        PlayerHit(-12); //3
                        inventory.RemoveItem(item);
                    }
                    break;

                case ItensCtrl.ItemType.Apple:
                    if (hp < maxHP)
                    {
                        PlayerHit(-2); //0.5
                        inventory.RemoveItem(item);
                    }
                    break;

                case ItensCtrl.ItemType.GoldApple:
                    if (hp < maxHP)
                    {
                        PlayerHit(-4); //1
                        inventory.RemoveItem(item);
                    }
                    break;

                case ItensCtrl.ItemType.RedMushroom:
                    if (hp < maxHP)
                    {
                        PlayerHit(-2); //0.5
                        inventory.RemoveItem(item);
                    }
                    break;

                case ItensCtrl.ItemType.GoldMushroom:
                    if (hp < maxHP)
                    {
                        PlayerHit(-4); //1
                        inventory.RemoveItem(item);
                    }
                    break;

                case ItensCtrl.ItemType.RottenApple:
                        PlayerHit(2); //0.5
                        inventory.RemoveItem(item);
                    break;

                case ItensCtrl.ItemType.Poison:
                    PlayerHit(6); //1.5
                    inventory.RemoveItem(item);
                    break;

                case ItensCtrl.ItemType.Boomerang:
                    shotType = "Boomerang";
                    inventory.RemoveItem(item);
                    break;

                case ItensCtrl.ItemType.Arrow:
                    shotType = "Arrow";
                    inventory.RemoveItem(item);
                    break;

                case ItensCtrl.ItemType.PoisonArrow:
                    shotType = "Poison Arrow";
                    inventory.RemoveItem(item);
                    break;

                case ItensCtrl.ItemType.FlamingArrow:
                    shotType = "Flaming Arrow";
                    inventory.RemoveItem(item);
                    break;

                case ItensCtrl.ItemType.FireRing:
                    shotType = "Fire Ball";
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

        if (hp >= maxHP)
        {
            hp = maxHP;
        }

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
        shotBttns.SetActive(false);

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
        shotBttns.SetActive(true);

        canMove = true;

        Time.timeScale = 1;
    }

    public void UseMode()
    {
        fogPanel.GetComponent<Image>().color = new Color32(168, 202, 88, 200);
        useBttn.SetActive(false);
        resumeUseBttn.SetActive(true);
        delBttn.SetActive(true);
        resumeDelBttn.SetActive(false);

        paternAnim.SetBool("UseMode", true);
        paternAnim.SetBool("DelMode", false);

        inventoryMode = "UseMode";
    }

    public void DelMode()
    {
        fogPanel.GetComponent<Image>().color = new Color32(207, 87, 60, 200);
        useBttn.SetActive(true);
        resumeUseBttn.SetActive(false);
        delBttn.SetActive(false);
        resumeDelBttn.SetActive(true);
        
        paternAnim.SetBool("UseMode", false);
        paternAnim.SetBool("DelMode", true);

        inventoryMode = "DelMode";
    }

    public void OrgMode()
    {
        fogPanel.GetComponent<Image>().color = new Color32(222, 158, 65, 200);

        useBttn.SetActive(true);
        delBttn.SetActive(true);
        resumeUseBttn.SetActive(false);
        resumeDelBttn.SetActive(false);

        paternAnim.SetBool("UseMode", false);
        paternAnim.SetBool("DelMode", false);

        inventoryMode = "OrgMode";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();

        if (itemWorld != null && canCollect)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
