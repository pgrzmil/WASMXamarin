package com.pgrzmil.nativedroid;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Button;

public class MenuActivity extends AppCompatActivity {

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
