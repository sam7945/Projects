/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author sam79
 */
public class LotTest {
    Terrain instance;


    public LotTest() throws Exception {
        CalculateurFoncier.fichierEntree = "entree.json";
        CalculateurFoncier.fichierSortie = "sortie.json";
        instance = Terrain.InstanceTerrain();
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

    /**
     * Test of getDescription method, of class Lot.
     */
    @Test
    public void testGetDescription() {
        System.out.println("getDescription");
        String expResult = "lot 1";
        String result = instance.getLots().get(0).getDescription();
        assertEquals(expResult, result);
    }

    /**
     * Test of getNombreDroitsPassage method, of class Lot.
     */
    @Test
    public void testGetNombreDroitsPassage() {
        System.out.println("getNombreDroitsPassage");
        int expResult = 4;
        int result = instance.getLots().get(0).getNombreDroitsPassage();
        assertEquals(expResult, result);
    }

    /**
     * Test of getNombreServices method, of class Lot.
     */
    @Test
    public void testGetNombreServices() {
        System.out.println("getNombreServices");
        int expResult = 0;
        int result = instance.getLots().get(0).getNombreServices();
        assertEquals(expResult, result);
    }

    /**
     * Test of getSuperficie method, of class Lot.
     */
    @Test
    public void testGetSuperficie() {
        System.out.println("getSuperficie");
        int expResult = 465;
        int result = instance.getLots().get(0).getSuperficie();
        assertEquals(expResult, result);
    }

    /**
     * Test of getDateMesure method, of class Lot.
     */
    @Test
    public void testGetDateMesure() throws ParseException {
        System.out.println("getDateMesure");


        Date expResult = getSimpleDateFormatISO8601().parse("2015-10-14");
        Date result = instance.getLots().get(0).getDateMesure();
        //2015-10-14
        assertEquals(expResult, result);
    }
    private SimpleDateFormat getSimpleDateFormatISO8601() {
        TimeZone timeZone = TimeZone.getTimeZone("UTC");
        SimpleDateFormat formatDate = new SimpleDateFormat("yyyy-MM-dd");
        formatDate.setTimeZone(timeZone);
        return formatDate;
    }
    
}
