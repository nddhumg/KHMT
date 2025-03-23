using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using Systems.Inventory;

namespace Systems.SaveLoad
{
    public static class SaveLoadSystem
    {
        private static IDataService dataService = new FileDataService(new JsonSerializer(), "json");

        public static IDataService DataService => dataService;

    }

}
