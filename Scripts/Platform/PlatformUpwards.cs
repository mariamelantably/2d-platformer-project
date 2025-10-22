using UnityEngine;

public class PlatformUpwards : MonoBehaviour
{
    [SerializeField] private Transform topEdge;
    [SerializeField] private Transform bottomEdge;
    [SerializeField] private float speed;

    private Vector3 initScale;
    private bool movingUp = true;

    [Header("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;


    private void Update()
    {
        if (!movingUp)
        {
            if (transform.position.y >= bottomEdge.position.y)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (transform.position.y <= topEdge.position.y)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
            movingUp = !movingUp;

    }

    private void MoveInDirection (int _direction)
    {
        idleTimer = 0;
        //Move
        transform.position = new Vector3(transform.position.x, Time.deltaTime*_direction*speed + transform.position.y, transform.position.z);
    }
}


