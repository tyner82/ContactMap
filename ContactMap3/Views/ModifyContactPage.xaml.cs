﻿using System.Linq;
using System.Collections.Generic;
using ContactMap3.Data;
using ContactMap3.ViewModels;
using ContactMap3.Models;
using Xamarin.Forms;
using System;

namespace ContactMap3.Views
{

    [QueryProperty("UId", "uid")]
    public partial class ModifyContactPage : ContentPage
    {

        string uid;
        public ModifyContactPage()
        {
            InitializeComponent();
            BindingContext = new ModifyContactViewModel();
        }

        public string UId
        {
            get { return uid; }
            set
            {
                Console.WriteLine("Modify contact got uid, sending to page model");
                uid = Uri.UnescapeDataString(value);
                MessagingCenter.Send<ModifyContactPage, string>(this, "uid", uid);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        //protected override void OnDisappearing()
        //{
        //        // Cancel back navigation if data is unsaved
        //        Console.WriteLine("NAvigationWarning!!");
        //        if (!BindingContext.isDataSaved)
        //        //{
        //        //    var v = WarningPrompt();
        //        //    if (v == Task.FromResult("Cancel")) 
        //        //    {
        //        //        e.Cancel();
        //        //    }
        //        //}
        //    }
        //    public async Task<string> WarningPrompt()
        //{
        //    return await Shell.Current.DisplayPromptAsync("Warning", "Any unsaved progress will be lost", "OK", "Cancel");
        //}

    }
}
