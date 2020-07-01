using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool isShaking = false;
    [SerializeField]
    private float shakeIntensity;
    [SerializeField]
    private float shakeAmount;

    private void Update()
    {
        if (isShaking)
        {
            Vector3 newPosition = Random.insideUnitSphere * (Time.deltaTime * shakeAmount);
            newPosition.z = transform.position.z; 
            transform.position = newPosition;
        }
    }
       

    public void shakeCamera()
    {
        StartCoroutine(shake());
    }

    private IEnumerator shake()
    {
        Vector3 originalPosition = transform.position;
        if (isShaking == false)
        {
            isShaking = true;
        }

        yield return new WaitForSeconds(shakeIntensity);
        isShaking = false;
        transform.position = originalPosition;

    }
}
