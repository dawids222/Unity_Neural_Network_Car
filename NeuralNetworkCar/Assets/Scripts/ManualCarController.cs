using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualCarController : MonoBehaviour
{
    [Header("Steering")]
    public KeyCode UpKey = KeyCode.W;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode LeftKey = KeyCode.A;

    public int MovementSpeed = 15;
    public int RotationSpeed = 90;

    [Header("Sensors")]
    public float SensorLength;
    public float SensorAngle;


    public float DistanceToLeftWall { get; private set; }
    public float DistanceToRightWall { get; private set; }


    // Update is called once per frame
    void Update ()
    {
        move();

        getDistanceToWalls();
    }

    private void move()
    {
        if (Input.GetKey(UpKey))
        {
            transform.position += transform.forward * MovementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(RightKey))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        }
        if (Input.GetKey(LeftKey))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * RotationSpeed);
        }
    }

    private void getDistanceToWalls()
    {
        RaycastHit leftHit;
        RaycastHit rightHit;
        Vector3 leftSensorStartPosition = transform.position;
        Vector3 rightSensorStartPosition = transform.position;

        if(Physics.Raycast(leftSensorStartPosition, Quaternion.AngleAxis(-SensorAngle, transform.up) * transform.forward, out leftHit, SensorLength))
        {
            DistanceToLeftWall = Vector3.Distance(leftSensorStartPosition, leftHit.point);
            Debug.Log("Left: " + DistanceToLeftWall);    
        }

        if (Physics.Raycast(rightSensorStartPosition, Quaternion.AngleAxis(SensorAngle, transform.up) * transform.forward, out rightHit, SensorLength))
        {
            DistanceToRightWall = Vector3.Distance(rightSensorStartPosition, rightHit.point);
            Debug.Log("Right: " + DistanceToRightWall); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
