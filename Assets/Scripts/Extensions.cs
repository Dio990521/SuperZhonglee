using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool Raycast(this Rigidbody2D rigidbody2d, float radius, float distance, Vector2 direction, LayerMask layerMask)
    {
        if (rigidbody2d.isKinematic)
        {
            return false;
        }
        RaycastHit2D hit = Physics2D.CircleCast(rigidbody2d.position, radius, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody2d;
    }

    public static bool Raycast(this Rigidbody2D rigidbody2d, float radius, float distance, Vector2 direction, LayerMask layerMask1, LayerMask layerMask2)
    {
        if (rigidbody2d.isKinematic)
        {
            return false;
        }
        RaycastHit2D hit1 = Physics2D.CircleCast(rigidbody2d.position, radius, direction.normalized, distance, layerMask1);
        RaycastHit2D hit2 = Physics2D.CircleCast(rigidbody2d.position, radius, direction.normalized, distance, layerMask2);
        return hit1.collider != null && hit1.rigidbody != rigidbody2d || hit2.collider != null && hit2.rigidbody != rigidbody2d;
    }

    public static bool Raycast(this Rigidbody2D rigidbody2d, float radius, float distance, Vector2 direction, LayerMask layerMask1, LayerMask layerMask2, LayerMask layerMask3)
    {
        if (rigidbody2d.isKinematic)
        {
            return false;
        }
        RaycastHit2D hit1 = Physics2D.CircleCast(rigidbody2d.position, radius, direction.normalized, distance, layerMask1);
        RaycastHit2D hit2 = Physics2D.CircleCast(rigidbody2d.position, radius, direction.normalized, distance, layerMask2);
        RaycastHit2D hit3 = Physics2D.CircleCast(rigidbody2d.position, radius, direction.normalized, distance, layerMask3);
        return hit1.collider != null && hit1.rigidbody != rigidbody2d 
            || hit2.collider != null && hit2.rigidbody != rigidbody2d
            || hit3.collider != null && hit3.rigidbody != rigidbody2d;
    }

    public static bool DotProductTest(this Transform origin, Transform target, Vector2 testDirection)
    {
        Vector2 direction =  target.position - origin.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.5f;
    }
}
