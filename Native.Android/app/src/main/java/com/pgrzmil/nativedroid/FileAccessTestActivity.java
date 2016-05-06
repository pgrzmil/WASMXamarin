package com.pgrzmil.nativedroid;

import android.app.ProgressDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import com.pgrzmil.services.FileAccessService;
import com.pgrzmil.services.PerformanceTestService;

public class FileAccessTestActivity extends AppCompatActivity {
    Stopwatch stopwatch;
    Button readButton;
    Button writeButton;
    TextView timeLabel;
    TextView resultView;
    ProgressDialog progressDialog;
    FileAccessService fileAccessService;
    String fileName = "testFile.txt";
    int digits = 10000;
    String contentToWrite;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_fileaccess);
        setTitle(R.string.menuLocation);

        timeLabel = (TextView) findViewById(R.id.timeLabel);
        resultView = (TextView) findViewById(R.id.resultView);
        readButton = (Button) findViewById(R.id.readButton);
        writeButton = (Button) findViewById(R.id.writeButton);

        stopwatch = new Stopwatch();

        fileAccessService = new FileAccessService();
    }

    public void startReading(View view) {
        stopwatch.start();
        progressDialog = ProgressDialog.show(this, "Przetwarzanie...", "");

        String filecontents = fileAccessService.readFromFile(fileName);
        resultView.setText(filecontents);
        
        stopwatch.stop();
        timeLabel.setText(stopwatch.getDurationBreakdown());
        progressDialog.dismiss();
    }

    public void startWriting(View view) {
        stopwatch.start();
        progressDialog = ProgressDialog.show(this, "Przetwarzanie...", "");
        resultView.setText("");

        if (contentToWrite == null) {
            contentToWrite = PerformanceTestService.getInstance().calculatePi(digits);
        }

        fileAccessService.writeToFile(fileName, contentToWrite);

        stopwatch.stop();
        timeLabel.setText(stopwatch.getDurationBreakdown());
        progressDialog.dismiss();
    }
}
