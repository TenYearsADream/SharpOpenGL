﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjectEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddProperty(string name)
        {
            var label = new Label();
            
            
        }

        public void SetCameraPosition(string value)
        {
            CameraPosition.Text = value;
        }

        private void CreateObjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ObjectCreateEventHandler(sender, e);
        }

        public EventHandler<EventArgs> ObjectCreateEventHandler;
    }
}
