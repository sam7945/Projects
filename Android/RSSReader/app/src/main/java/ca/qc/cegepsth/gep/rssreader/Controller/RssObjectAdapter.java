package ca.qc.cegepsth.gep.rssreader.Controller;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.*;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import ca.qc.cegepsth.gep.rssreader.AfficheFluxActivity;
import ca.qc.cegepsth.gep.rssreader.AfficheFluxActivity_;
import ca.qc.cegepsth.gep.rssreader.MainActivity;
import ca.qc.cegepsth.gep.rssreader.Model.Feed;
import ca.qc.cegepsth.gep.rssreader.Singletons.SingletonRootObject;
import ca.qc.cegepsth.gep.rssreader.R;

import java.util.ArrayList;

public class RssObjectAdapter extends ArrayAdapter<Feed> {

    int layoutRessourceId;
    Context context;
    Bitmap bit;
    //SingletonUrlsRss singletonUrlsRss;
    SingletonRootObject singletonRootObject;
    ArrayList<Feed> feeds;
    static int elementNonLus;
    public final String CONTENT_URI = "content://ca.qc.cegepsth.gep.rssreader/app";

    public RssObjectAdapter(@NonNull Context context, int resource, ArrayList<Feed> root) {
        super(context, resource, root);
        this.context = context;
        this.layoutRessourceId = resource;
        //singletonUrlsRss = SingletonUrlsRss.singletonInstance();
        singletonRootObject = SingletonRootObject.singletonInstance();
        this.feeds = root;
    }


    @NonNull
    @Override
    public View getView(final int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        convertView = LayoutInflater.from(getContext()).inflate(layoutRessourceId, parent, false);

        ImageView imageView = (ImageView) convertView.findViewById(R.id.imageViewFlux);
        TextView textViewTitre = (TextView) convertView.findViewById(R.id.titreView);
        TextView textViewNbArticle = (TextView) convertView.findViewById(R.id.nbArticleView);
        Button button = (Button) convertView.findViewById(R.id.buttonMoin);
        LinearLayout linearLayout = (LinearLayout) convertView.findViewById(R.id.layoutid);


        Cursor curseur = context.getContentResolver().query(Uri.parse(CONTENT_URI + "/Item/getitemnonvuByflux"), null, null, new String[]{Integer.toString(singletonRootObject.getRootObjectAtPos(position).getFeed().id)}, null);


        int nbnonvu = 0;
        while (curseur.moveToNext()) {
            ++nbnonvu;
        }
        elementNonLus = nbnonvu;

        curseur.close();
        textViewNbArticle.setText("Article non lu: " + nbnonvu);

        imageView.setImageBitmap(singletonRootObject.getRootObjectAtPos(position).getFeed().imageBitMap);

        textViewTitre.setText(singletonRootObject.getRootObjectAtPos(position).getFeed().title);

        View.OnClickListener startAfficherFlux = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getContext(), AfficheFluxActivity_.class);
                intent.putExtra("RootObjetPos", position);
                getContext().startActivity(intent);
            }
        };

        linearLayout.setOnClickListener(startAfficherFlux);
        imageView.setOnClickListener(startAfficherFlux);
        textViewTitre.setOnClickListener(startAfficherFlux);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //singletonUrlsRss.supprimerUrlRss(RssObject.getFeed().url);
                context.getContentResolver().delete(Uri.parse(MainActivity.CONTENT_URI + "/Feed/deleteFlux"), null, new String[]{singletonRootObject.getRootObjectAtPos(position).getFeed().url});
                singletonRootObject.removeRootObject(position);
                feeds.remove(position);
                RssObjectAdapter.this.notifyDataSetChanged();
            }
        });

        return convertView;
    }


    public static int elementNonLus(){
        return elementNonLus;
    }

}
