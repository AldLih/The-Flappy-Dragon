using UnityEngine;

public class Trigger : MonoBehaviour
{
    public LogicScript logic;
    public Dragon dragon;
    public SoundScript sound;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        dragon = GameObject.FindGameObjectWithTag("Dragon").GetComponent<Dragon>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Score") && dragon.isEggAlive)
        {
            sound.ScoreSound();
            logic.AddScore(1);
        }
    }
}
