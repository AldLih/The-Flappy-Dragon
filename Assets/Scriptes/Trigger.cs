using UnityEngine;

public class Trigger : MonoBehaviour
{
    public LogicScript logic;
    public Dragon dragon;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        dragon = GameObject.FindGameObjectWithTag("Dragon").GetComponent<Dragon>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Score") && dragon.isEggAlive)
        {
            logic.AddScore(1);
        }
    }
}
