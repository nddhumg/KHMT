using System.Collections.Generic;

namespace Systems.SaveLoad{
	public interface IDataService  {
		void Save<T>(ref T data, bool overwrite = true);
		T Load<T>(string name) where T : new();
		T Load<T>() where T : new();
        void Delete (string name);
		void DeleteAll ();
		IEnumerable<string> ListSave ();
	}

}