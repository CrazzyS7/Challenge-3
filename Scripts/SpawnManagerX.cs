using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] mObjectPrefabs;

    private float mSpawnInterval = 1.5f;
    private float mSpawnDelay = 2.0f;
    private float mIntervalX = 30.0f;
    private float mMaxRangeY = 15.0f;
    private float mMinRangeY = 5.0f;

    private PlayerControllerX mPlayerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", mSpawnDelay, mSpawnInterval);
        mPlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(mIntervalX, Random.Range(mMinRangeY, mMaxRangeY), 0);
        int index = Random.Range(0, mObjectPrefabs.Length);

        // If game is still active, spawn new object
        if (!mPlayerControllerScript.mIsGameOver)
        {
            Instantiate(mObjectPrefabs[index], spawnLocation, mObjectPrefabs[index].transform.rotation);
        }

    }
}
