using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 5f;
    [SerializeField] float maxSpawnDelay = 10f;
    [SerializeField] Attacker [] attackerPrefabArray;

    private bool spawn = true;
    

    IEnumerator Start()
    {
        minSpawnDelay -= PlayerPrefsController.GetDifficulty();
        maxSpawnDelay -= PlayerPrefsController.GetDifficulty();
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (spawn)
                SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Instantiate(myAttacker, transform.position, transform.rotation, transform);
    }

}
