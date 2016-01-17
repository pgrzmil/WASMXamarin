using System;

using UIKit;

namespace WASMXamarin.iOS
{
    public partial class InterfaceTestCell : UITableViewCell
    {
        public InterfaceTestCell(IntPtr handle) : base(handle)
        {
        }
        public InterfaceTestCell(String cellId) : base(UITableViewCellStyle.Default, cellId)
        {            
        }

        public void UpdateCell(string labeltext, UIImage img, bool toggleOn)
        {
            toggle.On = toggleOn;
            picture.Image = img;
            label.Text = labeltext;
            label.Font = UIFont.FromName("Cochin-BoldItalic", 22f);
            label.TextColor = UIColor.FromRGB(127, 51, 0);
            label.BackgroundColor = UIColor.Clear;
        }
    }
}