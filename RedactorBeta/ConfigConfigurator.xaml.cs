using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
//using WPFColorPickerLib;

namespace RedactorBeta
{
    /// <summary>
    /// Логика взаимодействия для ConfigConfigurator.xaml
    /// </summary>
    public partial class ConfigConfigurator : Window
    {
        public ConfigConfigurator()
        {
            InitializeComponent();

            MainConfigModel dataClass = JsonConvert.DeserializeObject<MainConfigModel>(File.ReadAllText("../../../../Terminal_XP/Terminal_XP/files/Config.json"));
            Theme.Text = dataClass.Theme;
            FontSize.Text = dataClass.FontSize.ToString();
            Opacity.Text = dataClass.Opacity.ToString();
            TerminalColor.Content = dataClass.TerminalColor;
            UsingDelayFastOutput.IsChecked = dataClass.UsingDelayFastOutput;
            DelayFastOutput.Text = dataClass.DelayFastOutput.ToString();
            DelayUpdateCarriage.Text = dataClass.DelayUpdateCarriage.ToString();
            SpecialSymbol.Text = dataClass.SpecialSymbol;
            RatioSpawnWords.Text = dataClass.RatioSpawnWords.ToString();
            LengthHackString.Text = dataClass.LengthHackString.ToString();
            DifficultyInfo.IsChecked = dataClass.DifficultyInfo;
            FontName.Text = dataClass.FontName;



            TerminalColor.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dataClass.TerminalColor));
        }




        private void TerminalColor_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TerminalColor.Background = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));
                TerminalColor.Content = TerminalColor.Background.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var a = JsonConvert.SerializeObject(new MainConfigModel()
            {
                Theme = Theme.Text,
                FontSize = ushort.Parse(FontSize.Text),
                Opacity = float.Parse(Opacity.Text),
                TerminalColor = TerminalColor.Content.ToString(),
                UsingDelayFastOutput = (bool)UsingDelayFastOutput.IsChecked,
                DelayFastOutput = uint.Parse(DelayFastOutput.Text),
                DelayUpdateCarriage = uint.Parse(DelayUpdateCarriage.Text),
                SpecialSymbol = SpecialSymbol.Text,
                RatioSpawnWords = uint.Parse(RatioSpawnWords.Text),
                LengthHackString = uint.Parse(LengthHackString.Text),
                DifficultyInfo = (bool)DifficultyInfo.IsChecked,
                FontName = FontName.Text,
            });
            File.WriteAllText("../../../../Terminal_XP/Terminal_XP/files/Config.json", a);
            Close();
        }

    }
}
