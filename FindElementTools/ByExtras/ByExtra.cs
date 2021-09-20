using OpenQA.Selenium;

namespace MatiasPili1216.FindElementTools
{
    public class ByExtra : By
    {
        public static By ChainedAND(params By[] bys) => new ByChainedAND(bys);
        public static By ChainedOR(params By[] bys) => new ByChainedOR(bys);
        public static By Attribute(string name, string value) => By.CssSelector($"[{name}='{value}']");
        public static By TagAndAttribute(string tag, string name, string value) => By.CssSelector($"{tag}[{name}='{value}']");
        public static By PartialClassName(string className) => By.CssSelector($"[class*='{className}']");
    }
}