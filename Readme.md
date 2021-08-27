<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128628765/10.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2907)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/E2907/Form1.cs) (VB: [Form1.vb](./VB/E2907/Form1.vb))
* [Program.cs](./CS/E2907/Program.cs) (VB: [Program.vb](./VB/E2907/Program.vb))
<!-- default file list end -->
# How to filter against a grid column that displays RTF data


<p>In this example, a GridControl contains a Description column that displays RTF data in its cells (using an RichTextBox in-place editor).<br />
By default, when displaying the column's filter dropdown list, this list will contain RTF text, including RTF specifiers, making the text human-unreadable.</p><p>This issue can be resolved as shown in the example.A helper unbound column is created that will be used as a substitute when the filtering functionality is invoked for the Description column.<br />
The unbound column's values will be the Description column's values converted to simple text.<br />
When an end-user invokes a filter dropdown list for the Description column, the list will actually display values of the created unbound column.</p><p>Here are the steps to implement this approach:</p><p>1) A new unbound column (field name:"SimpleText") is created. This column is hidden by setting its Visible and ShowInCustomizationForm properties to false.<br />
2) The SimpleText column's caption is set to the same value as for the Description column, so a user will not notice data replacement.<br />
3) The UnboundColumnData event is handled to populate the SimpleText column with data. The column's values will be the Description column's values converted to simple text.<br />
4) The Description column's FieldNameSortGroup property is set to the unbound column's field name ("SimpleText"). This forces the grid to use values of the SimpleText column when sorting/grouping/filtering is applied to the Description column.<br />
5) Set the Description column's OptionsFilter.FilterBySortField property to DevExpress.Utils.DefaultBoolean.True</p>

<br/>


