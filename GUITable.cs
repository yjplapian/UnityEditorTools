using UnityEngine;
using UnityEditor;

internal static class GUITable
{
    public static void DrawLine(Rect rect) =>
        GUI.DrawTexture(rect, EditorGUIUtility.whiteTexture);
    
    public static void DrawLine(Vector2 position, Vector2 size) =>
    GUI.DrawTexture(new Rect(position, size), EditorGUIUtility.whiteTexture);
    
    public static void DrawLine(float xMin, float yMin, float width, float height) =>
    GUI.DrawTexture(new Rect(xMin, yMin, width, height), EditorGUIUtility.whiteTexture);

    public static void DrawColumns(int columns, Rect[] textureRects) {
        for (int i = 0; i < columns; i++)
            DrawLine(textureRects[i]);
    }
    
    public static void DrawColumns(int columns, Vector2[] texturePositions, Vector2 textureSize) {
        for (int i = 0; i < columns; i++)
            DrawLine(texturePositions[i], textureSize);
    }
    
    public static void DrawColumns(int columns, Vector2[] texturePositions, Vector2[] textureSizes) {
        for (int i = 0; i < columns; i++)
            DrawLine(texturePositions[i], textureSizes[i]);
    }
    
    public static void DrawColumns(int columns, float[] xMin, float[] yMin, float[] width, float[] height) {
        for (int i = 0; i < columns; i++)
            DrawLine(xMin[i], yMin[i], width[i], height[i]);
    }

    public static void DrawRows(int rows, Rect[] textureRects) {
        for (int i = 0; i < rows; i++)
            DrawLine(textureRects[i]);
    }
    
    public static void DrawRows(int rows, Vector2[] texturePositions, Vector2 textureSize) {
        for (int i = 0; i < rows; i++)
            DrawLine(texturePositions[i], textureSize);
    }
    
    public static void DrawRows(int rows, Vector2[] texturePositions, Vector2[] textureSizes) {
        for (int i = 0; i < rows; i++)
            DrawLine(texturePositions[i], textureSizes[i]);
    }
    
    public static void DrawRows(int rows, float[] xMin, float[] yMin, float[] width, float[] height) {
        for (int i = 0; i < rows; i++)
            DrawLine(xMin[i], yMin[i], width[i], height[i]);
    }

    public static void DrawTable(int columns, Rect[] columnTextureLinePositions, int rows, Rect[] itemLinePositions) {
        DrawColumns(columns, columnTextureLinePositions);
        DrawRows(rows, itemLinePositions);
    }
    
    public static void DrawTable(int columns, Vector2[] columnTextureLinePositions, Vector2 columnLineSize, 
        int rows, Vector2[] itemTextureLinePositions, Vector2 itemLineSize) 
    {
        DrawColumns(columns, columnTextureLinePositions, columnLineSize);
        DrawRows(rows, itemTextureLinePositions, itemLineSize);
    }
    
    public static void DrawTable(int columns, Vector2[] columnTextureLinePositions, Vector2[] columnLineSizes,
    int rows, Vector2[] itemTextureLinePositions, Vector2[] itemLineSizes)
    {
        DrawColumns(columns, columnTextureLinePositions, columnLineSizes);
        DrawRows(rows, itemTextureLinePositions, itemLineSizes);
    }

    public static void DrawTable(int columns, float[] columnTextureXMin, float[] columnTextureYMin, float[] ColumnTextureWidth, 
        float[] ColumnTextureHeight, int rows, float[] itemTextureXMin, float[] itemTextureYMin, float[] itemColumnTextureWidth,
        float[] itemColumnTextureHeight)
    {
        DrawColumns(columns, columnTextureXMin, columnTextureYMin, ColumnTextureWidth, ColumnTextureHeight);
        DrawRows(rows, itemTextureXMin, itemTextureYMin, itemColumnTextureWidth, itemColumnTextureHeight);
    }
}
