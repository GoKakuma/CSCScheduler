using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSCScheduler
{
    /// <summary>
    /// メインウィンドウのクラス
    /// </summary>
    public partial class Form1 : Form
    {
        #region フィールド変数
        private CSCSchedulerLogic _logic;
        private WindowsFormsCommandBindings _commandBindings;
        #endregion

        #region コンストラクタ
        public Form1()
        {
            InitializeComponent();
            InitializeLogic();
            InitializeDataBindings();
            InitializeCommands();
            _commandBindings.RefreshControlEnabled();
        }
        #endregion

        #region メソッド
        private void InitializeLogic()
        {
            _logic = new CSCSchedulerLogic();
            _logic.PropertyChanged += new PropertyChangedEventHandler(_logic_PropertyChanged);
            Disposed += new EventHandler(Form1_Disposed);
        }

        private void InitializeDataBindings()
        {
            scheduleBindingSource.DataSource = _logic;
            scheduleListBindingSource.DataSource = scheduleBindingSource;
            scheduleListBindingSource.DataMember = "Items";

            BindingSource b = scheduleBindingSource;
            searchTextBox.DataBindings.Add("Text", b, "Keyword");
            titleTextBox.DataBindings.Add("Text", b, "Title");
            dataTextBox.DataBindings.Add("Text", b, "Contents");
            limitDateTimePicker.DataBindings.Add("Value", b, "Limit");
            finishCheckBox.DataBindings.Add("Checked", b, "IsFinished",
                false, DataSourceUpdateMode.OnPropertyChanged);

            listBox.DataSource = scheduleListBindingSource;
            listBox.DisplayMember = "Title";

            listBox.SelectedIndexChanged += new EventHandler(listBox_SelectedIndexChange);

            errorProvider1.DataSource = scheduleBindingSource;
        }

        private void InitializeCommands()
        {
            _commandBindings = new WindowsFormsCommandBindings();
            _commandBindings.AddCommand(clearButton, _logic.ClearCommand);
            _commandBindings.AddCommand(searchButton, _logic.SearchCommand);
            _commandBindings.AddCommand(newButton, _logic.AddNewCommand);
            _commandBindings.AddCommand(updateButton, _logic.UpdateCommand);
            _commandBindings.AddCommand(deleteButton, _logic.DeleteCommand);
            _commandBindings.AddCommand(deleteScheduleMenuItem, _logic.AutoDeleteCommand);
            _commandBindings.AddCommand(importMenuItem, _logic.ImportCommand);
            _commandBindings.AddCommand(exportMenuItem, _logic.ExportCommand);
        }
        #endregion

        #region イベントハンドラ
        void listBox_SelectedIndexChange(object sender, EventArgs e)
        {
            _logic.Item = listBox.SelectedItem as CSCSchedule;
        }

        void Form1_Disposed(object sender, EventArgs e)
        {
            _logic.Dispose();
        }

        void _logic_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Item") listBox.SelectedItem = _logic.Item;
            _commandBindings.RefreshControlEnabled();
            errorLabel.Text = _logic.Error;
        }
        #endregion

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
