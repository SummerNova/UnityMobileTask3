using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 MoveDirection = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveDirection*Time.deltaTime);
    }
}