using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] public Player2DProfile _player;
    [SerializeField,Range(1,2)]public int inputPlayer;

    [Header("Camera Controller")]
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2 _minPos;
    private Vector2 _maxPos;

    [Header("Move")]
    private Vector2 moveDirection;
    float moveX;
    float moveY;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
    }

    void FixedUpdate()
    {
        CreateBoundary();
        if (this.GetComponent<Player2DStats>().PlayerHP > 0)
        {
            Move();
        }
    }
    void MoveInput()
    {
        if (inputPlayer == 1)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
        else if (inputPlayer == 2)
        {
            moveX = Input.GetAxisRaw("Horizontal2");
            moveY = Input.GetAxisRaw("Vertical2");
        }
        AnimatorMove();

        moveDirection = new Vector2(moveX, moveY);
    }
    
    void Move()
    {
        //rb.velocity = moveDirection * moveSpeed * 50 * Time.fixedDeltaTime;
        var velocityFromInput = moveDirection * _player.moveSpeed;
        transform.position += (Vector3)velocityFromInput * Time.deltaTime;

        transform.position = ClampPosition(transform.position);
    }
    void AnimatorMove()
    {
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    void CreateBoundary()
    {
        _minPos = _camera.ViewportToWorldPoint(new Vector3(0f, 0f, transform.position.z - _camera.transform.position.z));
        _maxPos = _camera.ViewportToWorldPoint(new Vector3(1f, 1f, transform.position.z - _camera.transform.position.z));

        _minPos += (Vector2)_spriteRenderer.bounds.extents;
        _maxPos -= (Vector2)_spriteRenderer.bounds.extents;
    }

    Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3(
            Mathf.Clamp(position.x, _minPos.x, _maxPos.x),
            Mathf.Clamp(position.y, _minPos.y, _maxPos.y),
            position.z
            );
    }
}
