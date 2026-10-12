using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class FixSceneFunc
{
    [MenuItem("Tools/Fix Scene")]
    public static void FixScene()
    {
        foreach (var gameObject in GameObject.FindObjectsOfType<GameObject>())
        {
            gameObject.hideFlags = HideFlags.None;
        }
    }
}
