/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

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
public class LotSortieTest {
    private final Terrain terrain;
    private final List<Lot> lots;
    private final TerrainSortie terrainSortie;
    private final List<LotSortie> lotSorties;
    private final String fichierSortie = "sortie.json";

    public LotSortieTest() throws Exception {
        CalculateurFoncier.fichierEntree = "entree.json";
        CalculateurFoncier.fichierSortie = "sortie.json";
        Terrain.Reinitialisation();
        terrain = Terrain.InstanceTerrain();
        lots = terrain.getLots();
        TerrainSortie.Reinitialisation();
        terrainSortie = TerrainSortie.InstanceTerrain();
        lotSorties = terrainSortie.getLotissements();

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

    @BeforeClass
    public static void setUpClass() throws Exception {
        new LotSortieTest();
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
     * Test of getDescription method, of class LotSortie.
     */
    @Test
    public void testGetDescription() {
        System.out.println("getDescription");

        String expResult = "lot 1";
        String result = lotSorties.get(0).getDescription();
        assertEquals(expResult, result);

    }

    /**
     * Test of getValeurLot method, of class LotSortie.
     */
    @Test
    public void testGetValeurLot() {
        System.out.println("getValeurLot");

        double expResult = 2802.00;
        double result = lotSorties.get(0).getValeurLot();
        assertEquals(expResult, result, 0.0);

    }

    /**
     * Test of toString method, of class LotSortie.
     */
    @Test
    public void testToString() {
        System.out.println("toString");

        String expResult = "{\"description\":\"lot 1\",\"valeur_par_lot\":\"2802.00 $\"},";
        String result = lotSorties.get(0).toString();
        assertEquals(expResult, result);

    }

}
