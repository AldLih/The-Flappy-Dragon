using System;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float Strength;
    public LogicScript logic;
    public bool isEggAlive { get; private set; } = true;
    [SerializeField] private SoundScript soundScript;
    private float borderLine = 19f;



    private AudioSource audioSource;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        

    }
    void Update()
    {
        

        if (isEggAlive && Time.timeScale != 0)
        {
            bool isJump = Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began; 
            if (isJump)
            {
                soundScript.JumpSound();
                rb.linearVelocity = Vector2.up * Strength;
            }
        }

        if (isEggAlive)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
            {
                logic.PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 1) { logic.ContinueGame(); }
        }

        if (MathF.Abs(transform.position.y)>borderLine && isEggAlive )
        {
            Die();
        }
    }
    private void Die()
    {
        if (!isEggAlive && Time.timeScale != 0) return;
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
