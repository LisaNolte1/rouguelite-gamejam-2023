using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsEffect : MonoBehaviour, IEffect
{
    // Start is called before the first frame update
    public GameObject orbPrefab;        // Assign the orb prefab in the Inspector
    void Start()
    {
        
    }

    public void ApplyEffect(GameObject player)
    {
        float OrbsAmount = 3;
        float OrbsDistance = 3;

        List<GameObject> list = new List<GameObject>();
        GameObject orb = Resources.Load<GameObject>("OrbPrefab");

        for (int i = 0; i < OrbsAmount; i++)
        {
            float angle = i * 360f / OrbsAmount;
            Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, 0f, angle) * Vector3.right * OrbsDistance;

           GameObject currentOrb =  Instantiate(orb, spawnPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
