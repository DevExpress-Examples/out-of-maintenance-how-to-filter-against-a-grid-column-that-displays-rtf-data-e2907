using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace E2907 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitData();
        }

        void InitData() {
            string[] descriptions = new string[] {"General description", 
                @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Arial;}}{\colortbl\red0\green0\blue0;\red49\green105\blue198;\red255\green0\blue0;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}}{\sectd\pard\plain\ql{\b\f1\fs16\cf0 BOLD }{\f1\fs16\cf0 description}\par}}",
                @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Arial;}}{\colortbl\red0\green0\blue0;\red49\green105\blue198;\red255\green0\blue0;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}}{\sectd\pard\plain\ql{\f1\fs16\cf0 Description with }{\ul\f1\fs16\cf0 UNDERLINE }{\f1\fs16\cf0 text}\par}}", 
                @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Arial;}}{\colortbl\red0\green0\blue0;\red49\green105\blue198;\red255\green0\blue0;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}}{\sectd\pard\plain\ql{\i\f1\fs16\cf0 ITALIC }{\f1\fs16\cf0 description}\par}}"};
            DataTable tbl = new DataTable();
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Description", typeof(string));
            for(int i = 1; i < 10; i++)
                tbl.Rows.Add(i, string.Format("Item{0}", i), descriptions[i%4]);
            gridControl1.DataSource = tbl;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
            if(e.Column.FieldName == "SimpleText" && e.IsGetData) {
                object value = ((GridView)sender).GetListSourceRowCellValue(e.ListSourceRowIndex, colDescription);
                e.Value = repositoryItemRichTextEdit1.ConvertEditValueToPlainText(value);
            }
        }
    }
}