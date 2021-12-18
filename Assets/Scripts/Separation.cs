using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : MonoBehaviour
{

    private GameObject character;
    public float translationSpeed;
    public float translationWaitSeconds;
    public List<GameObject> targets;

    public float rotationSpeed;
    public float rotationWaitSeconds;

    public float separationRadius;

    void Start()
    {
        character = this.gameObject;
        targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Squad Member"));
        StartCoroutine(DoRotation());
        StartCoroutine(DoTranslation());
    }

    public IEnumerator DoRotation()
    {
        for (; ; )
        {
            foreach (GameObject target in targets)
            {
                if (target != this)
                {
                    Vector3 targetDirection = target.transform.position - character.transform.position;
                    float distance = targetDirection.magnitude;
                    targetDirection = -targetDirection;

                    if (distance < separationRadius)
                    {
                        float singleStep = DegreesToRadians(rotationSpeed);
                        Vector3 newDirection = Vector3.RotateTowards(character.transform.forward, targetDirection, singleStep, 0.0f);
                        transform.rotation = Quaternion.LookRotation(newDirection);
                    }
                }
            }

            yield return new WaitForSeconds(rotationWaitSeconds);
        }
    }

    public IEnumerator DoTranslation()
    {
        for (; ; )
        {
            character.transform.Translate(translationSpeed * character.transform.forward, Space.World);
            character.transform.forward = translationSpeed * character.transform.forward;
            yield return new WaitForSeconds(translationWaitSeconds);
        }
    }

    public static float DegreesToRadians(float degrees)
    {
        float radians = (Mathf.PI / 180) * degrees;
        return (radians);
    }

}
