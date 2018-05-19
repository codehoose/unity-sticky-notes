using UnityEngine;

public static class GameObjectExtensions
{
    /// <summary>
    /// Get component by interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public static T GetByInterface<T>(this GameObject gameObject) where T: class
    {
        foreach (var c in gameObject.GetComponents(typeof(MonoBehaviour)))
        {
            if (c.GetType().GetInterface(typeof(T).Name) != null)
            {
                return c as T;
            }
        }

        return default(T);
    }

    /// <summary>
    /// Get component by interface in children.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public static T GetByInterfaceInChildren<T>(this GameObject gameObject) where T: class
    {
        var component = GetByInterface<T>(gameObject);
        if (component != null)
            return component;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var chGo = gameObject.transform.GetChild(i);
            if (chGo == null || chGo.gameObject == null)
                continue;

            return GetByInterfaceInChildren<T>(chGo.gameObject);
        }

        return default(T);        
    }
}
