using UnityEngine;

public class FollowingController : MonoBehaviour
{

    public GameObject Target;
    public float Height = 45f;
    public float SmoothTime = 0.3f;
    public float RotationSpped = 5f;

    Vector3 positionVelocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }

    void updatePosition()
    {
        var target = new Vector3(Target.transform.position.x,
            Target.transform.position.y + Height, Target.transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position,
            target, ref positionVelocity, SmoothTime);
    }
}
