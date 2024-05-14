package calculateurfoncier;

import java.util.Date;

/**
 * Lot
 *
 * V1
 *
 * 2021-06-04
 *
 * @author sam79
 */
public class Lot {
    private final String DESCRIPTION; //Description du lot
    private final int NOMBRE_DROITS_PASSAGE; //Nombre de droit de passage
    private final int NOMBRE_SERVICES;//Nombre de services du lot
    private final int SUPERFICIE;//Superficie du lot
    private final Date DATE_MESURE;//Date à laquelle les mesures ont été faites.
    

    public Lot(String description, int nombreDroitPassage, int nombreServices,
               int superficie, Date dateMesure) {
        this.DESCRIPTION = description;
        this.NOMBRE_DROITS_PASSAGE = nombreDroitPassage;
        this.NOMBRE_SERVICES = nombreServices;
        this.SUPERFICIE = superficie;
        this.DATE_MESURE = dateMesure;
    }
 

    public String getDescription() {
        return DESCRIPTION;
    }


    public int getNombreDroitsPassage() {
        return NOMBRE_DROITS_PASSAGE;
    }


    public int getNombreServices() {
        return NOMBRE_SERVICES;
    }


    public int getSuperficie() {
        return SUPERFICIE;
    }
    
    public Date getDateMesure() {
        return DATE_MESURE;
    }


}
