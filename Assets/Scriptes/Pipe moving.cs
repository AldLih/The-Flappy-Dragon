using UnityEngine;


public class Pipemoving : MonoBehaviour
{
    [SerializeField] private float deadZone = -40;


    
    void Update()
    {
        float speed = Pipespawner.Instance.moveSpeed;

        Vector3 pos = transform.position;
        pos += Vector3.left * speed * Time.deltaTime;

        float ppu = 100f; 
        pos.x = Mathf.Round(pos.x * ppu) / ppu;

        transform.position = pos;

        if (pos.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
