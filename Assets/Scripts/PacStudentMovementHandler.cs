using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovementHandler : MonoBehaviour
{
    private AudioSource soundEffectSource;
    private Animator animator;
    private PositionTween positionTween;

    void Start()
    {
        soundEffectSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        transform.position = new Vector3(-13.0f, 16.0f, 0.0f);
        StartCoroutine(moveClockwiseAroundTopLeftBlock());
    }

    void Update()
    {
        if (positionTween != null) positionTween.animate(Time.deltaTime);
    }

    private IEnumerator moveClockwiseAroundTopLeftBlock()
    {
        float moveSpeed = 0.3f; // move at 0.3s per single grid speed

        Vector3 topLeftCornerPosition = new Vector3(-13.0f, 16.0f, 0.0f);
        Vector3 topRightCornerPosition = new Vector3(-8.0f, 16.0f, 0.0f);
        Vector3 bottomLeftCornerPosition = new Vector3(-13.0f, 12.0f, 0.0f);
        Vector3 bottomRightCornerPosition = new Vector3(-8.0f, 12.0f, 0.0f);

        while (true)
        {
            float duration = 5 * moveSpeed;
            positionTween = new PositionTween(transform, topLeftCornerPosition, topRightCornerPosition, Time.time, duration);
            yield return new WaitForSeconds(duration);

            duration = 4 * moveSpeed;
            positionTween = new PositionTween(transform, topRightCornerPosition, bottomRightCornerPosition, Time.time, duration);
            yield return new WaitForSeconds(duration);

            duration = 5 * moveSpeed;
            positionTween = new PositionTween(transform, bottomRightCornerPosition, bottomLeftCornerPosition, Time.time, duration);
            yield return new WaitForSeconds(duration);

            duration = 4 * moveSpeed;
            positionTween = new PositionTween(transform, bottomLeftCornerPosition, topLeftCornerPosition, Time.time, duration);
            yield return new WaitForSeconds(duration);
        }
    }
}
