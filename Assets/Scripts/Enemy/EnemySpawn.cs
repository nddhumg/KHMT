using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : ObjectHandler {
	protected uint spawnCountPerWave = 6;
	private Vector2 sizeCamera;
	protected Vector2 randomMaxDistance = new Vector3(5f,5f);
	protected Vector2 randomMinDistance = new Vector3(2f,2f);
	[SerializeField] protected GameObject enemy;

	protected void Start(){
		sizeCamera.y = 2f * Camera.main.orthographicSize;
		sizeCamera.x = sizeCamera.y * Camera.main.aspect;
	}

	protected override void ResetValue ()
	{
		actionDelay = 1.3f;
	}

	protected override void HandleObject ()
	{
		Vector3 spawnPosition = new Vector3();
		Vector2 randomDistanceCamera = new Vector2();
		Vector3 positionCamera;
		for (int i = 0; i < spawnCountPerWave; i++) {
			positionCamera = Camera.main.transform.position;
			randomDistanceCamera.x = Random.Range (randomMinDistance.x, randomMaxDistance.x);
			randomDistanceCamera.y = Random.Range (randomMinDistance.x, randomMaxDistance.y) ;
			spawnPosition.x = positionCamera.x + GetRandomSign () * (sizeCamera.x/2 + randomDistanceCamera.x);
			spawnPosition.y = positionCamera.y + GetRandomSign() * sizeCamera.y/2 + GetRandomSign() * randomDistanceCamera.y;

			EnemyPool.instance.GetFromPool (enemy, spawnPosition, Quaternion.identity);
		}
	}

	protected int GetRandomSign(){
		return Random.value <= 0.5f ? -1 : 1;
	}
}
