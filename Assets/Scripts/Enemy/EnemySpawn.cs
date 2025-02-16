using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	private Vector2 sizeCamera;
	protected Vector2 randomMaxDistance = new Vector3(5f, 5f);
	protected Vector2 randomMinDistance = new Vector3(2f, 2f);

	protected uint spawnCountPerWave = 6;
	protected List<SpawnRate> possibleWaveEnemies = new List<SpawnRate>();
	[SerializeField] protected List<SOSpawnRate> allSpawnableEnemies;
    protected CoolDownTimer spawnTimer;
	[SerializeField] protected float delaySpawn = 1.3f;


	private void Awake()
	{
		spawnTimer = new CoolDownTimer(delaySpawn);
	}

	protected void Start() {
		possibleWaveEnemies = allSpawnableEnemies[0].SpawnRateList;

        spawnTimer.OnCoolDownEnd += SpawnWave;
		sizeCamera.y = 2f * Camera.main.orthographicSize;
		sizeCamera.x = sizeCamera.y * Camera.main.aspect;

	}
	private void Update()
	{
		spawnTimer.CountTime(Time.deltaTime);
	}

	protected virtual void SpawnWave()
	{
		Vector3 spawnPosition = new Vector3();
		Vector2 randomDistanceCamera = new Vector2();
		Vector3 positionCamera;
		GameObject enemy; 
		for (int i = 0; i < spawnCountPerWave; i++) {
            enemy = GetRandomEnemy();
            positionCamera = Camera.main.transform.position;
			randomDistanceCamera.x = UnityEngine.Random.Range(randomMinDistance.x, randomMaxDistance.x);
			randomDistanceCamera.y = UnityEngine.Random.Range(randomMinDistance.x, randomMaxDistance.y);
			spawnPosition.x = positionCamera.x + GetRandomSign() * (sizeCamera.x / 2 + randomDistanceCamera.x);
			spawnPosition.y = positionCamera.y + GetRandomSign() * sizeCamera.y / 2 + GetRandomSign() * randomDistanceCamera.y;

			EnemyPool.instance.GetFromPool(enemy, spawnPosition, Quaternion.identity);
		}
	}

	protected int GetRandomSign() {
		return UnityEngine.Random.value <= 0.5f ? -1 : 1;
	}

	protected GameObject GetRandomEnemy(){
		float rate = UnityEngine.Random.value;
		float temp = 0;
		foreach (SpawnRate rateEnemy in possibleWaveEnemies) {
			temp += rateEnemy.Rate;
			if(rate <= temp)
				return rateEnemy.Prefab; 
		}
		return null;

    }
}
