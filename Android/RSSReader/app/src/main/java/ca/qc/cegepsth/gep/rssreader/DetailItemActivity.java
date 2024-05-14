package ca.qc.cegepsth.gep.rssreader;

import android.Manifest;
import android.app.DownloadManager;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.net.Uri;
import android.os.Build;
import android.os.Environment;
import android.support.constraint.BuildConfig;
import android.text.Html;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.method.LinkMovementMethod;
import android.text.method.ScrollingMovementMethod;
import android.util.Log;
import android.widget.*;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import androidx.core.app.ActivityCompat;
import androidx.core.content.FileProvider;
import ca.qc.cegepsth.gep.rssreader.Controller.myClickableSpan;
import ca.qc.cegepsth.gep.rssreader.Model.Item;
import ca.qc.cegepsth.gep.rssreader.Model.Media;
import ca.qc.cegepsth.gep.rssreader.Singletons.SingletonRootObject;
import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.UiThread;
import org.androidannotations.annotations.ViewById;

import java.io.File;
import java.util.ArrayList;

import static android.os.Environment.getExternalStoragePublicDirectory;
import static android.os.Environment.getExternalStorageState;

@EActivity
public class DetailItemActivity extends AppCompatActivity {

    Item item;
    TextView tv;
    VideoView vv;
    int rootObjetPos;
    int itemPos;
    //ImageView imageView;
    SingletonRootObject singletonRootObjet;

    //media download
    //String urlPathStr = "https://420-gep-hy.github.io/_Demos/TestData/";
    String fileName; //https://www.developpez.com/images/logos/       uk.png
    String downloadPath;
    String path = "MesMedias";
    Long downloadReference;
    Uri uri;
    String mimeType;
    BroadcastReceiver receiver;
    int idMedia;

