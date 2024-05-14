package ca.qc.cegepsth.gep.rssreader.DAL;

import android.content.ContentValues;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.util.Log;
import android.widget.Toast;
import com.rometools.rome.feed.synd.*;
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
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

public class FluxRssReader {
    public static DBHelper dbHelper;
    private Context context;
    private static FluxRssReader instance;
    private static int idflux = 0;
    protected FluxRssReader(Context context) {
        this.context = context;
    }

    public static FluxRssReader getInstance(Context context) {
        if (instance == null) {
            instance = new FluxRssReader(context);

        }

        return instance;
    }

    public static void getRootObjectFromUrl(final String urlRss, final Context context) {
        dbHelper = DBHelper.getInstance(context);

        Runnable n = new Runnable() {
            @Override
            public void run() {
                try {
                    idflux = 0;
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
                        ContentValues newValues = new ContentValues();
                        if (sf.getImage() != null) {
                            imageUrl = sf.getImage().getUrl();
                            imabyte = bitmapToByte(getImageBitmapFromStringUrl(imageUrl));
                            if(imabyte != null)
                                newValues.put("Logo",imabyte);
                        }



                        newValues.put("Nom", sf.getTitle());
                        newValues.put("FeedURL", urlRss);
                        newValues.put("DateMAJ", Calendar.getInstance().getTime().toString());

                        context.getContentResolver().insert(Uri.parse(RSSContentProvider.CONTENT_URI + "/Feed/addFlux/!!!" + sf.getLink() + "/!!!" + imageUrl), newValues);

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

                            idflux = dbHelper.getLastFluxId();
                            idflux--;
                            ContentValues Values = new ContentValues();
                            uri += sf.getTitle();

                            Values.put("FluxId",idflux);
                            Values.put("GUID", uri);
                            Values.put("URL", link);
                            Values.put("Titre", title);
                            Values.put("Description", description);
                            Values.put("date", publishedDate);
                            Values.put("ImageURL", imageUrl);
                            Values.put("Lu", 0);
                            Values.put("Conserver", 0);
                            Values.put("DateMAJ", getDateTime());


                            context.getContentResolver().insert(Uri.parse(RSSContentProvider.CONTENT_URI + "/Feed/addItem"), Values);

                            if (enclosures != null) {
                                for (SyndEnclosure m : enclosures) {
                                    ContentValues Values2 = new ContentValues();
                                    Values2.put("Type", m.getType());
                                    Values2.put("URL", m.getUrl());
                                    context.getContentResolver().insert(Uri.parse(RSSContentProvider.CONTENT_URI + "/Feed/addMedia/!!!" + m.getUrl()), Values2);
                                }
                            }
                        }

                        //r = new RootObject("ok", f, items);

                        //dbHelper.addFlux(r);
                    }

                } catch (MalformedURLException e) {
                    //Toast.makeText(context, e.getMessage(), Toast.LENGTH_LONG).show();
                } catch (IOException e) {
                    Log.e("UrlActivity", e.getMessage().toString());
                    //Toast.makeText(context, e.getMessage(), Toast.LENGTH_LONG).show();
                } catch (FeedException e) {
                    //Toast.makeText(context, e.getMessage(), Toast.LENGTH_LONG).show();
                } catch (NullPointerException e) {
                    //Toast.makeText(context, e.getMessage(), Toast.LENGTH_LONG).show();
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
    }

    public static String getDateTime() {
        Date date = new Date();
        SimpleDateFormat formateur = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
        return formateur.format(date);
    }

    public static byte[] bitmapToByte(Bitmap bitmap) {
        if(bitmap != null) {
            Bitmap image = bitmap;
            ByteArrayOutputStream stream = new ByteArrayOutputStream();
            image.compress(Bitmap.CompressFormat.PNG, 100, stream);
            byte imageInByte[] = stream.toByteArray();
            return imageInByte;
        }
        return null;
    }
    public static  Bitmap getImageBitmapFromStringUrl(String sUrl) {
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
    static Bitmap getBitmapFromUrl(final URL url) {
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
}
