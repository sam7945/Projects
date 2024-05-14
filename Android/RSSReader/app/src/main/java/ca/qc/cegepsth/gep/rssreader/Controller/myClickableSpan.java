package ca.qc.cegepsth.gep.rssreader.Controller;

import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.text.style.ClickableSpan;
import android.view.View;
import ca.qc.cegepsth.gep.rssreader.Model.Item;
import ca.qc.cegepsth.gep.rssreader.Singletons.SingletonRootObject;

public class myClickableSpan extends ClickableSpan {

    int pos;
    int posItem;
    int posObjet;
    Context context;
    Item item;
    SingletonRootObject rootObject;

    public myClickableSpan(int position, int posObjet , int posItem, Context context){
        this.pos=position;
        this.posItem = posItem;
        this.posObjet = posObjet;
        this.context = context;
        rootObject = SingletonRootObject.singletonInstance();
        item = rootObject.getItemAtPos(rootObject.getRootObjectAtPos(posObjet),posItem);
    }

    @Override
    public void onClick(View widget) {
        Intent intent = new Intent();
        intent.setData(Uri.parse(item.getMedias().get(pos).getUrl()));
        //intent.setType(item.getEnclosures().get(pos).getType());
        context.startActivity(intent);
    }

}