    @ViewById
    Button telecharger;
    @ViewById
    Button jouer;
    @ViewById
    Button suivi;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detail_item);

        singletonRootObjet = SingletonRootObject.singletonInstance();

        rootObjetPos = getIntent().getIntExtra("RootObjetPos", -1);
        itemPos = getIntent().getIntExtra("ItemPos", -1);
        ArrayList<Media> medias = new ArrayList<>();
        Cursor cursor = getContentResolver().query(Uri.parse(MainActivity.CONTENT_URI+"/Item/getMediaByItemId"), null,null, new String[]{Integer.toString(singletonRootObjet.getRootObjectItemAtPos(rootObjetPos, itemPos).getId())},null);
        while (cursor.moveToNext()) {
            int id = cursor.getInt(0);
            int iditem = cursor.getInt(1);
            String type = cursor.getString(2);
            String url = cursor.getString(3);

            Media media = new Media(type, url, null, id, this);
            medias.add(media);
        }
        cursor.close();
        singletonRootObjet.getRootObjectItemAtPos(rootObjetPos, itemPos).setMedias(medias);
        item = singletonRootObjet.getRootObjectItemAtPos(rootObjetPos, itemPos);
        tv = findViewById(R.id.textView);

        tv.setMovementMethod(new ScrollingMovementMethod());
        tv.setText(Html.fromHtml(item.getDescription()));


        //TODO aller fichier FluxRssReader et réussir a mettre une valeur dans videolink

        if (item.getMedias().size() == 0)
        {
            jouer.setEnabled(false);
            telecharger.setEnabled(false);
            return;

        }

        SpannableString string = new SpannableString(item.getMedias().get(0).getUrl());
        idMedia = item.getMedias().get(0).getId();
        downloadPath = item.getMedias().get(0).getUrl();
        String[] file = item.getMedias().get(0).getUrl().split("/");
        String filena = file[file.length - 1];

        if (filena.contains("?")) {
            String[] sep = filena.split("\\?");
            fileName = sep[0];
        } else
            fileName = filena;
        string.setSpan(new myClickableSpan(0, rootObjetPos, 0, this), 0, item.getMedias().get(0).getUrl().length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        tv.append(string);

        tv.setMovementMethod(LinkMovementMethod.getInstance());


        verificationExiste();
    }

    boolean verificationExiste() {
        uri = Uri.fromFile(new File(getExternalStoragePublicDirectory(path) + "/" + fileName));
        File f = Environment.getExternalStoragePublicDirectory(path);
        File[] f1 = f.listFiles();
        String s = "";

        ArrayList<String> list = new ArrayList<>();

        if(f1 != null){
            for (File file : f1) {
                s += file.getAbsolutePath() + "\n";
            }
            String[] split1 = s.split("\n");
            String[] split2 = null;
            String s1 = "";
            int arr = 0;
            for (String sp : split1) {
                String[] ss = sp.split("/");
                String st = ss[ss.length - 1];
                s1 += st + ",";
            }
            split2 = s1.split(",");

            for (String sp : split2) {
                list.add(sp);
            }
        }

        if (!list.contains(fileName)) {
            jouer.setEnabled(false);
            telecharger.setEnabled(true);
            return false;
        } else {
            jouer.setEnabled(true);
            telecharger.setEnabled(false);
            return true;
        }
    }

    @Click
    void telecharger() {


        if (!checkPermissions(
                Manifest.permission.INTERNET,
                Manifest.permission.ACCESS_NETWORK_STATE,
/*                Manifest.permission.WRITE_EXTERNAL_STORAGE,
                Manifest.permission.READ_EXTERNAL_STORAGE,*/
                //Manifest.permission.READ_MEDIA_VISUAL_USER_SELECTED,
                Manifest.permission.READ_MEDIA_VIDEO,
                Manifest.permission.READ_MEDIA_AUDIO,
                Manifest.permission.READ_MEDIA_IMAGES
        )) {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.UPSIDE_DOWN_CAKE) {
                ActivityCompat.requestPermissions(this,
                        new String[]{Manifest.permission.INTERNET,
                                Manifest.permission.ACCESS_NETWORK_STATE,
                                Manifest.permission.READ_MEDIA_VISUAL_USER_SELECTED,
                                Manifest.permission.READ_MEDIA_VIDEO,
                                Manifest.permission.READ_MEDIA_AUDIO,
                                Manifest.permission.READ_MEDIA_IMAGES},
                        100);
            }else {
                ActivityCompat.requestPermissions(this,
                        new String[]{Manifest.permission.INTERNET,
                                Manifest.permission.ACCESS_NETWORK_STATE,
                                Manifest.permission.WRITE_EXTERNAL_STORAGE,
                                Manifest.permission.READ_EXTERNAL_STORAGE,
                        },
                        100);
            }
            message("Permission: insuffisantes pour continuer");
        } else {
            receiver = new BroadcastReceiver() {
                @Override
                public void onReceive(Context context, Intent intent) {
                    DownloadManager downloadManager = (DownloadManager) getSystemService(Context.DOWNLOAD_SERVICE);

                    long id = intent.getLongExtra(DownloadManager.EXTRA_DOWNLOAD_ID, -1);

                    if (id == downloadReference) {
                        DownloadManager.Query query = new DownloadManager.Query();
                        query.setFilterById(downloadReference);
                        Cursor cursor = downloadManager.query(query);

                        if (cursor.moveToFirst()) {
                            switch (cursor.getInt(cursor.getColumnIndex(DownloadManager.COLUMN_STATUS))) {
                                case DownloadManager.STATUS_PAUSED: {
                                    int reason = cursor.getInt(cursor.getColumnIndex(DownloadManager.COLUMN_REASON));
                                    message("Téléchargement en pause ..."
                                            + (reason == DownloadManager.PAUSED_QUEUED_FOR_WIFI ? "En attente du wifi"
                                            : (reason == DownloadManager.PAUSED_WAITING_FOR_NETWORK ? "En attente du réseau"
                                            : (reason == DownloadManager.PAUSED_WAITING_TO_RETRY ? "Va réessayer plus tard"
                                            : "Raison inconnue"))));
                                    break;
                                }
                                case DownloadManager.STATUS_PENDING: {
                                    message("Téléchargement en attente...");
                                    break;
                                }
                                case DownloadManager.STATUS_RUNNING: {
                                    message("Téléchargement en cours...");
                                    break;
                                }
                                case DownloadManager.STATUS_FAILED: {
                                    int reason = cursor.getInt(cursor.getColumnIndex(DownloadManager.COLUMN_REASON));
                                    message("Erreur: " + reason);
                                    break;
                                }
                                case DownloadManager.STATUS_SUCCESSFUL: {
                                    mimeType = downloadManager.getMimeTypeForDownloadedFile(downloadReference);
                                    message("Destination: " + uri + "\nType" + mimeType);

                                    context.getContentResolver().update(Uri.parse(MainActivity.CONTENT_URI+"/Media/UpdateFilePath"), null,Integer.toString(idMedia), new String[]{path + "/" + fileName,Integer.toString(idMedia)});
                                    SingletonRootObject.singletonInstance().setMediaFilePath(idMedia, path + "/" + fileName);
                                    jouer.setEnabled(true);
                                    telecharger.setEnabled(false);
                                    break;
                                }
                                default:
                                    Log.e("MainActivity", "Erreur de téléchargement");
                            }
                        }
                    }


                }
            };
            message("Lancement du téléchargement... ça peut prendre un certain temps.");
            registerReceiver(receiver, new IntentFilter(DownloadManager.ACTION_DOWNLOAD_COMPLETE));

            DownloadManager downloadManager = (DownloadManager) getSystemService(Context.DOWNLOAD_SERVICE);

            DownloadManager.Request request = new DownloadManager.Request(Uri.parse(downloadPath));

            request.setAllowedNetworkTypes(DownloadManager.Request.NETWORK_MOBILE | DownloadManager.Request.NETWORK_WIFI);

            request.setNotificationVisibility(DownloadManager.Request.VISIBILITY_VISIBLE_NOTIFY_COMPLETED);
            request.allowScanningByMediaScanner();

            request.setDestinationUri(uri);


            downloadReference = downloadManager.enqueue(request);

        }

    }

    @Override
    protected void onStop() {
        super.onStop();
        if(receiver != null){
            unregisterReceiver(receiver);
        }
    }

    boolean checkPermissions(String... requestPerms) {
        requestPermissions(requestPerms, 1);
        for (String perm : requestPerms) {
            if (checkSelfPermission(perm) != PackageManager.PERMISSION_GRANTED) {
                return false;
            }
        }
        return true;
    }

    @UiThread
    void message(String msg) {
        Toast.makeText(this.getApplicationContext(),msg,Toast.LENGTH_SHORT).show();
    }

    @Click
    void suivi() {
        startActivity(new Intent(DownloadManager.ACTION_VIEW_DOWNLOADS));
    }

    @Click
    void Jouer() {
        String authority = BuildConfig.APPLICATION_ID + ".provider";

        if ("file".equals(uri.getScheme())) {
            Uri u = FileProvider.getUriForFile(DetailItemActivity.this,authority,new File(uri.getPath()));

            Intent intent = new Intent(Intent.ACTION_VIEW);

            intent.setDataAndType(u,mimeType);

            intent.setFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);
            startActivity(intent);
        }
    }
}
