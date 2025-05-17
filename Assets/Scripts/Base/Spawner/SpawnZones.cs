using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZones : MonoBehaviour
{
    [SerializeField] private Vector2 randomMaxDistance = new Vector3(1f, 1f);
    private Vector3 positionCamera = new();
    private Vector2 randomDistanceCamera = new Vector2();
    private Vector3 spawnPosition = new Vector3();

    public Vector2 GetRandomSpawnPosition()
    {
        Vector2 sizeCamera = CameraMain.instance.Size;
        sizeCamera = sizeCamera / 2;
        positionCamera = Camera.main.transform.position;
        randomDistanceCamera.x = Random.Range(0f, sizeCamera.x + randomMaxDistance.x);
        randomDistanceCamera.y = Random.Range(randomDistanceCamera.x <= sizeCamera.x ? sizeCamera.y : 0, sizeCamera.y + randomMaxDistance.y);

        spawnPosition.x = randomDistanceCamera.x * GetRandomSign() + positionCamera.x;
        spawnPosition.y = randomDistanceCamera.y * GetRandomSign() + positionCamera.y;
        return spawnPosition;
    }

    protected int GetRandomSign()
    {
        return Random.value <= 0.5f ? -1 : 1;
    }
}
