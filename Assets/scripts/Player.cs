using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocity;
    float timer = 2;
    float xDirection = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            xDirection *= -1;
            timer = 4;
        }

        Move();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector3 (xDirection, 0, 0).normalized * velocity;
    }

}
