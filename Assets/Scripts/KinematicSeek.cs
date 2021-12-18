using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MonoBehaviour
{
    private GameObject character;
    public GameObject target;
    public float rotationWaitSeconds;
    public float translationWaitSeconds;
    public float maxSpeed;

    // Update is called once per frame
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
            character.transform.LookAt(target.transform);
            yield return new WaitForSeconds(rotationWaitSeconds);

        }
    }

    public IEnumerator DoTranslation()
    {
        for (; ; )
        {
            Vector3 targetDirection = target.transform.position - character.transform.position;
            targetDirection.Normalize();
            Vector3 velocity = targetDirection * maxSpeed;
            transform.Translate(velocity, Space.World); // move
            yield return new WaitForSeconds(translationWaitSeconds);

        }
    }
}
