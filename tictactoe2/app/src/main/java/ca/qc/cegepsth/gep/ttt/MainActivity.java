package ca.qc.cegepsth.gep.ttt;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity implements EvenementsTTT {

    //Les images qui seront liées à l'id
    ImageView imgA1;
    ImageView imgA2;
    ImageView imgA3;
    ImageView imgB1;
    ImageView imgB2;
    ImageView imgB3;
    ImageView imgC1;
    ImageView imgC2;
    ImageView imgC3;

    private static Logique logique;
    private static Joueur joueurActif;

    private static boolean gagné = false;
    private static boolean cartePleine = false;

    Joueur[] j = new Joueur[9]; //tableau de joueur
    ImageView[] i1 = new ImageView[9]; //tableau des images
    int[] l = new int[9]; //Tableau des Id des images

    int posActuelle = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        if (logique == null) {
            logique = new Logique(this, Joueur.O);
            joueurActif = Joueur.O;
        }

        //Liste des images dans un tableau
        i1[0] = imgA1;
        i1[1] = imgA2;
        i1[2] = imgA3;
        i1[3] = imgB1;
        i1[4] = imgB2;
        i1[5] = imgB3;
        i1[6] = imgC1;
        i1[7] = imgC2;
        i1[8] = imgC3;

        //Id des images dans un tableau
        l[0] = R.id.imageA1;
        l[1] = R.id.imageA2;
        l[2] = R.id.imageA3;
        l[3] = R.id.imageB1;
        l[4] = R.id.imageB2;
        l[5] = R.id.imageB3;
        l[6] = R.id.imageC1;
        l[7] = R.id.imageC2;
        l[8] = R.id.imageC3;

        miseAJour();
        imageAjuste();

    }

    @Override
    public void auTourDe(Joueur joueur) {
        joueurActif = joueur;
        changeImage();
        Toast.makeText(MainActivity.this, "C'est au tour de " + joueur, Toast.LENGTH_SHORT).show();
    }

    @Override
    public void aGagne(Joueur joueur) {
        changeImage();
        Toast.makeText(MainActivity.this, "Le gagnant est  " + joueur, Toast.LENGTH_SHORT).show();
        gagné = true;
    }

    @Override
    public void cartePleine() {
        changeImage();
        Toast.makeText(MainActivity.this, "La carte est pleine et il n'y a aucun gagnant!", Toast.LENGTH_SHORT).show();
        cartePleine = true;
    }

    @Override
    public void positionDejaOccuppee() {
        Toast.makeText(MainActivity.this, "Cette position est déjà occuper!!", Toast.LENGTH_SHORT).show();
    }

    /**
     * Bind les images et Id ensemble et créer les évènements OnClick des images
     */
    private void imageAjuste() {

        for (int i = 0; i < 9; i++) {
            final int p = i + 1;
            i1[i] = this.findViewById(l[i]); //Liaison des images avec les id

            //Ajout d'un évènement pour attendre un click
            i1[i].setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    if (!gagné && !cartePleine) {

                        try {
                            joueurActif = logique.joueurActif;

                            logique.jouePosition(p);
                            posActuelle = p;
                        } catch (PositionInvalide positionInvalide) {
                            Toast.makeText(MainActivity.this, "Cette position n'est pas valide!", Toast.LENGTH_SHORT).show();
                        }
                    } else {
                        logique.reset();
                        changeImage();
                        gagné = false;
                        cartePleine = false;
                    }
                }
            });
        }
        changeImage();
    }

    //Modification des images lors d'un changement dans logique
    private void changeImage() {

        miseAJour();
        for (int i = 0; i < 9; i++) {
            if (j[i] == Joueur.O) {
                i1[i].setImageResource(R.drawable.o);
            } else if (j[i] == Joueur.X) {
                i1[i].setImageResource(R.drawable.x);
            } else {
                i1[i].setImageResource(R.drawable.vide);
            }
        }
    }

    //Mise à jour des cases
    private void miseAJour() {
        j[0] = logique.A1;
        j[1] = logique.A2;
        j[2] = logique.A3;
        j[3] = logique.B1;
        j[4] = logique.B2;
        j[5] = logique.B3;
        j[6] = logique.C1;
        j[7] = logique.C2;
        j[8] = logique.C3;
    }
}