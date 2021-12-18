using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour
{

    private GameObject character;
    public GameObject target;
    public float maxSpeed;
    public float radius;
    public float timeToTarget;
    public bool flee;

    // Start is called before the first frame update
    void Start()
    {
        character = this.gameObject;   
    }

    public KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        // Get the direction to the target.
        if (!flee)
        {
            result.velocity = target.transform.position - character.transform.position;
        }
        else
        {
            result.velocity = character.transform.position - target.transform.position;
        }

        if (!flee && result.velocity.magnitude < radius)
        {
            // Request no steering
            return null;
        }

        // we need to move our target, we'd like to get there in timeToTarget seconds
        result.velocity /= timeToTarget;

        // if this is too fast, clip it to the max speed
        if (result.velocity.magnitude > maxSpeed || flee)
        {
            result.velocity.Normalize();
            result.velocity *= maxSpeed;
        }

        // face in the direction we want to move 
        character.transform.forward = result.velocity;

        result.rotation = 0;
        return result;

    }

    // Update is called once per frame
    void Update()
    {
        KinematicSteeringOutput steering = GetSteering();
        if (steering != null)
        {
            character.transform.Translate(steering.velocity, Space.World);
        }
    }
}
