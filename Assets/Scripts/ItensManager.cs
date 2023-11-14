using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> commonItemsSpawners;
    [SerializeField] private List<GameObject> uncommonItensSpawners;
    [SerializeField] private List<GameObject> rareItensSpawners;

    [SerializeField] private float mimSpawTime;
    [SerializeField] private float maxSpawTime;
    private float currentSpawTime;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawTime = Random.Range(mimSpawTime, maxSpawTime);
    }

    // Update is called once per frame
    void Update()
    {
        ItemSpaw();
    }

    void ItemSpaw()
    {
        currentSpawTime -= Time.deltaTime;

        if (currentSpawTime <= 0)
        {
            currentSpawTime = Random.Range(mimSpawTime, maxSpawTime);

            float posY = Random.Range(-3.5f, 3.5f);
            Vector3 spawPos = new Vector2(10, posY);

            int itemType;

            int rarity = Random.Range(0, 100);

            if(rarity < 50) //Spaw Common Item
            {
                itemType = Random.Range(0, commonItemsSpawners.Count);
                GameObject item = Instantiate(commonItemsSpawners[itemType], spawPos, Quaternion.identity);
            }
            if (rarity >= 50 && rarity < 90) //Spaw Uncommon Item
            {
                itemType = Random.Range(0, uncommonItensSpawners.Count);
                GameObject item = Instantiate(uncommonItensSpawners[itemType], spawPos, Quaternion.identity);
            }
            if (rarity >= 90) //Spaw Rare Item
            {
                itemType = Random.Range(0, rareItensSpawners.Count);
                GameObject item = Instantiate(rareItensSpawners[itemType], spawPos, Quaternion.identity);
            }
        }
    }
}
