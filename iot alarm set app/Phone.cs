
using
    System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Util;
using System.Collections.Generic;

namespace MJPGApp
{
    [Activity(Label = " Enterprise Alarm Security", MainLauncher = false)]
    public class Phone : Activity
    { 
   //DECLARE WIDGETS
        private Button startBtn;
    private EditText timeTxt;
    private TimePicker TimePicker;
    private TextView alarmTextView;
    private Button start_alarm, stop_alarm;


    protected override void OnCreate(Bundle bundle)
    {
           // MainActivity.fa.Finish();
            base.OnCreate(bundle);
           

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.SecondPage);

        this.initializeViews();
            //MainActivity.fa.Finish();

    }
    /*
INITIALIZE VIEWS
*/
    private void initializeViews()
    {
        timeTxt = FindViewById<EditText>(Resource.Id.timeTxt);
        startBtn = FindViewById<Button>(Resource.Id.startBtn);


        TimePicker = FindViewById<TimePicker>(Resource.Id.alarmTimePicker);

        start_alarm = FindViewById<Button>(Resource.Id.start_alarm);

        stop_alarm = FindViewById<Button>(Resource.Id.stop_alarm);

        alarmTextView = FindViewById<TextView>(Resource.Id.alarmText);




        Calendar currentCal = Java.Util.Calendar.GetInstance(Java.Util.TimeZone.Default);

        start_alarm.Click += startBtn_Click;

        stop_alarm.Click += stopBtn_Click;

    }

    void stopBtn_Click(object sender, EventArgs e)
    {
       // Intent i = new Intent(this, typeof(MyReceiver));
        AlarmManager alarmManager = (AlarmManager)GetSystemService(AlarmService);
            Intent i = new Intent(this, typeof(MyReceiver));
           // StartActivity(i);
            PendingIntent pi = PendingIntent.GetBroadcast(this, 0, i, 0);

       alarmManager.Cancel(pi);
        setAlarmText("Alarm canceled");


    }
    void startBtn_Click(object sender, EventArgs e)
    {
        Calendar firingCal = Java.Util.Calendar.GetInstance(Java.Util.TimeZone.Default);


        Calendar currentCal = Java.Util.Calendar.GetInstance(Java.Util.TimeZone.Default);
        // go();




        int hour = (int)TimePicker.CurrentHour;

        int minute = (int)TimePicker.CurrentMinute; ;





        currentCal.Set(Calendar.HourOfDay, hour);
        currentCal.Set(Calendar.Minute, minute);
       

        AlarmManager alarmManager = (AlarmManager)GetSystemService(AlarmService);
            Intent i = new Intent(this, typeof(MyReceiver));
            i.PutExtra("extra", "yes");
        PendingIntent pi = PendingIntent.GetBroadcast(this, 0, i, 0);


        alarmManager.Set(AlarmType.RtcWakeup, currentCal.TimeInMillis, pi);

        setAlarmText("Alarm set to " + hour + ":" + minute);



    }
    public void setAlarmText(string alarmText)
    {
        // alarmTextView.SetText(alarmText);
        // TextView tv = new TextView(this);
        alarmTextView.Text = alarmText;
    }

};
  

}


/*
INITIALIZE AND START OUR ALARM
 */
/*private void go()
{
    //GET TIME IN SECONDS AND INITIALIZE INTENT
    int time=Convert.ToInt32(timeTxt.Text);
    Intent i=new Intent(this,typeof(MyReceiver));

    //PASS CONTEXT,YOUR PRIVATE REQUEST CODE,INTENT OBJECT AND FLAG
    PendingIntent pi = PendingIntent.GetBroadcast(this,0,i,0);

    //INITIALIZE ALARM MANAGER
    AlarmManager alarmManager= (AlarmManager) GetSystemService(AlarmService);

    //SET THE ALARM
    alarmManager.Set(AlarmType.RtcWakeup, JavaSystem.CurrentTimeMillis()+(time*1000),pi);
    Toast.MakeText(this, "Alarm set In: " + time + " seconds", ToastLength.Short).Show();
}


}
}
*/



