using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public void SpawnEnemies(GameObject enemy, Vector3 position, Quaternion rotation)
    {
        Instantiate(enemy, position, rotation);
        
    }

}
