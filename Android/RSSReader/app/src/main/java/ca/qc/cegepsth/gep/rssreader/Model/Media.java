package ca.qc.cegepsth.gep.rssreader.Model;

import android.content.Context;


public class Media {

    String type;
    String url;
    String filePath;
    int id;


    public Media(String type, String url, String filePath , int id,Context context) {
        this.type = type;
        this.url = url;
        this.filePath = filePath;
        this.id = id;
    }


    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getFilePath() { return filePath; }

    public void setFilePath(String filePath) {
        this.filePath = filePath;
    }

    public int getId() { return id; }

    public void setId(int id) { this.id = id; }
}
