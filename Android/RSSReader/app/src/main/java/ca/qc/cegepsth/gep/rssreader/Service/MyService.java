package ca.qc.cegepsth.gep.rssreader.Service;

import android.app.Service;
import android.content.Intent;
import android.os.Handler;
import android.os.IBinder;
import android.os.Message;
import android.os.Messenger;
import android.util.Log;


// je pense que on peut delete cette classe la.
public class MyService extends Service {
    MonServiceHandler monHandler ;
    Messenger monMessenger;

    public MyService(){
        monHandler = new MonServiceHandler();
        monMessenger = new Messenger(monHandler);
    }
    @Override
    public IBinder onBind(Intent intent) {
        return monMessenger.getBinder();
    }

    class MonServiceHandler extends Handler {
        @Override
        public void handleMessage(Message msg){
            Log.e("handle message","hel");
            switch (msg.what){
                case 1:
                    MaJobService.message = msg.getData().getString("message");
                default:
                    super.handleMessage(msg);
            }
        }
    }

}
