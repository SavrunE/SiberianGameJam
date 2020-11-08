using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnDelay;
    public float TimeToChangeDelay = 5f;
    public float ValueToChangeDelay = 0.1f;
    public GameObject EnemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(ChangeDelay());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnDelay);
            Vector3 playerPosition = Player.Instance.transform.position;
            Vector3 newSpawnPosition = new Vector3(Random.Range(-50f, 50f), 0f , Random.Range(-50f, 50f))+ playerPosition;

            Instantiate(EnemyPrefab, newSpawnPosition, this.transform.rotation);
        }
    }
    IEnumerator ChangeDelay()
    {
        while(SpawnDelay > ValueToChangeDelay + 0.1f)
        {
            yield return new WaitForSeconds(TimeToChangeDelay);
            SpawnDelay -= ValueToChangeDelay;
        }
    }
}
