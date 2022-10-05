using UnityEngine;
using System;

public static class GUILayoutWrappers
{
    public static void HorizontalWrapper(int indent, Action action)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Space(indent);
        action();
        GUILayout.EndHorizontal();
    }

    public static void VerticalWrapper(int indent, Action action)
    {
        GUILayout.BeginVertical();
        GUILayout.Space(indent);
        action();
        GUILayout.EndVertical();
    }

    public static void AreaWrapper(Rect area, Action action)
    {
        GUILayout.BeginArea(area);
        action();
        GUILayout.EndArea();
    }

    public static Vector2 ScrollViewWrapper(Vector2 scrollPos, Action action)
    {
        scrollPos = GUILayout.BeginScrollView(scrollPos);
        action();
        GUILayout.EndScrollView();
        return scrollPos;
    }
}