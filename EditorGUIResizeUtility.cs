using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// A custom utility tool for resizing elements.
/// </summary>
public static class EditorGUIResizeUtility
{
    /// <summary>
    /// Changes the cursor pictogram at the handle rect to be a resize pictogram in the desired axis.
    /// </summary>
    public static void AddResizeCursor(Rect handle, bool isVertical) =>
        EditorGUIUtility.AddCursorRect(handle, isVertical ? MouseCursor.ResizeVertical : MouseCursor.ResizeHorizontal);

    /// <summary>
    /// Checks if the the mouse button has been pressed and the rect contains the mouse position.
    /// </summary>
    public static bool ContainsCursor(Rect handle) =>
        Event.current.type == EventType.MouseDown && handle.Contains(Event.current.mousePosition);

    /// <summary>
    /// Sets either the starting x position or starting y position at the current mouse position depending on boolean flag.
    /// </summary>
    public static float SetHandlePositionAtCursor(Rect handle, bool isVertical) =>
        isVertical ? handle.y = Event.current.mousePosition.y : handle.x = Event.current.mousePosition.x;

    /// <summary>
    /// Sets an array of handles depending on the total width calculated
    /// </summary>
    public static float SetHandlePositions(float[] widths, int index)
    {
        float pos = 0f;

        for (int i = 0; i <= index; i++)
            pos += widths[i];

        return pos;
    }

    /// <summary>
    /// Sets an array of handles depending on the total width calculated
    /// </summary>
    public static float SetHandlePositions(List<float> widths, int index)
    {
        float pos = 0f;

        for (int i = 0; i <= index; i++)
            pos += widths[i];

        return pos;
    }

    /// <summary>
    /// Resizes by setting the value at the mouse position. Value is depending on the isVertical flag.
    /// It automatically is clamped with a minimum value. 
    /// </summary>
    public static float ResizeElement(float minValue, bool isVertical)
    {
        float value;

        if (isVertical)
            value = Event.current.mousePosition.y;
        else
            value = Event.current.mousePosition.x;

        if(value < minValue)
            value = minValue;

        return value;
    }

    /// <summary>
    /// Resizes by setting the value at the mouse position. Value is depending on the isVertical flag.
    /// It automatically is clamped with a minimum and maximum value. 
    /// </summary>
    public static float ResizeElement(float minValue, float maxValue, bool isVertical)
    {
        float value;

        if (isVertical)
            value = Event.current.mousePosition.y;
        else
            value = Event.current.mousePosition.x;


        if (value < minValue)
            value = minValue;
        else if(value > maxValue)
            value = maxValue;

        return value;
    }

    /// <summary>
    /// Resizes an array of elements by calculating the total width up to the index and subtracting the value of the mouse position.
    /// value results of mouse position - calculated width.
    /// </summary>
    public static float ResizeElements(float[] widths, int index, bool isVertical)
    {
        float width = 0f;

        for (int i = 0; i < index; i++)
            width += widths[i];

        return isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;
    }

    /// <summary>
    /// Resizes an array of elements by calculating the total width up to the index and subtracting the value of the mouse position.
    /// It automatically is clamped with a minimum value.
    /// value results of mouse position - calculated width.
    /// </summary>
    public static float ResizeElements(float[] widths, float minWidth, int index, bool isVertical)
    {
        float width = 0f;

        for (int i = 0; i < index; i++)
            width += widths[i];

        if(width < minWidth)
            width = minWidth;

        return isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;
    }

    /// <summary>
    /// Resizes an array of elements by calculating the total width up to the index and subtracting the value of the mouse position.
    /// It automatically is clamped with a minimum value and maximum value.
    /// value results of mouse position - calculated width.
    /// </summary>
    public static float ResizeElements(float[] widths, float minWidth, float maxWidth, int index, bool isVertical)
    {
        float width = 0f;

        for (int i = 0; i < index; i++)
            width += widths[i];

        if (width < minWidth)
            width = minWidth;

        else if(width > maxWidth)
            width = maxWidth;

        return isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;
    }

    /// <summary>
    /// Resizes an array of elements by calculating the total width up to the index and subtracting the value of the mouse position.
    /// value results of mouse position - calculated width.
    /// </summary>
    public static float ResizeElements(List<float> widths, int index, bool isVertical)
    {
        float width = 0f;

        for (int i = 0; i < index; i++)
            width += widths[i];

        return isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;
    }

    /// <summary>
    /// Resizes an array of elements by calculating the total width up to the index and subtracting the value of the mouse position.
    /// It automatically is clamped with a minimum value and.
    /// value results of mouse position - calculated width.
    /// </summary>
    public static float ResizeElements(List<float> widths, float minWidth, int index, bool isVertical)
    {
        float width = 0f;

        for (int i = 0; i < index; i++)
            width += widths[i];

        if (width < minWidth)
            width = minWidth;

        return isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;
    }

    /// <summary>
    /// Resizes an array of elements by calculating the total width up to the index and subtracting the value of the mouse position.
    /// It automatically is clamped with a minimum value and maximum value.
    /// value results of mouse position - calculated width.
    /// </summary>
    public static float ResizeElements(List<float> widths, float minWidth, float maxWidth, int index, bool isVertical)
    {
        float width = 0f;

        for (int i = 0; i < index; i++)
            width += widths[i];

        if (width < minWidth)
            width = minWidth;

        else if(width > maxWidth)
            width = maxWidth;

        return isVertical ? Event.current.mousePosition.y - width : Event.current.mousePosition.x - width;
    }

    /// <summary>
    /// Subtracts value of the mouse cursor position depending on the flag provided.
    /// </summary>
    public static float SubtractOfMouseCursorPosition(float value, bool isVertical) =>
    isVertical ? Event.current.mousePosition.y - value : Event.current.mousePosition.x - value;

    /// <summary>
    /// Adds value of the mouse cursor position depending on the flag provided.
    /// </summary>
    public static float AddToMouseCursorPosition(float value, bool isVertical) =>
        isVertical ? Event.current.mousePosition.y + value : Event.current.mousePosition.x + value;
}
