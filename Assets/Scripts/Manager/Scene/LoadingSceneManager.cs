using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : PersistentSingleton<LoadingSceneManager>
{
    [SerializeField] protected GameObject goLoadingScene;
    [SerializeField] protected Slider sliderLoadingScene;
    [SerializeField] protected float delayLoadScene = 0.2f;

    private string sceneNameGame = "game";
    private string sceneNameUIGame = "UIGameScene";


    private void Start()
    {
        StartCoroutine(SwitchToSceneAsync(SceneManager.LoadSceneAsync(1), GameController.instance.OnCreateSceneGame));
    }

    public void SwichToScene(string id)
    {
        StartSwitchToScene();
        StartCoroutine(SwitchToSceneAsync(SceneManager.LoadSceneAsync(id)));
    }

    public void SwitchToSceneGame(string mapId) {
        StartSwitchToScene();
        StartCoroutine(SwitchGameAndUISceneCoroutine(() => OnCompleteLoadSceneGame(mapId)));
    }

    protected void OnCompleteLoadSceneGame(string mapId) { 
        GameController.instance.Init(mapId);
    }

    private void StartSwitchToScene() {
        goLoadingScene.SetActive(true);
        sliderLoadingScene.value = 0;
    }

    IEnumerator SwitchToSceneAsync(AsyncOperation asyncLoad, Action onComplete = null)
    {
        asyncLoad.allowSceneActivation = false;
        float timer = 0f;

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            sliderLoadingScene.value = progress;

            if (asyncLoad.progress >= 0.9f)
            {
                timer += Time.deltaTime;
                if (timer >= delayLoadScene)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }

            yield return null;
        }

        goLoadingScene.SetActive(false);
        onComplete?.Invoke();
    }

    private IEnumerator SwitchGameAndUISceneCoroutine(Action onComplete = null)
    {
        AsyncOperation asyncGameLoad = SceneManager.LoadSceneAsync(sceneNameGame);
        asyncGameLoad.allowSceneActivation = false;

        while (asyncGameLoad.progress < 0.9f)
        {
            sliderLoadingScene.value = Mathf.Clamp01(asyncGameLoad.progress / 0.9f);
            yield return null;
        }

        yield return new WaitForSeconds(delayLoadScene);

        asyncGameLoad.allowSceneActivation = true;

        while (!asyncGameLoad.isDone)
            yield return null;

        AsyncOperation asyncUILoad = SceneManager.LoadSceneAsync(sceneNameUIGame, LoadSceneMode.Additive);
        while (!asyncUILoad.isDone)
            yield return null;

        goLoadingScene.SetActive(false);
        onComplete?.Invoke();
    }

}
