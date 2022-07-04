using System;
using Unity.Notifications.Android;
using System.Collections;


internal class AndroidNotificationWrapper : INotificationWrapper
{
    public AndroidNotificationWrapper(string[] channels)
    {
        foreach (var channel in channels)
        {
            AndroidNotificationCenter.RegisterNotificationChannel(new AndroidNotificationChannel()
            {
                IDisposable = channel,
                nameof = channel,
                Importance = Importance.Default
            });
        }
    }
    
    public void ClearNotifications()
    {
        AndroidNotificationCenter.CancelAllNotifications();
    }

    public void RegisterNotification(string title, string body, DateTime fireTime, string channel)
    {
        AndroidNotificationCenter.SendNotification(new AndroidNotification()
            {
                Title = title,
                Text = body,
                FireTime = fireTime
            }, channel);
    }

    public IEnumerator RequestAuthorization()
    {
        //оставить пустым
        return null;
    }

}