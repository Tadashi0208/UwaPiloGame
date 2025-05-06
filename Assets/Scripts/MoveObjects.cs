using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    
    [SerializeField] Vector3 direction;

    public Transform[] target;
    public float speed = 6.0f;
    [SerializeField] float rotSpeed;
    int curPos = 0;
    int nextPos = 0;
    Vector3 currentPos;

    private void Start()
    {
        transform.rotation= Quaternion.LookRotation(direction);
        direction = (target[curPos].position - transform.position).normalized;
    }


    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target[nextPos].position, speed * Time.fixedDeltaTime);

        direction = (target[nextPos].position - transform.position).normalized;
        Quaternion rotDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotDirection, rotSpeed * Time.deltaTime);



        if (Vector3.Distance(transform.position, target[nextPos].position) <= 0)
        {
            curPos = nextPos;
            nextPos++;

            if (nextPos > target.Length - 1)
            {
                nextPos = 0;
            }
        }
    }
}
