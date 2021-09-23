using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Create coroutine of IEnumerator to use yield events
    // Spawn enemies every 5 seconds
    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-10.07f, 10.07f), 12, 0); // Set vector3 of where enemy spawns  
            GameObject newEnemy = Instantiate(_enemy, posToSpawn, Quaternion.identity); // Define object being instantiated
            newEnemy.transform.parent = _enemyContainer.transform; // Create enemy as a child of enemy container
            yield return new WaitForSeconds(5.0f); // Wait 5 seconds before performing again
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
