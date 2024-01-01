using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InifiniteBackground : MonoBehaviour
{
    [SerializeField] PlayerController Player;

    private void OnValidate()
    {
        if (Player == null) throw new MissingReferenceException();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x - transform.position.x < -24) transform.Translate(new Vector3(-48, 0, 0));
        if (Player.transform.position.x - transform.position.x >  24) transform.Translate(new Vector3( 48, 0, 0));
        if (Player.transform.position.y - transform.position.y < -24) transform.Translate(new Vector3( 0,-48, 0));
        if (Player.transform.position.y - transform.position.y >  24) transform.Translate(new Vector3( 0, 48, 0));
    }
}
