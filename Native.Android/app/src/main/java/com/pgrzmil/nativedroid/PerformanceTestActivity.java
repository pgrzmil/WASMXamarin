package com.pgrzmil.nativedroid;

import android.app.ProgressDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.pgrzmil.services.*;

public class PerformanceTestActivity extends AppCompatActivity implements PerformanceTestListener {
    Stopwatch stopwatch;
    Button startButton;
    EditText digitsEntry;
    TextView timeLabel;
    TextView resultView;
    ProgressDialog progressDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_performance);
        setTitle(R.string.menuPerformance);

        digitsEntry = (EditText) findViewById(R.id.digitsEntry);
        timeLabel = (TextView) findViewById(R.id.timeLabel);
        resultView = (TextView) findViewById(R.id.resultView);
        startButton = (Button) findViewById(R.id.startButton);

        stopwatch = new Stopwatch();
        PerformanceTestService.getInstance().addListener(this);
    }

    public void startCalculation(View view) {
        stopwatch.start();
        final int digits = Integer.parseInt(digitsEntry.getText().toString());
        progressDialog = ProgressDialog.show(this, "Przetwarzanie...", "");
        new Thread(new Runnable() {
            @Override
            public void run() {
                PerformanceTestService.getInstance().calculatePi(digits);
            }
        }).start();
    }

    @Override
    public void piCalculationCompleted(final String result) {
        stopwatch.stop();
        runOnUiThread(new Runnable() {
            public void run() {
                resultView.setText(result);
                timeLabel.setText(stopwatch.getDurationBreakdown());
                progressDialog.dismiss();
            }
        });
    }
}
