﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace RedactorBeta
{
    /// <summary>
    /// Логика взаимодействия для ComboBoxInput.xaml
    /// </summary>
    public partial class ComboBoxInput : UserControl
    {
        public Action<ComboBoxInput> OnDelete;
        public Action<object, RoutedEventArgs> OnEdit;
        public MyTuple val = new MyTuple();
        public MyTuple loginPassword
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
                if (OnEdit != null)
                    OnEdit(null, null);
            }
        }

        public ComboBoxInput(MyTuple tuple = null)
        {
            loginPassword.Log = "Логин";
            loginPassword.Pas = "Пароль";
            if (tuple!=null)
            {
                if (tuple.Log != null)
                {
                    if (tuple.Pas != null)
                    {
                        loginPassword = tuple;
                    }
                }
            }
            DataContext = loginPassword;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnDelete(this);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OnEdit != null)
                 OnEdit(null, null);
        }

        //only once
        public void BrootPairCheck()
        {
            loginPassword.Log = login.Text;
            loginPassword.Pas = password.Text;
        }
    }
}
