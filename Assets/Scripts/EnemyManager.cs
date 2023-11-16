using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> commonEnemies;
    [SerializeField] private List<GameObject> uncommonEnemies;
    [SerializeField] private List<GameObject> rareEnemies;

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
        EnemySpaw();
    }

    void EnemySpaw()
    {
        currentSpawTime -= Time.deltaTime;

        if (currentSpawTime <= 0)
        {
            currentSpawTime = Random.Range(mimSpawTime, maxSpawTime);

            float posY = Random.Range(-3.5f, 3.5f);
            Vector3 spawPos = new Vector2(15, posY);

            int enemyType;

            int rarity = Random.Range(0, 100);

            if (rarity < 50) //Spaw Common Item
            {
                enemyType = Random.Range(0, commonEnemies.Count);
                GameObject enemy = Instantiate(commonEnemies[enemyType], spawPos, Quaternion.identity);

                Destroy(enemy, 12f);
            }
            if (rarity >= 50 && rarity < 90) //Spaw Uncommon Item
            {
                enemyType = Random.Range(0, uncommonEnemies.Count);
                GameObject enemy = Instantiate(uncommonEnemies[enemyType], spawPos, Quaternion.identity);

                Destroy(enemy, 12f);
            }
            if (rarity >= 90) //Spaw Rare Item
            {
                enemyType = Random.Range(0, rareEnemies.Count);
                GameObject enemy = Instantiate(rareEnemies[enemyType], spawPos, Quaternion.identity);

                Destroy(enemy, 12f);
            }
        }
    }
}
