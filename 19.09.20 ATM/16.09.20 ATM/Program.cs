using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Threading;

namespace _16._09._20_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositoryATM repository = new RepositoryATM();
            AccountRepository accRepository = new AccountRepository();
            Account acc1 = new Account();
            Card card1 = acc1.Initialize(accRepository);

            User user1 = new User(card1);
            Collector collector1 = new Collector("John");

            ATM atm1 = new ATM();
            atm1.InitializeATM(repository, atm1);

            atm1.LoadCurrency(collector1, 50000);

            atm1.Start(accRepository, user1);

            


            

        }

        public enum Menu
        {
            LOGIN = 1,
            SHOWINFO = 2,
            EXIT = 3
        };
        public enum Actions
        {
            CHANGEACCOUNT = 1,
            WITHDRAW = 2,
            TOPUP = 3,
            CHARGEINTEREST = 4,
            EXCHANGETOUAH = 5,
            EXCHANGETOEUR = 6,
            BACK = 7
        };
        public class IDGenerator
        {
            public static int GenerateID(RepositoryATM repository)
            {
                int id;
                Random random = new Random();

                do
                {
                    id = random.Next();
                } while (repository.CheckOutRepository(id) == true);

                return id;
            }
            public static int GenerateAccountID(AccountRepository repository)
            {
                int id;
                Random random = new Random();

                do
                {
                    id = random.Next();
                } while (repository.CheckOutRepository(id) == true);

                return id;
            }
        }
        public class RepositoryATM
        {
            public List<ATM> _atms = new List<ATM>();

            public void AddATM(ATM atm)
            {
                if (_atms.Count < 10)
                {
                    _atms.Add(atm);
                }
                else
                {
                    throw new RepositoryException("There is no more place for new ATM.");
                }
            }
            public bool CheckOutRepository(int id)
            {
                bool result = false;

                for (int i = 0; i < _atms.Count; i++)
                {
                    if(_atms[i].ID == id)
                    {
                        result = true;
                        break;
                    }
                }
                return result;
            }
        }
        public class AccountRepository
        {
            public List<Account> _accounts = new List<Account>();
            private uint _amountATMs = 10;

            public uint AmountATMs
            {
                get => _amountATMs;
                set
                {
                    try
                    {
                        if (value > 0)
                        {
                            _amountATMs = value;
                        }
                        else
                        {
                            throw new AmountException(("Amount of ATMs must be bigger than 0."), (int)value);
                        }
                    }
                    catch (AmountException message)
                    {
                        Console.WriteLine(message);
                    }
                }
            }

            public void AddAccount(Account account)
            {
                if (_accounts.Count < 10)
                {
                    _accounts.Add(account);
                }
                else
                {
                    throw new RepositoryException("Error! Repository is full.");
                }
            }
            public bool CheckOutRepository(int number)
            {
                bool result = false;

                for (int i = 0; i < _accounts.Count; i++)
                {
                    if (_accounts[i].Number == number)
                    {
                        result = true;
                        break;
                    }
                }

                return result;
            }
            public int SearchAccount(Card card)
            {
                for (int i = 0; i < _accounts.Count; i++)
                {
                    if (card.Number == _accounts[i].Number)
                    {
                        return i;
                    }
                }
                return -1;
            }
            public bool PINCheck(ushort PIN, ushort id)
            {
                if (PIN == _accounts[id].PIN)
                {
                    return true;
                }
                return false;
            }
        }
        public class Collector
        {
            private string _name;
      
            public string Name
            {
                get => _name;
                set
                {
                    try
                    {
                        if (value.Length != 0)
                        {
                            _name = value;
                        }
                        else
                        {
                            throw new ArgumentException("String must be not NULL.");
                        }
                    }
                    catch (ArgumentException message)
                    {
                        Console.WriteLine(message);
                    }
                }
            }
            public Collector(string name)
            {
                _name = name;
            }
        }
        public struct Card
        {
            private uint _number;
            private ushort _PIN;

            public ushort PIN
            {
                get => _PIN;
                set
                {
                    try
                    {
                        if (value != _PIN && value.ToString().Length == 4)
                        {
                            _PIN = value;
                        }
                        else
                        {
                            throw new PINException("PIN must be not like previous or must have 4 digits.");
                        }
                    }
                    catch (PINException message)
                    {
                        Console.WriteLine(message);
                    }
                }
            }
            public uint Number { get; set; }
        }
        public class User
        {
            private Card _card;
            private bool _isAuth = false;
            private ushort _tempPIN;

            public uint CardNumber
            {
                get => _card.Number;
                set
                {
                    _card.Number = value;
                }
            }
            public bool IsAuth { get; set; }
            public Card Card
            {
                get => _card;
            }
            public ushort TempPIN
            {
                get => _tempPIN;
                set
                {
                    try
                    {
                        if (value.ToString().Length == 4)
                        {
                            _tempPIN = value;
                        }
                        else
                        {
                            throw new PINException("PIN must be not like previous or must have 4 digits.");
                        }
                    }
                    catch (PINException message)
                    {
                        Console.WriteLine(message);
                    }
                }
            }
            public User(Card card)
            {
                _card.Number = card.Number;
            }
            public void Authorize(Account account)
            {
                ATMDisplay.ShowText("Enter your PIN: ");

            }
        }
        public class Account
        {
            private Card _card;
            private double _balance = 0;
            private string _name;
            private double _percent = 5;

            public uint Number
            {
                get => _card.Number;
                set
                {
                    _card.Number = value;
                }
            }
            public Card Card
            {
                get => _card;
            }
            public ushort PIN
            {
                get => _card.PIN;
                set
                {
                    try
                    {
                        if (value != _card.PIN && value.ToString().Length == 4)
                        {
                            _card.PIN = value;
                        }
                        else
                        {
                            throw new PINException("PIN must be not like previous or must have 4 digits.");
                        }
                    }
                    catch (PINException message)
                    {
                        Console.WriteLine(message);
                    }
                }
            }
            public double Balance
            {
                get => _balance;
                set
                {
                    _balance += value;
                }
            }
            public string Name
            {
                get => _name;
                set
                {
                    try
                    {
                        if (value.Length != 0)
                        {
                            _name = value;
                        }
                        else
                        {
                            throw new ArgumentException("String must be not NULL.");
                        }
                    }
                    catch (ArgumentException message)
                    {
                        Console.WriteLine(message);
                    }
                }
            }
            public Card Initialize(AccountRepository repository)
            {
                try
                {
                    ATMDisplay.ShowText("Enter your name: ");
                    Name = Console.ReadLine();
                    Console.Clear();
                    ATMDisplay.ShowText("Set a PIN: ");
                    _card.PIN = ushort.Parse(Console.ReadLine());
                    Console.Clear();
                    Number = (uint)IDGenerator.GenerateAccountID(repository);
                    repository.AddAccount(this);
                    ATMDisplay.ShowText("Your account has been successfully created!\n");
                    ATMDisplay.ShowText("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (RepositoryException message)
                {
                    Console.WriteLine(message);
                }
                return _card;
            }
            public void TopUp(ATM atm, int amount)
            {
                try
                {
                    if (amount > 0)
                    {
                        _balance += amount;
                        ATMDisplay.ShowText($"You topped up ${amount} on your account.\n");
                        ATMDisplay.ShowText($"Your balance now is ${_balance}.\n");
                        ATMDisplay.ShowText("You will be redirected in several seconds.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        throw new AmountException(("Amount must be bigger than 0."), amount);
                    }
                }
                catch (AmountException message)
                {
                    Console.WriteLine(message);
                    Console.WriteLine($"Entered amount is {amount}");
                }
            }
            public void Withdraw(ATM atm, int amount)
            {
                try
                {
                    if (amount <= _balance)
                    {
                        _balance -= amount;
                        ATMDisplay.ShowText($"You withdrew ${amount} from your account.\n");
                        ATMDisplay.ShowText($"Your balance now is ${_balance}.\n");
                        ATMDisplay.ShowText("You will be redirected in several seconds.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        throw new AmountException(("Amount must be less than balance."), amount);
                    }
                }
                catch (AmountException message)
                {
                    Console.WriteLine(message);
                    Console.WriteLine($"Entered amount is {amount}");
                }
            }
            public void ChargeInterest()
            {
                double temp = (_balance * _percent) / 100;
                _balance += temp;
                ATMDisplay.ShowText($"On your account were charged ${temp}.");
            }
            public void ExchangeToUAH()
            {
                ATMDisplay.ShowText($"Your ${_balance} is UAH{_balance * 28}.\n");
                ATMDisplay.ShowText("You will be redirected in several seconds.");
                Thread.Sleep(3000);
                Console.Clear();
            }
            public void ExchangeToEUR()
            {
                ATMDisplay.ShowText($"Your ${_balance} is UAH{_balance * 1.19}.\n");
                ATMDisplay.ShowText("You will be redirected in several seconds.");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
        public class ATMDisplay
        {
            public static Menu ShowMenu()
            {
                Menu choice;

                do
                {
                    Console.WriteLine("1. Log in");
                    Console.WriteLine("2. Show Information");
                    Console.WriteLine("3. Exit");

                    choice = (Menu)ushort.Parse(Console.ReadLine());
                    Console.Clear();

                } while (choice != Menu.LOGIN && choice != Menu.SHOWINFO && choice != Menu.EXIT);

                return choice;
            }
            public static Actions ShowActions()
            {
                Actions choice;

                do
                {
                    Console.WriteLine("1. Change account owner");
                    Console.WriteLine("2. Withdraw from account");
                    Console.WriteLine("3. Top up account");
                    Console.WriteLine("4. Charge percentage");
                    Console.WriteLine("5. Exchange to UAH");
                    Console.WriteLine("6. Exchange to EUR");
                    Console.WriteLine("7. Back to main menu");

                    choice = (Actions)ushort.Parse(Console.ReadLine());
                    Console.Clear();

                } while (
                         choice != Actions.CHANGEACCOUNT && choice != Actions.CHARGEINTEREST && choice != Actions.EXCHANGETOEUR &&
                         choice != Actions.EXCHANGETOUAH && choice != Actions.TOPUP && choice != Actions.WITHDRAW && choice != Actions.BACK
                        );

                return choice;
            }
            public static void ShowText(string str)
            {
                Console.Write(str);
            }
        }
        public class ATM
        {
            public ATMDisplay _display = new ATMDisplay();
            private int _id = -1;
            private uint _minValue = 10;
            private uint _maxValue = 1000;
            public int CurrentMoney { get; set; } = 0;
            public int ID { get => _id; }
            public uint MinValue
            {
                get => _minValue;
                set
                {
                    try
                    {
                        if (value >= 10 && value <= 200)
                        {
                            _minValue = value;
                        }
                        else
                        {
                            throw new AmountException(("Min value must be between 10 and 200"), (int)value);
                        }
                    }
                    catch (AmountException message)
                    {
                        Console.WriteLine(message);
                    }
                }
            }
            public uint MaxValue
            {
                get => _maxValue;
                set
                {
                    try
                    {
                        if (value >= 200 && value <= 1000)
                        {
                            _maxValue = value;
                        }
                        else
                        {
                            throw new AmountException(("Max value must be between 200 and 1000"), (int)value);
                        }
                    }
                    catch (AmountException message)
                    {
                        Console.WriteLine(message);
                    }
                }
            }
            public ATM()
            {
                MinValue = 10;
                MaxValue = 1000;
            }
            public ATM(int currentMoney, uint minValue, uint maxValue)
            {
                CurrentMoney = currentMoney;
                MinValue = minValue;
                MaxValue = maxValue;
            }
            public ATM(uint minValue, uint maxValue)
            {
                MinValue = minValue;
                MaxValue = maxValue;
            }
            public void InitializeATM(RepositoryATM repository, ATM atm)
            {
                try
                {
                    _id = IDGenerator.GenerateID(repository);
                    repository.AddATM(atm);
                }
                catch (RepositoryException message)
                {
                    Console.WriteLine(message);
                }
            }
            public int Authorize(AccountRepository repository, User user)
            {
                ushort count = 0;
                int id = repository.SearchAccount(user.Card);

                try
                {
                    if (id == -1)
                    {
                        throw new IndexOutOfRangeException("Account has not been found.");
                    }
                }
                catch (IndexOutOfRangeException message)
                {
                    Console.WriteLine(message);
                }

                try
                {
                    do
                    {
                        ATMDisplay.ShowText("Enter your PIN: ");
                        user.TempPIN = ushort.Parse(Console.ReadLine());
                        count++;
                    } while (repository.PINCheck(user.TempPIN, (ushort)id) == false && count < 3);

                    if (count >= 3)
                    {
                        throw new PINException("You entered incorrect PIN 3 times.");
                    }
                    Console.Clear();
                    user.IsAuth = true;
                    ATMDisplay.ShowText($"{repository._accounts[id].Name} has been successfully authorized!\n");
                    ATMDisplay.ShowText("You will be redirected in several seconds.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (PINException message)
                {
                    Console.WriteLine(message);
                }
                return id;
            }
            public void LoadCurrency(Collector collector, int moneyAmount)
            {
                try
                {
                    if (moneyAmount <= 0)
                    {
                        throw new AmountException(("Amount must be bigger than 0."), moneyAmount);
                    }
                    CurrentMoney += moneyAmount;
                    ATMDisplay.ShowText($"You loaded ${moneyAmount} into the ATM. ");
                    Console.WriteLine(ToString());
                    ATMDisplay.ShowText("You will be redirected in several seconds.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (AmountException message)
                {
                    Console.WriteLine(message);
                }
            }
            public void Withdraw(Collector collector, int moneyAmount)
            {
                try
                {
                    if (moneyAmount >= MinValue && moneyAmount <= MaxValue && moneyAmount <= CurrentMoney)
                    {
                        CurrentMoney -= moneyAmount;
                        ATMDisplay.ShowText($"You withdrew ${moneyAmount} from the ATM. ");
                        Console.WriteLine(ToString());
                        ATMDisplay.ShowText("You will be redirected in several seconds.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        throw new AmountException(("You pressed incorrect value."), moneyAmount);
                    }
                }
                catch (AmountException message)
                {
                    Console.WriteLine(message);
                }
            }
            public void Start(AccountRepository repository, User user)
            {
                Menu choice;
                do
                {
                    choice = ATMDisplay.ShowMenu();

                    switch (choice)
                    {
                        case Menu.LOGIN:

                            int amount = 0;
                            int id = Authorize(repository, user);
                            Actions c = ATMDisplay.ShowActions();

                            switch (c)
                            {
                                case Actions.CHANGEACCOUNT:

                                    ATMDisplay.ShowText("Enter a new owner of account: ");
                                    repository._accounts[id].Name = Console.ReadLine();
                                    Console.Clear();
                                    ATMDisplay.ShowText("Account owner has been successfully changed!\n");
                                    ATMDisplay.ShowText("You will be redirected in several seconds.");
                                    Thread.Sleep(2000);
                                    Console.Clear();

                                    break;

                                case Actions.WITHDRAW:

                                    ATMDisplay.ShowText("Enter an amount of withdrawal: ");
                                    amount = int.Parse(Console.ReadLine());
                                    repository._accounts[id].Withdraw(this, amount);

                                    break;

                                case Actions.TOPUP:
                                
                                    ATMDisplay.ShowText("Enter an amount to top up: ");
                                    amount = int.Parse(Console.ReadLine());
                                    repository._accounts[id].TopUp(this, amount);

                                    break;

                                case Actions.CHARGEINTEREST:

                                    repository._accounts[id].ChargeInterest();
                                    ATMDisplay.ShowText("Interest has been successfully charged to your account!");
                                    ATMDisplay.ShowText("You will be redirected in several seconds.");
                                    Thread.Sleep(2000);
                                    Console.Clear();

                                    break;

                                case Actions.EXCHANGETOUAH:

                                    repository._accounts[id].ExchangeToUAH();

                                    break;

                                case Actions.EXCHANGETOEUR:

                                    repository._accounts[id].ExchangeToEUR();

                                    break;

                                case Actions.BACK:

                                    break;
                            }

                            break;

                        case Menu.SHOWINFO:

                            Console.WriteLine("INFO");
                            Console.ReadKey();

                            break;

                        case Menu.EXIT:

                            System.Environment.Exit(1);
                            System.Threading.Thread.Sleep(1000);

                            break;
                    }
                    Console.Clear();
                } while (choice != Menu.EXIT);
            }
            public override string ToString()
            {
                return $"Current sum of money: {CurrentMoney}";
            }
        }
    }
}
