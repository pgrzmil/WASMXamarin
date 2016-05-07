package com.pgrzmil.services;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by pawel on 06.05.2016.
 */
public class PerformanceTestService {
    private static PerformanceTestService instance = new PerformanceTestService();
    private List<PerformanceTestListener> listeners = new ArrayList<>();

    public static PerformanceTestService getInstance() {
        return instance;
    }

    private PerformanceTestService() {}

    public void addListener(PerformanceTestListener toAdd) {
        listeners.add(toAdd);
    }

    public String calculatePi(int digits) {
        StringBuilder result = new StringBuilder();
        digits++;

        long [] x = new long[digits * 3 + 2];
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
            for (int j = 0; j < x.length; j++)
                x[j] = r[j] * 10;
        }

        String pi = result.insert(1, ".").toString();
        onPiCalculationCompleted(pi);
        return pi;
    }

    private void onPiCalculationCompleted(String result) {
        for (PerformanceTestListener listener : listeners)
            listener.piCalculationCompleted(result);
    }
}
