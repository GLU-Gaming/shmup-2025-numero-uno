using UnityEngine;

public class EnemyBehaviourBase : MonoBehaviour
{
    private bool shoots = false;

    void Update()
    {
        MoveBehaviour();
        if (shoots)
        {
            ShootBehaviour();
        }
    }

    private void ShootBehaviour()
    {

    }

    private void MoveBehaviour()
    {

    }
}
