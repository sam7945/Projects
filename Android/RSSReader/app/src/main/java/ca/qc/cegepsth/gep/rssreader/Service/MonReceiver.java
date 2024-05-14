package ca.qc.cegepsth.gep.rssreader.Service;

import android.app.job.JobInfo;
import android.app.job.JobScheduler;
import android.content.BroadcastReceiver;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;

public class MonReceiver extends BroadcastReceiver {
    static boolean runnedOnceOnStart = false;
    @Override
    public void onReceive(Context context, Intent intent) {
        context.startService(new Intent(context,MaJobService.class));
        scheduleJob(context);
    }
    public static void scheduleJob(Context c){
        JobInfo.Builder builder = new JobInfo.Builder(0,new ComponentName(c,MaJobService.class));

        if (runnedOnceOnStart == false){
            builder.setMinimumLatency(1);
            runnedOnceOnStart = true;
        }
        else{
            //30 minutes = 1 800 000
             builder.setMinimumLatency(1800000);
        }

        builder.setRequiredNetworkType(JobInfo.NETWORK_TYPE_UNMETERED);
        //1 heure = 3 600 000
        builder.setOverrideDeadline(3600000);
        builder.setRequiresBatteryNotLow(true);

        JobScheduler jobScheduler = c.getSystemService(JobScheduler.class);
        jobScheduler.schedule(builder.build());


    }
}
