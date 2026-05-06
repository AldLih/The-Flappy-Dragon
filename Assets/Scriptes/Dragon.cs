using System;
using System.Collections;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Collider2D mainCollider;
    [SerializeField] private Collider2D scoreTrigger;
    [SerializeField] private float Strength;
    [SerializeField] private UIScript uiScript;
    [SerializeField] private LogicScript logic;
    [SerializeField] private Animator animator;
    public bool isEggAlive { get; private set; } = true;
    [SerializeField] private SoundScript soundScript;
    private float borderLine = 19f;
    public bool dash = false;
    public bool x2 = false;

    private bool isX2Active = false; 
    private float x2Duration = 10f;
    private float x2CD = 10f;
    private bool enableX2 = true;
    private bool enableDash = true;
    private float dashCD = 10f;
    private float dashSpeed = 100f;
    private float moveSpeedBeforeDashSpeed;
    private float spawnRateBeforeDashSpeed;
    public bool isDashing = false;





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
        
        if (logic.isTutorial) return;

        if (isEggAlive && Time.timeScale != 0)
        {
            if ((Input.GetKeyDown(KeyCode.W)) || x2)
            {
                x2 = false;
                if (enableX2)
                {
                    StartCoroutine(X2());
                }
            }

            if ((Input.GetKeyDown(KeyCode.LeftShift)) || dash)
            {
                dash = false;
                if (enableDash)
                {
                    StartCoroutine(Dash());
                }
            }
            bool isJump = Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
            
            if (isJump)
            {
                soundScript.JumpSound();
                rb.linearVelocity = Vector2.up * Strength;
                animator.SetTrigger("isFlying");
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

        if (MathF.Abs(transform.position.y) > borderLine && isEggAlive)
        {
            Die();
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        enableDash = false;
        uiScript.ChangeDashButtonCollor(enableDash);
        mainCollider.enabled = false;
        spawnRateBeforeDashSpeed = Pipespawner.Instance.spawnRate;
        moveSpeedBeforeDashSpeed = Pipespawner.Instance.moveSpeed;
        soundScript.DashSound();
        Pipespawner.Instance.spawnRate = 0.5f;
        Pipespawner.Instance.maxSpeed = dashSpeed;
        Pipespawner.Instance.moveSpeed = dashSpeed;
        yield return new WaitForSeconds(soundScript.dashSound.length);
        mainCollider.enabled = true;
        isDashing = false;
        Pipespawner.Instance.spawnRate = spawnRateBeforeDashSpeed;
        Pipespawner.Instance.moveSpeed = moveSpeedBeforeDashSpeed;
        Pipespawner.Instance.maxSpeed = 45f;
        yield return new WaitForSeconds(dashCD);
        enableDash = true;
        uiScript.ChangeDashButtonCollor(enableDash);

    }

    IEnumerator X2()
    {
        enableX2 = false;
        isX2Active = true;
        logic.scoreMultiplier = 2;
        uiScript.ChangeX2ButtonCollor(enableX2, isX2Active);
        uiScript.UpdateScore(logic.playerScore, logic.scoreMultiplier);
        soundScript.X2Sound();
        yield return new WaitForSeconds(x2Duration);
        isX2Active = false;
        logic.scoreMultiplier = 1;
        uiScript.ChangeX2ButtonCollor(enableX2, isX2Active);
        uiScript.UpdateScore(logic.playerScore, logic.scoreMultiplier);
        yield return new WaitForSeconds(x2CD);
        enableX2 = true;
        uiScript.ChangeX2ButtonCollor(enableX2, isX2Active);
    }
    private void Die()
    {
        if (!isEggAlive) return;
        logic.GameOver();
        isEggAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isEggAlive && !isDashing)
        {
            Die();
        }
    }
}
