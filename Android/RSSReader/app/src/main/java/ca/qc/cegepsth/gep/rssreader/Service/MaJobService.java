package ca.qc.cegepsth.gep.rssreader.Service;

import android.app.job.JobParameters;
import android.app.job.JobService;
import android.content.*;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.util.Log;
import android.widget.Toast;

import ca.qc.cegepsth.gep.rssreader.Service.RssHelper.FeedRss;
import ca.qc.cegepsth.gep.rssreader.Service.RssHelper.ItemRss;
import ca.qc.cegepsth.gep.rssreader.Service.RssHelper.MediaRss;
import ca.qc.cegepsth.gep.rssreader.Service.RssHelper.RootObjectRss;

import com.rometools.rome.feed.synd.SyndCategory;
import com.rometools.rome.feed.synd.SyndEnclosure;
import com.rometools.rome.feed.synd.SyndEntry;
import com.rometools.rome.feed.synd.SyndFeed;
import com.rometools.rome.io.FeedException;
import com.rometools.rome.io.SyndFeedInput;
import com.rometools.rome.io.XmlReader;

import javax.net.ssl.HttpsURLConnection;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.*;

import static ca.qc.cegepsth.gep.rssreader.DAL.FluxRssReader.getDateTime;

public class MaJobService extends JobService {
    static String message = "Service a update la Bd";

    private static String CONTENT_URI = "content://ca.qc.cegepsth.gep.rssreader/service";

    private Bitmap getBitmapFromBytes(byte[] bytes) { //Pour prendre le BLOB et le remettre en Bitmap
        if (bytes != null) {
            return BitmapFactory.decodeByteArray(bytes, 0, bytes.length);
        }
        return null;
    }
    @Override
    public boolean onStartJob(JobParameters params) {

        //Toast.makeText(this,message,Toast.LENGTH_SHORT).show();

        //liste des url rss a update
        ArrayList<String> listUrlBd = new ArrayList<String>();
        //liste des id rss
        ArrayList<Integer> listIdUrlBd = new ArrayList<>();

        Cursor curseur = getContentResolver().query(Uri.parse(CONTENT_URI+"/Feed/getallfeed"),null,null,null,null);
        while (curseur.moveToNext()) {
            listIdUrlBd.add(curseur.getInt(0));
            String url = curseur.getString(2);
            listUrlBd.add(url);
        }
        curseur.close();


        // Objet Rss download de l'internet.
        ArrayList<RootObjectRss> listRootObjectRssInternet = new ArrayList<RootObjectRss>();

        for (String urlRss : listUrlBd)
        {
            RootObjectRss rootObject = getRootObjectFromUrl(urlRss,getBaseContext());
            listRootObjectRssInternet.add(rootObject);
        }

        // Objet Rss download de la Bd.
        ArrayList<RootObjectRss> listRootObjectRssBd = new ArrayList<>();

        for(int i : listIdUrlBd)
        {
            RootObjectRss rootObject = new RootObjectRss();
            rootObject.items = new ArrayList<>();
            rootObject.status = "ok";

            //Populer le feed
            Cursor curseurFlux = getContentResolver().query(Uri.parse(CONTENT_URI+"/Feed/getFluxById"), null,null, new String[]{Integer.toString(i)},null);
            while (curseurFlux.moveToNext()) {
                FeedRss feed = new FeedRss();
                feed.id = curseurFlux.getInt(0);
                feed.Nom = curseurFlux.getString(1);
                feed.feedURL = curseurFlux.getString(2);
                feed.Logo = curseurFlux.getBlob(3);
                feed.DateMAJ = curseurFlux.getString(4);
                rootObject.feed = feed;
                break;
            }
            curseurFlux.close();

            Cursor curseurItemFlux = getContentResolver().query(Uri.parse(CONTENT_URI+"/Feed/getItemsByFluxId"), null,null, new String[]{Integer.toString(i)},null);
            while (curseurItemFlux.moveToNext()) {
                ItemRss item = new ItemRss();
                item.medias = new ArrayList<>();
                item.id = curseurItemFlux.getInt(0);
                item.Fluxid = curseurItemFlux.getInt(1);
                item.GUID = curseurItemFlux.getString(2);
                item.URL = curseurItemFlux.getString(3);
                item.titre = curseurItemFlux.getString(4);
                item.description = curseurItemFlux.getString(5);
                item.date = curseurItemFlux.getString(6);
                item.ImageURL = curseurItemFlux.getString(7);
                item.lu = curseurItemFlux.getInt(8);
                item.conserver = curseurItemFlux.getInt(9);
                item.DateMaj = curseurItemFlux.getString(10);

                Cursor curseurMediaItem = getContentResolver().query(Uri.parse(CONTENT_URI+"/Feed/getMediaByItemId"), null,null, new String[]{Integer.toString(item.id)},null);
                while(curseurMediaItem.moveToNext()){
                    MediaRss mediaRss = new MediaRss();
                    mediaRss.id = curseurMediaItem.getInt(0);
                    mediaRss.itemId = curseurMediaItem.getInt(1);
                    mediaRss.type = curseurMediaItem.getString(2);
                    mediaRss.url = curseurMediaItem.getString(3);
                    mediaRss.filePath = curseurMediaItem.getString(4);
                    item.medias.add(mediaRss);
                }
                curseurMediaItem.close();

                rootObject.items.add(item);
            }
            curseurItemFlux.close();
            listRootObjectRssBd.add(rootObject);
        }


        //comparer et regarder la différence entre les deux liste.
        for (int i=0; i<listRootObjectRssBd.size(); i++) {
            RootObjectRss objetInternet = listRootObjectRssInternet.get(i);
            RootObjectRss objetBd = listRootObjectRssBd.get(i);


            //comparer la différence entre les deux liste.
            while(objetBd.items.size() != 0){
                //prendre premier item
                ItemRss itemBd = objetBd.items.get(0);

                //regarder si sa existe dans l'objet internet

                boolean itemfound = false;
                for (int j=0; j<objetInternet.items.size();j++){
                    ItemRss itemInternet = objetInternet.items.get(j);
                    if (itemBd.GUID.equals(itemInternet.GUID)){
                        itemfound = true;
                        objetInternet.items.remove(itemInternet);
                        break;
                    }
                }

                if (!itemfound){
                     getContentResolver().delete(Uri.parse(CONTENT_URI+"/Feed/retireMedia"), null, new String[]{Integer.toString(itemBd.id)});
                    getContentResolver().delete(Uri.parse(CONTENT_URI+"/Feed/retireItem"), null, new String[]{Integer.toString(itemBd.id)});
                }
                objetBd.items.remove(itemBd);
            }
        }

        int pos = 0;
        for(RootObjectRss ro:listRootObjectRssInternet){

            for(ItemRss item:ro.items){


                int fluxid = listIdUrlBd.get(pos);
                item.Fluxid = fluxid;


                ContentValues Values = new ContentValues();
                Values.put("FluxId",item.Fluxid);
                Values.put("GUID", item.GUID);
                Values.put("URL", item.URL);
                Values.put("Titre", item.titre);
                Values.put("Description", item.description);
                Values.put("date",  item.date);
                Values.put("ImageURL", item.ImageURL);
                Values.put("Lu", 0);
                Values.put("Conserver", 0);
                Values.put("DateMAJ", getDateTime());

                getContentResolver().insert(Uri.parse(CONTENT_URI+"/Feed/addItem"),Values);

               for(MediaRss m: item.medias){
                   ContentValues Values2 = new ContentValues();
                   Values2.put("Type", m.type);
                   Values2.put("URL", m.url);
                   getContentResolver().insert(Uri.parse(CONTENT_URI + "/Feed/addMedia/!!!" + m.url), Values2);
               }
            }

            pos++;
        }

        Toast.makeText(this,message,Toast.LENGTH_SHORT).show();
        //reschedule a job
        MonReceiver.scheduleJob(this);
        return true;
    }

