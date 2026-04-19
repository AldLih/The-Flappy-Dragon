using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Pipespawner : MonoBehaviour
{
    [SerializeField] private GameObject Pipe;
    public static Pipespawner Instance;
    public float spawnRate = 2;
    private float timer = 0;
    private float pipeRange = 9;
    private float spawnOffset = 5f;
    public float moveSpeed = 10f;
    public float maxSpeed = 40f;
    void Start()
    {

    }
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Spawn();
            timer = 0;
        }
    }

    public void Spawn()
    {
        float CameraEdge = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect;
        float spawnX = CameraEdge + spawnOffset;
        float pipeHighPos = transform.position.y + pipeRange;
        float pipeLowPos = transform.position.y - pipeRange;
        Instantiate(Pipe, new Vector3(spawnX, Random.Range(pipeLowPos, pipeHighPos), 0), transform.rotation);
    }
}