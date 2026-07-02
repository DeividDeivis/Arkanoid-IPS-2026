using System.Drawing;
using UnityEngine;

public class PointSystem
{
    public PointSystem(int maxPoints)
    {
        PointsToWin = maxPoints;
        points = 0;
    }

    private int points = 0;
    public int CurrentPoints => points;
    private int PointsToWin = 0;
    public bool IsWin => points >= PointsToWin ? true : false;

    public void AddPoints(int pointsToAdd = 1)
    {
        points += pointsToAdd;
        //points = Mathf.Clamp(points, 0, PointsToWin);
        UIController.Instance?.SetPointsUI(points);
    }

    public void ResetPoint()
    {
        points = 0;
    }
}
