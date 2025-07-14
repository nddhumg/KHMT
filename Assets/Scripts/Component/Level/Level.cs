using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour  {
	[SerializeField]protected uint levelCurrent = 0;
	[SerializeField]protected uint levelMax = 1;

	public uint LevelCurrent{
		get{ 
			return levelCurrent;
		}
	}

	public virtual bool LevelUp(){
		levelCurrent++;
		if (levelCurrent > levelMax) {
			levelCurrent = levelMax;
			return false;
		}
		return true;
	}

	public virtual bool CanLevelUp(){
		return levelCurrent < levelMax;
	}
}
