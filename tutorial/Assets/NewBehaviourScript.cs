using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rigid.AddForce(vec, ForceMode.Impulse);
    }
}