    @Override
    public boolean onStopJob(JobParameters params) {
        return false;
    }

    public int onStartCommand(Intent i , int flags, int startId){
        return START_NOT_STICKY;
    }

    private Bitmap getBitmapFromUrl(final URL url) {
        final Bitmap[] nouveauBitmap = {null};
        Runnable r = new Runnable() {
            @Override
            public void run() {
                try {
                    HttpURLConnection connection = null;
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setDoInput(true);
                    connection.connect();

                    InputStream inputStream = connection.getInputStream();
                    nouveauBitmap[0] = BitmapFactory.decodeStream(inputStream);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        };

        Thread t = new Thread(r);
        t.start();
        try {
            t.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return nouveauBitmap[0];
    }
    private byte[] bitmapToByte(Bitmap bitmap) {
        Bitmap image = bitmap;
        ByteArrayOutputStream stream = new ByteArrayOutputStream();
        image.compress(Bitmap.CompressFormat.PNG, 100, stream);
        byte imageInByte[] = stream.toByteArray();
        return imageInByte;
    }
    private Bitmap getImageBitmapFromStringUrl(String sUrl) {
        Bitmap imageBitMap = null;
        if (imageBitMap == null) {
            try {
                URL url = new URL(sUrl);
                imageBitMap = getBitmapFromUrl(url);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return imageBitMap;
    }
    private RootObjectRss getRootObjectFromUrl(final String urlRss, final Context context) {
        final RootObjectRss rootObjectRss = new RootObjectRss();
        rootObjectRss.status = "pasok";
        rootObjectRss.items = new ArrayList<>();
        Runnable n = new Runnable() {
            @Override
            public void run() {
                try {
                    int idflux = 0;
                    SyndFeedInput source = new SyndFeedInput();
                    URL url;
                    SyndFeed feed;


                    url = new URL(urlRss);

                    if (urlRss.contains("https")) {
                        HttpsURLConnection connection = (HttpsURLConnection) url.openConnection();
                        feed = source.build(new XmlReader(connection));
                    } else {
                        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
                        feed = source.build(new XmlReader(connection));
                    }

                    List<SyndEntry> elements = feed.getEntries();


                    if (!elements.isEmpty()) {
                        SyndFeed sf = feed;
                        String imageUrl = null;
                        byte[] imabyte = null;
                        if (sf.getImage() != null) {
                            imageUrl = sf.getImage().getUrl();
                            imabyte = bitmapToByte(getImageBitmapFromStringUrl(imageUrl));
                        }




                        FeedRss feedRss = new FeedRss();
                        feedRss.Nom = sf.getTitle();
                        feedRss.feedURL = urlRss;
                        feedRss.DateMAJ = Calendar.getInstance().getTime().toString();
                        feedRss.id = 0;
                        feedRss.Logo = imabyte;

                        rootObjectRss.feed = feedRss;


                        int nb = elements.size();
                        for (int i = 0; i < nb; i++) {
                            String title = null;
                            if (elements.get(i).getTitle() != null) {
                                title = elements.get(i).getTitle();
                            }
                            String publishedDate = null;
                            if (elements.get(i).getPublishedDate() != null) {
                                publishedDate = elements.get(i).getPublishedDate().toString();
                            }
                            String link = null;
                            if (elements.get(i).getLink() != null) {
                                link = elements.get(i).getLink();
                            }
                            String author = null;
                            if (elements.get(i).getAuthor() != null) {
                                author = elements.get(i).getAuthor();
                            }
                            String description = null;
                            if (elements.get(i).getDescription() != null) {
                                description = elements.get(i).getDescription().getValue();
                            }
                            Object content = null;
                            if (elements.get(i).getContents() != null) {
                                content = elements.get(i).getContents().toArray();
                            }
                            List<SyndCategory> categorie = null;
                            if (elements.get(i).getCategories() != null) {
                                categorie = elements.get(i).getCategories();

                            }
                            List<SyndEnclosure> enclosures = null;
                            if (elements.get(i).getEnclosures() != null) {
                                enclosures = elements.get(i).getEnclosures();
                            }
                            String uri = null;
                            if (elements.get(i).getUri() != null) {
                                uri = elements.get(i).getUri();
                            }

                       /*     Cursor idCursor = getContentResolver().query(Uri.parse(CONTENT_URI+"/Feed/getLastFlux"),null,null,null,null);
                            idflux = idCursor.getInt(0);
                            //retourne 1 de trop pour le id
                            idflux--;*/

                            ItemRss itemRss = new ItemRss();
                            uri += sf.getTitle();

                            itemRss.id = 0;
                            itemRss.Fluxid = 0;
                            itemRss.GUID = uri;
                            itemRss.URL = link;
                            itemRss.titre = title;
                            itemRss.description = description;
                            itemRss.date = publishedDate;
                            itemRss.ImageURL = imageUrl;
                            itemRss.lu = 0;
                            itemRss.conserver = 0;
                            itemRss.date = getDateTime();
                            itemRss.DateMaj = getDateTime();
                            itemRss.medias = new ArrayList<>();


                            if (enclosures != null) {
                                for (SyndEnclosure m : enclosures) {
                                    ContentValues Values2 = new ContentValues();
                                    Values2.put("Type", m.getType());
                                    Values2.put("URL", m.getUrl());
                                    MediaRss mediaRss = new MediaRss();
                                    mediaRss.type = m.getType();
                                    mediaRss.url = m.getUrl();
                                    mediaRss.id = 0;
                                    mediaRss.itemId = 0;

                                    itemRss.medias.add(mediaRss);
                                }
                            }
                            rootObjectRss.items.add(itemRss);
                            rootObjectRss.status = "ok";
                        }

                    }

                } catch (MalformedURLException e) {
                    //Toast.makeText(this, e.getMessage(), Toast.LENGTH_LONG).show();
                } catch (IOException e) {
                    Log.e("UrlActivity", e.getMessage().toString());
                    //Toast.makeText(this, e.getMessage(), Toast.LENGTH_LONG).show();
                } catch (FeedException e) {
                    //Toast.makeText(this, e.getMessage(), Toast.LENGTH_LONG).show();
                } catch (NullPointerException e) {
                    //Toast.makeText(this, e.getMessage(), Toast.LENGTH_LONG).show();
                    Log.e("UrlActivity", e.getMessage().toString());
                }
            }
        };
        Thread t = new Thread(n);
        t.start();
        try {
            t.join();
        } catch (
                InterruptedException e) {
            e.printStackTrace();
        }
        return rootObjectRss;
    }

}
