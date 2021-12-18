using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{

    public Vector3 position;
    public float orientation;

    public Vector3 velocity;
    public float rotation;

    public SteeringOutput steering;

    // Update is called once per frame
    void FixedUpdate()
    {
        float time = Time.time;

        // Update the position and orientation
        position += velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;

        // Update the velocity and rotation
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;

        transform.SetPositionAndRotation(position,
        Quaternion.Euler(new Vector3(0f, rotation, 0f)));
     }
}
