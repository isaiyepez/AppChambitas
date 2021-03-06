﻿namespace AppChambitasV1.ViewModels
{
    public class MainViewModel
    {
    #region Properties
    public LoginViewModel Login
    {
        get;
        set;
    }

    public CategoriesViewModel Categories
    {
        get;
        set;
    }
    #endregion

    #region Constructors
        public MainViewModel()
        {
        instance = this;
        Login= new LoginViewModel();
        }
        #endregion

        #region Singleton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
         
        #endregion
    }
}
