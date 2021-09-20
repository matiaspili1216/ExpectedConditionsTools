using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.ObjectModel;

namespace MatiasPili1216.ExpectedConditionsTools
{
    public static class ExplicitWaits
    {
        public static IWebElement Wait(this IWebDriver driver, int timeoutInSeconds, Func<IWebDriver, IWebElement> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static bool Wait(this IWebDriver driver, int timeoutInSeconds, Func<IWebDriver, bool> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static void Wait(this IWebDriver driver, int timeoutInSeconds, Func<IWebDriver, IWebDriver> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static IAlert Wait(this IWebDriver driver, int timeoutInSeconds, Func<IWebDriver, IAlert> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static ReadOnlyCollection<IWebElement> Wait(this IWebDriver driver, int timeoutInSeconds, Func<IWebDriver, ReadOnlyCollection<IWebElement>> func) => new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static IWebElement Wait(this IWebElement element, int timeoutInSeconds, Func<IWebElement, IWebElement> func) => new WebElementWait(element, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static bool Wait(this IWebElement element, int timeoutInSeconds, Func<IWebElement, bool> func) => new WebElementWait(element, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static ReadOnlyCollection<IWebElement> Wait(this IWebElement element, int timeoutInSeconds, Func<IWebElement, ReadOnlyCollection<IWebElement>> func) => new WebElementWait(element, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static IWebElement Wait(this By by, int timeoutInSeconds, Func<By, IWebElement> func) => new ByWait(by, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);

        public static ReadOnlyCollection<IWebElement> Wait(this By by, int timeoutInSeconds, Func<By, ReadOnlyCollection<IWebElement>> func) => new ByWait(by, TimeSpan.FromSeconds(timeoutInSeconds)).Until(func);
    }
}