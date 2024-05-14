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

import org.apache.commons.io.FileUtils;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;

public class FileWriter {

    public static void saveStringIntoFile(
            String filePath,String contentToSave) throws IOException {

        try {
            File f = new File(filePath);
            FileUtils.writeStringToFile(f, contentToSave, "UTF-8");
        } catch (Exception e) {
            throw new IOException("Une erreur est survenue lors de " +
                    "l'écriture du fichier!");
        }

    }
}
