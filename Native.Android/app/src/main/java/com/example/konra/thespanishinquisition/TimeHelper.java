package com.example.konra.thespanishinquisition;

import java.util.concurrent.TimeUnit;

/**
 * Created by konra on 19.01.2016.
 */
public final class TimeHelper {

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
