using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Xamarin.iOS
{
    public class TableSource : UITableViewSource
    {
        string[] TableItems {get; set;}
        string CellIdentifier = "TableCell";

        public TableSource(string[] items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.RegisterNibForCellReuse(UINib.FromName("InterfaceTestCell", NSBundle.MainBundle), CellIdentifier);
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);
            string item = TableItems[indexPath.Row];

            if (cell == null)
            {
                cell = new InterfaceTestCell(CellIdentifier);
            }
            (cell as InterfaceTestCell).UpdateCell(item);
            return cell;
        }
    }
}
