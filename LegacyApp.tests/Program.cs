using System;

namespace LegacyApp.Tests
{
    class Program
    {
        static UserServiceTests serviceTests = new();

        static void Main(string[] args)
        {
            CheckTest(serviceTests.TestIfUserFirstNameIsEmptyThenAddUserShouldReturnFalse, true);
            CheckTest(serviceTests.TestIfUserCheckEmail, true);
            CheckTest(serviceTests.TestIfUserCheckAge, true);
            CheckTest(serviceTests.CheckClientById, true);
            CheckTest(serviceTests.CheckCreditLimitEqual500, true);

            Console.ReadKey();
        }

        static void CheckTest(Func<bool> TestTheory, bool result)
        {
            if (TestTheory() == result)
                Console.WriteLine($"{TestTheory.Method.Name} => PASSED");

            else
                Console.WriteLine($"{TestTheory.Method.Name} => FAILED");
        }

    }
}