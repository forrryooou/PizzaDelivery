using CsvHelper;
using CsvHelper.Configuration;
using LAB5.Repository;
using Microsoft.Win32;
using PizzaDelivery.Model.CustomEntities;
using PizzaDelivery.Model.Entities;
using PizzaDelivery.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PizzaDelivery.ViewModel.ForAdminPages
{
    public class ReportsViewModel : ViewModelBase
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private Report1 _dataTable;
        private List<OrderStatus> _statuses;
        private int? _statusId;
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public Report1 DataTable { get => _dataTable; set { _dataTable = value; OnPropertyChanged(nameof(DataTable)); } }
        public List<OrderStatus> Statuses { get => _statuses; set { _statuses = value; OnPropertyChanged(nameof(Statuses)); } }
        public int? StatusId { get => _statusId; set { _statusId = value; OnPropertyChanged(nameof(StatusId)); } }


        public ICommand UpdateReportDataTableCommand { get; set; }
        public ICommand DownloadReportDataTableCommand { get; set; }

        private DbRepos context;
        public ReportsViewModel()
        {
            context = new DbRepos();
            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;

            Statuses = new List<OrderStatus> { new OrderStatus() { Id = 0, Name = "Все заказы" } };
            Statuses.AddRange(context.Statuses.GetList());
            StatusId = 0;

            DataTable = new Report1();
            DataTable.StartData = StartDate; DataTable.EndData = EndDate;
            DataTable.Orders = new ObservableCollection<OrdersByDate>(context.Reports.OrderByDate(StartDate, EndDate, StatusId));

            DownloadReportDataTableCommand = new RelayCommand(DownloadReportDataTable);
            UpdateReportDataTableCommand = new RelayCommand(UpdateReportDataTable);
        }

        private void UpdateReportDataTable(object obj)
        {
            DataTable.Orders = new ObservableCollection<OrdersByDate>(context.Reports.OrderByDate(StartDate, EndDate, StatusId));
        }

        private string filePath;
        private void DownloadReportDataTable(object obj)
        {
            filePath = OpenFolderDialog();

            if (!string.IsNullOrEmpty(filePath))
            {
                string _filePath = Path.Combine(filePath, "output.csv");

                GenerateCsvReport(DataTable.Orders, _filePath);
            }
        }

        public string OpenFolderDialog()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Выберите папку",
                Filter = "Все файлы (.)|.",
                OverwritePrompt = false,
                FileName = "Новый файл"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                return Path.GetDirectoryName(saveFileDialog.FileName);
            }

            return null;
        }

        public static void GenerateCsvReport(ObservableCollection<OrdersByDate> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath, false, Encoding.GetEncoding("windows-1251")))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(new CultureInfo("ru-RU"))))
            {
                csv.WriteRecords(data.Select(item => new { Дата = item.Date, Время = item.Time, Статус_заказа = item.Status, Количество_пицц = item.CountOfPizzas, Стоимость_заказа = item.Price }));
            }
        }
    }
}
