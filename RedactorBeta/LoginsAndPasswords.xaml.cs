﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RedactorBeta
{
    /// <summary>
    /// Логика взаимодействия для LoginsAndPasswords.xaml
    /// </summary>
    public partial class LoginsAndPasswords : UserControl
    {
        public Action OnSave;
        public int PassAmount { get { return loginsAndPasswords.Children.Count; }}
        public LoginsAndPasswords()
        {
            InitializeComponent();
        }
        public LoginsAndPasswords(DataClass dataClass)
        {

            foreach (var item in dataClass.LoginsAndPasswords)
            {
                loginsAndPasswords.Children.Insert(0, new ComboBoxInput(new MyTuple() { Log = item.Key, Pas = item.Value }));
                (loginsAndPasswords.Children[0] as ComboBoxInput).OnDelete += Delete;
                (loginsAndPasswords.Children[0] as ComboBoxInput).OnEdit += Save;
            }
        }
        public void SaveToDataClass(DataClass dataClass)
        {

            for (int i = 0; i < loginsAndPasswords.Children.Count - 1; i++)
            {
                if (!dataClass.LoginsAndPasswords.ContainsKey((loginsAndPasswords.Children[i] as ComboBoxInput).loginPassword.Log))
                {
                    dataClass.LoginsAndPasswords.Add((loginsAndPasswords.Children[i] as ComboBoxInput).loginPassword.Log, (loginsAndPasswords.Children[i] as ComboBoxInput).loginPassword.Pas);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateCMBI();
        }
        public void CreateCMBI()
        {
            ComboBoxInput cbi = new ComboBoxInput();
            cbi.login.Text += loginsAndPasswords.Children.Count;
            loginsAndPasswords.Children.Insert(loginsAndPasswords.Children.Count - 1, cbi);
            cbi.OnDelete += Delete;
            cbi.OnEdit += Save;
            Save(null, null);
            cbi.BrootPairCheck();
        }
        public void Delete(ComboBoxInput cbi)
        {
            loginsAndPasswords.Children.Remove(cbi);
            Save(null, null);
        }

        public void Load(DataClass dataClass)
        {
            foreach (var item in dataClass.LoginsAndPasswords)
            {
                loginsAndPasswords.Children.Insert(0, new ComboBoxInput(new MyTuple() { Log = item.Key, Pas = item.Value }));
                (loginsAndPasswords.Children[0] as ComboBoxInput).OnDelete += Delete;
                (loginsAndPasswords.Children[0] as ComboBoxInput).OnEdit += Save;
            }
        }
        public void Save(object obj, RoutedEventArgs ev)
        {
            for (int i = 0; i < loginsAndPasswords.Children.Count-1; i++)
            {
                bool isOk = true;
                for (int j = 0; j < loginsAndPasswords.Children.Count - 1; j++)
                {
                    if (i!=j)
                    {
                        if ((loginsAndPasswords.Children[i] as ComboBoxInput).login.Text == (loginsAndPasswords.Children[j] as ComboBoxInput).login.Text)
                        {
                            (loginsAndPasswords.Children[j] as ComboBoxInput).login.BorderBrush = Brushes.Red;
                            isOk = false;
                        }

                    }
                }
                if (isOk)
                {
                    (loginsAndPasswords.Children[i] as ComboBoxInput).login.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
                }
                else
                {
                    (loginsAndPasswords.Children[i] as ComboBoxInput).login.BorderBrush = Brushes.Red;
                }
            }
        }
    }
}
