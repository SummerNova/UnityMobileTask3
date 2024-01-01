using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] GameObject Parent;

    public void DisableParent()
    {
        Parent.SetActive(false);
    }
}
