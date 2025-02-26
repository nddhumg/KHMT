using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

[CustomEditor(typeof(UnityEngine.Object), true)]
public class IBindEditor : Editor
{
    private Editor objectEditor;

    private void OnEnable()
    {
        objectEditor = CreateEditor(target, typeof(ObjectEditor)); 
    }

    public override void OnInspectorGUI()
    {
        if (objectEditor != null)
        {
            objectEditor.OnInspectorGUI(); 
        }

        object targetObject = target;
        Type type = targetObject.GetType();
        Type iBindType = type.GetInterface("IBind`1");

        if (iBindType != null)
        {
            PropertyInfo idProperty = type.GetProperty("ID");
            if (idProperty != null && idProperty.PropertyType == typeof(string))
            {
                if (GUILayout.Button("Generate New GUID"))
                {
                    idProperty.SetValue(targetObject, Guid.NewGuid().ToString());
                    EditorUtility.SetDirty(target);
                }
            }
        }
    }
}
