package ca.qc.cegepsth.gep.rssreader.DAL;

import android.content.ContentProvider;
import android.content.ContentValues;
import android.database.Cursor;
import android.net.Uri;

public class RSSContentProvider extends ContentProvider {
    public static final String CONTENT_PROVIDER_MIME = "vnd.android.cursor.dir/vmd.ca.qc.cegepsth.gep.noms";
    public static final String CONTENT_URI = "content://ca.qc.cegepsth.gep.rssreader/app";
    DBHelper db;
    FluxRssReader fr;
    @Override
    public boolean onCreate() {
        db = DBHelper.getInstance(getContext());
        fr = FluxRssReader.getInstance(getContext());
        return false;
    }

    @Override
    public Cursor query(Uri uri, String[] projection, String selection, String[] selectionArgs, String sortOrder) {
        //uri:/nom/Table/operation
        //projection:colonne ex:* , id
        //selection: where
        //selectionarg = ex new string[]{url}
        //Cursor cursor = db.rawQuery("SELECT id FROM Media WHERE URL = ?", selectionArgs);
        String[] s = uri.getPath().split("//");
        String[] ss = s[0].split("/");
        Cursor cursor = null;
        if (ss[1].equals("app")) {
            if (ss[3].equals("getallfeed"))
                cursor = db.GetFlux();
            if(ss[3].equals("getallfeedid"))
                db.getInstance(getContext()).verifFlux(selectionArgs[0]);
            if(ss[3].equals("addFeed"))
                fr.getRootObjectFromUrl(selectionArgs[0],getContext());
            if(ss[3].equals("getitemnonvuByflux"))
                cursor = db.getitemnonvuByflux(Integer.parseInt(selectionArgs[0]));
            if(ss[3].equals("getItemsByFluxId"))
                cursor = db.GetItems(Integer.parseInt(selectionArgs[0]));
            if(ss[3].equals("getMediaByItemId"))
                cursor = db.getMedia(Integer.parseInt(selectionArgs[0]));
            if(ss[3].equals("VerifFlux")){
                cursor = db.GetFluxByUrl(selectionArgs[0]);
            }
        }
        else if(ss[1].equals("service")){
            if(ss[3].equals("getLastFlux")){
                cursor = db.getLastFlux();
            }
            else if (ss[3].equals("getallfeed"))
                cursor = db.GetFlux();
            else if(ss[3].equals("getItemsByFluxId"))
                cursor = db.GetItems(Integer.parseInt(selectionArgs[0]));
            else if(ss[3].equals("getMediaByItemId"))
                cursor = db.getMedia(Integer.parseInt(selectionArgs[0]));
            else if(ss[3].equals("getFluxById"))
                cursor = db.getFluxById(Integer.parseInt(selectionArgs[0]));
            else if(ss[3].equals("getLastItem"))
                cursor = db.getLastItem();
            else if(ss[3].equals("getLastMedia"))
                cursor = db.getLastMedia();

        }


        /*DBHelper db = DBHelper.getInstance(this.getContext());
        Cursor curseur = db.retireFlux();*/
        return cursor;
}

    @Override
    public String getType(Uri uri) {
        return null;
    }

    @Override
    public Uri insert(Uri uri, ContentValues contentValues) {


        String[] s = uri.getPath().split("//");
        String[] ss = s[0].split("/");
        String[] sss = uri.getPath().split("!!!");
        if (ss[1].equals("app")) {
            if (ss[3].equals("addFlux"))
                db.getInstance(getContext()).addFlux(contentValues,sss[1],sss[2]);
            if (ss[3].equals("addItem"))
                db.getInstance(getContext()).addItem(contentValues);
            if(ss[3].equals("addMedia"))
                db.getInstance(getContext()).addMedia(contentValues,sss[1]);
        }
        else if(ss[1].equals("service")){
            if (ss[3].equals("addFlux"))
                db.getInstance(getContext()).addFlux(contentValues,sss[1],sss[2]);
            if (ss[3].equals("addItem"))
                db.getInstance(getContext()).addItem(contentValues);
            if(ss[3].equals("addMedia"))
                db.getInstance(getContext()).addMedia(contentValues,sss[1]);
        }
        return null;
    }

    @Override
    public int delete(Uri uri, String selection, String[] selectionArgs) {
        String[] s = uri.getPath().split("//");
        String[] ss = s[0].split("/");
        Cursor cursor = null;
        if (ss[1].equals("app")) {
            if (ss[3].equals("deleteFlux"))
                db.retireFlux(selectionArgs[0]);
        }
        else if(ss[1].equals("service")){
            if (ss[3].equals("retireItem"))
                db.deleteItem(Integer.parseInt(selectionArgs[0]));
            if (ss[3].equals("retireMedia"))
                db.retireMedia(Integer.parseInt(selectionArgs[0]));
        }
        return 0;
    }

    @Override
    public int update(Uri uri, ContentValues contentValues, String selection, String[] selectionArgs) {
        String[] s = uri.getPath().split("//");
        String[] ss = s[0].split("/");
        Cursor cursor = null;
        if (ss[1].equals("app")) {
            if (ss[3].equals("UpdateLu"))
                db.itemVu(selectionArgs[0],selectionArgs[1]);
            if(ss[3].equals("UpdateFilePath"))
                db.addFilePathMedia(selectionArgs[0],Integer.parseInt(selectionArgs[1]));
        }
        return 0;
    }
}
