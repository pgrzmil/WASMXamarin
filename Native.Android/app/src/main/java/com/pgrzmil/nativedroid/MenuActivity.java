package com.pgrzmil.nativedroid;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.app.Activity;

public class MenuActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle(R.string.menu);
    }

    public void openPerformanceTestActivity(View view) {
        Intent i = new Intent(MenuActivity.this, PerformanceTestActivity.class);
        startActivity(i);
    }

    public void openNetworkTestActivity(View view) {
        Intent i = new Intent(MenuActivity.this, NetworkTestActivity.class);
        startActivity(i);
    }

    public void openLocationTestActivity(View view) {
        Intent i = new Intent(MenuActivity.this, LocationTestActivity.class);
        startActivity(i);
    }

    public void openFileAccessTestActivity(View view) {
        Intent i = new Intent(MenuActivity.this, FileAccessTestActivity.class);
        startActivity(i);
    }
}
