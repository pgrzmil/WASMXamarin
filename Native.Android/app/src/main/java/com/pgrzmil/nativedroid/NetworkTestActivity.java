package com.pgrzmil.nativedroid;

import android.app.ProgressDialog;
import android.graphics.Bitmap;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import com.pgrzmil.services.NetworkTestListener;
import com.pgrzmil.services.NetworkTestService;

public class NetworkTestActivity extends AppCompatActivity implements NetworkTestListener {
    Stopwatch stopwatch;
    NetworkTestService networkService;
    Button startButton;
    EditText addressField;
    TextView timeLabel;
    ImageView downloadedImage;
    ProgressDialog progressDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_download);
        setTitle(R.string.menuNetwork);

        addressField = (EditText) findViewById(R.id.addressField);
        timeLabel = (TextView) findViewById(R.id.timeLabel);
        downloadedImage = (ImageView) findViewById(R.id.downloadedImage);
        startButton = (Button) findViewById(R.id.startButton);

        addressField.setText("http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg");

        stopwatch = new Stopwatch();
        networkService = new NetworkTestService();
        networkService.addListener(this);
    }

    public void startDownloading(View view) {
        stopwatch.start();
        progressDialog = ProgressDialog.show(this, "Pobieranie...", "");

        new Thread(new Runnable() {
            @Override
            public void run() {
                networkService.downloadImage(addressField.getText().toString());
            }
        }).start();
    }

    @Override
    public void imageDownloadCompleted(final Bitmap image){
        stopwatch.stop();
        runOnUiThread(new Runnable() {
            public void run() {
                downloadedImage.setImageBitmap(image);
                timeLabel.setText(stopwatch.getDurationInSeconds());
                progressDialog.dismiss();
            }
        });
    }

}
