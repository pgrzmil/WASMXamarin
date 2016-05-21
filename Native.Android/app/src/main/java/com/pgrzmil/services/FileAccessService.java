package com.pgrzmil.services;

import android.content.Context;
import android.util.*;
import java.io.*;

/**
 * Created by pawel on 06.05.2016.
 */
public class FileAccessService {
    Context context;

    public FileAccessService(Context context) {
        this.context = context;
    }

    public void writeToFile(String fileName, String text) {
        try {
            File file = new File(context.getFilesDir().getAbsolutePath(), fileName);
            if (file.exists()) {
                file.delete();
            }

            OutputStreamWriter outputStreamWriter = new OutputStreamWriter(context.openFileOutput(fileName, Context.MODE_PRIVATE));
            outputStreamWriter.write(text);
            outputStreamWriter.close();
        } catch (IOException e) {
            Log.e("Exception", "File write failed: " + e.toString());
        }
    }

    public String readFromFile(String filename) {
        String ret = "";

        try {
            InputStream inputStream = context.openFileInput(filename);

            if (inputStream != null) {
                InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
                String receiveString;
                StringBuilder stringBuilder = new StringBuilder();

                while ((receiveString = bufferedReader.readLine()) != null) {
                    stringBuilder.append(receiveString);
                }

                inputStream.close();
                ret = stringBuilder.toString();
            }
        } catch (FileNotFoundException e) {
            Log.e("Exception", "File not found: " + e.toString());
        } catch (IOException e) {
            Log.e("Exception", "Can not read file: " + e.toString());
        }

        return ret;
    }
}
