using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RitghtTarget;

    public float Speed;

    public float StopTime;

    public Direction CurrentDirection;

    private bool _isStopped;

    public Transform RayStart;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    private void Start()
    {
        LeftTarget.parent = null;
        RitghtTarget.parent = null;
    }

    private void Update()
    {
        if(_isStopped == true)
        {
            return;
        }


        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime, 0f, 0f);
            if (transform.position.x < LeftTarget.position.x)
            {
                CurrentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0f, 0f);
            if (transform.position.x > RitghtTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnRightTarget.Invoke();
            }
        }

        //Перемещение свиньи на землю
        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    void ContinueWalk()
    {
        _isStopped = false;
    }
}
