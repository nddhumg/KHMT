using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.SaveLoad{
	public class SaveLoadSystem {
		private static SaveData saveData = new SaveData();
		private static IDataService dataService = new FileDataService (new JsonSerializer (), "json");

		[System.Serializable]
		public class SaveData  {
			
		}

		public static void SaveGame(){
			HandleSaveData ();
			dataService.Save <SaveData>(ref saveData);

		}

		private static void HandleSaveData(){
		}

		public static void LoadGame(){
			saveData = dataService.Load<SaveData> (typeof(SaveData).Name);
			HandleLoadData ();
		}	

		private static void HandleLoadData(){

		}
	}
}
