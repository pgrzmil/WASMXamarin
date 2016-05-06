package com.pgrzmil.nativedroid;

import android.app.ProgressDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.*;

import com.pgrzmil.services.*;

public class LocationTestActivity extends AppCompatActivity implements LocationTestListener {
    Stopwatch stopwatch;
    LocationTestService locationService;
    Button startButton;
    TextView timeLabel;
    TextView positionLabel;
    ProgressDialog progressDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_location);
        setTitle(R.string.menuLocation);

        timeLabel = (TextView) findViewById(R.id.timeLabel);
        positionLabel = (TextView) findViewById(R.id.positionLabel);
        startButton = (Button) findViewById(R.id.startButton);

        stopwatch = new Stopwatch();

        locationService = new LocationTestService(this);
        locationService.addListener(this);
    }

    public void startPositioning(View view) {
        stopwatch.start();
        progressDialog = ProgressDialog.show(this, "Wyznaczanie pozycji...", "");
        new Thread(new Runnable() {
            @Override
            public void run() {
                locationService.getLocation();
            }
        }).start();
    }

    @Override
    public void locationChanged(final double latitude, final double longitude) {
        stopwatch.stop();
        runOnUiThread(new Runnable() {
            public void run() {
                positionLabel.setText(String.format("Długość: %d\nSzerokość: %d", Math.round(longitude * 100) / 100, Math.round(latitude * 100) / 100));
                timeLabel.setText(stopwatch.getDurationBreakdown());
                progressDialog.dismiss();
            }
        });
    }
}
