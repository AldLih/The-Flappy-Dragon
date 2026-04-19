using UnityEngine;


public class Pipemoving : MonoBehaviour
{
    public float movespeed = 20f;
    public float deadZone = -40;
    void Update()
    {
        transform.position = transform.position + (Vector3.left * movespeed* Time.deltaTime) ;
        if (transform.position.x< deadZone)
        {
            Destroy(gameObject);
        }
    }
}
