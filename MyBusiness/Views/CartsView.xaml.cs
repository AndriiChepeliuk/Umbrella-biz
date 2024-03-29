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
using UmbrellaBiz.ViewModels;

namespace UmbrellaBiz.Views
{
    /// <summary>
    /// Interaction logic for CreateCartView.xaml
    /// </summary>
    public partial class CreateCartView : UserControl
    {
        public CreateCartView()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataContext = DataContext as CartsViewModel;
            if (dataContext != null)
            {
                dataContext.GetCartFullInfoCommand.Execute(this);
            }
        }
    }
}
