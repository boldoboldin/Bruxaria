using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private InventoryItensCtrl currentItem;
    public Image customCursor;

    public CraftingSlotsCtrl[] slots;

    public List<InventoryItensCtrl> itensList;
    public string[] recipes;
    public InventoryItensCtrl[] recipeResults;
    public CraftingSlotsCtrl resultSlot;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(currentItem != null)
            {
                customCursor.gameObject.SetActive(false);
                CraftingSlotsCtrl nearestSlot = null;
                float shortestDist = float.MaxValue;

                foreach(CraftingSlotsCtrl slot in slots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if(dist < shortestDist)
                    {
                        shortestDist = dist;
                        nearestSlot = slot;
                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestSlot.item = currentItem;
                itensList[nearestSlot.index] = currentItem;

                currentItem = null;
            }
        }

        CheckForCreatedRecipes();
    }

    void CheckForCreatedRecipes()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";

        foreach (InventoryItensCtrl item in itensList)
        {
            if (item != null)
            {
                currentRecipeString += item.itemName;
            }
            else
            {
                currentRecipeString += "null";
            }
        }

        for (int i = 0; i < recipes.Length; i++)
        {
            if(recipes[i] == currentRecipeString)
            {
                resultSlot.gameObject.SetActive(true);
                resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                resultSlot.item = recipeResults[i];
            }
        }
    }

    public void OnClickSlot(CraftingSlotsCtrl slot)
    {
        slot.item = null;
        itensList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }

    public void OnMouseDownItem(InventoryItensCtrl item)
    {
        if(currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
        }
    }
}
