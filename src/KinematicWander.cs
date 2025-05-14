using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicWander : MonoBehaviour
{

    private GameObject character;
    public float maxSpeed;
    public float maxRotation;
    public float rotationWaitSeconds;
    public float translationWaitSeconds;
     
    void Start()
    {
        character = this.gameObject;
        StartCoroutine(DoRotation());
        StartCoroutine(DoVelocity());
    }

    public float RandomBinomial()
    {
        return UnityEngine.Random.Range(0f,1f) - UnityEngine.Random.Range(0f, 1f);
    }

    public IEnumerator DoRotation()
    {
        for (; ; )
        {
            character.transform.rotation = Quaternion.Euler(new Vector3(0f, RandomBinomial() * maxRotation, 0f));
            yield return new WaitForSeconds(rotationWaitSeconds);
        }
    }

    public IEnumerator DoVelocity()
    {
        for (; ; )
        {
            character.transform.Translate(maxSpeed * character.transform.forward, Space.World);
            character.transform.forward = maxSpeed * character.transform.forward;
            yield return new WaitForSeconds(translationWaitSeconds);
        }
    }

}
