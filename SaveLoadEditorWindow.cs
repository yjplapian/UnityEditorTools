using UnityEngine;
using UnityEditor;

public static class SaveLoadEditorWindow
{
    public static void JsonToWindow(string classContext, object type)
    {
        var data = EditorPrefs.GetString(classContext, JsonUtility.ToJson(type, false));
        JsonUtility.FromJsonOverwrite(data, type);
    }

    public static void EditorToJson(string classContext, object type)
    {
        var data = JsonUtility.ToJson(type, false);
        EditorPrefs.SetString(classContext, data);
    }
}