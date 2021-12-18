using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    private GameObject character;
    public float rotationWaitSeconds;
    public float translationWaitSeconds;
    public Vector3 velocity;
    public float rotation;

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
            character.transform.Rotate(new Vector3(0f, rotation, 0f));
            yield return new WaitForSeconds(rotationWaitSeconds);

        }
    }

    public IEnumerator DoTranslation()
    {
        for (; ; )
        {
            transform.Translate(velocity, Space.World); // move
            yield return new WaitForSeconds(translationWaitSeconds);

        }
    }
}
