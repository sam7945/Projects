package ca.qc.cegepsth.gep.rssreader.Model;

import android.os.Parcel;

import java.util.List;


public class RootObject{
    String status;
    Feed feed;
    List<Item> items;

    public RootObject(String status,Feed feed, List<Item> items){
        this.status = status;
        this.feed = feed;
        this.items = items;
    }

    protected RootObject(Parcel in) {
        status = in.readString();
    }
    public void setStatus(String status) {
        this.status = status;
    }

    public void setFeed(Feed feed) {
        this.feed = feed;
    }

    public void setItems(List<Item> items) {
        this.items = items;
    }

    public String getStatus() {
        return status;
    }

    public Feed getFeed() {
        return feed;
    }

    public List<Item> getItems() {
        return items;
    }



}
