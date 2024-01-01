using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 MoveDirection = Vector2.zero;
    public float Speed = 10f;
    [SerializeField] AnimationCurve Acceleration;
    [SerializeField] AnimationCurve Deceleration;
    [SerializeField] float DecelerationDuration = 1;
    [SerializeField] float AccelerationDuration = 1;

    private float currentSpeed = 0;
    private Vector2 LastAimed;
    private float AccelerationTimer = 0;
    private float DecelerationTimer = 0;
    private bool Accelerating = true;
    private bool Decelerating = false;

    // Update is called once per frame
    void Update()
    {
        if (MoveDirection == Vector2.zero && Decelerating)
        {
            Accelerating = true;
            AccelerationTimer = 0;
            DecelerationTimer += Time.deltaTime;
            Debug.Log("Decelerating - " + Deceleration.Evaluate(DecelerationTimer / DecelerationDuration));
            currentSpeed = (1-Deceleration.Evaluate(DecelerationTimer / DecelerationDuration)) * Speed;
            if (DecelerationTimer > DecelerationDuration) Decelerating = false;
        }

        if (MoveDirection != Vector2.zero && Accelerating)
        {
            Decelerating = true;
            DecelerationTimer = 0;
            AccelerationTimer += Time.deltaTime;
            Debug.Log("Accelerating - " + Acceleration.Evaluate(AccelerationTimer / AccelerationDuration));
            currentSpeed = (Acceleration.Evaluate(AccelerationTimer / AccelerationDuration)) * Speed;
            if (DecelerationTimer > DecelerationDuration) Accelerating = false;
        }

        if (MoveDirection != Vector2.zero) LastAimed = MoveDirection;
        transform.Translate(LastAimed*Time.deltaTime*currentSpeed);
    }
}
