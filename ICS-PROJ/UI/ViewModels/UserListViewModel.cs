﻿using BL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        public UserListViewModel()
        {
            Users.Add(new UserListModel { 
                Name = "Ananas"
            });


            Users.Add(new UserListModel
            {
                Name = "Romamas"
            });

    
        }
        public ObservableCollection<UserListModel> Users { get; set; } = new();
    }
}
