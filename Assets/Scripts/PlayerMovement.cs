using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string IsRun = "IsRun";
    private const string IsJump = "IsJump";

    [SerializeField] private float _speed;
    [SerializeField] private float _thrust;

    private Animator _animator;

    private bool _isOnSurfase = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.D)) 
        {
            int MovementDirection = 1;
            DescribeMovement(MovementDirection);
        }

        else if(Input.GetKey(KeyCode.A)) 
        {
            int MovementDirection = -1;
            DescribeMovement(MovementDirection);
        }

        else 
        {
            _animator.SetBool(IsRun, false);
        }

        if(Input.GetKeyDown(KeyCode.W)) 
        {
            if(_isOnSurfase == true) 
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * _thrust, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Ground ground)) 
        {
            _animator.SetBool(IsJump, false);
            _isOnSurfase = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Ground ground)) 
        {
            _animator.SetBool(IsJump, true);
            _isOnSurfase = false;
        }
    }

    private void DescribeMovement(int movementDirection)
    {
        _animator.SetBool(IsRun, true);
        transform.Translate(_speed * Time.deltaTime * movementDirection, 0, 0);
        Vector3 newScale = new Vector3(movementDirection, transform.localScale.y, transform.localScale.z);
        transform.localScale = newScale;
    }
}

