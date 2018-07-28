using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MJPGApp
{
  
    [BroadcastReceiver]
    public class MyReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Alarm Ringing!", ToastLength.Short).Show();

            /*AlertDialog.Builder dialog = new AlertDialog.Builder(context);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("ALARM");
            alert.SetMessage("ALARM RINGING");
        
            alert.Show();*/

          
            var resultIntent = new Intent(context, typeof(Phone));
            resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);

            var pending = PendingIntent.GetActivity(context, 0,
                resultIntent,
                PendingIntentFlags.CancelCurrent);

            var builders = new Notification.Builder(context)
                           .SetContentTitle("Its time to wake Up" + "!")
                           .SetContentText("Click to Cancel Alarm")
                           .SetSmallIcon(Resource.Drawable.Icon)
                          .SetDefaults(NotificationDefaults.All)
                          .SetAutoCancel(true);

            /*var builder =
                new Notification.Builder(context)
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetSmallIcon(Resource.Drawable.Icon)
                    .SetDefaults(NotificationDefaults.All);*/

             builders.SetContentIntent(pending);

           //var notification = builders.Build();

           // var manager = NotificationManager.FromContext(context);
           // manager.Notify(1337, notification);
        }
    }
}

