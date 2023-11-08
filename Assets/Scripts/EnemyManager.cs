using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

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

            int enemyType = Random.Range(0, 2);

            GameObject enemy = Instantiate(enemies[enemyType], spawPos, Quaternion.identity);
            Destroy(enemy, 5f);
        }
    }
}
