using System.Collections.Generic;
using UnityEngine;

namespace Systems.SaveLoad{
	public interface IDataService  {
		void Save<T>(ref T data, bool overwrite = true);
		T Load<T>(string name,GameObject obj);
		T Load<T>(GameObject obj);
        void Delete (string name);
		void DeleteAll ();
		IEnumerable<string> ListSave ();
	}

}