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
import static org.junit.Assert.*;

/**
 *
 * @author Franck
 */
public class StatistiquesTest {
    
    private Terrain terrain;
    private final String TESTFILEPATH = "src\\test\\java\\calculateurfoncier\\";

    
    public Terrain TerrainTest() throws Exception {
        Terrain.Reinitialisation();
        terrain = null;
        terrain = Terrain.InstanceTerrain();
        CalculateurFoncier.fichierEntree = null;
        return terrain;
    }
    
    public StatistiquesTest() {
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
         Terrain.Reinitialisation();
    }

    /**
     * Test of totalLots method, of class Statistiques.
     */
    @Test
    public void testTotalLots() throws Exception {
        CalculateurFoncier.fichierEntree = TESTFILEPATH
                + "entreeTestCommercial_1.json";
        terrain = TerrainTest();
        System.out.println("totalLots");
        int expResult = 3;
        int result = Statistiques.totalLots();
        assertEquals(expResult, result);
        
    }
    
    /**
     * Test of totalLots method, of class Statistiques.
     */
    @Test
    public void testTotalLots2() throws Exception {
        CalculateurFoncier.fichierEntree = TESTFILEPATH
                + "entreeTestAgricole_1.json";
        terrain = TerrainTest();
        System.out.println("totalLots");
        int expResult = 3;
        int result = Statistiques.totalLots();
        assertEquals(expResult, result);
        
    }

    /**
     * Test of valeurLot method, of class Statistiques.
     */
    @Test
    public void testValeurLot() throws Exception {
        CalculateurFoncier.fichierEntree = TESTFILEPATH
                + "entreeTestCommercial_1.json";
        terrain = TerrainTest();
        System.out.println("valeurLot");

        double expResult = 2802.0;
        double result = Statistiques.valeurLot(0);
        assertEquals(expResult, result, 0.0);
        
    }

    /**
     * Test of superficieMaximaleLot method, of class Statistiques.
     */
    @Test
    public void testSuperficieMaximaleLot() throws Exception {
        CalculateurFoncier.fichierEntree = TESTFILEPATH
                + "entreeTestCommercial_1.json";
        terrain = TerrainTest();
        System.out.println("superficieMaximaleLot");
        double expResult = 5000.0;
        double result = Statistiques.superficieMaximaleLot();
        assertEquals(expResult, result, 0.0);
        
    }

    /**
     * Test of valeurMaximaleLot method, of class Statistiques.
     */
    @Test
    public void testValeurMaximaleLot() throws Exception {
        CalculateurFoncier.fichierEntree = TESTFILEPATH
                + "entreeTestCommercial_1.json";
        terrain = TerrainTest();
        System.out.println("valeurMaximaleLot");
        double expResult = 12574.0;
        double result = Statistiques.valeurMaximaleLot();
        assertEquals(expResult, result, 0.0);
       
    }

    /**
     * Test of sommeStatistiques method, of class Statistiques.
     */
    @Test
    public void testSommeStatistiques() throws Exception {
        CalculateurFoncier.fichierEntree = TESTFILEPATH
                + "entreeTestCommercial_1.json";
        terrain = TerrainTest();
        System.out.println("sommeStatistiques");
        Statistiques result = Statistiques.sommeStatistiques();
        assertNotNull(result);
    }
    
}
