using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 6;

    CharacterController player;

    [SerializeField] GameObject maiCamera;

    Vector3 camForward;
    Vector3 camRight;

    Vector3 direction;

    void Start()
    {
        player = GetComponent<CharacterController>();
        
    }

    
    void Update()
    {
        Move();
        player.Move(direction * Time.deltaTime * speed);
    }

    public void Move()
    {
        Vector2 inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        camForward=maiCamera.transform.forward;
        camRight=maiCamera.transform.right;
        camForward.y=0;
        camRight.y=0;

        direction=camRight*inputs.x+camForward*inputs.y;

        
    }
    
}
