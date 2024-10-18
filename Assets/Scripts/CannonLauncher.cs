using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour
{
    //Publicly modifiable varaiables
    public float launchVelocity = 10f;
    public float launchAngle = 30f;
    public float gravity = -9.81f;

    public Vector3 v3InitialVelocity;
    public Vector3 v3CurrentVelocity;
    private Vector3 v3Acceleration;

    private float airTime = 0f;
    private float xDisplacement = 0f;
    private bool simulate = false;

    //Variables that relate to the drawing of the path of the projectile
    private List<Vector3> pathPoints;
    private int simulationSteps = 1000; //Number of points on the projectiles path

    private void Start() {
        //Initialise path vector for drawing
        pathPoints = new List<Vector3>();
        CalculateProjectile();
        CalculatePath();
    }

    private void Update() {
        if (!simulate) {
            pathPoints = new List<Vector3>();
            CalculateProjectile();
            CalculatePath();
        }
        DrawPath();
        if (Input.GetKeyDown(KeyCode.Space) && !simulate) {
            simulate = true;
            v3CurrentVelocity = v3InitialVelocity;
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            simulate = false;
            transform.position = Vector3.zero;
        }
    }

    private void CalculateProjectile() {
        //Work out velocity as vector quantity
        v3InitialVelocity.x = launchVelocity * Mathf.Cos(launchAngle * Mathf.Deg2Rad);
        v3InitialVelocity.y = launchVelocity * Mathf.Sin(launchAngle * Mathf.Deg2Rad);

        //Gravity as a vector
        v3Acceleration = new Vector3(0f, gravity, 0f);

        //Calculate total time in air
        float FinalYVel = 0f;
        airTime = 2f * (FinalYVel - v3InitialVelocity.y) / v3Acceleration.y;

        //Calculate total distance travelled in x
        xDisplacement = airTime * v3InitialVelocity.x;
    }

    private void FixedUpdate() {
        if (simulate) {
            Vector3 currentPos = transform.position;

            //Work out current velocity
            v3CurrentVelocity += v3Acceleration * Time.fixedDeltaTime;

            //Work out displacement
            Vector3 displacement = v3CurrentVelocity * Time.fixedDeltaTime;
            currentPos += displacement;
            transform.position = currentPos;
        }
    }

    private void CalculatePath() {
        Vector3 launchPos = transform.position;
        pathPoints.Add(launchPos);

        for (int i = 0; i <= simulationSteps; i++) {
            float simTime = (i / (float)simulationSteps) * airTime;
            //Suvat formula for displacement: s = ut + 0.5at^2
            Vector3 displacement = v3InitialVelocity * simTime + v3Acceleration * simTime * simTime * 0.5f;
            Vector3 drawPoint = launchPos + displacement;
            pathPoints.Add(drawPoint);
        }
    }

    private void DrawPath() {
        for (int i = 0; i < pathPoints.Count - 1; i++) {
            Debug.DrawLine(pathPoints[i], pathPoints[i + 1], Color.green);
        }
    }
}
