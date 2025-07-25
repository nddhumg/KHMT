using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum SceneName
{
    StartSceen,
    game,
}

public class LoadingSceneManager : PersistentSingleton<LoadingSceneManager>
{
    [SerializeField] protected GameObject goLoadingScene;
    [SerializeField] protected Slider sliderLoadingScene;
    [SerializeField] protected float delayLoadScene = 0.2f;
    public bool isDebug = false;

    private string sceneNameGame = "game";
    private string sceneNameUIGame = "UIGameScene";


    private void Start()
    {
        if (isDebug)
        {
            goLoadingScene.SetActive(false);
        }
        else
        {
            SwitchToSceneStartGame();
        }
    }

    public void SwichToScene(string id)
    {
        StartSwitchToScene();
        StartCoroutine(SwitchToSceneAsync(SceneManager.LoadSceneAsync(id)));
    }

    public void SwitchToSceneStartGame()
    {
        StartSwitchToScene();
        StartCoroutine(SwitchToSceneAsync(SceneManager.LoadSceneAsync(SceneName.StartSceen.ToString())));
        MusicManager.instance.PlayMusic(MusicKey.StartSceen);
    }

    public void SwitchToSceneGame(string mapId)
    {
        StartSwitchToScene();
        _ = SwitchGameAndUISceneCoroutine(mapId, () => { GameController.instance.Init(); });
    }


    private void StartSwitchToScene()
    {
        goLoadingScene.SetActive(true);
        sliderLoadingScene.value = 0;
    }

    IEnumerator SwitchToSceneAsync(AsyncOperation asyncLoad, Action onComplete = null)
    {
        asyncLoad.allowSceneActivation = false;
        
        while ( asyncLoad.progress < 0.9f)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            sliderLoadingScene.value = progress;
            yield return null;
        }
        asyncLoad.allowSceneActivation = true;
        yield return new WaitForSeconds(delayLoadScene);
        goLoadingScene.SetActive(false);
        onComplete?.Invoke();
    }

    private async Task SwitchGameAndUISceneCoroutine(string mapid, Action OnComplete = null)
    {
        Task loadTask = GameController.instance.LoadAddressableMap(mapid);

        AsyncOperation asyncGameLoad = SceneManager.LoadSceneAsync(sceneNameGame);
        asyncGameLoad.allowSceneActivation = false;

        while (asyncGameLoad.progress < 0.9f || !loadTask.IsCompleted)
        {
            sliderLoadingScene.value = Mathf.Clamp01(asyncGameLoad.progress / 0.9f);
            await Task.Yield();
        }

        await loadTask;
        asyncGameLoad.allowSceneActivation = true;

        AsyncOperation asyncUILoad = SceneManager.LoadSceneAsync(sceneNameUIGame, LoadSceneMode.Additive);
        while (!asyncUILoad.isDone)
        {
            await Task.Yield();
        }
        await Task.Delay(100);
        OnComplete?.Invoke();
        await Task.Delay((int)(delayLoadScene * 1000));
        goLoadingScene.SetActive(false);
    }

}
