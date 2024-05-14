/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculateurfoncier;

import java.io.File;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Simon
 */
public class CalculateurFoncierTest {
    private String testFilePath = "src\\test\\java\\calculateurfoncier\\";
    private final String FIC_HISTORIQUE_TEST = testFilePath+"historiqueTest.json";
    private File fichierSortie = null;
    private File historiqueTest = null;
    
    public CalculateurFoncierTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
        
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        if (historiqueTest != null){
            historiqueTest.delete();
            historiqueTest = null;
        }
    }
    
    @After
    public void tearDown() {
        if (fichierSortie != null){
            fichierSortie.delete();
            fichierSortie = null;
        }
        if (historiqueTest != null){
            historiqueTest.delete();
            historiqueTest = null;
        }
    }

    @Test
    public void testconstructeur() throws Exception {
        assertNotNull(new CalculateurFoncier());
    }
    
    @Test
    public void testMain() throws Exception {
        System.out.println("main");
        String[] args = {
            testFilePath + "entreeTestAgricole_1.json", 
            testFilePath + "SortieTest.json"};
        CalculateurFoncier.main(args);
        fichierSortie = new File(FIC_HISTORIQUE_TEST);
        assertNotNull(fichierSortie);
    }
    
    @Test
    public void testMainOptionS() throws Exception {
        System.out.println("main");
        String[] args = {"-S"};
        CalculateurFoncier.main(args);
        fichierSortie = new File(testFilePath+fichierSortie);
        assertNotNull(fichierSortie);
    }
    
    @Test
    public void testMainOptionSR() throws Exception {
        System.out.println("main");
        String[] args = {"-SR"};
        CalculateurFoncier.main(args);
        historiqueTest = new File(FIC_HISTORIQUE_TEST);
        assertNotNull(historiqueTest);
    }
    
    @Test
    public void testMainOptionErreur() throws Exception {
        System.out.println("main");
        String[] args = {"-Z"};
        CalculateurFoncier.main(args);
        assertNull(historiqueTest);
    }
}
