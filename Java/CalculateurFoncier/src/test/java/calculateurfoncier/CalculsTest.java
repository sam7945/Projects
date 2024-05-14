/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

import org.junit.Test;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

/**
 *
 * @author Simon
 */
public class CalculsTest {
    
    public CalculsTest() {
    }
    
/*    @Rule
    public Timeout globalTimeout = Timeout.millis(1000);*/
    
    @Test
    public void testconstructeur() throws Exception {
        assertNotNull(new Calculs());
    }
    @Test
    public void testArrondirPlancher() {
        double nombre = 2.06;
        double expResult = 2.05;
        double result = Calculs.Arrondir(nombre);
        assertEquals(expResult, result,0.0);
    }
    @Test
    public void testArrondirPlafond() {
        double nombre = 2.14;
        double expResult = 2.15;
        double result = Calculs.Arrondir(nombre);
        assertEquals(expResult, result,0.0);
    }
    @Test
    public void testArrondirLarge() {
        double nombre = 1.7976931348623157;
        double expResult = 1.80;
        double result = Calculs.Arrondir(nombre);
        assertEquals(expResult, result,0.0);
    }
    @Test
    public void testArrondirNégatif() {
        double nombre = -2.01;
        double expResult = -2.00;
        double result = Calculs.Arrondir(nombre);
        assertEquals(expResult, result,0.0);
    }
    
    @Test
    public void testArrondirInt() {
        int nombre = 2;
        double expResult = 2.00;
        double result = Calculs.Arrondir(nombre);
        assertEquals(expResult, result,0.0);
    }
    
    @Test
    public void testArrondirFloat() {
        float nombre = 2.06f;
        double expResult = 2.05;
        double result = Calculs.Arrondir(nombre);
        assertEquals(expResult, result,0.0);
    } 
}
