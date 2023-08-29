using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnManager.RegisterSpawnPoint(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
