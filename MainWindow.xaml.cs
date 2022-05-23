using System;
using System.Collections.Generic;
using System.IO;
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

namespace mileage_efficiency
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

        private void EMG_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Erros, t = if string and p if empty
            string t = "Please Enter A Value > 0";
            string p = "Boxes cannot be empty";

            //for Calc, Excluing my info
            string path = @"C:\Users\deowi\Desktop\PRG521FA3\MilesperGallon.txt";
            //for exceptionsc
            string paths = @"C:\Users\deowi\Desktop\PRG521FA3\Exceptionfile.txt";
            try
            {
                //if boxes are empty
                if (string.IsNullOrEmpty(GU.Text) && string.IsNullOrEmpty(MD.Text))
                {
                    String strs = "Exception : " + p + " Time : " + DateTime.Now.ToString();
                    MessageBox.Show(p);
                    //streamwriter
                    using (StreamWriter writerr = new StreamWriter(paths, true))
                    {

                        if (!File.Exists(paths))
                        {
                            File.Create(paths);
                            // Rewrite the entire value of str to the file
                            writerr.WriteLine(strs);
                        }
                        else
                        {
                            // Rewrite the entire value of str to the file
                            writerr.WriteLine(strs);
                        }
                    }
                }
                else
                {


                    if (GU.Text != String.Empty || MD.Text != String.Empty)
                    {
                        if (MD.Text != String.Empty || GU.Text != String.Empty)
                        {

                            //if both are numeric, calculate
                            /*
                             * Double MD = Math.Round(Double.Parse(MD.Text),2)
                             * Double GU = Math.Round(Double.Parse(GU.Text),2)
                             * Double EMG = MD/GU;
                             * EMG.Text = EMG.ToString();
                             * 
                             */
                            //Simplified to this.
                            EMG.Text = Math.Round(Double.Parse(MD.Text) / Double.Parse(GU.Text), 2).ToString();
                            //if true save

                        }

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(path, true))
                            {
                                String g = "MilesperGallong : " + EMG.Text + " Time : " + DateTime.Now.ToString();

                                if (!File.Exists(path))
                                {
                                    File.Create(path);


                                    // Rewrite the entire value of EMG.Text to the file
                                    writer.WriteLine(g);
                                    MessageBox.Show("Saved");
                                    MD.Clear();
                                    GU.Clear();
                                    EMG.Clear();

                                }

                                else if (File.Exists(path))
                                {

                                    // Rewrite the entire value of EMG.Text to the file
                                    writer.WriteLine(g);
                                    MessageBox.Show("Saved");
                                    MD.Clear();
                                    GU.Clear();
                                    EMG.Clear();

                                }
                            }
                        }
                        //if saving failed
                        catch
                        {
                            MessageBox.Show("Saving Failed");
                            GU.Clear();
                            MD.Clear();
                            EMG.Clear();
                        }

                    }
                }
            }
            //if values are not numeric
            catch
            {


                using (StreamWriter writers = new StreamWriter(paths,true))
                {

                    if (MD.Text != String.Empty || GU.Text != String.Empty)
                    {
                        if (GU.Text != String.Empty || MD.Text != String.Empty)
                        {

                            String str = "Exception : " + t + " Time : " + DateTime.Now.ToString();
                            MessageBox.Show(t);
                            MD.Clear();
                            GU.Clear();

                            if (!File.Exists(paths))
                            {
                                File.Create(paths);
                                // Rewrite the entire value of str to the file
                                writers.WriteLine(str);
                            }
                            else
                            {
                                // Rewrite the entire value of str to the file
                                writers.WriteLine(str);
                            }
                        }
                    }
                }
            }
        }
        private void GU_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
