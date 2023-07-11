using System;
using System.ComponentModel;
using System.Data;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Printing;

namespace WpfPrintGridThemeSync {
    public partial class MainWindow : DXWindow {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            gridControl1.ItemsSource = TabletDataSet.CreateData().Tables[0];
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            PrintableControlLink link = new PrintableControlLink((DevExpress.Xpf.Grid.TableView)gridControl1.View, "My Document");
            DocumentPreviewWindow preview = new DocumentPreviewWindow();
            preview.PreviewControl.DocumentSource = link;
            link.CreateDocument(true);

            ThemeManager.SetThemeName(preview, ThemeManager.GetThemeName(gridControl1));

            preview.Show();
        }
    }

    public class TabletDataSet : DataSet {
        private const int m_columns = 5;
        private const int m_rows = 5;

        public TabletDataSet()
            : base() {
            DataTable table = new DataTable("table");

            DataSetName = "ManualDataSet";

            for (int i = 0; i < m_columns; i++) {
                table.Columns.Add("Column" + i.ToString(), typeof(Int32));
            }

            Tables.AddRange(new DataTable[] { table });
        }

        public static TabletDataSet CreateData() {
            TabletDataSet ds = new TabletDataSet();
            DataTable table = ds.Tables["table"];

            for (int i = 0; i < m_rows; i++) {
                object[] row = new object[m_columns];

                for (int j = 0; j < m_columns; j++) {
                    row[j] = i * m_columns + j;
                }

                table.Rows.Add(row);
            }

            return ds;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables {
            get { return base.Tables; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations {
            get { return base.Relations; }
        }
    }

}
