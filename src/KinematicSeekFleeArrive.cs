using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeekFleeArrive : MonoBehaviour
{
    public enum Behaviour { Seek, Flee }

    public Behaviour behaviour;
    private GameObject character;
    public GameObject target;
    public float translationSpeed;
    public float rotationSpeed;
    public float rotationWaitSeconds;
    public float translationWaitSeconds;

    public float targetRadius;
    public float slowRadius;

    private void Start()
    {
        character = this.gameObject;
        StartCoroutine(DoRotation());
        StartCoroutine(DoTranslation());
    }

    public IEnumerator DoRotation()
    {
        for (; ; )
        {
            Vector3 targetDirection = target.transform.position - character.transform.position;

            if (behaviour == Behaviour.Flee)
            {
                targetDirection = -targetDirection;
            }
            float singleStep = DegreesToRadians(rotationSpeed);
            Vector3 newDirection = Vector3.RotateTowards(character.transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            yield return new WaitForSeconds(rotationWaitSeconds);

        }
    }

    public IEnumerator DoTranslation()
    {
        for (; ; )
        {
            Vector3 targetDirection = target.transform.position - character.transform.position;
            float distance = targetDirection.magnitude;
            if (distance >= targetRadius)
            {
                if (behaviour == Behaviour.Flee || distance > slowRadius)
                {
                    transform.Translate(transform.forward * translationSpeed, Space.World); // move

                } else
                {
                    transform.Translate((transform.forward * translationSpeed) * (distance / slowRadius), Space.World); // move
                }
            }
            yield return new WaitForSeconds(translationWaitSeconds);

        }
    }

    public static float DegreesToRadians(float degrees)
    {
        float radians = (Mathf.PI / 180) * degrees;
        return (radians);
    }
}
