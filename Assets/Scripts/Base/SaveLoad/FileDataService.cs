using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Systems.SaveLoad{
	public class FileDataService : IDataService {
		ISerializer serializer;
		string dataPath;
		string fileExtension;

		public FileDataService(ISerializer serializer, string fileExtension){
			this.dataPath = Application.persistentDataPath;
			this.fileExtension = fileExtension;
			this.serializer = serializer;
		}
		public void Save<T>(ref T data, bool overwrite = true) {
			string fileLocation = GetPathToFile (typeof(T).Name);

			if (!overwrite && File.Exists (fileLocation)) {
				Debug.LogWarning ($"The file '{typeof(T).Name}.{fileExtension}' already exits and cannot be overwite." );
			}

			File.WriteAllText (fileLocation, serializer.Serialize (data));
		}

		public T Load <T>(string name) where T : new()
		{
			string fileLocation = GetPathToFile (name);

			if (!File.Exists (fileLocation)) {
				Debug.LogWarning ($"No presisted GameData with name '{name}'" );
				return new T();
			}
			T data = serializer.Deserialize<T>(File.ReadAllText(fileLocation));
			return data ?? new T();
		}

        public T Load<T>() where T : new()
        {
			return Load<T>(typeof(T).Name);
        }


        public void Delete (string name){
			string fileLocation = GetPathToFile (name);

			if (File.Exists (fileLocation)) {
				File.Delete (fileLocation);
			}
		}

		public void DeleteAll (){
			foreach (string filePath in Directory.GetFiles(dataPath)) {
				File.Delete (filePath);
			}
		}

		public IEnumerable<string> ListSave (){
			foreach (string path in Directory.EnumerateFiles(dataPath)) {
				if (Path.GetExtension (path) == fileExtension) {
					yield return Path.GetFileNameWithoutExtension (path);
				}
			}
		}


		private string GetPathToFile(string fileName){
			return Path.Combine (dataPath, string.Concat (fileName, ".", fileExtension));
		}
	}
}
