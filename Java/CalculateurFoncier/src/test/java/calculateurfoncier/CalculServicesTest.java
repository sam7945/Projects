/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

import org.junit.AfterClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Simon
 */
public class CalculServicesTest {

    private Terrain terrain;
    private String testFilePath = "src\\test\\java\\calculateurfoncier\\";

    public Terrain TerrainTest() throws Exception {
        Terrain.Reinitialisation();
        terrain = null;
        terrain = Terrain.InstanceTerrain();
        CalculateurFoncier.fichierEntree = null;
        return terrain;
    }

    @AfterClass
    public static void tearDownClass() {
        Terrain.Reinitialisation();
    }

    @Test
    public void testconstructeur() throws Exception {
        assertNotNull(new CalculServices());
    }

    @Test
    public void testCalculServicesCommercialLot0() throws Exception {
        System.out.println("calculServices");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestCommercial_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(0);
        double expResult = 1000;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testCalculServicesCommercialLot1() throws Exception {
        System.out.println("calculServices");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestCommercial_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(1);
        double expResult = 4500;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testCalculServicesCommercialLot2() throws Exception {
        System.out.println("calculServices");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestCommercial_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(2);
        double expResult = 5000;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testCalculServicesResidentielLot0() throws Exception {
        System.out.println("calculServices");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestResidentiel_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(0);
        double expResult = 0;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testCalculServicesResidentielLot01() throws Exception {
        System.out.println("calculServices");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestResidentiel_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(1);
        double expResult = 1500;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testCalculServicesResidentielLot2() throws Exception {
        System.out.println("calculServices");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestResidentiel_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(2);
        double expResult = 5000;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testCalculServicesAgricoleLot0() throws Exception {
        System.out.println("calculServices");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestAgricole_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(0);
        double expResult = 0;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testCalculServicesAgricoleLot1() throws Exception {
        System.out.println("calculServices");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestAgricole_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(0);
        double expResult = 0;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testCalculServicesAgricoleLot2() throws Exception {
        System.out.println("testCalculServicesAgricoleLot2");
        CalculateurFoncier.fichierEntree = testFilePath
                + "entreeTestAgricole_1.json";
        terrain = TerrainTest();
        Lot lot = terrain.getLots().get(0);
        double expResult = 0;
        double result = CalculServices.calculServices(terrain, lot);
        assertEquals(expResult, result, 0.0);
    }

    @Test(expected = Exception.class)
    public void testValidationNombreServicesNeg() throws Exception {
        System.out.println("validationNombreServices");
        int nombreServices = 6;
        String descriptionLot = "Description";
        CalculServices.validationNombreServices(nombreServices, descriptionLot);
    }

    @Test(expected = Exception.class)
    public void testValidationNombreServicesMax() throws Exception {
        System.out.println("validationNombreServices");
        int nombreServices = -1;
        String descriptionLot = "Description";
        CalculServices.validationNombreServices(nombreServices, descriptionLot);
    }

    @Test(expected = Exception.class)
    public void testValidationTypeTerrainNeg() throws Exception {
        System.out.println("validationTypeTerrain");
        int typeTerrain = -1;
        String descriptionLot = "Description";
        CalculServices.validationTypeTerrain(typeTerrain, descriptionLot);
    }

    @Test(expected = Exception.class)
    public void testValidationTypeTerrainMax() throws Exception {
        System.out.println("validationTypeTerrain");
        int typeTerrain = 3;
        String descriptionLot = "Description";
        CalculServices.validationTypeTerrain(typeTerrain, descriptionLot);
    }

    @Test(expected = Exception.class)
    public void testValidationSuperficieLotNeg() throws Exception {
        System.out.println("validationSuperficieLot");
        double superficieLot = -1;
        String descriptionLot = "";
        CalculServices.validationSuperficieLot(superficieLot, descriptionLot);
    }

    @Test(expected = Exception.class)
    public void testValidationSuperficieLotMax() throws Exception {
        System.out.println("validationSuperficieLot");
        double superficieLot = 50001;
        String descriptionLot = "";
        CalculServices.validationSuperficieLot(superficieLot, descriptionLot);
    }

}
