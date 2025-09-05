using UnityEngine;
using System.Collections;

public class EdditeSpawner : MonoBehaviour
{
    public GameObject edditePrefab;
    public float spawnInterval;
    public Transform corner1;
    public Transform corner2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEddite());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEddite()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval * Random.Range(0.1f, 3f));
            Vector3 spawnPosition = new Vector3(Random.Range(corner1.position.x, corner2.position.x), 0, Random.Range(corner2.position.z, corner2.position.z));
            UnityEngine.AI.NavMeshAgent newAgent = Instantiate(edditePrefab, spawnPosition, Quaternion.identity, transform).GetComponent<UnityEngine.AI.NavMeshAgent>();
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(spawnPosition, out hit, 100f, UnityEngine.AI.NavMesh.AllAreas))
            {
                newAgent.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(hit.position);
            }
            
        }
    }
}
