package ca.qc.cegepsth.gep.rssreader;

import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.widget.ListView;
import androidx.appcompat.app.AppCompatActivity;
import ca.qc.cegepsth.gep.rssreader.Controller.RssItemAdapter;
import ca.qc.cegepsth.gep.rssreader.Model.Item;
import ca.qc.cegepsth.gep.rssreader.Singletons.SingletonRootObject;
import org.androidannotations.annotations.EActivity;

import java.util.ArrayList;

@EActivity
public class AfficheFluxActivity extends AppCompatActivity {
    ListView lv;
    SingletonRootObject singletonRootObjet;
    int rootObjetPos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_affiche_flux);

        lv = findViewById(R.id.listView);
        singletonRootObjet =SingletonRootObject.singletonInstance();

        rootObjetPos = (int)getIntent().getIntExtra("RootObjetPos",-1);

        if (rootObjetPos == -1)
            return;

        ArrayList<Item> items = new ArrayList<>();
        Cursor cursor = getContentResolver().query(Uri.parse(MainActivity.CONTENT_URI+"/Item/getItemsByFluxId"), null,null, new String[]{Integer.toString(singletonRootObjet.getRootObjectAtPos(rootObjetPos).getFeed().getId())},null);
        while (cursor.moveToNext()) {
            Item item;

            int id = cursor.getInt(0);
            int fluxId = cursor.getInt(1);
            String guid = cursor.getString(2);
            String url = cursor.getString(3);
            String title = cursor.getString(4);
            String description = cursor.getString(5);
            String date = cursor.getString(6);
            String imageUrl = cursor.getString(7);
            int lu = cursor.getInt(8);
            int conserver = cursor.getInt(9);
            String datemaj = cursor.getString(10);

            item = new Item(id,title, date, url, null, description, null, null, lu,null, guid);
            items.add(item);
        }
        cursor.close();
        singletonRootObjet.getRootObjectAtPos(rootObjetPos).setItems(items);
        RssItemAdapter rssItemAdapter = new RssItemAdapter(this, R.layout.flux_items,singletonRootObjet.getRootObjectAtPos(rootObjetPos),rootObjetPos);

        lv.setAdapter(rssItemAdapter);

    }

}
