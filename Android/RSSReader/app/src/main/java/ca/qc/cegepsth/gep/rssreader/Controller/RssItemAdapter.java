package ca.qc.cegepsth.gep.rssreader.Controller;

import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.*;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import ca.qc.cegepsth.gep.rssreader.*;
import ca.qc.cegepsth.gep.rssreader.Model.Item;
import ca.qc.cegepsth.gep.rssreader.Model.RootObject;
import ca.qc.cegepsth.gep.rssreader.Singletons.SingletonRootObject;

public class RssItemAdapter extends ArrayAdapter<Item> {

    RootObject rootObjet;
    int layoutRessourceId;
    SingletonRootObject singletonRootObject;
    int rootObjetPos;



    public RssItemAdapter(@NonNull Context context, int resource, RootObject ro,int rootobjetpos) {
        super(context, resource,ro.getItems());
        this.rootObjet = ro;
        this.rootObjetPos = rootobjetpos;
        this.layoutRessourceId = resource;
        singletonRootObject = SingletonRootObject.singletonInstance();

    }


    @NonNull
    @Override
    public View getView(final int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        convertView = LayoutInflater.from(getContext()).inflate(layoutRessourceId,parent,false);

        TextView textViewTitre = (TextView) convertView.findViewById(R.id.titreView);
        CheckBox checkBox = (CheckBox) convertView.findViewById(R.id.checkBox2);
        //dbUrlRss.getItemAtPos(pos,position)

        final Item item = singletonRootObject.getRootObjectItemAtPos(rootObjetPos,position);


        textViewTitre.setText(item.getTitle());


        int vu = item.getDejaVue();
        if (vu == 1 || singletonRootObject.getRootObjectItemAtPos(rootObjetPos,position).getDejaVue() == 1)
        {
            checkBox.setChecked(true);
        }
           // convertView.setBackgroundColor(Color.RED);



        textViewTitre.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                singletonRootObject.updateItemReadValueAtPos(rootObjetPos,position);

                ContentValues values = new ContentValues();
                values.put("Lu",1);
                getContext().getContentResolver().update(Uri.parse(MainActivity.CONTENT_URI+"/Item/UpdateLu"), values,"Lu", new String[]{singletonRootObject.getItemAtPos(rootObjet,position).getLink(),singletonRootObject.getItemAtPos(rootObjet,position).getUri()});

                notifyDataSetChanged();
                Intent intent = new Intent();
                intent.putExtra("RootObjetPos",rootObjetPos);
                intent.putExtra("ItemPos",position);
                intent.setClass(getContext(), DetailItemActivity_.class);
                getContext().startActivity(intent);
            }
        });
        return convertView;
    }
}
