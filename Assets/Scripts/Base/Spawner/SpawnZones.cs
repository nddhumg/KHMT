using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZones : MonoBehaviour
{
    private Vector2 sizeCamera = new();
    private Vector2 randomMaxDistance = new Vector3(5f, 5f);
    private Vector2 randomMinDistance = new Vector3(2f, 2f);
    private Vector3 positionCamera = new();
    private Vector2 randomDistanceCamera = new Vector2();
    private Vector3 spawnPosition = new Vector3();

    private void Start()
    {
        sizeCamera.y = 2f * Camera.main.orthographicSize;
        sizeCamera.x = sizeCamera.y * Camera.main.aspect;
    }

    public Vector2 GetRandomSpawnPosition(){
        randomDistanceCamera.x = Random.Range(randomMinDistance.x, randomMaxDistance.x);
        randomDistanceCamera.y = Random.Range(randomMinDistance.x, randomMaxDistance.y);
        positionCamera = Camera.main.transform.position;
        
        spawnPosition.x = positionCamera.x + GetRandomSign() * (sizeCamera.x / 2 + randomDistanceCamera.x);
        spawnPosition.y = positionCamera.y + GetRandomSign() * sizeCamera.y / 2 + GetRandomSign() * randomDistanceCamera.y;
        return spawnPosition;
    }

    protected int GetRandomSign()
    {
        return Random.value <= 0.5f ? -1 : 1;
    }
}
