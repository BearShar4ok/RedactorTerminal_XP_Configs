﻿using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace RedactorBeta
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow getInstance { get; set; }
        public bool isGreen = false;
        public MainWindow()
        {
            InitializeComponent();
            //Save after closing
            Closed += (a, b) =>
            {
                if (folderer.Children.Count > 0)
                    (folderer.Children[0] as ElementAndBooleans).CloseSave();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            };
            getInstance = this;
            //this.SizeChanged += (object sender, SizeChangedEventArgs e) => scroller.Height = this.Height - (buttonsDockPanel.Height + visualDockPanel.Height + indicator.Height);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scroller.Height = ActualHeight - (buttonsDockPanel.ActualHeight + visualDockPanel.ActualHeight + indicator.ActualHeight)-63;//-58
        }
        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            //Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //    mainfolder = new ElementAndBooleans(openFileDialog.FileName);

            using (System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.SelectedPath = Directory.GetCurrentDirectory();
                if (folderer.Children.Count > 0)
                    folderBrowserDialog.SelectedPath = (folderer.Children[0] as ElementAndBooleans).path;
                folderBrowserDialog.Description = "Выберите путь до редактируемого сценария";
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (folderBrowserDialog.SelectedPath == Directory.GetCurrentDirectory())
                    {
                        MessageBox.Show("Нельзя открыть папку, конфиги самого приложения могут быть повреждены.");
                    }
                    else
                    {
                        folderer.Children.Clear();
                        folderer.Children.Add(new ElementAndBooleans(folderBrowserDialog.SelectedPath));
                    }
                }

            }

        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (folderer.Children.Count > 0)
            {
                (folderer.Children[0] as ElementAndBooleans).CloseSave();
                Saved();
            }
        }
        public void Saved()
        {
            new System.Threading.Thread(() =>
            {
                try
                {
                    Dispatcher.Invoke(() => { indicator.Fill = Brushes.Green; }, System.Windows.Threading.DispatcherPriority.Normal);
                    Thread.Sleep(1000);
                    Dispatcher.Invoke(() => { indicator.Fill = Brushes.Gray; }, System.Windows.Threading.DispatcherPriority.Normal);
                }
                catch
                {
                }
            }).Start();
        }
        private void Button_Click_Instruction(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Наведите мышку на галочку, чтобы подписалось её назначение." +
                "\nПервая - Можно ли менять ползователю файл" +
                "\nВторая - Можно ли копировать файл" +
                "\nТретья - Можно ли удалить файл" +
                "\nЧетвертая - Есть ли пароли" +
                "\nЕсли да, то будет открыт доступ равее к добавлению паролей, наведитесь и нажмите на плюс, у вас добавится окно ввода пароля, один логин нелзя использовать дважды для одного файла" +
                "\nВвод числа - Количество попыток ввода пароля" +
                "\n" +
                "\nВ приложении присутствует автосохранение по изменению и закрытию сценария." +
                "\nПри открытии подпапок для всех их файлов автоматически создаются конфиг-файлы." +
                "\nНе открывайте папки не относящиеся к сценарию, могут повредиться файлы сторонние .config (поэтому лучше не открывать в приложении папку с .exe приложением)");
        }

        private void Button_Config_Click(object sender, RoutedEventArgs e)
        {
            ConfigConfigurator cc = new ConfigConfigurator();
            cc.Show();

        }
    }
}
