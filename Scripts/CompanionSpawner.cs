using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject companionPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private int maxCompanions = 3;

    private List<GameObject> companions = new List<GameObject>();
    [SerializeField] private ThrowCompanion throwCompanionScript; 

    private void Start()
    {
        StartCoroutine(GenerateCompanions());
    }

    private IEnumerator GenerateCompanions()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (companions.Count < maxCompanions)
            {
                SpawnCompanion();
            }
        }
    }

    private void SpawnCompanion()
    {
        GameObject newCompanion = Instantiate(companionPrefab, spawnPoint.position, Quaternion.identity);
        companions.Add(newCompanion);

        // Actualiza la lista de compañeros en ThrowCompanion
        if (throwCompanionScript != null)
        {
            throwCompanionScript.SetCompanions(companions);
        }
    }
}
