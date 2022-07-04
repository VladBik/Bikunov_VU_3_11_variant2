using System;
using System.Collections;

internal interface INotificationWrapper
{
    void RegisterNotification(string title, string body, DateTime fireTime, string channel);

    void ClearNotifications();
    public IEnumerator RequestAutorization();
}