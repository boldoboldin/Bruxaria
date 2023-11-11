using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> itensSpawners;

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

            int itemType = Random.Range(0, 13);

            GameObject item = Instantiate(itensSpawners[itemType], spawPos, Quaternion.identity);
        }
    }
}
