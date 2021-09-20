using MatiasPili1216.ExpectedConditionsTools;

using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MatiasPili1216.FindElementTools
{
    public static class FindElementMethods
    {
        private static string GetStartError(string name) => string.IsNullOrEmpty(name) ? "" : $"When trying to find the element '{name}'. ";

        /// <summary>
        /// Permite realizar un 'ISearchContext.FindElement(By)' y retornar NULL si la busqueda genera la Exception 'NoSuchElementException'.
        /// </summary>
        /// <param name="driver">Contexto en donde se realzara la busqueda</param>
        /// <param name="by">Mecanismo de buaqueda</param>
        /// <param name="timeoutInSeconds">Valor que indica cuánto tiempo esperar por la condición.</param>
        /// <param name="name">Nombre del elemento a buscar </param>
        /// <returns>El primer IWebElement que se encuentra en el contexto</returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds, string name = "")
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver), $"{GetStartError(name)}'driver' in FindElement is null.");
            if (by == null) throw new ArgumentNullException(nameof(by), $"{GetStartError(name)}{nameof(by)}");

            try
            {
                return driver.Wait(timeoutInSeconds, ExpectedConditionsForWebDriver.FindElement(by));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite realizar un 'ISearchContext.FindElement(By)' y retornar NULL si la busqueda genera la Exception 'NoSuchElementException'.
        /// </summary>
        /// <param name="element">Contexto en donde se realzara la busqueda</param>
        /// <param name="by">Mecanismo de buaqueda</param>
        /// <param name="timeoutInSeconds">Valor que indica cuánto tiempo esperar por la condición.</param>
        /// <param name="name">Nombre del elemento a buscar </param>
        /// <returns>El primer IWebElement que se encuentra en el contexto</returns>
        public static IWebElement FindElement(this IWebElement element, By by, int timeoutInSeconds, string name = "")
        {
            if (element == null) throw new ArgumentNullException(nameof(element), $"{GetStartError(name)}'element' in FindElement is null.");
            if (by == null) throw new ArgumentNullException(nameof(by), $"{GetStartError(name)}{nameof(by)}");

            try
            {
                return element.Wait(timeoutInSeconds, ExpectedConditionsForWebElement.FindElement(by));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static IWebElement FindElement(this By by, ISearchContext context, int timeoutInSeconds, string name = "")
        {
            if (by == null) throw new ArgumentNullException(nameof(by), $"{GetStartError(name)}{nameof(by)}");
            if (context == null) throw new ArgumentNullException(nameof(context), $"{GetStartError(name)}'element' in FindElement is null.");

            try
            {
                return by.Wait(timeoutInSeconds, ExpectedConditionsForBy.FindElement(context));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static IWebElement FindElement(this ISearchContext searchContext, params By[] bys)
        {
            if (searchContext == null) throw new ArgumentNullException(nameof(searchContext), "'searchContext' in MyFindElements is null");

            try
            {
                return searchContext.FindElement(ByExtra.ChainedOR(bys));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite realizar un 'ISearchContext.FindElement(By)' y retornar NULL si la busqueda genera la Exception 'NoSuchElementException'.
        /// </summary>
        /// <param name="driver">Contexto en donde se realzara la busqueda</param>
        /// <param name="by">Mecanismo de buaqueda</param>
        /// <param name="timeoutInSeconds">Valor que indica cuánto tiempo esperar por la condición.</param>
        /// <param name="name">Nombre del elemento a buscar </param>
        /// <returns>El primer IWebElement que se encuentra en el contexto</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds, string name = "")
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver), $"{GetStartError(name)}'driver' in FindElement is null.");
            if (by == null) throw new ArgumentNullException(nameof(by), $"{GetStartError(name)}{nameof(by)}");

            try
            {
                return driver.Wait(timeoutInSeconds, ExpectedConditionsForWebDriver.FindElements(by));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite realizar un 'ISearchContext.FindElement(By)' y retornar NULL si la busqueda genera la Exception 'NoSuchElementException'.
        /// </summary>
        /// <param name="element">Contexto en donde se realzara la busqueda</param>
        /// <param name="by">Mecanismo de buaqueda</param>
        /// <param name="timeoutInSeconds">Valor que indica cuánto tiempo esperar por la condición.</param>
        /// <param name="name">Nombre del elemento a buscar </param>
        /// <returns>El primer IWebElement que se encuentra en el contexto</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebElement element, By by, int timeoutInSeconds, string name = "")
        {
            if (element == null) throw new ArgumentNullException(nameof(element), $"{GetStartError(name)}'element' in FindElement is null.");
            if (by == null) throw new ArgumentNullException(nameof(by), $"{GetStartError(name)}{nameof(by)}");

            try
            {
                return element.Wait(timeoutInSeconds, ExpectedConditionsForWebElement.FindElements(by));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this By by, ISearchContext context, int timeoutInSeconds, string name = "")
        {
            if (by == null) throw new ArgumentNullException(nameof(by), $"{GetStartError(name)}{nameof(by)}");
            if (context == null) throw new ArgumentNullException(nameof(context), $"{GetStartError(name)}'element' in FindElement is null.");

            try
            {
                return by.Wait(timeoutInSeconds, ExpectedConditionsForBy.FindElements(context));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this ISearchContext searchContext, params By[] bys)
        {
            if (searchContext == null) throw new ArgumentNullException(nameof(searchContext), "'searchContext' in MyFindElements is null");

            try
            {
                return searchContext.FindElements(ByExtra.ChainedOR(bys));
            }
            catch (NoSuchElementException)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { });
            }
        }
    }
}