package calculateurfoncier;

/**
 * FileReader
 * <p>
 * V1
 * <p>
 * 2021-06-04
 *
 * @author sam79
 */

import org.apache.commons.io.IOUtils;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;

public class FileReader {

    public static String loadFileIntoString(
            String filePath,String fileEncoding) 
            throws IOException {
        String fichier = "";
        try {
            fichier = IOUtils.toString(new FileInputStream(filePath),
                    fileEncoding);
            return fichier;
        } catch (Exception e) {
            throw new IOException("Une erreur est survenue lors de la " +
                    "lecture du fichier.");
        }
    }
}
