/*
 类：MainForm
 描述：模板填充规则文件生成工具UI
 编 码 人：韩兆新 日期：2015年01月17日
 修改记录：

*/

using System;
using System.IO;
using System.Windows.Forms;
using ExcelReport;

namespace XmlGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelecttxtExcelTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "Excel 2003文件|*.xls|Excel 2007文件|*.xlsx|所有文件|*";
            if (DialogResult.OK.Equals(openFileDlg.ShowDialog()))
            {
                txtExcelTemplatePath.Text = openFileDlg.FileName;
            }
        }

        private void txtExcelTemplatePath_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            txtExcelTemplatePath.Text = path;
        }

        private void txtExcelTemplatePath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btnFillTemplate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtExcelTemplatePath.Text.Trim()))
            {
                MessageBox.Show("请选择Excel模板文件！", "提示");
                return;
            }
            string xmlFilePath = Path.ChangeExtension(txtExcelTemplatePath.Text, ".xml");
            try
            {
                WorkbookParameterContainer workbookParameter = ParseTemplate.Parse(txtExcelTemplatePath.Text);
                workbookParameter.Save(xmlFilePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show("生成失败" + ex.Message);
                return;
            }
            MessageBox.Show("生成成功：" + xmlFilePath);
        }
    }
}