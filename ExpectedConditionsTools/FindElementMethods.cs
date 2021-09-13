using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatiasPili1216.ExpectedConditionsTools
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
                return driver.Wait(timeoutInSeconds, ExpectedConditionsForWebDriver.ElementExists(by));
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
                return element.Wait(timeoutInSeconds, ExpectedConditionsForWebElement.ElementExists(by));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
    }
}