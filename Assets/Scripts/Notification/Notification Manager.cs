using UnityEngine;
using System.Collections;

public class NotificationManager : MonoBehaviour
{
    [SerializeField]
    private string[] channels = { "default" };
    
    private INotificationWrapper _wrapper;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _wrapper = new iOSNotificationWrapper();
        }
        else
        {
            _wrapper = new AndroidNotificationWrapper(channels);
        }

        _wrapper.ClearNotifications();

        DontDestroyOnLoad(this.gameObject);

        _wrapper.RequestAuthorization();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            RegisterNotifications();
        }
        else
        {
            _wrapper.ClearNotifications();
        }
    }

    private void RegisterNotifications()
    {
        //вычисления
        _wrapper.RegisterNotification("title", "body", DateTime.Now.AddDays(1), channels[0]);
    }

}
