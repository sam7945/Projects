/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

import net.sf.json.JSONArray;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

import java.io.IOException;
import java.util.List;

import static org.junit.Assert.*;

/**
 *
 * @author sam79
 */
public class TerrainSortieTest {

    private final Terrain terrain;
    private final List<Lot> lots;
    private final TerrainSortie terrainSortie;
    private final List<LotSortie> lotSorties;
    private final String fichierSortie = "sortie.json";

    public TerrainSortieTest() throws Exception {
        CalculateurFoncier.fichierEntree = "entree.json";
        CalculateurFoncier.fichierSortie = "sortie.json";
        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();
        terrainSortie = TerrainSortie.InstanceTerrain();
        lotSorties = terrainSortie.getLotissements();
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void ajoutsLotUpdateValues() throws Exception {
        if (lotSorties.size() == 0) {
            for (int i = 0; i < lots.size(); i++) {
                String descriptionLot = lots.get(i).getDescription();

                double montantServices = CalculServices.calculServices(
                        terrain, lots.get(i));
                double valeurTerrain = ValeurFonciere.calculValeurTerrain(
                        terrain, lots.get(i));
                double montantPassages =
                        DroitsPassage.coutPassage(terrain, lots.get(i),
                                valeurTerrain);

                terrainSortie.ajoutLots(
                        new LotSortie(descriptionLot, montantServices +
                                montantPassages + valeurTerrain));
            }
        }

    }

    @Test
    public void fileWriterSave() throws Exception {
        Observation.Observations().reinitialisationObservations();
        FileWriter.saveStringIntoFile(
                fichierSortie,terrainSortie.toString());
    }
}
