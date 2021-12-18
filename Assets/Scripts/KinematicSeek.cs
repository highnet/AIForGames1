using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MonoBehaviour
{
    private GameObject character;
    public GameObject target;
    public float maxSpeed;

    public bool flee;

    private void Start()
    {
        character = this.gameObject;
    }

    public KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();


        if (!flee)
        {
            result.velocity = target.transform.position - character.transform.position;
        } else
        {
            result.velocity = character.transform.position - target.transform.position;
        }

        // the velocity is along this direction, at full speed.
        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        // face in the direction we want to move
        character.transform.forward = result.velocity;

        result.rotation = 0;
        return result;
    }

    private void Update()
    {
        KinematicSteeringOutput steering = GetSteering();
        character.transform.Translate(steering.velocity,Space.World);
    }
}
