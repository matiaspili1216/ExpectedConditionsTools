using OpenQA.Selenium;

using System;
using System.Collections.ObjectModel;

namespace MatiasPili1216.ExpectedConditionsTools
{
    public class ExpectedConditionsForBy
    {

        public static Func<By, IWebElement> FindElement(ISearchContext context) => (by) => { return by.FindElement(context); };

        public static Func<By, ReadOnlyCollection<IWebElement>> FindElements(ISearchContext context) => (by) => { return by.FindElements(context); };     
    }
}