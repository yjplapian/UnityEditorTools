using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class EditorGUIResizeUtility
{
    public static void CreateResizeCursor(Rect handle, bool isVertical) =>
        EditorGUIUtility.AddCursorRect(handle, isVertical ? MouseCursor.ResizeVertical : MouseCursor.ResizeHorizontal);

    public static bool ContainsCursor(Rect handle) =>
        handle.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseDown;

    public static void SetHandlePositionAtMouseCursor(Rect handle, bool isVertical)
    {
        if (isVertical)
            handle.y = Event.current.mousePosition.y;

        else
            handle.x = Event.current.mousePosition.x;
    }

    public static float ResizeElement(bool isVertical) =>
        isVertical ? Event.current.mousePosition.y : Event.current.mousePosition.x;

    public static float ResizeElement(float minWidth, bool isVertical)
    {
       var width = isVertical ? Event.current.mousePosition.y : Event.current.mousePosition.x;

        if(width < minWidth)
            width = minWidth;

        return width;
    }

    public static float ResizeElement(float minWidth, float maxWidth, bool isVertical)
    {
        var width = isVertical ? Event.current.mousePosition.y : Event.current.mousePosition.x;

        if (width < minWidth)
            width = minWidth;

        else if (width > maxWidth)
            width = maxWidth;

        return width;
    }

    public static float ResizeElements(List<float> excessWidths, bool isVertical)
    {
        var trimWidth = 0f;

        for (int i = 0; i < excessWidths.Count; i++)
            trimWidth += excessWidths[i];

       return isVertical ? Event.current.mousePosition.y : Event.current.mousePosition.x - trimWidth;
    }

    public static float ResizeElements(List<float> excessWidths, float minWidth, bool isVertical)
    {
        var trimWidth = 0f;
        float width;

        for (int i = 0; i < excessWidths.Count; i++)
            trimWidth += excessWidths[i];

        width = SubtractOfMouseCursorPosition(trimWidth, isVertical);

        if (width < minWidth)
            width = minWidth;

        return width;
    }

    public static float ResizeElements(List<float> excessWidths, float minWidth, float maxWidth, bool isVertical)
    {
        var trimWidth = 0f;
        float width;

        for (int i = 0; i < excessWidths.Count; i++)
            trimWidth += excessWidths[i];

        width = SubtractOfMouseCursorPosition(trimWidth, isVertical);

        if (width < minWidth)
            width = minWidth;

        else if(width > maxWidth)
            width = maxWidth;

        return width;
    }

    public static float SubtractOfMouseCursorPosition(float value, bool isVertical) =>
        isVertical ? Event.current.mousePosition.y - value : Event.current.mousePosition.x - value;

    public static float AddToMouseCursorPosition(float value, bool isVertical) =>
        isVertical ? Event.current.mousePosition.y + value : Event.current.mousePosition.x + value;
}