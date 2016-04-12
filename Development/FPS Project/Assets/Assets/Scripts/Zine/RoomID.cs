using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum RoomType {Empty, MonsterHouse, Puzzle, Standard, DodgyLighting, UnaccasibleCloseDoor, Boss};
[ExecuteInEditMode]
public class RoomID : MonoBehaviour
{
    public RoomType roomType;
    public int roomID;
    public GameObject[] enemiesThatWillSpawnHere;
    public Transform[] spawnPoints;
    public List<bool> spawnBools = new List<bool>();
    [Range(0,10)]
    public int enemyFrequency;
    public int timeBetweenSpawn;
    public int roomLength;
    public int roomWidth;
    public int roomHeigth;
    public GameObject room;
    public GameObject spawnedRoom;
    public SpawnEnemy spawnEnemy;
    void Start()
    {
        spawnBools.Clear();
        for(int i = 0; i<spawnPoints.Length; i++)
        {
            spawnBools.Add(false);
            print(spawnBools.Count);
        }
        if(enemyFrequency>spawnPoints.Length)
        {
            enemyFrequency=spawnPoints.Length;
        }
        StartCoroutine("SpawnEnemy");
    }

    int GetRandomNumber()
    {
        return Random.Range(0,spawnPoints.Length);
    }

    int RNG ()
    {
        int rng = GetRandomNumber();
        while (spawnBools[rng]==true)
        {
            rng = GetRandomNumber();
        }
        return rng;
    }

    float CalculateFloorHeight()
    {
        float heigth = roomHeigth;
        heigth = heigth/2;
        heigth += 0.5f;
        return heigth;
    }

    public void BuildRoom()
    {
        if (spawnedRoom != null)
        {
            DestroyImmediate(spawnedRoom);

        }
        room.transform.localScale = new Vector3(roomWidth,1,roomLength);
        GameObject spawnedFloor = (GameObject) Instantiate(room,transform.position-new Vector3(0,CalculateFloorHeight(),0),transform.rotation);
        spawnedFloor.transform.SetParent(transform);
        spawnedRoom = spawnedFloor;
        
    }


    public IEnumerator SpawnEnemy()
    {
        for(int i = 0; i<enemyFrequency; i++)
        {
            int index = RNG();
            Instantiate(enemiesThatWillSpawnHere[Random.Range(0,enemiesThatWillSpawnHere.Length)],spawnPoints[index].position,spawnPoints[index].rotation);
            spawnEnemy.SpawnEnemy(enemiesThatWillSpawnHere[Random.Range(0, enemiesThatWillSpawnHere.Length)], spawnPoints[index].position, spawnPoints[index].position, spawnPoints[index].rotation);
            spawnBools[index]=true;
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,new Vector3(roomWidth,roomHeigth,roomLength));
    }
}
