
using Delegate;

namespace CS_CreditCard
{
    class CreditCard
    {
        readonly string _creditCardNumber;

        string _FullName;
        string _dateOfExpire;
        string _pin;
        double _creditLimit;
        double _amount;

        public CreditCard(string creditCardNumber,
                        string fullName,
                        string dateOfExpire,
                        string pin,
                        double amount, 
                        double creditLimit)
            {
                _creditCardNumber = creditCardNumber;
                _FullName = fullName;
                _dateOfExpire = dateOfExpire;
                _pin = pin;
                _creditLimit = creditLimit;
                _amount = amount;            
            }

        public double CurrentAmount
        {
            get { return _amount; }
        }

        public void Put(double amount)
        {
            if (EnterPIN())
            {
                _amount += amount;
                del?.Invoke("Сумма " + amount.ToString() + " зачислена на кредитную карту." + " Остаток : " + CurrentAmount + " Кредитный лимит : " + CreditLimit);
            }
        }

        public void Withdraw(double amount)
        {
            if (EnterPIN())
            {
                if (amount <= _amount + CreditLimit)
                {
                    _amount -= amount;

                    del?.Invoke("Сумма " + amount.ToString() + " снята с кредитной карты." + " Остаток : " + CurrentAmount + " Кредитный лимит : " + CreditLimit);
                }
                else
                {
                    del?.Invoke("Кредитный лимит " + CreditLimit + " исчерпан." + " Остаток : " + CurrentAmount);
                }
            }
        }

        public double CreditLimit
        {
            get { return _creditLimit; }
        }

        public string Pin
        {            
            get => _pin;

            set => _pin = value;
        }
        public bool ChangePIN()
        {
            Console.WriteLine("\nИзменить PIN? ([y]es/[n]o) ");

            string answer = Console.ReadLine();

            if (answer == "y")
            {
                Pin = null;   
                return true;
            }

            if (answer == "n") return false;
              else
                {
                    Console.WriteLine("\nНе понял\n");
                    ChangePIN();
                    return true;
                }
        }
        public bool EnterPIN()
        {
            Console.WriteLine("\nВведите PIN код: ");

            string temp = Console.ReadLine();

            if ((temp.Length == 4) && (Pin == null))
            {
                Pin = temp;

                Console.WriteLine("\nPIN код сохранен");
                
                if (ChangePIN()) EnterPIN();
                return true;
            }
            if ((temp.Length == 4) && (Pin == temp))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\nPIN код введен не верно ");

                EnterPIN();
            }
            return false;
        }

        public event CreditCardStateHandler del;
    }
}
