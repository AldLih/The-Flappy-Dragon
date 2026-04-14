using System;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Strength;
    public LogicScript logic;
    public bool isEggAlive { get; private set; } = true;
    [SerializeField] private AudioClip jumpSound;
    private float borderLine = 19f;



    private AudioSource audioSource;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }
    void Update()
    {

        if (isEggAlive)
        {
            bool isJump = Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0); 
            if (isJump)
            {
                audioSource.PlayOneShot(jumpSound);
                rb.linearVelocity = Vector2.up * Strength;
            }

        }

        if (MathF.Abs(transform.position.y)>borderLine && isEggAlive )
        {
            Die();
        }
    }
    private void Die()
    {
        if (!isEggAlive) return;
        logic.GameOver();
        isEggAlive = false;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isEggAlive)
        {
            Die();
        }
    }
}
