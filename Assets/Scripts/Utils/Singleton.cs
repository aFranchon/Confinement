using UnityEngine;

//this is to say that T type has to be a singleton implementation
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singletont] Multiple Instance of singleton of type: " + typeof(T));
            return;
        }

        //casting this to fit the type of instance
        instance = (T) this;
    }

    protected virtual void OnDestroy()
    {
        if (instance != null)
        {
            instance = null;
        }
    }
}
