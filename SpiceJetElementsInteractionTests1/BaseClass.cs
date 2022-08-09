﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpiceJetElementsInteractionTests1
{
    public class BaseClass
    {
        protected IWebDriver _webDriver;

        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            _webDriver = new ChromeDriver();
            new DriverManager().SetUpDriver(new ChromeConfig());
            //new DriverManager().SetUpDriver(new FirefoxConfig());
            //_webDriver = new FirefoxDriver();
           

        }

        [TearDown]
        protected void OneTimeAfter()
        {
             _webDriver.Quit();
        }

        [SetUp]
        protected void Setup() {
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl("https://www.spicejet.com/");
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Window.Maximize();
            ChromeOptions p = new ChromeOptions();
            p.AddArguments("--disable-notifications");
        }
    }
}
