using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using lab2_cs.Models;
using lab2_cs.Tools;
using lab2_cs.Tools.Managers;
using lab2_cs.Tools.Navigation;
using lab2_cs.Exceptions;

namespace lab2_cs.ViewModels
{
    internal class CreatePersonViewModel 
    {

        #region Fields
        private ICommand _proceedCommand;
        #endregion

        #region Properties

        public Person CurrentPerson { get; }

        #region Commands

        public ICommand ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(ProceedImplementation, CanProceedExecute));
            }
        }


        #endregion
        #endregion

        #region Constructors
        public CreatePersonViewModel()
        {
            CurrentPerson = new Person("", "", "");
            StationManager.CurrentPerson = CurrentPerson;
        }
        #endregion


        private bool CanProceedExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(CurrentPerson.Name) &&
                   !String.IsNullOrWhiteSpace(CurrentPerson.LastName) &&
                   !String.IsNullOrWhiteSpace(CurrentPerson.Email);
        }

        private async void ProceedImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    try
                    {
                        Thread.Sleep(1500);
                        
                        if (IsDateCorrect())
                        {
                            if (CurrentPerson.IsBirthday)
                            {
                                MessageBox.Show("Happy birthday, dear!!!");
                            }

                        }
                    }
                    catch (PersonNotBornYetException exc)
                    {
                        MessageBox.Show($"{exc.Message}: {exc.Birthday}");
                        return false;
                    }
                    catch (PersonTooOldException exc)
                    {
                        MessageBox.Show($"{exc.Message}: {exc.Birthday}");
                        return false;
                    }

                    try
                    {
                        ValidateFullName(CurrentPerson.Name, CurrentPerson.LastName);
                    }
                    catch (InvalidNameException exc)
                    {
                        MessageBox.Show($"{exc.Message} {exc.Name}!");
                        return false;
                    }
                    catch (InvalidLastNameException exc)
                    {
                        MessageBox.Show($"{exc.Message} {exc.LastName}!");
                        return false;
                    }

                    try
                    {
                        ValidateEmail(CurrentPerson.Email);
                    }
                    catch (InvalidEmailAdressException exc)
                    {
                        MessageBox.Show(exc.Message);
                        return false;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"something went wrong while creating a new person\nreason: {exc.Message}");
                    return false;
                }
                MessageBox.Show($"Person {CurrentPerson.Name} was successfully created.");
                return true;
            });

            LoaderManager.Instance.HideLoader();

            if (result)
                NavigationManager.Instance.Navigate(ViewType.PersonInfo);

        }

        private bool IsDateCorrect()
        {
            if ((DateTime.Now.Year - CurrentPerson.Birthday.Year) > 135)
            {
                throw new PersonTooOldException(CurrentPerson.Birthday);
            }
            else if (CurrentPerson.Birthday > DateTime.Now)
            {
                throw new PersonNotBornYetException(CurrentPerson.Birthday);
            }
            else
            {
                return true;
            }
        }


        private void ValidateFullName(string name, string lastName)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (!regex.IsMatch(name))
            {
                throw new InvalidNameException(name);
            }
            if (!regex.IsMatch(lastName))
            {
                throw new InvalidLastNameException(lastName);
            }
        }


        private void ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(email))
            {
                throw new InvalidEmailAdressException(email);
            }
        }
    }
} 
