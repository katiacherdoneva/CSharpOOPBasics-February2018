﻿namespace Forum.App.Services
{
    using System;

    using Forum.App.Services.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class CategoriesController : IController, IPaginationController
    {
        public int CurrentPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MenuState ExecuteCommand(int index)
        {
            throw new NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
