using AVFoundation;
using CoreAnimation;
using CoreMedia;
using Foundation;
using System;

using UIKit;

namespace WASMXamarin.iOS
{
    public partial class InterfaceTestCell : UITableViewCell
    {
        AVPlayer _player;
        AVPlayerLayer _playerLayer;
        AVAsset _asset;
        AVPlayerItem _playerItem;
        UIImageView image;

        public InterfaceTestCell(IntPtr handle) : base(handle)
        {
        }
        public InterfaceTestCell(String cellId) : base(UITableViewCellStyle.Default, cellId)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            _asset = AVAsset.FromUrl(NSUrl.FromFilename("video.mp4"));
            _playerItem = new AVPlayerItem(_asset);
            _player = new AVPlayer(_playerItem);

            image = new UIImageView(UIImage.FromFile("Icon-76.png"));
            label.Font = UIFont.FromName("Cochin-BoldItalic", 22f);
            label.TextColor = UIColor.FromRGB(127, 51, 0);
            label.BackgroundColor = UIColor.Clear;
            LayoutIfNeeded();
            _playerLayer = AVPlayerLayer.FromPlayer(_player);
            
            _player.ExternalPlaybackVideoGravity = AVLayerVideoGravity.ResizeAspectFill;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();      

            image.Frame = new CoreGraphics.CGRect(Frame.Size.Width - 40, Frame.Size.Height - 40, 20, 20);
            image.ContentMode = UIViewContentMode.ScaleAspectFit;

            CABasicAnimation rotationAnimation = new CABasicAnimation();
            rotationAnimation.KeyPath = "transform.rotation.z";
            rotationAnimation.To = new NSNumber(Math.PI * 2);
            rotationAnimation.Duration = 1;
            rotationAnimation.Cumulative = true;
            rotationAnimation.RepeatCount = float.MaxValue;
            Add(image);
            image.Layer.AddAnimation(rotationAnimation, "rotationAnimation");            
        }

        public void UpdateCell(string labeltext)
        {
            label.Text = labeltext;
            _playerLayer.Frame = new CoreGraphics.CGRect(5, 30, Frame.Size.Width - 10, Frame.Size.Height - 40); ;
            playerView.Layer.AddSublayer(_playerLayer);
            _player.Play();
        }
    }
}