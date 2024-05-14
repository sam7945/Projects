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

import java.util.List;

import static org.junit.Assert.*;

/**
 * @author sam79
 */
public class ObservationTest {

    private final Terrain terrain;
    private final List<Lot> lots;
    private final TerrainSortie terrainSortie;
    private final List<LotSortie> lotSorties;

    public ObservationTest() throws Exception {
        CalculateurFoncier.fichierEntree = "entree.json";
        CalculateurFoncier.fichierSortie = "sortie.json";
        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();
        terrainSortie = TerrainSortie.InstanceTerrain();
        lotSorties = terrainSortie.getLotissements();
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
        new ObservationTest();
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


    /**
     * Test of recuperationObservations method, of class Observation.
     */
    @Test
    public void testRecuperationObservations() throws Exception {
        System.out.println("recuperationObservations");

        String expResult = "\"observations\":[\"La valeur du prix maximum au " +
                "mètre carée ne doit pas dépasser 2 fois la valeur du prix minimum.\",\"L'écart des dates maximales et minimales entre les dates de mesure des lots doit être inférieure à 6 mois.\"]";
        Observation.Observations().reinitialisationObservations();
        String result = Observation.Observations().recuperationObservations();

        assertEquals(expResult, result);
    }

}
