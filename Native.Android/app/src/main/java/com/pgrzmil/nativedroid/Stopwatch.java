package com.pgrzmil.nativedroid;

import java.util.concurrent.TimeUnit;

public class Stopwatch {
    private long startTime;
    private long stopTime;

    public void start(){
        startTime = System.nanoTime();
    }

    public void stop(){
        stopTime = System.nanoTime();
    }

    public String getDurationBreakdown()
    {
        long nanos = stopTime - startTime;

        long seconds = TimeUnit.NANOSECONDS.toSeconds(nanos);
        nanos -= TimeUnit.SECONDS.toNanos(seconds);
        long milis = TimeUnit.NANOSECONDS.toMillis(nanos);

        StringBuilder sb = new StringBuilder(64);
        sb.append("Czas wykonania: ");
        sb.append(seconds);
        sb.append(",");
        sb.append(milis);
        sb.append(" s");

        return sb.toString();
    }
}
