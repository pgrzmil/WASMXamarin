package com.example.konra.thespanishinquisition;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import java.io.IOException;
import java.io.InputStream;
import java.net.MalformedURLException;
import java.net.URL;

public class DownloadActivity extends AppCompatActivity {

    Button startBtn;
    EditText urlText;
    TextView timeText;
    ImageView resultView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_download);

        if (android.os.Build.VERSION.SDK_INT > 9) {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }

urlText = (EditText)findViewById(R.id.urlText);
timeText = (TextView)findViewById(R.id.timeText);
resultView = (ImageView)findViewById(R.id.imageView);
startBtn = (Button)findViewById(R.id.startBtn);

startBtn.setOnClickListener(new View.OnClickListener() {
    @Override
    public void onClick(View v) {
        long startTime = System.nanoTime();
        String url = urlText.getText().toString();
        Bitmap result = null;
        try {
            result = DownloadImage(url);
        } catch (IOException e) {
            e.printStackTrace();
        }
        long stopTime = System.nanoTime();

        resultView.setImageBitmap(result);
        timeText.setText(TimeHelper.getDurationBreakdown(stopTime - startTime));
    }
});
    }

    private Bitmap DownloadImage(String urlString) throws IOException {
        URL url = new URL(urlString);
        InputStream stream = url.openConnection().getInputStream();
        Bitmap bmp = BitmapFactory.decodeStream(stream);
        return bmp;
    }
}
