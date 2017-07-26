using _01_OrderLable.Properties;
using ExcelReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_OrderLable
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            var saveFileDlg = new SaveFileDialog { Filter = Resources.SaveFileFilter };

            if (DialogResult.OK.Equals(saveFileDlg.ShowDialog()))
            {
                var workbookParameterContainer = new WorkbookParameterContainer();
                workbookParameterContainer.Load(@"Template\orderlabel.xml");
                var sheetParameterContainer = workbookParameterContainer["Sheet1"];
                OrderLabel orderLabel = OrderLabelLogic.GetModel();
                //执行单信息
                SheetFormatter orderInfo = new SheetFormatter("Sheet1",
                        new CellFormatter(sheetParameterContainer["PatName"], orderLabel.PatName),
                        new CellFormatter(sheetParameterContainer["PatSex"], orderLabel.PatSex),
                        new CellFormatter(sheetParameterContainer["IpNo"], orderLabel.IpNo),
                        new CellFormatter(sheetParameterContainer["PatAge"], orderLabel.PatAge),
                        new CellFormatter(sheetParameterContainer["BedNo"], orderLabel.BedNo),
                        new CellFormatter(sheetParameterContainer["QrCode"], orderLabel.QrCode),
                        new CellFormatter(sheetParameterContainer["Freq"], orderLabel.Freq),
                        new CellFormatter(sheetParameterContainer["Seq"], orderLabel.Seq),
                        new CellFormatter(sheetParameterContainer["ExecDate"], orderLabel.ExecDate),
                        new CellFormatter(sheetParameterContainer["UsageName"], orderLabel.UsageName));
                //执行单中医嘱项目
                SheetFormatter itemList = new SheetFormatter("Sheet1",
                        new TableFormatter<Item>(sheetParameterContainer["ItemName"], orderLabel.ItemList,
                        new CellFormatter<Item>(sheetParameterContainer["ItemName"], t => t.ItemName),
                        new CellFormatter<Item>(sheetParameterContainer["Quantity"], t => t.Quantity)));
                ExportHelper.ExportToLocal(@"Template\orderlabel.xlsx", saveFileDlg.FileName, orderInfo, itemList);
            }
        }
    }
}
