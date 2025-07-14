using Core.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStateManager 
{
    public Enemy Enemy { get; }
    public void SetPosition(Vector3 position);
    public void SetPosition(Vector2 position);

    public Vector3 GetPosition();

    public Vector3 GetPositionPlayer();

    public Vector3 GetDirecTionToPlayer();
}
