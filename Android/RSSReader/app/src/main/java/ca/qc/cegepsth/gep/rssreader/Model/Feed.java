package ca.qc.cegepsth.gep.rssreader.Model;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Parcel;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public class Feed {


    public int id;
    public String url;
    public String title;
    public String link;
    public String author;
    public String description;
    public String imageUrl;
    public Bitmap imageBitMap;

    public Feed(String url, String title, String link, String author, String description, String image, Bitmap imagevu) {

        this.url = url;
        this.title = title;
        this.link = link;
        this.author = author;
        this.description = description;
        this.imageUrl = image;

        if (imagevu == null) {
            getImageBitmapFromStringUrl(image);
        }
        else{
            imageBitMap = imagevu;
        }
    }
    public Feed(int id,String url, String title, String link, String author, String description, Bitmap image) {
        this.id = id;
        this.url = url;
        this.title = title;
        this.link = link;
        this.author = author;
        this.description = description;
        this.imageBitMap = image;

    }

    protected Feed(Parcel in) {
        id = in.readInt();
        url = in.readString();
        title = in.readString();
        link = in.readString();
        author = in.readString();
        description = in.readString();
        imageUrl = in.readString();
        imageBitMap = in.readParcelable(Bitmap.class.getClassLoader());
    }


    public void setUrl(String url) {
        this.url = url;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setLink(String link) {
        this.link = link;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public void setImage(String image) {
        this.imageUrl = image;
    }

    public String getUrl() {
        return url;
    }

    public String getTitle() {
        return title;
    }

    public String getLink() {
        return link;
    }

    public String getAuthor() {
        return author;
    }

    public String getDescription() {
        return description;
    }

    public String getImage() {
        return imageUrl;
    }
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
    public void getImageBitmapFromStringUrl(String sUrl) {
        if (imageBitMap == null) {
            try {
                URL url = new URL(sUrl);
                getBitmapFromUrl(url);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    void getBitmapFromUrl(final URL url) {
        Runnable r = new Runnable() {
            @Override
            public void run() {
                try {
                    HttpURLConnection connection = null;
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setDoInput(true);
                    connection.connect();

                    InputStream inputStream = connection.getInputStream();
                    Bitmap nouveauBitmap = BitmapFactory.decodeStream(inputStream);
                    imageBitMap = nouveauBitmap;
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
    }

}
