using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private float _gravity = 9.81f;

    private CharacterController _characterController;

    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();   
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        //Vector for player
        Vector3 _direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        //increment by speed
        Vector3 _velocity = _direction * _speed;

        //apply gravity
        //should decrement gravity scale from velocity y axis
        _velocity.y -= _gravity;

        //charactor move
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
