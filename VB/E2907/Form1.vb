Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Namespace E2907
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			InitData()
		End Sub

		Private Sub InitData()
			Dim descriptions() As String = {"General description", "{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Arial;}}{\colortbl\red0\green0\blue0;\red49\green105\blue198;\red255\green0\blue0;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}}{\sectd\pard\plain\ql{\b\f1\fs16\cf0 BOLD }{\f1\fs16\cf0 description}\par}}", "{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Arial;}}{\colortbl\red0\green0\blue0;\red49\green105\blue198;\red255\green0\blue0;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}}{\sectd\pard\plain\ql{\f1\fs16\cf0 Description with }{\ul\f1\fs16\cf0 UNDERLINE }{\f1\fs16\cf0 text}\par}}", "{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}{\f1 Arial;}}{\colortbl\red0\green0\blue0;\red49\green105\blue198;\red255\green0\blue0;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}}{\sectd\pard\plain\ql{\i\f1\fs16\cf0 ITALIC }{\f1\fs16\cf0 description}\par}}"}
			Dim tbl As New DataTable()
			tbl.Columns.Add("ID", GetType(Integer))
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("Description", GetType(String))
			For i As Integer = 1 To 9
				tbl.Rows.Add(i, String.Format("Item{0}", i), descriptions(i Mod 4))
			Next i
			gridControl1.DataSource = tbl
		End Sub

		Private Sub gridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gridView1.CustomUnboundColumnData
			If e.Column.FieldName = "SimpleText" AndAlso e.IsGetData Then
				Dim value As Object = (CType(sender, GridView)).GetListSourceRowCellValue(e.ListSourceRowIndex, colDescription)
				e.Value = repositoryItemRichTextEdit1.ConvertEditValueToPlainText(value)
			End If
		End Sub
	End Class
End Namespace