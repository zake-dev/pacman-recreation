using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTween
{
    public Transform Target { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public PositionTween(Transform target, Vector3 startPos, Vector3 endPos, float startTime, float duration)
    {
        Target = target;
        StartPos = startPos;
        EndPos = endPos;
        StartTime = startTime;
        Duration = duration;
    }

    public void animate(float deltaTime)
    {
        float ellapsedTime = Time.time - StartTime;
        if (ellapsedTime > Duration) return;

        Target.position = Vector3.Lerp(StartPos, EndPos, ellapsedTime / Duration);
    }
}
