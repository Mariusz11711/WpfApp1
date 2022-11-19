using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //TODO null string X3
        private bool StringValidation(string txt, int condition, string value, bool caseSensitive)
        {
            bool returnValue = false;
            try
            {
                if(!caseSensitive) 
                    CaseSensitiveTreu(ref txt, ref value);

                returnValue = ConditionFasade(condition, txt, value);

            }catch(Exception except)
            {
                throw except;
            }

            return returnValue;
        }

        private bool ConditionFasade(int condition, string txt, string value)
        {
            bool result = false;
            try
            {
                switch (condition)
                {
                    case 1:
                        result = txt.Equals(value);
                        break;
                    case  2:
                        result = txt.StartsWith(value);
                        break;
                    case 3:
                        result = txt.EndsWith(value);
                        break;
                    case 4:
                        result = txt.Contains(value);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }catch(Exception except)
            {
                throw except;
            }

            return result;
        }

        private void CaseSensitiveTreu(ref string txt, ref string value)
        {
            try
            {
                    txt = txt.ToUpper();
                    value = value.ToUpper();
            }
            catch (Exception except)
            {
                throw except;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string txt = "";
            string value = "";
            int condition = 1;

            txt = TxtValidation(TxtLabel.Content.ToString(), Txt_field.Text);
            value = TxtValidation(ValueLabel.Content.ToString(), Value_field.Text);
            condition = GetCondition();

            if (condition != 0 && txt != "" && value != "")
                ReturnValue.Content = StringValidation(txt, condition, value, (bool)CaseSensitive.IsChecked);

        }


        //możliwe warunki:
        //1 równa się,
        //2 zaczyna się od,
        //3 kończy się na,
        //4 zawiera
        private int GetCondition()
        {
            int radioButtonValue = 0;
            try
            {
                if (Equal.IsChecked.Value) radioButtonValue = 1;
                else if (Begin.IsChecked.Value) radioButtonValue = 2;
                else if (End.IsChecked.Value) radioButtonValue = 3;
                else if (Cont.IsChecked.Value) radioButtonValue = 4;
            }
            catch (Exception except)
            {
                throw except;
            }

            return radioButtonValue;
        }

        private string TxtValidation(string field, string contains = "")
        {
            try
            {
                if (contains.Equals(""))
                    MessageBox.Show("Proszę podać wartość w polu: " + field);
            }
            catch (Exception except)
            {
                throw except;
            }

            return contains;
        }
    }
}
