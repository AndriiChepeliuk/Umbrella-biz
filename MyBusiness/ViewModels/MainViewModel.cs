﻿using FontAwesome.Sharp;
using System.Windows.Input;

namespace UmbrellaBiz.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowAllProductsViewCommand { get; }
        public ICommand ShowCartsViewCommand { get; }
        public ICommand ShowSuppliesViewCommand { get; }
        public ICommand ShowAddProductViewCommand { get; }
        public ICommand ShowAddCustomerViewCommand { get; }
        public ICommand ShowAllCustomersViewCommand { get; }

        public MainViewModel()
        {
            //--> Initialize commands
            ShowAllProductsViewCommand = new ViewModelCommand(ExecuteShowAllProductsViewCommand);
            ShowCartsViewCommand = new ViewModelCommand(ExecuteShowCartsViewCommand);
            ShowSuppliesViewCommand = new ViewModelCommand(ExecuteShowSuppliesViewCommand);
            ShowAddProductViewCommand = new ViewModelCommand(ExecuteShowAddProductViewCommand);
            ShowAddCustomerViewCommand = new ViewModelCommand(ExecuteShowAddCustomerViewCommand);
            ShowAllCustomersViewCommand = new ViewModelCommand(ExecuteShowAllCustomersViewCommand);

            //--> Default view
            ExecuteShowAllProductsViewCommand(null);
        }

        private void ExecuteShowAllCustomersViewCommand(object obj)
        {
            CurrentChildView = new AllCustomersViewModel();
            Caption = "Customers";
            Icon = IconChar.Users;
        }

        private void ExecuteShowAddCustomerViewCommand(object obj)
        {
            CurrentChildView = new AddCustomerViewModel();
            Caption = "Add customer";
            Icon = IconChar.UserPlus;
        }

        private void ExecuteShowSuppliesViewCommand(object obj)
        {
            CurrentChildView = new SuppliesViewModel();
            Caption = "Supplies";
            Icon = IconChar.CubesStacked;
        }

        private void ExecuteShowCartsViewCommand(object obj)
        {
            CurrentChildView = new CartsViewModel();
            Caption = "Carts";
            Icon = IconChar.CartShopping;
        }

        private void ExecuteShowAllProductsViewCommand(object obj)
        {
            CurrentChildView = new AllProductsViewModel();
            Caption = "All products";
            Icon = IconChar.ListCheck;
        }

        private void ExecuteShowAddProductViewCommand(object obj)
        {
            CurrentChildView = new AddProductViewModel();
            Caption = "Add product";
            Icon = IconChar.FileCirclePlus;
        }
    }
}
