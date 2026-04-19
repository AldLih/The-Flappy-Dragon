using UnityEngine;


public class Pipemoving : MonoBehaviour
{
    [SerializeField] private float deadZone = -40;


    
    void Update()
    {
        float speed = Pipespawner.Instance.moveSpeed;
        transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
