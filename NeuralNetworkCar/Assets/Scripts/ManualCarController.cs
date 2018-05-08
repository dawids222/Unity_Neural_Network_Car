using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualCarController : MonoBehaviour
{

    public KeyCode UpKey = KeyCode.W;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode LeftKey = KeyCode.A;

    public int MovementSpeed = 15;
    public int RotationSpeed = 90;

    // Update is called once per frame
    void Update ()
    {
        move();
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

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
