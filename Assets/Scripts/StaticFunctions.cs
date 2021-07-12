using UnityEngine;

public class StaticFunctions
{

    public static Vector2 GetRandomDirection()
    {
        float rangeFlyingDirection = 1f;
        
        var rangeX = Random.Range(-rangeFlyingDirection, rangeFlyingDirection);
        var rangeY = Random.Range(-rangeFlyingDirection, rangeFlyingDirection);

        var randomDirection = new Vector2(rangeX, rangeY);
        // Exclude the zero vector
        if (randomDirection != Vector2.zero)
            return randomDirection;

        return GetRandomDirection();
    }



}

