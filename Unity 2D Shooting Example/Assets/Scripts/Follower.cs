using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float maxShotDelay;
    public float curShotDelay;
    public ObjectManager objectManager;

    public Vector3 followrPos;
    public int followDelay;
    public Transform parent;
    public Queue<Vector3> parentPos;

    void Awake()
    {
        parentPos = new Queue<Vector3>();
    }

    void Update()
    {
        Watch();
        Follow();
        Fire();
        Reload();
    }

    void Watch()
    {
        if (!parentPos.Contains(parent.position))
        {
            parentPos.Enqueue(parent.position);
        }

        if (parentPos.Count > followDelay)
        {
            followrPos = parentPos.Dequeue();
        }
        else if (parentPos.Count < followDelay)
        {
            followrPos = parent.position;
        }
    }

    void Follow()
    {
        transform.position = followrPos;
    }

    void Fire()
    {
        if (!Input.GetButton("Fire1"))
        {
            return;
        }
        if (curShotDelay < maxShotDelay)
        {
            return;
        }

        GameObject bullet = objectManager.MakeObj("BulletFollower");
        bullet.transform.position = transform.position;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}
