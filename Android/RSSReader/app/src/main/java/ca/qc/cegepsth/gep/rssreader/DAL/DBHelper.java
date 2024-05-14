package ca.qc.cegepsth.gep.rssreader.DAL;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Log;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

public class DBHelper extends SQLiteOpenHelper {

    private static final String DATABASE_NAME = "tp3db";
    private static DBHelper instance;
    private static SQLiteDatabase db;
    private String path = "MesMedias";
    private Context context;

    public DBHelper(Context context, String name, SQLiteDatabase.CursorFactory factory, int version) {
        super(context, name, factory, version);
        this.context = context;
    }

    public static DBHelper getInstance(Context context) {
        if (instance == null) {
            instance = new DBHelper(context, DATABASE_NAME, null, 1);
        }

        return instance;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {

        if (db == null) {
            db = getWritableDatabase();
        }

        db.execSQL("CREATE TABLE if not exists Flux (" +
                " id INTEGER  PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT," +
                " Nom TEXT NOT NULL," +
                " FeedURL TEXT NOT NULL," +
                " Logo BLOB," +
                " DateMAJ DATETIME)");

        db.execSQL("CREATE TABLE if not exists Item (" +
                " id INTEGER  PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT," +
                " FluxId INTEGER NOT NULL," +
                " GUID TEXT UNIQUE ON CONFLICT ROLLBACK," +
                " URL TEXT NOT NULL," +
                " Titre TEXT NOT NULL," +
                " Description TEXT," +
                " date DATETIME," +
                " ImageURL TEXT," +
                " Lu INTEGER DEFAULT 0," +
                " Conserver INTEGER DEFAULT 0," +
                " DateMAJ DATETIME NOT NULL )");

        db.execSQL("CREATE TABLE if not exists Media (" +
                "    id       INTEGER    PRIMARY KEY ASC ON CONFLICT ROLLBACK AUTOINCREMENT," +
                "    ItemId   INTEGER    NOT NULL," +
                "    Type     TEXT NOT NULL," +
                "    URL      TEXT NOT NULL," +
                "    FilePath TEXT )");
    }

    public void addFlux(ContentValues contentValues,String url,String logoUrl) {
        if (db == null) {
            db = getWritableDatabase();
        }

        byte[] logobyte = null;
        try {
            logobyte = bitmapToByte(getBitmapFromUrl(new URL(logoUrl)));
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }

        if (verifFlux(url) == false) {
            try {
                db.beginTransaction();
                if(logobyte != null)
                    contentValues.put( "Logo",logobyte);

                db.insertOrThrow("Flux", null, contentValues);
                db.setTransactionSuccessful();
            } catch (Exception e) {
                Log.d("DB", "Problème à l'insertion de données: addFeed");
            } finally {
                db.endTransaction();
            }
            //addItem(object.getItems(), object.getFeed().imageUrl);
        }
    }

    public void addItem(ContentValues contentValues) {
        if (db == null) {
            db = getWritableDatabase();
        }

        try {
            db.beginTransaction();
            db.insertOrThrow("Item", null, contentValues);
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème à l'insertion de données: addItem");
        } finally {
            db.endTransaction();
        }
    }

    public void addMedia(ContentValues contentValues,String url) {
        int idItem = getLastItemId(db);
        try {
            db.beginTransaction();
            contentValues.put("ItemId", idItem - 1);


            String[] file = url.split("/");
            String filena = file[file.length - 1];
            String fileName;
            if (filena.contains("?")) {
                String[] sep = filena.split("\\?");
                fileName = sep[0];
            } else
                fileName = filena;


            contentValues.put("FilePath", (path + "/" + fileName));
            db.insertOrThrow("Media", null, contentValues);
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB",e.getMessage());
            Log.d("DB", "Problème à l'insertion de données: addMedia");
        } finally {
            db.endTransaction();
        }

    }

    public void addFilePathMedia(String file, int idMedia) {
        String idmedia = String.valueOf(idMedia);
        try {
            db.beginTransaction();
            String sql = "UPDATE Media SET FilePath = ? WHERE id = ?";
            db.execSQL(sql, new String[]{file, idmedia});
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.e("DB", "Problème à l'ajout du filepath du média");
        } finally {

            db.endTransaction();
        }
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

    }

    public byte[] bitmapToByte(Bitmap bitmap) {
        if(bitmap != null){
        Bitmap image = bitmap;
        ByteArrayOutputStream stream = new ByteArrayOutputStream();
        image.compress(Bitmap.CompressFormat.PNG, 100, stream);
        byte imageInByte[] = stream.toByteArray();
        return imageInByte;
        }
        return null;
    }


    public int getLastFluxId() {
        int id = 0;
        db.beginTransaction();
        try {
            Cursor cursor = db.rawQuery("SELECT * FROM Flux ORDER BY id DESC LIMIT 1;", null);
            cursor.moveToFirst();
            id = cursor.getInt(0);

            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème à l'insertion de données: addFeed");
        } finally {
            db.endTransaction();
        }
        return id + 1;
    }
    public Cursor getLastFlux() {
        Cursor c = null;
        db.beginTransaction();
        try {
            Cursor cursor = db.rawQuery("SELECT * FROM Flux ORDER BY id DESC LIMIT 1;", null);
            cursor.moveToFirst();
            c = cursor;
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème à l'insertion de données: addFeed");
        } finally {
            db.endTransaction();
        }
        return c;
    }


    public Cursor getLastItem() {
        Cursor c = null;
        db.beginTransaction();
        try {
            Cursor cursor = db.rawQuery("SELECT * FROM Item ORDER BY id DESC LIMIT 1;", null);
            cursor.moveToFirst();
            c = cursor;
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème à l'insertion de données: addFeed");
        } finally {
            db.endTransaction();
        }
        return c;
    }

    public Cursor getLastMedia() {
        Cursor c = null;
        db.beginTransaction();
        try {
            Cursor cursor = db.rawQuery("SELECT * FROM Media ORDER BY id DESC LIMIT 1;", null);
            cursor.moveToFirst();
            c = cursor;
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème à l'insertion de données: addFeed");
        } finally {
            db.endTransaction();
        }
        return c;
    }

    public int getLastItemId(SQLiteDatabase db) {
        int id = 0;
        db.beginTransaction();
        try {
            Cursor cursor = db.rawQuery("SELECT last_insert_rowid() FROM Item", null);
            cursor.moveToFirst();
            id = cursor.getInt(0);

            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème à l'insertion de données: addFeed");
        } finally {
            db.endTransaction();
        }
        return id + 1;
    }

    public boolean verifFlux(String url) {

        int getcount = 0;
        try {
            db.beginTransaction();
            String sql = "SELECT id FROM Flux WHERE FeedURL = ?";
            Cursor cursor = db.rawQuery(sql, new String[]{url});

            getcount = cursor.getCount();

            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème à la vérification de flux");
        } finally {
            if (getcount > 0) {
                db.endTransaction();
                return true;
            }
            db.endTransaction();
        }
        return false;
    }

    public void retireFlux(String urlFlux) {
        try {
            db.beginTransaction();
            String sql1 = "SELECT id FROM Flux WHERE FeedURL = ?";
            Cursor cursor1 = db.rawQuery(sql1, new String[]{urlFlux});
            while (cursor1.moveToNext()) {
                retireItems(cursor1.getInt(0));
            }
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de l'effacement des flux");
        } finally {
            db.endTransaction();
        }

        try {
            db.beginTransaction();
            String sql = "DELETE FROM Flux WHERE FeedURL = ?";
            db.execSQL(sql, new String[]{urlFlux});
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de l'effacement des flux");
        } finally {
            db.endTransaction();

        }
    }

    void retireItems(int idFlux) {
        String s = String.valueOf(idFlux);

        try {
            db.beginTransaction();
            String sql1 = "SELECT id FROM Item WHERE FluxId = ?";
            Cursor cursor1 = db.rawQuery(sql1, new String[]{s});
            while (cursor1.moveToNext()) {
                retireMedia(cursor1.getInt(0));
            }
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de l'effacement des items");
        } finally {
            db.endTransaction();
        }

        try {
            db.beginTransaction();
            String sql = "DELETE FROM Item WHERE FluxId =" + idFlux;
            db.execSQL(sql);
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de l'effacement des items");
        } finally {
            db.endTransaction();

        }
    }

    void retireMedia(int idItem) {
        try {
            db.beginTransaction();
            String sql = "DELETE FROM Media WHERE ItemId =" + idItem;
            db.execSQL(sql);
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de l'effacement d'un media");
        } finally {
            db.endTransaction();

        }
    }

    void deleteItem(int idItem) {
        try {
            db.beginTransaction();
            String sql = "DELETE FROM Item WHERE id =" + idItem;
            db.execSQL(sql);
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de l'effacement d'un media");
        } finally {
            db.endTransaction();

        }
    }



    public void itemVu(String url, String guid) {
        try {
            db.beginTransaction();
            String sql = "UPDATE Item SET Lu = 1 WHERE URL = ? OR GUID = ?";
            db.execSQL(sql, new String[]{url, guid});
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de la modification si l'item est vu.");
        } finally {
            db.endTransaction();

        }
    }

    public Cursor GetFlux() {
        if (db == null) {
            db = getWritableDatabase();
        }
        Cursor cursor = null;
        try {
            db.beginTransaction();
            String sql1 = "SELECT * FROM Flux";

            cursor = db.rawQuery(sql1, null);

            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de la récupération des flux.");
        } finally {
            db.endTransaction();
        }
        return cursor;
    }
    public Cursor GetFluxByUrl(String url) {
        if (db == null) {
            db = getWritableDatabase();
        }
        Cursor cursor = null;
        try {
            db.beginTransaction();
            String sql1 = "SELECT * FROM Flux WHERE FeedURL = ?";

            cursor = db.rawQuery(sql1, new String[]{url});

            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de la récupération des flux.");
        } finally {
            db.endTransaction();
        }
        return cursor;
    }

    public Cursor GetItems(int idFlux) {
        Cursor cursorI = null;
        try {
            db.beginTransaction();
            String sql1 = "SELECT * FROM Item WHERE FluxId = ?";

            cursorI = db.rawQuery(sql1, new String[]{Integer.toString(idFlux)});

            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de la récupération des items.");
        } finally {
            db.endTransaction();
        }
        return cursorI;
    }
    public Cursor getFluxById(int idFlux) {
        Cursor cursorI = null;
        try {
            db.beginTransaction();
            String sql1 = "SELECT * FROM Flux WHERE id = ?";

            cursorI = db.rawQuery(sql1, new String[]{Integer.toString(idFlux)});

            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de la récupération des flux.");
        } finally {
            db.endTransaction();
        }
        return cursorI;
    }

    Cursor getMedia(int idItem) {

        Cursor cursorM = null;
        try {
            db.beginTransaction();
            String sql1 = "SELECT * FROM Media WHERE ItemId = ?";

            cursorM = db.rawQuery(sql1, new String[]{Integer.toString(idItem)});

            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de la récupération des medias.");
        } finally {
            db.endTransaction();
        }
        return cursorM;
    }

    public Cursor getitemnonvuByflux(int id){
        Cursor cur = null;
        try {
            db.beginTransaction();
            String query = "SELECT id FROM Item WHERE FluxId = ? and Lu = ?";
            cur = db.rawQuery(query, new String[]{Integer.toString(id),"0"});
            db.setTransactionSuccessful();
        } catch (Exception e) {
            Log.d("DB", "Problème lors de la récupération du dernier item de media entrer.");
        } finally {
            db.endTransaction();
        }
        return cur;

    }
    Bitmap getBitmapFromUrl(final URL url) {
        final Bitmap[] nouveauBitmap = new Bitmap[1];
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
