using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private PlayerCtrl playerCtrl;

    [SerializeField] private RectTransform nameTag;

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image image;
    private ItensCtrl item;
    private TextMeshProUGUI amountText;


    public string itemName;
    public Vector2 nameTagSize = new Vector2 (3, 0.65f);
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        image = transform.Find("Image").GetComponent<Image>();
        amountText = transform.Find("AmountTxt").GetComponent<TextMeshProUGUI>();
        playerCtrl = FindObjectOfType<PlayerCtrl>();
    }

    private void Update()
    {
        if (playerCtrl.inventoryMode == "UseMode" || playerCtrl.inventoryMode == "DelMode")
        {
            canvasGroup.blocksRaycasts = false;
        }
        else if (playerCtrl.inventoryMode == "OrgMode")
        {
            canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
        UI_ItemDrag.Instance.Show(item);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        UI_ItemDrag.Instance.Hide();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Right click, split
            if (item != null)
            {
                // Has item
                if (item.IsStackable())
                {
                    // Is Stackable
                    if (item.amount > 1)
                    {
                        // More than 1
                        if (item.GetItemHolder().CanAddItem())
                        {
                            // Can split
                            int splitAmount = Mathf.FloorToInt(item.amount / 2f);
                            item.amount -= splitAmount;
                            ItensCtrl duplicateItem = new ItensCtrl { itemType = item.itemType, amount = splitAmount };
                            item.GetItemHolder().AddItem(duplicateItem);
                        }
                    }
                }
            }
        }
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
        Debug.Log("Set UI Sprite");
    }

    public void SetName(string itemName)
    {
        this.itemName = itemName; 
    }

    public void SetAmountText(int amount)
    {
        if (amount <= 1)
        {
            amountText.text = "";
        }
        else
        {
            // More than 1
            amountText.text = amount.ToString();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetItem(ItensCtrl item)
    {
        this.item = item;
        SetSprite(ItensCtrl.GetSprite(item.itemType));
        SetName(ItensCtrl.GetName(item.itemType));
        SetAmountText(item.amount);

        Debug.Log("Set UI Item");
    }

    public void UpdateNameTag(UI_Item item)
    {
        nameTag.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName;
        nameTag.sizeDelta = item.nameTagSize;
        nameTag.localPosition = new Vector2(item.nameTagSize.x / 2, 0.5f);
    }
}
