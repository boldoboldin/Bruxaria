using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Inventory/Crafting Variables")]
    [SerializeField] private Vector2 inventoryVisiblePos;
    [SerializeField] private Vector2 inventoryHiddenPos;
    [SerializeField] private Animator paternAnim;
    private InventoryCtrl inventory;
    public string inventoryMode = "OrgMode";
    public string fala;

    public int score = 0;

    public GameObject delBttn, useBttn, resumeDelBttn, resumeUseBttn;

    [SerializeField] private CustomerCtrl customerCtrl;
    
    private void Awake() 
    {
        inventory = new InventoryCtrl(UseItem, 29);
    }

    // Start is called before the first frame update
    void Start()
    {
        //HideInventory();
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void FixedUpdate()
    {

    }

    private void UseItem(ItensCtrl item)
    {
        if (inventoryMode == "UseMode")
        {
            // Itens Func
            switch (item.itemType)
            {
                case ItensCtrl.ItemType.VenenoDeCobra:
                    if (customerCtrl.order == "veneno de cobra")
                    {
                        score = score + 100;
                        fala = "Ah perfeito!";
                    }
                    else
                    {
                        fala = "Não foi isso que eu pedi!";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.VenenoDeCobraFrutosDoMar:
                    if (customerCtrl.order == "veneno de cobra s/ frutos do mar")
                    {
                        score = score + 125;
                        fala = "Exatamente  o que eu queria";
                    }
                    else
                    {
                        fala = "Ta querendo me matar é?";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.VenenoDeCobraAzeitona:
                    if (customerCtrl.order == "veneno de cobra c/ azeitona")
                    {
                        score = score + 125;
                        fala = "Que cheiro maravilhoso! Obrigado!";
                    }
                    else
                    {
                        fala = "Não foi isso que eu pedi!";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.MatadorDeColosso:
                    if (customerCtrl.order == "matador de colosso")
                    {
                        score = score + 100;
                        fala = "Que cheiro maravilhoso! Obrigado!";
                    }
                    else
                    {
                        fala = "O que era pra ser isso";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.MatadorDeColossoCastanha:
                    if (customerCtrl.order == "matador de coloso c/ castanha")
                    {
                        score = score + 125;
                        fala = "Que cheiro maravilhoso! Obrigado!";
                    }
                    else
                    {
                        fala = "Não foi isso que eu pedi!";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.MatadorDeColossoSacheDeMiojo:
                    if (customerCtrl.order == "matador de coloso c/ sache de miojo")
                    {
                        score = score + 125;
                        fala = "Que cheiro maravilhoso! Obrigado!";
                    }
                    else
                    {
                        fala = "Tira essa nojeira de perto de mim";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.SonoEterno:
                    if (customerCtrl.order == "sono eterno")
                    {
                        score = score + 100;
                        fala = "Ah perfeito!";
                    }
                    else
                    {
                        fala = "O que era pra ser isso?";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.SonoEternoAdocante:
                    if (customerCtrl.order == "sono eterno c/ adocante")
                    {
                        score = score + 125;
                        fala = "Ah perfeito!";
                    }
                    else
                    {
                        fala = "Não foi isso que eu pedi!";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.SonoEternoFrutasVermelhas:
                    if (customerCtrl.order == "sono eterno c/ frutas vermelhase")
                    {
                        score = score + 125;
                        fala = "Que cheiro maravilhoso! Obrigado!";
                    }
                    else
                    {
                        fala = "O que era pra ser isso?";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.DorDeBarrigaEterna:
                    if (customerCtrl.order == "dor de barriga eterna")
                    {
                        score = score + 100;
                        fala = "Hihihi…";
                    }
                    else
                    {
                        fala = "Tira essa nojeira de perto de mim";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.DorDeBarrigaEternaDoce:
                    if (customerCtrl.order == "dor de barriga eterna c/ doce")
                    {
                        score = score + 125;
                        fala = "Hihihi…";
                    }
                    else
                    {
                        fala = "Tira essa nojeira de perto de mim";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.CoracaoPartido:
                    if (customerCtrl.order == "coracao partido")
                    {
                        score = score + 100;
                        fala = "Exatamente o que eu queria…";
                    }
                    else
                    {
                        fala = "O que era pra ser isso?";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.CoracaoPartidoAUltimaLagrima:
                    if (customerCtrl.order == "coração partido c/ a ultima lagrima")
                    {
                        score = score + 125;
                        fala = "Ah perfeito!";
                    }
                    else
                    {
                        fala = "O que era pra ser isso?";
                    }
                    inventory.RemoveItem(item);
                    break;
                case ItensCtrl.ItemType.MatadorDeColossoPeloDeRaboDeRato:
                    if (customerCtrl.order == "matador de colosso c/ pelo de rato")
                    {
                        score = score + 125;
                        fala = "Exatamente o que eu queria";
                    }
                    else
                    {
                        fala = "Não foi isso que eu pedi!";
                    }
                    inventory.RemoveItem(item);
                    break;

            }

            customerCtrl.EndDialogue(fala);
        }
    }

    public InventoryCtrl GetInventory()
    {
        return inventory;
    }

    public void ShowInventory()
    {
        //hudInventory.transform.position = inventoryVisiblePos;

        //resumeBttn.SetActive(true);
        //settingsBttn.SetActive(true);
        //fogPanel.SetActive(true);
        //pauseBttn.SetActive(false);
        //equipBttns.SetActive(false);

        OrgMode();

        Time.timeScale = 0.1f;
    }

    public void HideInventory()
    {
        //hudInventory.transform.position = inventoryHiddenPos;

        //resumeBttn.SetActive(false);
        //settingsBttn.SetActive(false);
        //useBttn.SetActive(false);
        //delBttn.SetActive(false);
        //resumeUseBttn.SetActive(false);
        //resumeDelBttn.SetActive(false);
        //fogPanel.SetActive(false);
        //pauseBttn.SetActive(true);
        //equipBttns.SetActive(true);

        Time.timeScale = 1;
    }

    public void UseMode()
    {
        
        useBttn.SetActive(false);
        resumeUseBttn.SetActive(true);
        delBttn.SetActive(false);
        resumeDelBttn.SetActive(false);

        inventoryMode = "UseMode";
    }

    public void DelMode()
    {
        useBttn.SetActive(false);
        resumeUseBttn.SetActive(false);
        delBttn.SetActive(false);
        resumeDelBttn.SetActive(true);

        inventoryMode = "DelMode";
    }

    public void OrgMode()
    {

        useBttn.SetActive(true);
        delBttn.SetActive(true);
        resumeUseBttn.SetActive(false);
        resumeDelBttn.SetActive(false);

        inventoryMode = "OrgMode";
    }

    public void BuyItem()
    {
        inventory = new InventoryCtrl(UseItem, 29);
    }

    public void ShowGameOver(int score)
    {
        //hudInventory.transform.position = inventoryHiddenPos;

        //fogPanel.GetComponent<Image>().color = new Color32(207, 87, 60, 200);
        //fogPanel.SetActive(true);
        //paternAnim.SetTrigger("GameOverMode");

        //resumeBttn.SetActive(false);
        //settingsBttn.SetActive(false);
        //useBttn.SetActive(false);
        //delBttn.SetActive(false);
        //resumeUseBttn.SetActive(false);
        //resumeDelBttn.SetActive(false);
        //pauseBttn.SetActive(false);
        //equipBttns.SetActive(false);

        //gameOverTitle.SetActive(true);
        //replayBttn.SetActive(true);
    }  
}
