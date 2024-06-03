using UnityEngine;


/// <summary>
/// Singleton for MonoBehaviours
/// </summary>
/// <typeparam name="T"></typeparam>
[DisallowMultipleComponent]
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{    /// <summary>
    /// Singleton instance. May be null if DoNotDestroyOnLoad flag was not set.
    /// </summary>
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("MonoSingleton: object of type already exists, instance will be destroyed=" + typeof(T).Name);
            Destroy(this.gameObject);
            return;
        }

        Instance = this as T;
    }
}

