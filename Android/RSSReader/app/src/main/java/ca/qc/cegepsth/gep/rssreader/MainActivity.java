package ca.qc.cegepsth.gep.rssreader;

import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.*;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;
import ca.qc.cegepsth.gep.rssreader.Controller.RssObjectAdapter;
import ca.qc.cegepsth.gep.rssreader.Model.Feed;
import ca.qc.cegepsth.gep.rssreader.Model.RootObject;
import ca.qc.cegepsth.gep.rssreader.Service.MaJobService;
import ca.qc.cegepsth.gep.rssreader.Service.MonReceiver;
import ca.qc.cegepsth.gep.rssreader.Service.MyService;
import ca.qc.cegepsth.gep.rssreader.Singletons.SingletonRootObject;
import com.google.android.material.textfield.TextInputEditText;
import org.androidannotations.annotations.EActivity;

import java.util.ArrayList;

@EActivity
public class MainActivity extends AppCompatActivity {

    ListView listView;
    TextInputEditText textInputEditText;
    Button buttonAdd;

    ArrayList<Feed> feeds;
    SingletonRootObject singletonFeeds;
    RssObjectAdapter objectAdapter;

    Messenger monMessenger;
    public static final String CONTENT_URI = "content://ca.qc.cegepsth.gep.rssreader/app"; //(site/app ou service/table/operation )

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        listView = (ListView) findViewById(R.id.listView);
        textInputEditText = (TextInputEditText) findViewById(R.id.textInputEditText);
        buttonAdd = (Button) findViewById(R.id.buttonAdd);
        singletonFeeds = SingletonRootObject.singletonInstance();
        feeds = singletonFeeds.getFeedsList();


        //start de la Job récurrente
        Intent intent = new Intent(this, MaJobService.class);
        startService(intent);

        //Service de communication
        intent = new Intent(this, MyService.class);
        startService(intent);


        ServiceConnection sc = new ServiceConnection() {
            @Override
            public void onServiceConnected(ComponentName componentName, IBinder service) {
                monMessenger = new Messenger(service);
                Log.d("de service connected","conection marche");
            }
            @Override
            public void onServiceDisconnected(ComponentName name) {
            }
        };
        bindService(intent, sc, Context.BIND_AUTO_CREATE);
        MonReceiver.scheduleJob(this);

        textInputEditText.setText("https://ici.radio-canada.ca/rss/4159");

        Cursor curseur = getContentResolver().query(Uri.parse(CONTENT_URI+"/Feed/getallfeed"),null,null,null,null);

        ArrayList<Feed> feeds = new ArrayList<>();

        while (curseur.moveToNext()) {
            RootObject root;
            Feed feed;
            int id = curseur.getInt(0);
            String title = curseur.getString(1);
            String url = curseur.getString(2);
            byte[] image = curseur.getBlob(3);
            Bitmap imageBitmap = getBitmapFromBytes(image);
            String date = curseur.getString(4);

            feed = new Feed(id,url, title, null, null, null, imageBitmap);
            feeds.add(feed);
            root = new RootObject("ok",feed,null);

            singletonFeeds.addRootObject(root);
            this.feeds = singletonFeeds.getFeedsList();
        }
        curseur.close();

        objectAdapter = new RssObjectAdapter(this, R.layout.flux_rss,this.feeds);
        listView.setAdapter(objectAdapter);


        buttonAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ajouterFlux(textInputEditText.getText().toString(),true);
                afficheFlux();
            }
        });
    }

    public void afficheFlux() {
        objectAdapter.notifyDataSetChanged();
    }

    private void ajouterFlux( String urlRss,boolean ajouterDansBd){

        Cursor curseur = getContentResolver().query(Uri.parse(CONTENT_URI+"/Feed/VerifFlux"), new String[] {"id"},"where", new String[] {urlRss},null);

        boolean contient = false; //null = rien
        while(curseur.moveToNext()){
            contient = true;
        }
/*        if(curseur.getCount() != 0) {
            contient = true;
        }*/

        if (contient)
        {
            Toast t = Toast.makeText(this,"Lien existe deja!",Toast.LENGTH_SHORT);
            t.setGravity(Gravity.TOP|Gravity.CENTER_HORIZONTAL,0,0);
            t.show();
            return;
        }
        curseur.close();
        getContentResolver().query(Uri.parse(CONTENT_URI+"/Feed/addFeed"), null,null, new String[]{urlRss},null);
        singletonFeeds.setFluxWithServer(this);
        feeds = singletonFeeds.getFeedsList();

        objectAdapter = new RssObjectAdapter(this, R.layout.flux_rss,this.feeds);
        listView.setAdapter(objectAdapter);
        MainActivity.this.objectAdapter.notifyDataSetChanged();
    }
    @Override
    public void onRestart()
    {
        super.onRestart();
        objectAdapter.notifyDataSetChanged();
    }
    public static Bitmap getBitmapFromBytes(byte[] bytes) { //Pour prendre le BLOB et le remettre en Bitmap
        if (bytes != null) {
            return BitmapFactory.decodeByteArray(bytes, 0, bytes.length);
        }
        return null;
    }

    @Override
    protected void onResume() {
        super.onResume();
        int value = objectAdapter.elementNonLus();
        widgetNonLus(value);
    }

    public void widgetNonLus(int value){
        Intent intent = new Intent(this, RSSAppWidget.class);
        intent.putExtra("value", value);
        sendBroadcast(intent);
    }
}

