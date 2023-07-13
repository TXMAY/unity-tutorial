using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("키 누름");
        }
        if (Input.anyKey)
        {
            Debug.Log("키 누르는 중");
        }
    }
}
