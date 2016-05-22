package com.pgrzmil.nativedroid;

import android.app.ProgressDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.*;
import android.app.Activity;

import com.pgrzmil.services.*;

import java.math.RoundingMode;
import java.text.DecimalFormat;

public class LocationTestActivity extends Activity implements LocationTestListener {
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
        progressDialog = ProgressDialog.show(this, "Wyznaczanie pozycji...", "");
        stopwatch.start();

        locationService.getLocation();
    }

    @Override
    public void locationChanged(final double latitude, final double longitude) {
        stopwatch.stop();
        locationService.stop();

        runOnUiThread(new Runnable() {
            public void run() {
                DecimalFormat formatter = new DecimalFormat("#.####");
                formatter.setRoundingMode(RoundingMode.CEILING);
                positionLabel.setText(String.format("Długość: %s\nSzerokość: %s", formatter.format(longitude), formatter.format(latitude)));
                timeLabel.setText(String.format("%s\n%s", stopwatch.getDurationInSeconds(), stopwatch.getDurationInMilliseconds()));
                progressDialog.dismiss();
            }
        });
    }
}
