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
        float _horizontalInput = Input.GetAxis("Horizontal");
        float _verticalInput = Input.GetAxis("Vertical");

        //Vector for player
        Vector3 _direction = new Vector3(_horizontalInput, 0f, _verticalInput);

        //increment by speed
        Vector3 _velocity = _direction * _speed;

        //apply gravity because we dont use rigidbody with charactor controller. Its not physics base
        //should decrement gravity scale from velocity y axis
        _velocity.y -= _gravity;

        //set local space to global space
        _velocity = transform.transform.TransformDirection(_velocity);

        //charactor move
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
