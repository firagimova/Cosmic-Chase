using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class AndroidNotificationsController : MonoBehaviour
{
#if UNITY_ANDROID
    private const string channel_id = "channel_id";
    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = channel_id,
            Name = "Channel Name",
            Importance = Importance.Default,
            Description = "Channel Descripton"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
        //print("register not");
        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Hint!!",
            Text = "Watching ad may help ;)",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, channel_id);
        //print("send not");
    }
#endif
}