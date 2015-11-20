/*
 * Copyright 2015, Plejd AB. All Rights Reserved.
 * 
 * All information contained herein is the property of Plejd AB.
 * Reproduction of this material is strictly forbidden unless prior
 * written permission is obtained from Plejd AB.
 */

using System;
using Xamarin.Forms;

namespace PlejdTest
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new TestPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

