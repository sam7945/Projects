package calculateurfoncier;

import java.util.HashMap;
import java.util.Map;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Simon
 */
public class DonneesTest {
    
    public DonneesTest() {
    }
    
    @Test
    public void testGetNbTotalLots() {
        System.out.println("getNbTotalLots");
        Donnees instance = new Donnees();
        int nbTotalLots = 6;
        instance.setNbTotalLots(nbTotalLots);
        int expResult = 6;
        int result = instance.getNbTotalLots();
        assertEquals(expResult, result);
    }

    @Test
    public void testGetSuperficieMaxLot() {
        System.out.println("getSuperficieMaxLot");
        Donnees instance = new Donnees();
        double superficieMaxLot = 123.56;
        instance.setSuperficieMaxLot(superficieMaxLot);
        double expResult = 123.56;
        double result = instance.getSuperficieMaxLot();
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testGetValeurMaximaleLot() {
        System.out.println("getValeurMaximaleLot");
        Donnees instance = new Donnees();
        double valuerMaxLot = 456.78;
        instance.setValeurMaximaleLot(valuerMaxLot);
        double expResult = 456.78;
        double result = instance.getValeurMaximaleLot();
        assertEquals(expResult, result, 0.0);
    }

    @Test
    public void testGetNbLotsParValeur() {
        System.out.println("getNbLotsParValeur");
        Donnees instance = new Donnees();
        Map<String, Integer> nbLotsParValeur = new HashMap<>();
        nbLotsParValeur.put("patate",8);
        instance.setNbLotsParValeur(nbLotsParValeur);
        Map<String, Integer> expResult = new HashMap<>();
        expResult.put("patate",8);
        Map<String, Integer> result = instance.getNbLotsParValeur();
        assertEquals(expResult, result);
    }

    @Test
    public void testGetNbLotsParType() {
        System.out.println("getNbLotsParType");
        Donnees instance = new Donnees();
        Map<String, Integer> nbLotsParType = new HashMap<>();
        nbLotsParType.put("Cheval",123);
        Map<String, Integer> expResult = new HashMap<>();
        expResult.put("Cheval",123);
        instance.setNbLotsParType(nbLotsParType);
        Map<String, Integer> result = instance.getNbLotsParType();
        assertEquals(expResult, result);
    }

}
