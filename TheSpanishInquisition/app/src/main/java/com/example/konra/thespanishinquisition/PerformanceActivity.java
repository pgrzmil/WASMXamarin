package com.example.konra.thespanishinquisition;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.util.concurrent.TimeUnit;

public class PerformanceActivity extends AppCompatActivity {

    Button startBtn;
    EditText digitsText;
    TextView timeText;
    TextView resultText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_performance);

        digitsText = (EditText)findViewById(R.id.digitsText);
        timeText = (TextView)findViewById(R.id.timeText);
        resultText = (TextView)findViewById(R.id.resultText);
        startBtn = (Button)findViewById(R.id.startBtn);

        digitsText.setText("100");

        startBtn.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                long startTime = System.nanoTime();
                int digits = getDigits();
                String result = CalculatePi(digits);
                long stopTime = System.nanoTime();
                resultText.setText(result);
                timeText.setText(getDurationBreakdown(stopTime - startTime));
            }
        });
    }

    private String CalculatePi(int digits) {
        StringBuilder result = new StringBuilder();
        digits++;

        long[] x = new long[digits * 3 + 2];
        long[] r = new long[digits * 3 + 2];

        for (int j = 0; j < x.length; j++)
            x[j] = 20;

        for (int i = 0; i < digits; i++) {
            long carry = 0;
            for (int j = 0; j < x.length; j++) {
                long num = (long) (x.length - j - 1);
                long dem = num * 2 + 1;

                x[j] += carry;

                long q = x[j] / dem;
                r[j] = x[j] % dem;

                carry = q * num;
            }
            if (i < digits - 1)
                result.append((x[x.length - 1] / 10));
            r[x.length - 1] = x[x.length - 1] % 10;
            ;
            for (int j = 0; j < x.length; j++)
                x[j] = r[j] * 10;
        }

        return result.insert(1, ".").toString();
    }

    public int getDigits() {
        EditText editText = (EditText) findViewById(R.id.digitsText);
        String text = editText.getText().toString();
        return Integer.parseInt(text);
    }

    /**
     * Convert a millisecond duration to a string format
     *
     * @param nanos A duration to convert to a string form
     * @return A string of the form "hh:mm:ss.SS".
     */
    public static String getDurationBreakdown(long nanos)
    {
        if(nanos < 0)
        {
            throw new IllegalArgumentException("Duration must be greater than zero!");
        }

        long hours = TimeUnit.NANOSECONDS.toHours(nanos);
        nanos -= TimeUnit.HOURS.toNanos(hours);
        long minutes = TimeUnit.NANOSECONDS.toMinutes(nanos);
        nanos -= TimeUnit.MINUTES.toNanos(minutes);
        long seconds = TimeUnit.NANOSECONDS.toSeconds(nanos);
        nanos -= TimeUnit.SECONDS.toNanos(seconds);
        long milis = TimeUnit.NANOSECONDS.toMillis(nanos);

        StringBuilder sb = new StringBuilder(64);
        sb.append(hours);
        sb.append(":");
        sb.append(minutes);
        sb.append(":");
        sb.append(seconds);
        sb.append(".");
        sb.append(milis);

        return(sb.toString());
    }
}
