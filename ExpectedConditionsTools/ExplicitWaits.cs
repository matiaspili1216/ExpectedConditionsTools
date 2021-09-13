using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.ObjectModel;

namespace MatiasPili1216.ExpectedConditionsTools
{
    public static class ExplicitWaits
    {
        public static IWebElement ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, IWebElement> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(func);

        public static bool ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, bool> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(func);

        public static void ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, IWebDriver> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(func);

        public static IAlert ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, IAlert> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(func);

        public static ReadOnlyCollection<IWebElement> ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, ReadOnlyCollection<IWebElement>> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(func);

        public static IWebElement ExplicitWait(this IWebElement element, int time, Func<IWebElement, IWebElement> func) => new WebElementWait(element, TimeSpan.FromSeconds(time)).Until(func);

        public static bool ExplicitWait(this IWebElement element, int time, Func<IWebElement, bool> func) => new WebElementWait(element, TimeSpan.FromSeconds(time)).Until(func);

        public static ReadOnlyCollection<IWebElement> ExplicitWait(this IWebElement element, int time, Func<IWebElement, ReadOnlyCollection<IWebElement>> func) => new WebElementWait(element, TimeSpan.FromSeconds(time)).Until(func);

    }
}