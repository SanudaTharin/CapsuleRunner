
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacles()
    {
        //Choose random point on the ground tile and spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }

    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinToSpawn = 10;
        for (int i = 0; i < coinToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform); //Spawn coinPrefab

            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)  //Vector3 is a point in 3D space
    {
        Vector3 point = new Vector3(        //Generates random points within the collider

            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if (point != collider.ClosestPoint(point))  //Checks random point generated above is in the colider
                                                    //Collider means the 3d limit of the ground tile
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;   //All coins are in y=1 height

        return point; //Since the function is a Vector3, it will return a position in 3D space
    }
}
