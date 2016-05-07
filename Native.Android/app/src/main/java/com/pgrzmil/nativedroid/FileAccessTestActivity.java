package com.pgrzmil.nativedroid;

import android.app.ProgressDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.pgrzmil.services.*;

public class FileAccessTestActivity extends AppCompatActivity implements PerformanceTestListener {
    String fileName = "testFile.txt";
    int digits = 10000;

    Stopwatch stopwatch;
    Button readButton;
    Button writeButton;
    TextView timeLabel;
    TextView resultView;
    ProgressDialog progressDialog;
    FileAccessService fileAccessService;
    String contentToWrite;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_fileaccess);
        setTitle(R.string.menuFileAccess);

        timeLabel = (TextView) findViewById(R.id.timeLabel);
        resultView = (TextView) findViewById(R.id.resultView);
        readButton = (Button) findViewById(R.id.readButton);
        writeButton = (Button) findViewById(R.id.writeButton);

        stopwatch = new Stopwatch();
        fileAccessService = new FileAccessService(this);
        PerformanceTestService.getInstance().addListener(this);

        progressDialog = ProgressDialog.show(this, "Przetwarzanie...", "");
        new Thread(new Runnable() {
            public void run() {
                PerformanceTestService.getInstance().calculatePi(digits);
            }
        }).start();
    }

    public void startReading(View view) {
        stopwatch = new Stopwatch();
        stopwatch.start();
        resultView.setText("");

        String fileContents = fileAccessService.readFromFile(fileName);
        resultView.setText(fileContents);

        stopwatch.stop();
        timeLabel.setText(stopwatch.getDurationInMilliseconds());
    }

    public void startWriting(View view) {
        stopwatch = new Stopwatch();
        stopwatch.start();
        resultView.setText("");

        fileAccessService.writeToFile(fileName, contentToWrite);

        stopwatch.stop();
        timeLabel.setText(stopwatch.getDurationInMilliseconds());
    }

    @Override
    public void piCalculationCompleted(String result) {
        contentToWrite = result;
        runOnUiThread(new Runnable() {
            public void run() {
                progressDialog.dismiss();
            }
        });
    }
}
