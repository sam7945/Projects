/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.TimeZone;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;
import org.junit.*;

import static org.junit.Assert.*;

/**
 * @author sam79
 */
public class TerrainTest {

    Terrain instance;
    public static final String DESCRIPTION = "description";
    public static final String NOMBREDROITSPASSAGE = "nombre_droits_passage";
    public static final String NOMBRESERVICES = "nombre_services";
    public static final String SUPERFICIE = "superficie";
    public static final String DATEMESURE = "date_mesure";

    public TerrainTest() throws Exception {
        CalculateurFoncier.fichierEntree = "entree.json";
        CalculateurFoncier.fichierSortie = "sortie.json";
        instance = Terrain.InstanceTerrain();
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
        new TerrainTest();
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

    @Test(expected = IOException.class)
    public void testInstanceTerrainFailLoad() throws Exception {
        System.out.println("Instance terrain fail load file");
        CalculateurFoncier.fichierEntree = "connerie";
        FileReader.loadFileIntoString(CalculateurFoncier.fichierEntree,
                CalculateurFoncier.ENCODAGE);
    }

    /**
     * Test of validationPropriétésJsonTerrain method, of class Terrain.
     */
    @Test
    public void testValidationPropriétésJsonTerrain() throws Exception {
        System.out.println("validationPropri\u00e9t\u00e9sJsonTerrain");
        JSONObject jsonObject = (JSONObject.fromObject(FileReader
                .loadFileIntoString(CalculateurFoncier.fichierEntree,
                        CalculateurFoncier.ENCODAGE)));

        Terrain.validationPropriétésJsonTerrain(jsonObject);

    }

    /**
     * Test of validationPropriétésJsonLot method, of class Terrain.
     */
    @Test
    public void testValidationPropriétésJsonLot() throws Exception {
        System.out.println("validationPropri\u00e9t\u00e9sJsonLot");

        JSONObject jsonObject = (JSONObject.fromObject(FileReader
                .loadFileIntoString(CalculateurFoncier.fichierEntree,
                        CalculateurFoncier.ENCODAGE)));
        JSONArray lots = jsonObject.getJSONArray("lotissements");

        //un objet lot
        int i = 0;
        for (Object lot : lots) {
            JSONObject json = JSONObject.fromObject(lot);
            Terrain.validationPropriétésJsonLot(json, i);
            i++;
        }


    }

    /**
     * Test of getTypeTerrain method, of class Terrain.
     */
    @Test
    public void testGetTypeTerrain() {
        System.out.println("getTypeTerrain");
        int expResult = 2;
        int result = instance.getTypeTerrain();
        assertEquals(expResult, result);

    }

    /**
     * Test of getPrixM2Min method, of class Terrain.
     */
    @Test
    public void testGetPrixM2Min() {
        System.out.println("getPrixM2Min");
        double expResult = 3.45;
        double result = instance.getPrixM2Min();
        assertEquals(expResult, result, 0.0);
    }

    /**
     * Test of getPrixM2Max method, of class Terrain.
     */
    @Test
    public void testGetPrixM2Max() {
        System.out.println("getPrixM2Max");
        double expResult = 7.00;
        double result = instance.getPrixM2Max();
        assertEquals(expResult, result, 0.0);

    }

    /**
     * Test of getLots method, of class Terrain.
     */
    @Test
    public void testGetLots() throws IOException, ParseException {
        System.out.println("getLots");
        assertNotNull(instance.getLots());

    }


}
