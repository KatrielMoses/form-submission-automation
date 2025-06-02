using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // ——— 1. Setup ChromeDriver & Wait ———
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        IWebDriver driver = new ChromeDriver(options);
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        try
        {
            // ——— 2. Navigate & iframe switch ———
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            Console.WriteLine("🌐 Page loaded");

            var frames = wait.Until(d => d.FindElements(By.TagName("iframe")));
            driver.SwitchTo().Frame(frames[1]);
            Console.WriteLine("✅ Switched to form iframe");

            // ——— 3. Fill fields ———
            var firstName = wait.Until(d => d.FindElement(By.Id("fname")));
            firstName.Clear();
            firstName.SendKeys("TestUser");
            Console.WriteLine("✍️  First Name filled");

            var lastName = wait.Until(d => d.FindElement(By.Id("lname")));
            lastName.Clear();
            lastName.SendKeys("TestLast");
            Console.WriteLine("✍️  Last Name filled");

            var email = wait.Until(d => d.FindElement(By.Id("email")));
            email.Clear();
            email.SendKeys("test@example.com");
            Console.WriteLine("✍️  Email filled");

            var genderMale = wait.Until(d => d.FindElement(By.Id("male")));
            if (!genderMale.Selected) genderMale.Click();
            Console.WriteLine("🔘 Gender ‘Male’ selected");

            var cricket = wait.Until(d => d.FindElement(By.Id("Cricket")));
            if (!cricket.Selected) cricket.Click();
            Console.WriteLine("✅ Hobby ‘Cricket’ checked");

            // ——— 4. Validation ———
            Console.WriteLine("--- Validating inputs ---");
            Console.WriteLine(
                firstName.GetAttribute("value") == "TestUser"
                    ? "✅ First Name OK"
                    : "❌ First Name WRONG"
            );
            Console.WriteLine(
                lastName.GetAttribute("value") == "TestLast"
                    ? "✅ Last Name OK"
                    : "❌ Last Name WRONG"
            );
            Console.WriteLine(
                email.GetAttribute("value") == "test@example.com"
                    ? "✅ Email OK"
                    : "❌ Email WRONG"
            );
            Console.WriteLine(
                genderMale.Selected 
                    ? "✅ Gender OK" 
                    : "❌ Gender NOT selected"
            );
            Console.WriteLine(
                cricket.Selected 
                    ? "✅ Hobby OK" 
                    : "❌ Hobby NOT selected"
            );

            // ——— 5. Submit the form ———
            var submitBtn = wait.Until(d =>
            {
                // try input[type=submit] first, then button[type=submit]
                var btn = d.FindElements(By.CssSelector("input[type='submit']"));
                if (btn.Count > 0) return btn[0];
                return d.FindElement(By.CssSelector("button[type='submit']"));
            });
            submitBtn.Click();
            Console.WriteLine("🚀 Form submitted!");

            Thread.Sleep(2000);  // watch it fire
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Test failed: " + ex.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}
