using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;

namespace MatiasPili1216.ExpectedConditionsTools
{
    public class ByWait : DefaultWait<By>
    {
        public ByWait(By by, TimeSpan timeout) : base(by) => Timeout = timeout;
        public ByWait(IClock clock, By by, TimeSpan timeout, TimeSpan sleepInterval) : base(by, clock)
        {
            Timeout = timeout;
            PollingInterval = sleepInterval;
        }
    }
}