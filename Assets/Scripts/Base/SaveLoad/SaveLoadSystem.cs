using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Systems.SaveLoad
{
    public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem>
    {
        [SerializeField] private GameData saveData;
        private IDataService dataService;

        protected override void Awake()
        {
            base.Awake();
            dataService = new FileDataService(new JsonSerializer(), "json");
            LoadGame();
        }
        private void Start()
        {
            Bind<Inventory, InventorySave>(saveData.inventory);
        }

        private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
        private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        void OnSceneLoaded(Scene s, LoadSceneMode mode)
        {
        }

        void Bind<T, TData>(TData data) where T : MonoBehaviour, IBind<TData> where TData : ISaveable, new()
        {
            var entity = FindObjectsByType<T>(FindObjectsSortMode.None).FirstOrDefault();
            if (entity == null)
                return;
            if (data == null)
            {
                data = new TData() { ID = entity.ID };
            }
            entity.Bind(data);
        }

        void Bind<T, TData>(List<TData> datas) where T : MonoBehaviour, IBind<TData> where TData : ISaveable, new()
        {
            var entities = FindObjectsByType<T>(FindObjectsSortMode.None);
            foreach (var entity in entities)
            {
                var data = datas.FirstOrDefault(d => d.ID == entity.ID);
                if (data == null)
                {
                    data = new TData { ID = entity.ID };
                    datas.Add(data);
                }
                entity.Bind(data);
            }
        }
        [Button]
        public void SaveGame()
        {
            dataService.Save<GameData>(ref saveData);

        }
        [Button]
        public void LoadGame()
        {
            saveData = dataService.Load<GameData>(typeof(GameData).Name);
            if (saveData == null)
            {
                saveData = new();
            }
        }

    }

}
