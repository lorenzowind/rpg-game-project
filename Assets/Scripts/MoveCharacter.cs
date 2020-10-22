using UnityEngine;

public class MoveCharacter : MonoBehaviour
{

    private float velocity;
    private Vector2 direction;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 3;
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterInput();
        transform.Translate(direction * velocity * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)
        {
            Animation(direction);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }
    }

    void CharacterInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
    }

    void Animation(Vector2 dir)
    {
        anim.SetLayerWeight(1, 1);

        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);
    }
}
