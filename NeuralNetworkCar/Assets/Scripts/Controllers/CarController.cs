using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class CarController : MonoBehaviour
{
    [Header("Steering")]
    public int MovementSpeed;
    public int RotationSpeed;

    [Header("Sensors")]
    public float SensorLength;
    public float SensorAngle;

    public float DistanceToLeftWall { get; private set; }
    public float DistanceToRightWall { get; private set; }

	
	// Update is called once per frame
	protected virtual void Update () {
        getDistanceToWalls();
    }

    public void MoveForward()
    {
        transform.position += transform.forward * MovementSpeed * Time.deltaTime;
    }

    public void TurnLeft()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * RotationSpeed);
    }

    public void TurnRight()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
    }

    private void getDistanceToWalls()
    {
        RaycastHit leftHit;
        RaycastHit rightHit;
        Vector3 leftSensorStartPosition = transform.position;
        Vector3 rightSensorStartPosition = transform.position;

        if (Physics.Raycast(leftSensorStartPosition, Quaternion.AngleAxis(-SensorAngle, transform.up) * transform.forward, out leftHit, SensorLength))
        {
            DistanceToLeftWall = Vector3.Distance(leftSensorStartPosition, leftHit.point);
            Debug.DrawLine(leftSensorStartPosition, leftHit.point);
        }

        if (Physics.Raycast(rightSensorStartPosition, Quaternion.AngleAxis(SensorAngle, transform.up) * transform.forward, out rightHit, SensorLength))
        {
            DistanceToRightWall = Vector3.Distance(rightSensorStartPosition, rightHit.point);
            Debug.DrawLine(rightSensorStartPosition, rightHit.point);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
