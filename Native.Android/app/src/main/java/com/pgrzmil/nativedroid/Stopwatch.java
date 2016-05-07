package com.pgrzmil.nativedroid;

import java.math.RoundingMode;
import java.text.DecimalFormat;

public class Stopwatch {
    private long startTime;
    private long stopTime;

    public void start() {
        startTime = System.nanoTime();
    }

    public void stop() {
        stopTime = System.nanoTime();
    }

    public String getDurationInMilliseconds() {
        long nanos = stopTime - startTime;
        double millis = nanos / 1000000.0;

        DecimalFormat formatter = new DecimalFormat("#.###");
        formatter.setRoundingMode(RoundingMode.CEILING);
        return String.format("Czas wykonania: %s ms", formatter.format(millis));
    }

    public String getDurationInSeconds() {
        long nanos = stopTime - startTime;
        double seconds = nanos / 1000000000.0;

        DecimalFormat formatter = new DecimalFormat("#.###");
        formatter.setRoundingMode(RoundingMode.CEILING);
        return String.format("Czas wykonania: %s s", formatter.format(seconds));
    }
}
