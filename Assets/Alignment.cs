using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : MonoBehaviour
{

    private GameObject character;
    public GameObject target;

    public float translationSpeed;
    public float rotationSpeed;
    public float rotationWaitSeconds;
    public float translationWaitSeconds;

    // Start is called before the first frame update
    void Start()
    {
        character = this.gameObject;
        target = GameObject.FindGameObjectWithTag("Squad Leader");
        StartCoroutine(DoRotation());
        StartCoroutine(DoTranslation());
    }

    public IEnumerator DoRotation()
    {
        for (; ; )
        {

            Vector3 rotation = target.transform.rotation.eulerAngles - character.transform.rotation.eulerAngles;
            character.transform.Rotate(rotation);
            
            yield return new WaitForSeconds(rotationWaitSeconds);
        }
    }

    public IEnumerator DoTranslation()
    {
        for (; ; )
        {

            transform.Translate(transform.forward * translationSpeed, Space.World); // move
            character.transform.forward = transform.forward * translationSpeed;

            yield return new WaitForSeconds(translationWaitSeconds);

        }
    }

    public static float DegreesToRadians(float degrees)
    {
        float radians = (Mathf.PI / 180) * degrees;
        return (radians);
    }

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
