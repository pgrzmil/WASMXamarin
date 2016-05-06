package com.pgrzmil.services;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by pawel on 06.05.2016.
 */
public class NetworkTestService {
    private static NetworkTestService ourInstance = new NetworkTestService();
    private List<NetworkTestListener> listeners = new ArrayList<>();

    public static NetworkTestService getInstance() {
        return ourInstance;
    }

    private NetworkTestService() {
    }

    public void addListener(NetworkTestListener toAdd) {
        listeners.add(toAdd);
    }

    public void downloadImage(String urlString) {
        try {
            URL url = new URL(urlString);
            InputStream stream = url.openConnection().getInputStream();
            Bitmap image = BitmapFactory.decodeStream(stream);
            onImageDownloadCompleted(image);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void onImageDownloadCompleted(Bitmap result) {
        for (NetworkTestListener listener : listeners)
            listener.ImageDownloadCompleted(result);
    }
}
