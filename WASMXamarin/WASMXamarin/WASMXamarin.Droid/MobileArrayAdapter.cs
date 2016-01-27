using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;

namespace WASMXamarin.Droid
{
    public class MobileArrayAdapter : ArrayAdapter<String>, TextureView.ISurfaceTextureListener
    {
        private Context context;
        private String[] values;

        public MobileArrayAdapter(Context context, string[] values) : base(context, Resource.Layout.activity_layout, values)
        {
            this.context = context;
            this.values = values;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);

            View rowView = inflater.Inflate(Resource.Layout.activity_layout, parent, false);

            TextureView textureView = rowView.FindViewById<TextureView>(Resource.Id.textureView);
            textureView.SurfaceTextureListener = this;

            return rowView;
        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            MediaPlayer mediaPlayer = MediaPlayer.Create(context.ApplicationContext, context.Resources.GetIdentifier("video", "raw", context.PackageName));
            mediaPlayer.SetSurface(new Surface(surface));
            try
            {
                mediaPlayer.Start();
                mediaPlayer.Looping = true;
            }
            catch (Exception e)
            {
            }
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
        }
    }
}