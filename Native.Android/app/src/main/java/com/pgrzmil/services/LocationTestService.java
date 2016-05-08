package com.pgrzmil.services;

import android.Manifest;
import android.app.Application;
import android.content.Context;
import android.content.pm.PackageManager;
import android.location.*;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by pawel on 06.05.2016.
 */
public class LocationTestService implements LocationListener {
    LocationManager locationManager;
    String locationProvider;
    Context context;
    private List<LocationTestListener> listeners = new ArrayList<>();

    public LocationTestService(Context context) {
        this.context = context;
        locationManager = (LocationManager) context.getSystemService(Context.LOCATION_SERVICE);
        Criteria criteriaForLocationService = new Criteria();
        criteriaForLocationService.setAccuracy(Criteria.ACCURACY_FINE);
        List<String> acceptableLocationProviders = locationManager.getProviders(criteriaForLocationService, true);

        if (acceptableLocationProviders.size() > 0) {
            locationProvider = acceptableLocationProviders.get(0);
        }
    }

    public void addListener(LocationTestListener toAdd) {
        listeners.add(toAdd);
    }

    public void getLocation() {
        if (ActivityCompat.checkSelfPermission(context, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(context, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            return;
        }
        locationManager.requestLocationUpdates(locationProvider, 5, 10, this);
    }

    public void stop(){
        if (ActivityCompat.checkSelfPermission(context, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(context, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            return;
        }
        locationManager.removeUpdates(this);
    }

    private void onLocationChanged(double latitude, double longitude) {
        for (LocationTestListener listener : listeners)
            listener.locationChanged(latitude, longitude);
    }

    @Override
    public void onLocationChanged(Location location) {
        if (location != null) {
            onLocationChanged(location.getLatitude(), location.getLongitude());
        }
    }

    @Override
    public void onStatusChanged(String provider, int status, Bundle extras) {
    }

    @Override
    public void onProviderEnabled(String provider) {
    }

    @Override
    public void onProviderDisabled(String provider) {
    }
}
