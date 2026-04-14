using UnityEngine;

public class Pipespawner : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRate = 2;
    private float timer = 0;
    private float pipeRange = 9;
    private float nextSpawnX;
    void Start()
    {
        nextSpawnX = transform.position.x;
        Spawn(-10);
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Spawn(0);
            timer = 0;
        }
    }

    public void Spawn(int xRange)
    {
        nextSpawnX += 10;
        float pipeHighPos = transform.position.y + pipeRange;
        float pipeLowPos = transform.position.y - pipeRange;
        Instantiate(Pipe, new Vector3(nextSpawnX + xRange, Random.Range(pipeLowPos, pipeHighPos), 0), transform.rotation);
    }
}