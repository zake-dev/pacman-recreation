using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovementHandler : MonoBehaviour
{
    private AudioSource soundEffectSource;
    [SerializeField]
    private AudioClip moveSoundEffectClip;
    private Animator animator;
    private PositionTween positionTween;

    void Start()
    {
        soundEffectSource = gameObject.GetComponentInChildren<AudioSource>();
        animator = gameObject.GetComponent<Animator>();

        float moveSpeed = 0.3f; // move at 0.3s per single grid speed
        StartCoroutine(moveClockwiseAroundTopLeftBlock(moveSpeed));
        StartCoroutine(playMovingSound(moveSpeed));
    }

    void Update()
    {
        if (positionTween != null) positionTween.animate(Time.deltaTime);
    }

    private IEnumerator moveClockwiseAroundTopLeftBlock(float moveSpeed)
    {
        Vector3 topLeftCornerPosition = new Vector3(-13.0f, 16.0f, 0.0f);
        Vector3 topRightCornerPosition = new Vector3(-8.0f, 16.0f, 0.0f);
        Vector3 bottomLeftCornerPosition = new Vector3(-13.0f, 12.0f, 0.0f);
        Vector3 bottomRightCornerPosition = new Vector3(-8.0f, 12.0f, 0.0f);

        while (true)
        {
            float duration = 5 * moveSpeed;
            positionTween = new PositionTween(transform, topLeftCornerPosition, topRightCornerPosition, Time.time, duration);
            animator.SetTrigger("moveRight");
            yield return new WaitForSeconds(duration);

            duration = 4 * moveSpeed;
            positionTween = new PositionTween(transform, topRightCornerPosition, bottomRightCornerPosition, Time.time, duration);
            animator.SetTrigger("moveDown");
            yield return new WaitForSeconds(duration);

            duration = 5 * moveSpeed;
            positionTween = new PositionTween(transform, bottomRightCornerPosition, bottomLeftCornerPosition, Time.time, duration);
            animator.SetTrigger("moveLeft");
            yield return new WaitForSeconds(duration);

            duration = 4 * moveSpeed;
            positionTween = new PositionTween(transform, bottomLeftCornerPosition, topLeftCornerPosition, Time.time, duration);
            animator.SetTrigger("moveUp");
            yield return new WaitForSeconds(duration);
        }
    }

    private IEnumerator playMovingSound(float moveSpeed)
    {
        soundEffectSource.clip = moveSoundEffectClip;
        soundEffectSource.loop = false;

        while (true)
        {
            yield return new WaitForSeconds(moveSpeed);
            soundEffectSource.Play();
        }
    }
}
