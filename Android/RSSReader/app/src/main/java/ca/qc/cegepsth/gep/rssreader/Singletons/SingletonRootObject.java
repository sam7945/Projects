package ca.qc.cegepsth.gep.rssreader.Singletons;

import android.content.Context;
import android.database.Cursor;
import android.database.Observable;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import ca.qc.cegepsth.gep.rssreader.MainActivity;
import ca.qc.cegepsth.gep.rssreader.Model.Feed;
import ca.qc.cegepsth.gep.rssreader.Model.Item;
import ca.qc.cegepsth.gep.rssreader.Model.Media;
import ca.qc.cegepsth.gep.rssreader.Model.RootObject;

import java.util.ArrayList;

public class SingletonRootObject extends Observable {

    private static SingletonRootObject instance;

    private static ArrayList<RootObject> feeds;

    protected SingletonRootObject()
    {
        feeds = new ArrayList<RootObject>();
    }
    public static SingletonRootObject singletonInstance()
    {
        if (instance == null)
        {
            instance = new SingletonRootObject();
        }
        return instance;
    }

    public void setFluxWithServer(Context context){
        Cursor curseur =  context.getContentResolver().query(Uri.parse(MainActivity.CONTENT_URI +"/Feed/getallfeed"), null,null, null,null);
        ArrayList<Feed> feeds = new ArrayList<>();
        ArrayList<RootObject> r = new ArrayList<>();
        while(curseur.moveToNext())
        {
            RootObject root;
            Feed fe;
            int id = curseur.getInt(0);
            String title = curseur.getString(1);
            String url = curseur.getString(2);
            byte[] image = curseur.getBlob(3);
            Bitmap imageBitmap = getBitmapFromBytes(image);
            String date = curseur.getString(4);

            fe = new Feed(id,url, title, null, null, null, imageBitmap);
            feeds.add(fe);
            root = new RootObject("ok",fe,null);
            r.add(root);

        }
        this.feeds = r;
        curseur.close();
    }


    public void addRootObject(RootObject ro)
    {
        feeds.add(ro);
    }
    public ArrayList<RootObject> getFeeds()
    {
        return feeds;
    }
    public void removeRootObject(RootObject ro)
    {
        feeds.remove(ro);
    }
    public void removeRootObject(int pos)
    {
        feeds.remove(pos);
    }
    public RootObject getRootObjectAtPos(int pos)
    {
        return feeds.get(pos);
    }
    public Item getRootObjectItemAtPos(int rootObjectPos, int itemPos)
    {
        return  feeds.get(rootObjectPos).getItems().get(itemPos);
    }
    public void updateItemReadValueAtPos(int rootobjectpos, int itemPos)
    {
        feeds.get(rootobjectpos).getItems().get(itemPos).setDejaVue(1);
    }
    public ArrayList<Feed> getFeedsList()
    {
        ArrayList<Feed> list = new ArrayList<>();
        for(RootObject r : feeds)
        {
            list.add(r.getFeed());
        }

        return list;
    }
    public int getNombreNonVue(RootObject ro)
    {
        int nbNonVue = 0;
        for (Item i:ro.getItems())
            if (i.getDejaVue() == 0)
                nbNonVue++;

        return nbNonVue;
    }
    public Item getItemAtPos(RootObject ro,int pos)
    {
        RootObject rootobjet = findRootObject(ro);
        if (rootobjet == null)
            return null;

        return rootobjet.getItems().get(pos);


    }
    private RootObject findRootObject(RootObject ro)
    {
        for (RootObject rootObject: feeds)
        {
            if (rootObject.equals(ro))
                return rootObject;
        }
        return null;
    }
    public boolean setMediaFilePath(int idMedia,String filePath){
        for(RootObject f:feeds)
        {
            if(f.getItems() != null) {
                for (Item i : f.getItems()) {
                    if (i.getMedias() != null) {
                        for (Media m : i.getMedias()) {
                            if (m.getId() == idMedia) {
                                m.setFilePath(filePath);
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
    public static Bitmap getBitmapFromBytes(byte[] bytes) { //Pour prendre le BLOB et le remettre en Bitmap
        if (bytes != null) {
            return BitmapFactory.decodeByteArray(bytes, 0, bytes.length);
        }
        return null;
    }
}
