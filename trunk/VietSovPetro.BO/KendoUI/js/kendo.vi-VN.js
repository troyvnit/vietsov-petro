/*
* Kendo UI Localization Project for v2012.3.1114 
* Copyright 2012 Telerik AD. All rights reserved.
* 
* English US (en-US) Language Pack
*
* Project home  : https://github.com/loudenvier/kendo-global
* Kendo UI home : http://kendoui.com
* Author        : Felipe Machado (Loudenvier) 
*                 http://feliperochamachado.com.br/index_en.html
*
* This project is released to the public domain, although one must abide to the 
* licensing terms set forth by Telerik to use Kendo UI, as shown bellow.
*
* Telerik's original licensing terms:
* -----------------------------------
* Kendo UI Web commercial licenses may be obtained at
* https://www.kendoui.com/purchase/license-agreement/kendo-ui-web-commercial.aspx
* If you do not own a commercial license, this file shall be governed by the
* GNU General Public License (GPL) version 3.
* For GPL requirements, please review: http://www.gnu.org/copyleft/gpl.html
*/

kendo.ui.Locale = "Tiếng Việt VN (vi-VN)";
kendo.ui.ColumnMenu.prototype.options.messages = 
  $.extend(kendo.ui.ColumnMenu.prototype.options.messages, {

/* COLUMN MENU MESSAGES 
 ****************************************************************************/   
  sortAscending: "Sắp xếp tăng dần",
  sortDescending: "Sắp xếp giảm dần",
  filter: "Bộ lọc",
  columns: "Cột"
 /***************************************************************************/   
});

kendo.ui.Groupable.prototype.options.messages = 
  $.extend(kendo.ui.Groupable.prototype.options.messages, {

/* GRID GROUP PANEL MESSAGES 
 ****************************************************************************/   
  empty: "Nắm kéo tên cột vào đây để nhóm theo cột"
 /***************************************************************************/   
});

kendo.ui.FilterMenu.prototype.options.messages = 
  $.extend(kendo.ui.FilterMenu.prototype.options.messages, {
  
/* FILTER MENU MESSAGES 
 ***************************************************************************/   
  info: "Show items with value that:", // sets the text on top of the filter menu
  isTrue: "is true",                   // sets the text for "isTrue" radio button
  isFalse: "is false",                 // sets the text for "isFalse" radio button
  filter: "Filter",                    // sets the text for the "Filter" button
  clear: "Clear",                      // sets the text for the "Clear" button
  and: "And",
  or: "Or",
  selectValue: "-Select value-"
 /***************************************************************************/   
});
         
kendo.ui.FilterMenu.prototype.options.operators =           
  $.extend(kendo.ui.FilterMenu.prototype.options.operators, {

/* FILTER MENU OPERATORS (for each supported data type) 
 ****************************************************************************/   
  string: {
      eq: "Is equal to",
      neq: "Is not equal to",
      startswith: "Starts with",
      contains: "Contains",
      doesnotcontain: "Does not contain",
      endswith: "Ends with"
  },
  number: {
      eq: "Is equal to",
      neq: "Is not equal to",
      gte: "Is greater than or equal to",
      gt: "Is greater than",
      lte: "Is less than or equal to",
      lt: "Is less than"
  },
  date: {
      eq: "Is equal to",
      neq: "Is not equal to",
      gte: "Is after or equal to",
      gt: "Is after",
      lte: "Is before or equal to",
      lt: "Is before"
  },
  enums: {
      eq: "Is equal to",
      neq: "Is not equal to"
  }
 /***************************************************************************/   
});

kendo.ui.Pager.prototype.options.messages = 
  $.extend(kendo.ui.Pager.prototype.options.messages, {
  
/* PAGER MESSAGES 
 ****************************************************************************/   
  display: "{0} - {1} của {2} items",
  empty: "Không có item nào",
  page: "Trang",
  of: "của {0}",
  itemsPerPage: "item mỗi trang",
  first: "Đi đến trang đầu",
  previous: "Đi đến trang trước",
  next: "Đi đến trang kế",
  last: "Đi đến trang cuối",
  refresh: "Làm tươi"
 /***************************************************************************/   
});

kendo.ui.Validator.prototype.options.messages = 
  $.extend(kendo.ui.Validator.prototype.options.messages, {

/* VALIDATOR MESSAGES 
 ****************************************************************************/   
  required: "{0} được yêu cầu",
  pattern: "{0} không hợp lệ",
  min: "{0} phải lớn hơn hoặc bằng {1}",
  max: "{0} phảo nhỏ hơn hoặc bằng {1}",
  step: "{0} không hợp lệ",
  email: "{0} email không hợp lệ",
  url: "{0} URL không hợp lệ",
  date: "{0} ngày không hợp lệ"
 /***************************************************************************/   
});

kendo.ui.ImageBrowser.prototype.options.messages = 
  $.extend(kendo.ui.ImageBrowser.prototype.options.messages, {

/* IMAGE BROWSER MESSAGES 
 ****************************************************************************/   
  uploadFile: "Upload",
  orderBy: "Arrange by",
  orderByName: "Name",
  orderBySize: "Size",
  directoryNotFound: "A directory with this name was not found.",
  emptyFolder: "Empty Folder",
  deleteFile: 'Bạn có chắc rằng muốn xóa "{0}"?',
  invalidFileType: "The selected file \"{0}\" is not valid. Supported file types are {1}.",
  overwriteFile: "A file with name \"{0}\" already exists in the current directory. Do you want to overwrite it?",
  dropFilesHere: "drop files here to upload"
 /***************************************************************************/   
});

kendo.ui.Editor.prototype.options.messages = 
  $.extend(kendo.ui.Editor.prototype.options.messages, {

/* EDITOR MESSAGES 
 ****************************************************************************/   
  bold: "Bold",
  italic: "Italic",
  underline: "Underline",
  strikethrough: "Strikethrough",
  superscript: "Superscript",
  subscript: "Subscript",
  justifyCenter: "Center text",
  justifyLeft: "Align text left",
  justifyRight: "Align text right",
  justifyFull: "Justify",
  insertUnorderedList: "Insert unordered list",
  insertOrderedList: "Insert ordered list",
  indent: "Indent",
  outdent: "Outdent",
  createLink: "Insert hyperlink",
  unlink: "Remove hyperlink",
  insertImage: "Insert image",
  insertHtml: "Insert HTML",
  fontName: "Select font family",
  fontNameInherit: "(inherited font)",
  fontSize: "Select font size",
  fontSizeInherit: "(inherited size)",
  formatBlock: "Format",
  foreColor: "Color",
  backColor: "Background color",
  style: "Styles",
  emptyFolder: "Empty Folder",
  uploadFile: "Upload",
  orderBy: "Arrange by:",
  orderBySize: "Size",
  orderByName: "Name",
  invalidFileType: "The selected file \"{0}\" is not valid. Supported file types are {1}.",
  deleteFile: 'Bạn có chắc rằng muốn xóa "{0}"?',
  overwriteFile: 'A file with name "{0}" already exists in the current directory. Do you want to overwrite it?',
  directoryNotFound: "A directory with this name was not found.",
  imageWebAddress: "Web address",
  imageAltText: "Alternate text",
  dialogInsert: "Insert",
  dialogButtonSeparator: "or",
  dialogCancel: "Cancel"
 /***************************************************************************/   
});
