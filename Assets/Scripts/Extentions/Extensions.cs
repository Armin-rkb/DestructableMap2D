using UnityEngine;
using System;

public static class Extensions
{
    public static void Execute<T>(this GameObject target, Action<T> message)
    {
        T[] components = target.GetComponents<T>();
        
        foreach (T component in components)
        {
            message(component);
        }
    }
}
