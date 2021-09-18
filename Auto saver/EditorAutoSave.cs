#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace TelumaGames._Editor
{
    [InitializeOnLoad]
    public static class EditorAutoSave
    {
        private static float timer = 300;
        public static float resetTimer = 300;

        static EditorAutoSave()
        {
            EditorApplication.playModeStateChanged += SaveOnPlay;
            EditorApplication.update += SaveOnTime;
            EditorApplication.quitting += SaveOnClose;
        }

        public static void SaveOnPlay(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                Debug.Log("Auto Save : Exited Play Mode");

                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
            }
        }

        public static void SaveOnClose()
        {
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }

        [ExecuteInEditMode]
        public static void SaveOnTime()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            else if (timer <= 0 && !EditorApplication.isPlaying)
            {
                Debug.Log("Auto Save : Timed");
                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
                timer = resetTimer;
            }
        }
    }
}
#endif