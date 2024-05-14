package ca.qc.cegepsth.gep.rssreader.Model;
import com.rometools.rome.feed.synd.SyndCategory;

import java.util.List;

public class Item {


    int id;
    String title;
    String pubDate;
    String link;
    String author;
    String description;
    Object content;
    String uri; //GUID

    List<SyndCategory> categories;

    List<Media> medias;

    public List<Media> getMedias() {
        return medias;
    }

    public void setMedias(List<Media> medias) {
        this.medias = medias;
    }

    //1 = true, 0 = false
    int dejaVue;




    public Item(int id,String title, String pubDate, String link, String author, String description, Object content, List<SyndCategory> categories, int dejavue, List<Media> medias, String uri)


    {
        this.id = id;
        this.title = title;
        this.pubDate = pubDate;
        this.link = link;
        this.author = author;
        this.description = description;
        this.content = content;
        this.categories = categories;
        this.dejaVue = dejavue;
        this.medias = medias;
        this.uri = uri;
    }


    public void setTitle(String title) {
        this.title = title;
    }

    public void setPubDate(String pubDate) {
        this.pubDate = pubDate;
    }

    public void setLink(String link) {
        this.link = link;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public void setDejaVue(int dv){this.dejaVue = dv;}

    public void setDescription(String description) {
        this.description = description;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public void setCategories(List<SyndCategory> categories) {
        this.categories = categories;
    }

    public String getTitle() {
        return title;
    }

    public String getPubDate() {
        return pubDate;
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

    public Object getContent() {
        return content;
    }
    public int getDejaVue(){return dejaVue;}

    public List<SyndCategory> getCategories() {
        return categories;
    }

    public String getUri() {
        return uri;
    }

    public void setUri(String uri) {
        this.uri = uri;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
}
