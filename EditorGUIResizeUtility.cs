using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GUIResizeUtility
{
    public static void AddResizeCursor(Rect handle, bool isVertical) =>
        EditorGUIUtility.AddCursorRect(handle, isVertical ? MouseCursor.ResizeVertical : MouseCursor.ResizeHorizontal);

    public static bool IsDraggingHandle(Rect handle) =>
        Event.current.type == EventType.MouseDown && handle.Contains(Event.current.mousePosition);

    public static bool OnMouseUp() => 
        Event.current.type == EventType.MouseUp;

    public static float SetHandlePositionAtCursor(Rect handle, bool isVertical) =>
        isVertical ? handle.y = Event.current.mousePosition.y : handle.x = Event.current.mousePosition.x;

    public static float SetHandlePositions(float[] widths, int index)
    {
        float pos = 0f;

        for (int i = 0; i <= index; i++)
            pos += widths[i];

        return pos;
    }

    public static float SetHandlePositions(List<float> widths, int index)
    {
        float pos = 0f;

        for (int i = 0; i <= index; i++)
            pos += widths[i];

        return pos;
    }

    public static float ResizeElement(float minValue, bool isVertical)
    {
        float value;

        if (isVertical)
            value = Event.current.mousePosition.y;
        else
            value = Event.current.mousePosition.x;

        if (value < minValue)
            value = minValue;

        return value;
    }

    public static float ResizeElement(float minValue, float maxValue, bool isVertical)
    {
        float value;

        if (isVertical)
            value = Event.current.mousePosition.y;
        else
            value = Event.current.mousePosition.x;

        if (value < minValue)
            value = minValue;
        else if (value > maxValue)
            value = maxValue;

        return value;
    }

    public static float ResizeElements(float[] widths, int index, bool isVertical)
    {
        float width = 0f;

        for (int i = 0; i < index; i++)
            width += widths[i];

        return isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;
    }

    public static float ResizeElements(float[] widths, float minWidth, int index, bool isVertical)
    {
        float width = 0f;
        float value;

        for (int i = 0; i < index; i++)
            width += widths[i];

        value = isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;

        if (value < minWidth)
            value = minWidth;

        return value;
    }

    public static float ResizeElements(float[] widths, float minWidth, float maxWidth, int index, bool isVertical)
    {
        float width = 0f;
        float value;

        for (int i = 0; i < index; i++)
            width += widths[i];

        value = isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;

        if (value < minWidth)
            value = minWidth;
        else if (value > maxWidth)
            value = maxWidth;

        return value;
    }

    public static float ResizeElements(List<float> widths, int index, bool isVertical)
    {
        float width = 0f;

        for (int i = 0; i < index; i++)
            width += widths[i];

        return isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;
    }

    public static float ResizeElements(List<float> widths, float minWidth, int index, bool isVertical)
    {
        float width = 0f;
        float value;

        for (int i = 0; i < index; i++)
            width += widths[i];

        value = isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;

        if (value < minWidth)
            value = minWidth;

        return value;
    }

    public static float ResizeElements(List<float> widths, float minWidth, float maxWidth, int index, bool isVertical)
    {
        float width = 0f;
        float value;

        for (int i = 0; i < index; i++)
            width += widths[i];

        value = isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;

        if (value < minWidth)
            value = minWidth;
        else if (value > maxWidth)
            value = maxWidth;

        return value;
    }

    public static float SubtractOfMouseCursorPosition(float value, bool isVertical) =>
    isVertical ? Event.current.mousePosition.y - value : Event.current.mousePosition.x - value;

    public static float AddToMouseCursorPosition(float value, bool isVertical) =>
        isVertical ? Event.current.mousePosition.y + value : Event.current.mousePosition.x + value;
}
