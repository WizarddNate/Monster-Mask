using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public float speed;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("iswalking", false);
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //Debug.Log("Received movement input: " + direction);
            controller.Move(direction * speed * Time.deltaTime);
            anim.SetBool("iswalking", true);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
    }
}
