using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class LinePlotter : MonoBehaviour {
    [SerializeField] private List<Vector3> points;
    public float x1 = 0f;
    public float y1 = 0f;
    public float m = 1f;
    public float c = 0f;

    [Range(-5, 5)]
    public int p = 1;

    public bool isCircle = false;
    public bool funkyMode = false;

    private void OnDrawGizmos() {
        //if there are points in the list
        if (points != null) {
            //set the gizmo colour
            Gizmos.color = Color.green;
            //draw a line between each point in the list
            for (int i = 0; i < points.Count - 1; i++) {
                //rotate hue each point
                Gizmos.color = Color.HSVToRGB((1.0f/points.Count)*i, 1, 1);
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
        }
    }

    private float CalcY(float x, float x1, float y1, float m, float c, int p) {
        return m * Mathf.Pow((x - x1), p) + c + y1;
    }

    private float CalcCircleY(float x, float x1, float c) {
        float ySqr = c - ((x - x1) * (x - x1));

        //stops the script from trying to square root a negative value
        float y = (ySqr >= 0) ? Mathf.Pow(ySqr, 0.5f) : -1 * Mathf.Pow(-ySqr, 0.5f);
        return y;
    }

    private void Start() {
        points = new List<Vector3>();

        float x = -10f;

        //create points to go on the line
        for (float xPos = x; xPos < 10f; xPos += 0.2f) {
            points.Add(new Vector3(xPos, CalcY(xPos, x1, y1, m, c, p), 0f));
        }
    }

    private void OnValidate() {
        //clears points list 
        points.Clear();
        
        float x = -10f;

        for (float xPos = x; xPos < 10f; xPos += 0.2f) {
            switch (isCircle) {
                case true:
                    //calculates circle
                    points.Add(new Vector3(xPos, CalcCircleY(xPos, x1, c), 0f));
                    if (funkyMode) {
                        //makes circle look funky :)
                        points.Add(new Vector3(xPos, -1 * CalcCircleY(xPos, x1, c), 0f));
                    }
                    break;
                case false:
                    //calculates non-circle line
                    points.Add(new Vector3(xPos, CalcY(xPos, x1, y1, m, c, p), 0f));
                    break;
            }
        }

        if (isCircle && !funkyMode) {
            //loops back from the end for bottom half of circle
            for (float xPos = -1 * x; xPos > x; xPos -= 0.2f) {
                points.Add(new Vector3(xPos, -1 * CalcCircleY(xPos, x1, c), 0f));
            }
        }
        Debug.Log("Repopulating gizmo positions");
    }
}
