using UnityEngine;

public class LittleEnemy : GreenMucus
{
    protected override void ChaseToPlayer()
    {
        Vector3 targetPosition;
        if (playerObject == 1)
        {
            targetPosition = new Vector3(playerA.transform.position.x, transform.position.y, transform.position.z);
        }
        else if (playerObject == 2)
        {
            targetPosition = new Vector3(playerB.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
