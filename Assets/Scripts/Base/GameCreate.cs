using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCreate : MonoBehaviour
{

    [Header("DonDestroy")]
    [SerializeField] protected GameObject music;
    [SerializeField] protected GameObject ads;
    [SerializeField] protected GameObject scene;

    protected void Awake()
    {
        //CreateUIGameSceen();
        CreateGameObjDontDestroy();
    }

    //protected void CreateUIGameSceen() {
    //    Instantiate(uiStatic);
    //    Instantiate(ui);
    //    SceneManager.MoveGameObjectToScene(uiStatic, SceneManager.GetSceneByName(EnumName.SceneName.UIGameScene.ToString()));
    //}

    protected void CreateGameObjDontDestroy() {
        Instantiate(music);
        Instantiate(ads);
        Instantiate(scene);
    }
}
